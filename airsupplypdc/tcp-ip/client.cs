using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AirSupplyPDC.TCP_IP
{
    public class Client
    {
        public delegate void OnOffClient(Client client, bool isconnect);
        public OnOffClient iConnect = delegate { };

        public delegate void StreamData(Guid GuidStr, string iDataConnect, string content, string respond, bool isSuccess);
        public StreamData DataStream = delegate { };

        public delegate void UpdateCabinet(int _idCabinet);
        public delegate void UpdateListCaninet(int[] _idCabinet);
        public UpdateCabinet updateCab = delegate { };
        public UpdateListCaninet updatelsCab = delegate { };

        public delegate void AddAction(Action action);
        public AddAction Add = delegate { };

        public string iDataConnect { get; set; } = string.Empty;
        public Guid GuidStr { get; set; } = Guid.NewGuid();
        //public delegate void SendDataHandler(string area, string part_, DateTime dateTimeNow, int qty_stock_box, int qty_stock_pcs, int qty_in, int qty_out);
        // public SendDataHandler Send = delegate { };
        public Client()
        {
            //Run(client);
        }
        public void Run(TcpClient tcpClient_)
        {
            iDataConnect = tcpClient_.Client.RemoteEndPoint.ToString();
            iConnect(this, 1 == 1);
            using (NetworkStream stream_ = tcpClient_.GetStream())
            {
                stream_.ReadTimeout = 10000;
                try
                {
                    byte[] bytee_ = new byte[tcpClient_.ReceiveBufferSize];
                    int Data_ = stream_.Read(bytee_, 0, bytee_.Length);
                    if (Data_ > 0)
                    {
                        byte[] buff_ = new byte[Data_];
                        Buffer.BlockCopy(bytee_, 0, buff_, 0, Data_);
                        string strData_ = Encoding.ASCII.GetString(buff_);
                        ExeString(tcpClient_, strData_);
                        CloseSocket(tcpClient_);
                    }
                    else
                        CloseSocket(tcpClient_);
                }
                catch
                {
                    CloseSocket(tcpClient_);
                }
            }
            iConnect(this, 1 == 2);
        }
        public DateTime DateTimeNow(AirSupplyPDCEntities supplyObento)
        {
            try
            {
                ObjectResult<DateTime?> datimenow_ = supplyObento.GetTimeNow();
                if (datimenow_.FirstOrDefault() is DateTime dateTime_)
                    return dateTime_;
            }
            catch { }
            return DateTime.Now;
        }
        public Task<DateTime> DateTimeNowAsyn(AirSupplyPDCEntities supplyObento)
        {
            return Task<DateTime>.Factory.StartNew(() =>
            {
                try
                {
                    ObjectResult<DateTime?> datimenow_ = supplyObento.GetTimeNow();
                    if (datimenow_.FirstOrDefault() is DateTime dateTime_)
                        return dateTime_;
                }
                catch { }
                return DateTime.Now;
            });
        }
        private void ExeString(TcpClient client, string data)
        {
            try
            {
                string datatoUp = data.ToUpper();
                if (Program.inforCommon.isCondition)
                {
                    InforCommon infor = Program.inforCommon;
                    if (isMatcRegex(datatoUp, @"^GETDATA$"))
                    {
                        //string strJson = JsonConvert.SerializeObject(infor);
                        //SendDataAndClose(client, data, strJson);
                    }
                    else
                        if (isMatcRegex(datatoUp, @"^CELL$"))
                    {
                        //string strJson = JsonConvert.SerializeObject(infor);
                        if (Program.inforCommon.cellInfors.Any())
                        {
                            using (AirSupplyPDCEntities db_ = new AirSupplyPDCEntities())
                            {
                                int[] cells = Program.inforCommon.cellInfors.Select(x => x.idCell).ToArray();
                                tb_Cell[] tb_Cells = db_.tb_Cell.Where(x => cells.Any(y => y == x.ID_)).ToArray();
                                SendDataAndClose(client, data, string.Join(",", tb_Cells.Select(x => x.NAME_).ToArray()));
                            }
                        }
                        else SendDataAndClose(client, datatoUp, "0");
                    }
                    else if (isMatcRegex(datatoUp, @"^O:\d+$"))
                    {
                        string[] arrData_ = datatoUp.Split(':');
                        string cabinet_ = arrData_[1];
                        using (AirSupplyPDCEntities db_ = new AirSupplyPDCEntities())
                        {
                            if (db_.tb_Cabinet.Any(x => x.tb_Location.ID_AREA == infor.idArea && x.NAME_ == cabinet_ && x.tb_Remain.Any(y => y.ISFINISH)))
                            {
                                tb_Cabinet tbCabinetcheck = db_.tb_Cabinet.FirstOrDefault(x => x.tb_Location.ID_AREA == infor.idArea && x.NAME_ == cabinet_ && x.tb_Remain.Any(y => y.ISFINISH));
                                if (tbCabinetcheck != null)
                                {
                                    tb_Remain tbRemain_ = db_.tb_Remain.Where(x => x.ISFINISH && x.ID_CABINET == tbCabinetcheck.ID_).OrderBy(x => x.ID_).FirstOrDefault();
                                    tb_Part tbPart_ = tbRemain_.tb_Part;
                                    db_.tb_InOutRecord.Add(new tb_InOutRecord()
                                    {
                                        PARTID = tbPart_.PARTID,
                                        ID_AREA = infor.idArea,
                                        ID_CABINET = tbCabinetcheck.ID_,
                                        SNP_ = tbPart_.PCSPBOX_,
                                        INOUT_ = false,
                                        DATE_OUTSTORE = DateTimeNow(db_)
                                    });
                                    db_.tb_Remain.Remove(tbRemain_);
                                    if (db_.SaveChanges() > 0)
                                    {
                                        SendDataAndClose(client, datatoUp, "1");
                                        updateCab(tbCabinetcheck.ID_);
                                    }
                                    else
                                        SendDataAndClose(client, datatoUp, "0");
                                }
                                else
                                    SendDataAndClose(client, datatoUp, "0");
                            }
                            else
                                SendDataAndClose(client, datatoUp, "0");
                        }
                    }
                    else if (isMatcRegex(datatoUp, @"^MO-\d+$"))
                    {
                        string[] arrData_ = datatoUp.Split('-');
                        string box_ = arrData_[1];
                        using (AirSupplyPDCEntities db_ = new AirSupplyPDCEntities())
                        {
                            ConnecttoDb cntodb = new ConnecttoDb
                            {
                                ConnectString = db_.Database.Connection.ConnectionString
                            };
                            DataTable datatb = cntodb.GetData(@"SELECT TOP 1 [DATE_ENTRY]
                                                                              ,[USER_ENTRY]
                                                                              ,[PART_NO]
                                                                              ,[DEPT_NAME]
                                                                              ,[SHIFT]
                                                                              ,[PALLET_DATE]
                                                                              ,[ID_BOX_VE]
                                                                              ,[OUT_STATUS]
                                                                              ,[RETURN_STATUS]
                                                                              ,[WAIT_STATUS]
                                                                              ,[ID_VE]
                                                                              ,[ID_VE_OUT]
                                                                              ,[FULL_CART]
                                                                          FROM[TSHKDB]..[HKS].[IH_IO_HISTORY_DETAIL_BOX]
                                                                          WHERE[RETURN_STATUS] = 0 AND [ID_BOX_VE] = @idbox
                                                                          ORDER BY[DATE_ENTRY] DESC; ", new System.Data.SqlClient.SqlParameter("@idbox", box_));
                            if (datatb.Rows.Count == 1)
                            {
                                string part = datatb.Rows[0]["PART_NO"].ToString();
                                if (db_.tb_Part.Any(x => x.PARTID == part))
                                {

                                    actionCabinet[] actionCabinets = db_.tb_Cabinet.Where(x => x.tb_Location.ID_AREA == infor.idArea).ToArray().Select(x => new actionCabinet(x)).ToArray();
                                    if (!actionCabinets.Any(x => x.IsMustOut()))
                                    {
                                        actionCabinets = actionCabinets.Where(x => x._Cabinet.tb_Location.ID_AREA == infor.idArea && x._Cabinet.tb_Location.ENABLE_ && x._Cabinet.ENABLE_ && x._Cabinet.tb_SettingCabinetPart.Any(y => y.PARDID == part)).ToArray();
                                        actionCabinet actionSelect = actionCabinets.OrderBy(x => x.remain + x.oncon).FirstOrDefault(x => x.CheckPart(part));
                                        if (actionSelect != null)
                                        {
                                            db_.tb_Remain.Add(new tb_Remain()
                                            {
                                                ID_AREA = infor.idArea,
                                                ID_CABINET = actionSelect._Cabinet.ID_,
                                                PARTID = part,
                                                ONCONVEYOR_DATE = DateTimeNow(db_),
                                                ISFINISH = false
                                            });
                                            if (db_.SaveChanges() > -1)
                                            {
                                                SendDataAndClose(client, datatoUp, "1");
                                                updateCab(actionSelect._Cabinet.ID_);
                                            }
                                        }
                                        else SendDataAndClose(client, datatoUp, "0");
                                    }
                                    else SendDataAndClose(client, datatoUp, "0");
                                }
                                else
                                {
                                    SendDataAndClose(client, datatoUp, "0");
                                }
                            }
                            else SendDataAndClose(client, datatoUp, "0");
                        }
                    }
                    else if (isMatcRegex(datatoUp, @"^1:MO-\d+$"))
                    {
                        string[] arrData_ = datatoUp.Split('-');
                        string box_ = arrData_[1];
                        using (AirSupplyPDCEntities db_ = new AirSupplyPDCEntities())
                        {
                            ConnecttoDb cntodb = new ConnecttoDb
                            {
                                ConnectString = db_.Database.Connection.ConnectionString
                            };
                            DataTable datatb = cntodb.GetData(@"SELECT TOP 1 [DATE_ENTRY]
                                                                              ,[USER_ENTRY]
                                                                              ,[PART_NO]
                                                                              ,[DEPT_NAME]
                                                                              ,[SHIFT]
                                                                              ,[PALLET_DATE]
                                                                              ,[ID_BOX_VE]
                                                                              ,[OUT_STATUS]
                                                                              ,[RETURN_STATUS]
                                                                              ,[WAIT_STATUS]
                                                                              ,[ID_VE]
                                                                              ,[ID_VE_OUT]
                                                                              ,[FULL_CART]
                                                                          FROM[TSHKDB]..[HKS].[IH_IO_HISTORY_DETAIL_BOX]
                                                                          WHERE[RETURN_STATUS] = 0 AND [ID_BOX_VE] = @idbox
                                                                          ORDER BY[DATE_ENTRY] DESC; ", new System.Data.SqlClient.SqlParameter("@idbox", box_));
                            if (datatb.Rows.Count == 1)
                            {
                                string part_ = datatb.Rows[0]["PART_NO"].ToString();
                                if (db_.tb_Part.Any(x => x.PARTID == part_))
                                    //if (checkRemainPartWithCondition(infor, db_))
                                    if (db_.tb_Remain.Any(x => x.PARTID == part_ && !x.ISFINISH && x.ID_AREA == infor.idArea))
                                    {
                                        tb_Remain tbRemain_ = db_.tb_Remain
                                            .Where(x => x.PARTID == part_ && !x.ISFINISH && x.ID_AREA == infor.idArea).OrderBy(x => x.ID_).FirstOrDefault();
                                        tbRemain_.ISFINISH = true;
                                        tbRemain_.INSTORE_DATE = DateTimeNow(db_);
                                        db_.tb_InOutRecord.Add(new tb_InOutRecord()
                                        {
                                            PARTID = part_,
                                            ID_AREA = infor.idArea,
                                            ID_CABINET = tbRemain_.ID_CABINET,
                                            SNP_ = tbRemain_.tb_Part.PCSPBOX_,
                                            INOUT_ = true,
                                            DATE_ONCONVEYOR = tbRemain_.ONCONVEYOR_DATE,
                                            DATE_INSTORE = tbRemain_.INSTORE_DATE
                                        });
                                        if (db_.SaveChanges() > -1)
                                        {
                                            string strresult_ = string.Format("I:{0}", tbRemain_.tb_Cabinet.NAME_);
                                            SendDataAndClose(client, data, strresult_);
                                            updateCab(tbRemain_.ID_CABINET);
                                        }
                                    }
                                    else
                                        SendDataAndClose(client, datatoUp, "0");
                                //else
                                //SendDataAndClose(client, datatoUp, "0");
                                else
                                    SendDataAndClose(client, datatoUp, "0");
                            }
                            else SendDataAndClose(client, datatoUp, "0");
                        }
                    }
                    else if (isMatcRegex(datatoUp, @"^1:\w{3}-\d{4}$") || isMatcRegex(datatoUp, @"^1:\w{3}-\d{4}-\w{3,4}$"))
                    {
                        string[] arrData_ = datatoUp.Split(':');
                        string part_ = arrData_[1].ToUpper();
                        using (AirSupplyPDCEntities db_ = new AirSupplyPDCEntities())
                        {
                            if (db_.tb_Part.Any(x => x.PARTID == part_))
                                //if (checkRemainPartWithCondition(infor, db_))
                                if (db_.tb_Remain.Any(x => x.PARTID == part_ && !x.ISFINISH && x.ID_AREA == infor.idArea))
                                {
                                    tb_Remain tbRemain_ = db_.tb_Remain
                                        .Where(x => x.PARTID == part_ && !x.ISFINISH && x.ID_AREA == infor.idArea).OrderBy(x => x.ID_).FirstOrDefault();
                                    tbRemain_.ISFINISH = true;
                                    tbRemain_.INSTORE_DATE = DateTimeNow(db_);
                                    db_.tb_InOutRecord.Add(new tb_InOutRecord()
                                    {
                                        PARTID = part_,
                                        ID_AREA = infor.idArea,
                                        ID_CABINET = tbRemain_.ID_CABINET,
                                        SNP_ = tbRemain_.tb_Part.PCSPBOX_,
                                        INOUT_ = true,
                                        DATE_ONCONVEYOR = tbRemain_.ONCONVEYOR_DATE,
                                        DATE_INSTORE = tbRemain_.INSTORE_DATE
                                    });
                                    if (db_.SaveChanges() > -1)
                                    {
                                        string strresult_ = string.Format("I:{0}", tbRemain_.tb_Cabinet.NAME_);
                                        SendDataAndClose(client, data, strresult_);
                                        updateCab(tbRemain_.ID_CABINET);
                                    }
                                }
                                else
                                    SendDataAndClose(client, datatoUp, "0");
                            //else
                            //SendDataAndClose(client, datatoUp, "0");
                            else
                                SendDataAndClose(client, datatoUp, "0");
                        }
                    }
                    else if (isMatcRegex(datatoUp, @"^CL:\w+$"))
                    {
                        string[] arrData_ = datatoUp.Split(':');
                        string obj_ = arrData_[1].ToUpper();
                        using (AirSupplyPDCEntities db_ = new AirSupplyPDCEntities())
                        {
                            if (obj_ == "ALL")
                            {
                                if (db_.tb_Remain.Any(x => x.ID_AREA == infor.idArea || x.tb_Cabinet.tb_Location.ID_AREA == infor.idArea))
                                {
                                    List<int> lscabinet_ = new List<int>();
                                    foreach (tb_Remain remain in db_.tb_Remain.Where
                                        (x => x.ID_AREA == infor.idArea || x.tb_Cabinet.tb_Location.ID_AREA == infor.idArea))
                                    {
                                        if (remain.ISFINISH)
                                        {
                                            if (!lscabinet_.Any(x => x == remain.ID_CABINET)) lscabinet_.Add(remain.ID_CABINET);
                                            db_.tb_InOutRecord.Add(new tb_InOutRecord()
                                            {
                                                PARTID = remain.PARTID,
                                                ID_AREA = infor.idArea,
                                                ID_CABINET = remain.ID_CABINET,
                                                SNP_ = remain.tb_Part.PCSPBOX_,
                                                INOUT_ = false,
                                                DATE_OUTSTORE = DateTimeNow(db_)
                                            });
                                        }
                                        db_.tb_Remain.Remove(remain);
                                    }
                                    if (db_.SaveChanges() > 0)
                                    {
                                        SendDataAndClose(client, datatoUp, "1");
                                        updatelsCab(lscabinet_.OrderBy(x => x).ToArray());
                                    }
                                    else
                                        SendDataAndClose(client, datatoUp, "0");
                                }
                                else
                                    SendDataAndClose(client, datatoUp, "0");
                            }
                            else
                                if (obj_ == "BC")
                            {
                                if (db_.tb_Remain.Any(x => x.ID_AREA == infor.idArea || x.tb_Cabinet.tb_Location.ID_AREA == infor.idArea))
                                {
                                    List<int> lscabinet_ = new List<int>();
                                    foreach (tb_Remain remain in db_.tb_Remain.Where
                                        (x => x.ID_AREA == infor.idArea || x.tb_Cabinet.tb_Location.ID_AREA == infor.idArea))
                                    {
                                        if (!remain.ISFINISH)
                                        {
                                            if (!lscabinet_.Any(x => x == remain.ID_CABINET)) lscabinet_.Add(remain.ID_CABINET);
                                            db_.tb_Remain.Remove(remain);
                                        }
                                    }
                                    if (db_.SaveChanges() > 0)
                                    {
                                        SendDataAndClose(client, datatoUp, "1");
                                        updatelsCab(lscabinet_.OrderBy(x => x).ToArray());
                                    }
                                    else
                                        SendDataAndClose(client, datatoUp, "0");
                                }
                                else
                                    SendDataAndClose(client, datatoUp, "0");
                            }
                            else
                            if (obj_ == "TT")
                            {
                                string[] parttt = db_.tb_SettingPart.Where(x => x.ID_AREA == infor.idArea).Select(x => x.PARTID).GroupBy(x => x).Select(x => x.Key).ToArray();
                                if (db_.tb_Remain.Where(x => x.ID_AREA == infor.idArea || x.tb_Cabinet.tb_Location.ID_AREA == infor.idArea).Any(x => parttt.Contains(x.PARTID)))
                                {
                                    List<int> lscabinet_ = new List<int>();
                                    foreach (tb_Remain remain in db_.tb_Remain.Where
                                        (x => x.ID_AREA == infor.idArea || x.tb_Cabinet.tb_Location.ID_AREA == infor.idArea).Where(x => parttt.Contains(x.PARTID)))
                                    {
                                        if (!lscabinet_.Any(x => x == remain.ID_CABINET)) lscabinet_.Add(remain.ID_CABINET);
                                        if (remain.ISFINISH)
                                            db_.tb_InOutRecord.Add(new tb_InOutRecord()
                                            {
                                                PARTID = remain.PARTID,
                                                ID_AREA = infor.idArea,
                                                ID_CABINET = remain.ID_CABINET,
                                                SNP_ = remain.tb_Part.PCSPBOX_,
                                                INOUT_ = false,
                                                DATE_OUTSTORE = DateTimeNow(db_)
                                            });
                                        db_.tb_Remain.Remove(remain);
                                    }
                                    if (db_.SaveChanges() > 0)
                                    {
                                        SendDataAndClose(client, datatoUp, "1");
                                        updatelsCab(lscabinet_.OrderBy(x => x).ToArray());
                                    }
                                    else
                                        SendDataAndClose(client, datatoUp, "0");
                                }
                                else
                                    SendDataAndClose(client, datatoUp, "0");
                            }
                            else
                            if (db_.tb_Cabinet.Any(x => x.tb_Location.ID_AREA == infor.idArea && x.NAME_ == obj_ && x.tb_Remain.Any()))
                            {
                                tb_Cabinet tbCabinetcheck = db_.tb_Cabinet.FirstOrDefault(x => x.tb_Location.ID_AREA == infor.idArea && x.NAME_ == obj_ && x.tb_Remain.Any());
                                if (tbCabinetcheck != null)
                                {
                                    string strpart_ = string.Empty;
                                    foreach (tb_Remain remain in tbCabinetcheck.tb_Remain.ToArray())
                                    {
                                        if (remain.ISFINISH)
                                            db_.tb_InOutRecord.Add(new tb_InOutRecord()
                                            {
                                                PARTID = remain.PARTID,
                                                ID_AREA = infor.idArea,
                                                ID_CABINET = remain.ID_CABINET,
                                                SNP_ = remain.tb_Part.PCSPBOX_,
                                                INOUT_ = false,
                                                DATE_OUTSTORE = DateTimeNow(db_)
                                            });
                                        db_.tb_Remain.Remove(remain);
                                    }
                                    if (db_.SaveChanges() > 0)
                                    {
                                        SendDataAndClose(client, datatoUp, "1");
                                        updateCab(tbCabinetcheck.ID_);
                                    }
                                    else SendDataAndClose(client, datatoUp, "0");

                                }
                                else
                                    SendDataAndClose(client, datatoUp, "0");
                            }
                            else
                                SendDataAndClose(client, datatoUp, "0");
                        }
                    }
                    else if (isMatcRegex(datatoUp, @"^CL:\w{3}-\d{4}$") || isMatcRegex(datatoUp, @"^CL:\w{3}-\d{4}-\d{3}$"))
                    {
                        string[] arrData_ = datatoUp.Split(':');
                        string part_ = arrData_[1].ToUpper();
                        using (AirSupplyPDCEntities db_ = new AirSupplyPDCEntities())
                        {
                            if (db_.tb_Remain.Any(x => x.ID_AREA == infor.idArea && x.PARTID == part_ && !x.ISFINISH))
                            {
                                List<int> lscabinet_ = new List<int>();
                                foreach (tb_Remain remain in db_.tb_Remain.Where(x => x.ID_AREA == infor.idArea && x.PARTID == part_ && !x.ISFINISH))
                                {
                                    if (!lscabinet_.Any(x => x == remain.ID_CABINET)) lscabinet_.Add(remain.ID_CABINET);
                                    db_.tb_Remain.Remove(remain);
                                }
                                if (db_.SaveChanges() > 0)
                                {
                                    SendDataAndClose(client, datatoUp, "1");
                                    updatelsCab(lscabinet_.OrderBy(x => x).ToArray());
                                }
                            }
                            else SendDataAndClose(client, datatoUp, "0");
                        }
                    }
                    else
                    {
                        using (AirSupplyPDCEntities db_ = new AirSupplyPDCEntities())
                        {
                            if (db_.tb_Part.Any(x => x.PARTID == datatoUp))
                            {

                                actionCabinet[] actionCabinets = db_.tb_Cabinet.Where(x => x.tb_Location.ID_AREA == infor.idArea).ToArray().Select(x => new actionCabinet(x)).ToArray();
                                if (!actionCabinets.Any(x => x.IsMustOut()))
                                {
                                    actionCabinets = actionCabinets.Where(x => x._Cabinet.tb_Location.ID_AREA == infor.idArea && x._Cabinet.tb_Location.ENABLE_ && x._Cabinet.ENABLE_ && x._Cabinet.tb_SettingCabinetPart.Any(y => y.PARDID == datatoUp)).ToArray();
                                    actionCabinet actionSelect = actionCabinets.OrderBy(x => x.remain + x.oncon).FirstOrDefault(x => x.CheckPart(datatoUp));
                                    if (actionSelect != null)
                                    {
                                        db_.tb_Remain.Add(new tb_Remain()
                                        {
                                            ID_AREA = infor.idArea,
                                            ID_CABINET = actionSelect._Cabinet.ID_,
                                            PARTID = datatoUp,
                                            ONCONVEYOR_DATE = DateTimeNow(db_),
                                            ISFINISH = false
                                        });
                                        if (db_.SaveChanges() > -1)
                                        {
                                            SendDataAndClose(client, datatoUp, "1");
                                            updateCab(actionSelect._Cabinet.ID_);
                                        }
                                    }
                                    else SendDataAndClose(client, datatoUp, "0");
                                }
                                else SendDataAndClose(client, datatoUp, "0");
                            }
                            else
                            {
                                SendDataAndClose(client, datatoUp, "0");
                            }
                        }
                    }
                }
                else SendDataAndClose(client, data, "PLEASE SELECT AREA");
            }
            catch
            {
                SendDataAndClose(client, data, "ERROR");
            }
        }
        public bool isMatcRegex(string data, string Regexstr)
        {
            //Regex regex = new Regex(Regexstr);
            return new Regex(Regexstr).IsMatch(data);
        }
        public void CloseSocket(TcpClient client)
        {
            try
            {
                if (client != null && client.Connected)
                {
                    client.Close();
                    client.Dispose();
                }
            }
            catch { }
        }
        public void SendDataAndClose(TcpClient client, string content, string DataSend)
        {
            try
            {
                if (client != null && client.Connected)
                {
                    NetworkStream stream_ = client.GetStream();
                    if (stream_ != null)
                        try
                        {
                            byte[] bytee_ = Encoding.ASCII.GetBytes(DataSend);
                            stream_.Write(bytee_, 0, bytee_.Length);
                            if (!content.Contains("GETDATA"))
                                DataStream(GuidStr, iDataConnect, content, DataSend, true);
                        }
                        catch { }
                }
            }
            catch
            {
                try
                {
                    DataStream(GuidStr, iDataConnect, content, DataSend, true);
                }
                catch { }
            }
        }
    }
}
