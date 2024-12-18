using System.Linq;

namespace AirSupplyPDC.TCP_IP
{
    public class actionCabinet
    {
        public class RemainPart
        {
            public string Part_ { get; set; }
            public int Oncon_ { get; set; }
            public int Remain_ { get; set; }
            public int Empty_ { get; set; }
            public RemainPart(string part, tb_Remain partremain, int oncon, int remain, int cap, tb_Cabinet cabinet)
            {
                this.Part_ = part;
                if (partremain == null)
                {
                    this.Remain_ = 0;
                    this.Oncon_ = 0;
                    this.Empty_ = cabinet.ENABLE_ ? cap : 0;
                }
                else
                {
                    if (part != partremain.PARTID)
                    {
                        this.Remain_ = 0;
                        this.Empty_ = 0;
                        this.Oncon_ = 0;
                    }
                    else
                    {
                        this.Remain_ = remain;
                        this.Oncon_ = oncon;
                        this.Empty_ = (cap > remain + oncon) && cabinet.ENABLE_ ? cap - remain - oncon : 0;
                    }
                }
            }
        }
        private tb_Cabinet _CabinetPri { get; set; }
        public bool isUsed { get; set; } = false;
        public int capacity { get; set; } = 0;
        public int remain { get; set; } = 0;
        public int oncon { get; set; } = 0;
        public tb_Remain tb_Remain { get; set; }
        public tb_Cabinet _Cabinet
        {
            get => _CabinetPri;
            set
            {
                _CabinetPri = value;
                if (value != null)
                {
                    capacity = value.CAPACITY_;
                    tb_Remains = value.tb_Remain.ToArray();
                    tb_Remain = tb_Remains.FirstOrDefault();
                    remain = tb_Remains.Count(x => x.ISFINISH);
                    oncon = tb_Remains.Count(x => !x.ISFINISH);
                    
                    tb_PartCabinet = value.tb_SettingCabinetPart.Select(x => x.PARDID).ToArray();
                    if (tb_PartAllowPri != null && cellInforsPri != null)
                    {
                        int? id_cell_ = value.ID_CELL_MAIN;
                        tb_SettingCabinetCell[] tb_SettingCabinetCells = value.tb_SettingCabinetCell.ToArray();
                        if (!tb_SettingCabinetCells.Any())
                        {
                            isUsed = !id_cell_.HasValue;
                        }
                        else
                        {
                            if (id_cell_.HasValue)
                            {
                                if (tb_SettingCabinetCells.Any(x => x.ID_CELL == id_cell_.Value))
                                {
                                    int dem = 0;
                                    tb_SettingCabinetCell tb_SettingCabinet = null;
                                    foreach (tb_SettingCabinetCell tb_Setting in tb_SettingCabinetCells)
                                        if (cellInforsPri.Any(x => x.idCell == tb_Setting.ID_CELL))
                                        {
                                            dem++;
                                            tb_SettingCabinet = tb_Setting;
                                        }
                                    if (dem == 1)
                                    {
                                        tb_CellSelected = tb_SettingCabinet.tb_Cell;
                                        isUsed = true;
                                    }
                                    else if (dem > 1)
                                    {
                                        tb_CellSelected = value.tb_Cell;
                                        isUsed = true;
                                    }

                                }
                            }
                            else
                            {
                                int dem = 0;
                                tb_SettingCabinetCell tb_SettingCabinet = null;
                                foreach (tb_SettingCabinetCell tb_Setting in tb_SettingCabinetCells)
                                    if (cellInforsPri.Any(x => x.idCell == tb_Setting.ID_CELL))
                                    {
                                        dem++;
                                        tb_SettingCabinet = tb_Setting;
                                    }
                                if (dem == 1)
                                {
                                    tb_CellSelected = tb_SettingCabinet.tb_Cell;
                                    isUsed = true;
                                }
                            }
                        }
                        if (isUsed)
                        {
                            if (tb_CellSelected != null)
                            {
                                CellInfor cell = this.cellInforsPri.FirstOrDefault(x => x.idCell == tb_CellSelected.ID_);
                                tb_SettingPart[] tb_Settings = tb_PartAllowPri.Where(y => y.ID_MER == cell.idMer && y.ID_MODEL == cell.idModel).ToArray();
                                tb_PartAllow = tb_PartCabinet.Where(x => tb_Settings.Any(y => y.PARTID == x)).ToArray();
                            }
                            else
                            {
                                tb_PartAllow = tb_PartCabinet.ToArray();
                            }
                        }
                    }
                }
            }
        }
        public bool CheckPart(string idPart)
        {
            return !IsMustOut() && CheckPartCell(idPart)
                && IsAllowInput() && (tb_Remain == null || tb_Remain.PARTID == idPart);
        }
        public bool CheckPartCell(string idPart)
        {
            return (isUsed && tb_PartAllow.Any(x => x == idPart));
        }
        public bool IsMustOut()
        {
            return tb_Remain != null && !tb_PartAllow.Any(x => x == tb_Remain.PARTID);
        }
        public bool IsFull()
        {
            return capacity > 0 && remain + oncon >= capacity;
        }
        public bool IsAllowInput()
        {
            return capacity > 0 && remain + oncon < capacity;
        }
        private CellInfor[] cellInforsPri { get; set; } = Program.inforCommon.cellInfors;
        private tb_SettingPart[] tb_PartAllowPri { get; set; } = Program.inforCommon.tb_Settings;

        public actionCabinet(tb_Cabinet _Cabi)
        {
            this._Cabinet = _Cabi;
        }
        public tb_Cell tb_CellSelected { get; set; }
        public string[] tb_PartCabinet { get; set; }
        public string[] tb_PartAllow { get; set; } = new string[0];
        public tb_Remain[] tb_Remains { get; set; } = new tb_Remain[0];
        public RemainPart[] remainParts { get => tb_PartAllow.Select(x => new RemainPart(x, tb_Remain, this.oncon, this.remain, this.capacity, _CabinetPri)).ToArray(); }
    }
}
