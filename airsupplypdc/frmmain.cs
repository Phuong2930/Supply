using AirSupplyPDC.AsynProcess;
using AirSupplyPDC.TCP_IP;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataSave = AirSupplyPDC.Properties.Settings;

namespace AirSupplyPDC
{
    public partial class frmMain : DevExpress.XtraEditors.XtraForm
    {
        public frmServerList frmServer { get; set; }
        private frmStore[] frmStores { get; set; }

        private tb_Cabinet[] tb_Cabinets { get; set; }

        public Queue<int> lsIDCabinet { get; set; } = new Queue<int>();
        public Queue<TransactionInfor> lsTransactionInfor { get; set; } = new Queue<TransactionInfor>();


        public Thread thread { get; set; }

        public bool isClosing { get; set; } = false;

        public frmMain()
        {
            InitializeComponent();
            InitOriginal();
        }
        public void InitServer(frmServerList server)
        {
            frmServer = new frmServerList() { DataStream = this.iDataStream, iConnect = this.iConnect, updateCab = this.updateCab, updatelsCab = this.updatelsCab };
            frmServer.Show();
        }
        public void InitOriginal()
        {
            using (AirSupplyPDC.AirSupplyPDCEntities dbContext = new AirSupplyPDC.AirSupplyPDCEntities())
                tb_AreaBindingSource.DataSource = dbContext.tb_Area.ToArray();
            thread = new Thread(NewThread);
            thread.Start();
            if (frmServer == null)
                InitServer(frmServer);
        }
        public void NewThread()
        {
            SyncupdateCab();
        }
        private void iDataStream(Guid GuidStr, string iDataConnect, string content, string respond, bool isSuccess)
        {
            lsTransactionInfor.Enqueue(new TransactionInfor
            {
                Guid = GuidStr,
                EventOccur = DateTime.Now,
                IPSend = iDataConnect,
                SendData = content,
                RespondData = respond,
                isSuccess = isSuccess
            });
        }
        private void iConnect(Client client, bool isconnect)
        {
            if (isconnect)
                Processing.SetListBoxValue(listBoxConnect, client.iDataConnect);
            else
                Processing.RemoveListBoxValue(listBoxConnect, client.iDataConnect);
        }
        private void updateCab(int _idCabinet)
        {
            lsIDCabinet.Enqueue(_idCabinet);
        }
        public void SyncupdateCab()
        {
            while (!isClosing)
            {
                Thread.Sleep(500);
                while (lsIDCabinet.Any())
                    if (lsIDCabinet.Dequeue() is int id_ && id_ > 0)
                    {
                        try
                        {
                            if (frmStores != null)
                            {
                                using (AirSupplyPDCEntities db_ = new AirSupplyPDCEntities())
                                {
                                    tb_Cabinet tb_ = db_.tb_Cabinet.FirstOrDefault(x => x.ID_ == id_);
                                    if (tb_ != null)
                                    {
                                        foreach (frmStore frm in frmStores)
                                            if (frm.idloc == tb_.ID_LOC)
                                            {
                                                frm.IsAccessible = !frm.IsAccessible;
                                                frm.RefeshCabinet(id_, tb_.NAME_);
                                                frm.IsAccessible = !frm.IsAccessible;
                                                break;
                                            }
                                        //itemRemain[] itemCabinets = frmStores.SelectMany(x => x.controls).Where(x => x.actionCabinet != null && x.actionCabinet.oncon > 0).Select(x => x.actionCabinet).SelectMany(x => x.tb_Remains.Where(y => !y.ISFINISH))
                                        //     .OrderBy(x => x.ONCONVEYOR_DATE).Select(x => new itemRemain() { RemainAdd = new tb_Remain() { PARTID = x.PARTID, ISFINISH = x.ISFINISH }, Margin = new Padding(0) }).ToArray();
                                        //if (!flowLayoutPanelOnconveyor.InvokeRequired)
                                        //    Processing.SetFlowLayoutPanel(flowLayoutPanelOnconveyor, true, itemCabinets);
                                        //else
                                        //    flowLayoutPanelOnconveyor.Invoke(new MethodInvoker(() => Processing.SetFlowLayoutPanel(flowLayoutPanelOnconveyor, true, itemCabinets)));

                                    }
                                }
                            }
                        }
                        catch { }
                    }
                while (lsTransactionInfor.Any())
                    if (lsTransactionInfor.Dequeue() is TransactionInfor id_)
                    {
                        if (!gridControlData.InvokeRequired)
                            Processing.AddGridItem(gridControlData, transactionInforBindingSource, id_);
                        else
                            Processing.AddGridItem(gridControlData, transactionInforBindingSource, id_);
                    }
            };
        }
        private void updatelsCab(int[] _lsCabinet)
        {
            if (_lsCabinet.Any())
                foreach (int frm in _lsCabinet)
                    lsIDCabinet.Enqueue(frm);
        }
        private async void gridLookUpEditArea_EditValueChanged(object sender, EventArgs e)
        {
            if (sender is GridLookUpEdit gridLookUp)
            {
                if (frmStores != null)
                {
                    foreach (frmStore frm in frmStores)
                    {
                        frm.idloc = 0;
                        frm.Close();
                        frm.Dispose();
                    }
                }
                flowLayoutPanelCell.Controls.Clear();
                Program.inforCommon.cellInfors = new CellInfor[0];
                if (gridLookUp.EditValue is int idgrid)
                {
                    if (DataSave.Default.idarea != idgrid)
                    {
                        DataSave.Default.idarea = idgrid;
                        DataSave.Default.Save();
                    }
                    Program.inforCommon.idArea = idgrid;
                    using (AirSupplyPDC.AirSupplyPDCEntities dbContext = new AirSupplyPDC.AirSupplyPDCEntities())
                        if (dbContext.tb_Area.Any(x => x.ID_ == idgrid))
                        {
                            tb_Area tb_ = dbContext.tb_Area.FirstOrDefault(x => x.ID_ == idgrid);
                            tb_Location[] tb_Locations = tb_.tb_Location.ToArray();
                            Program.inforCommon.tb_Settings = tb_.tb_SettingPart.ToArray();

                            itemCell[] itemCells = tb_.tb_Cell.ToArray().Select(x => new itemCell(x.ID_) { Changed = getCell }).ToArray();
                            Processing.SetFlowLayoutPanel(flowLayoutPanelCell, true, itemCells);


                            gridLookUp.Enabled = false;
                            frmStores = tb_Locations.Select(x => new frmStore(x.ID_)).ToArray();
                            tb_Cabinets = dbContext.tb_Cabinet.Where(x => x.tb_Location.ID_AREA == idgrid).ToArray();
                            if (frmStores != null)
                            {
                                foreach (frmStore frm in frmStores)
                                {
                                    frm.Show();
                                    frm.IsAccessible = !frm.IsAccessible;
                                }
                                foreach (frmStore frm in frmStores)
                                {
                                    await Task.Run(() =>
                                        {
                                            //await Task.Delay(2000);
                                            frm.InitLocationOri(frm.idloc, tb_Cabinets.Where(x => x.ID_LOC == frm.idloc).ToArray());
                                            //frm.RunRefeshCabinet();
                                        });
                                    frm.IsAccessible = !frm.IsAccessible;
                                }
                            }
                            //itemRemain[] itemCabinets = frmStores.SelectMany(x => x.controls).Where(x => x.actionCabinet != null && x.actionCabinet.oncon > 0).Select(x => x.actionCabinet).SelectMany(x => x.tb_Remains.Where(y => !y.ISFINISH))
                            //             .OrderBy(x => x.ONCONVEYOR_DATE).Select(x => new itemRemain() { RemainAdd = new tb_Remain() { PARTID = x.PARTID, ISFINISH = x.ISFINISH }, Margin = new Padding(0) }).ToArray();
                            //Processing.SetFlowLayoutPanel(flowLayoutPanelOnconveyor, true, itemCabinets);
                            gridLookUp.Enabled = true;

                        }
                }
                else
                {
                    Program.inforCommon.idArea = 0;
                    Program.inforCommon.cellInfors = new CellInfor[0];
                    Program.inforCommon.tb_Settings = new tb_SettingPart[0];
                }
                GC.Collect();
            }
        }

        private void getCell()
        {
            IEnumerable<itemCell> controls = flowLayoutPanelCell.Controls.Cast<itemCell>();
            Program.inforCommon.cellInfors = controls.Where(x => x.isEnable).Select(x => x.cellInfor).ToArray();
            btnUpdate.Enabled = true;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            btnUpdate.Enabled = false;
            if (frmStores != null)
                foreach (frmStore frm in frmStores)
                {
                    await Task.Run(() =>
                    {
                        frm.RunRefeshCabinet();
                    });
                }
        }

        private void frmMain_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            isClosing = true;
            if (thread != null && thread.IsAlive)
                thread.Join();
            if (frmServer != null)
            {
                frmServer.isClosing = isClosing;
                frmServer.CloseAllPort();
                frmServer.Close();
                frmServer.Dispose();
            }
        }
    }
}
