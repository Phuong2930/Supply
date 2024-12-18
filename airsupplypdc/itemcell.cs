using AirSupplyPDC.AsynProcess;
using AirSupplyPDC.TCP_IP;
using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AirSupplyPDC
{
    public partial class itemCell : DevExpress.XtraEditors.XtraUserControl
    {
        public delegate void ChangedEvent();
        public ChangedEvent Changed = delegate { };
        public int idCell { get; set; }
        //public tb_SettingPart[] tb_SettingParts { get; set; }
        public bool isEnable { get; set; } = false;
        public CellInfor cellInfor
        {
            get
            {
                CellInfor cell = new CellInfor
                {
                    idCell = idCell
                };
                if (gridLookUpEditModel.EditValue is int idmodel)
                    cell.idModel = idmodel;
                if (gridLookUpEditMerc.EditValue is int idmer)
                    cell.idMer = idmer;
                return cell;
            }
        }
        public itemCell(int idcell)
        {
            InitializeComponent();
            InitCell(idcell);
            getStatus();
        }
        public void InitCell(int idcell)
        {
            using (AirSupplyPDCEntities db_ = new AirSupplyPDCEntities())
            {
                tb_Cell _Cell = db_.tb_Cell.FirstOrDefault(x => x.ID_ == idcell);
                if (_Cell != null)
                {
                    this.idCell = _Cell.ID_;
                    lbName.Text = _Cell.NAME_;
                }
            }

        }
        private void toggleSwitchEnable_Toggled(object sender, EventArgs e)
        {
            if (sender is ToggleSwitch toggle)
            {
                if (!toggle.IsOn)
                {
                    gridLookUpEditModel.EditValue = null;
                    gridLookUpEditModel.Enabled = false;
                    Changed();
                }
                else
                {
                    using (AirSupplyPDCEntities db_ = new AirSupplyPDCEntities())
                    {
                        tb_Cell _Cell = db_.tb_Cell.FirstOrDefault(x => x.ID_ == this.idCell);
                        if (_Cell != null)
                        {
                            tb_Model[] tb_Models = db_.tb_SettingPart.Where(x => x.ID_AREA == _Cell.ID_AREA).ToArray().GroupBy(x => x.tb_Model).Select(x => x.Key).OrderBy(x => x.ID_).ToArray();
                            tb_ModelBindingSource.DataSource = tb_Models;
                        }
                    }
                    gridLookUpEditModel.Enabled = true;
                }
            }
            getStatus();
        }

        private void gridLookUpEditModel_EditValueChanged(object sender, EventArgs e)
        {
            if (sender is GridLookUpEdit gridLook)
            {
                if (gridLook.EditValue is int idMoldel)
                {
                    using (AirSupplyPDCEntities db_ = new AirSupplyPDCEntities())
                    {
                        tb_Cell _Cell = db_.tb_Cell.FirstOrDefault(x => x.ID_ == this.idCell);
                        if (_Cell != null)
                        {
                            tb_SettingPart[] tb_Settings = db_.tb_SettingPart.Where(x => x.ID_AREA == _Cell.ID_AREA).ToArray().Where(x => x.ID_MODEL == idMoldel).ToArray();
                            tb_Merchandise[] tb_Merchandises = tb_Settings.GroupBy(x => x.tb_Merchandise).Select(x => x.Key).OrderBy(x => x.ID_).ToArray();
                            tb_MerchandiseBindingSource.DataSource = tb_Merchandises;
                            gridLookUpEditMerc.Enabled = true;
                            Changed();
                        }
                    }
                }
                else
                {
                    gridLookUpEditMerc.EditValue = null;
                    gridLookUpEditMerc.Enabled = false;
                }
            }
            getStatus();
        }
        private void getStatus()
        {
            isEnable = false;
            if (toggleSwitchEnable.IsOn)
            {
                if (gridLookUpEditModel.EditValue != null && gridLookUpEditMerc.EditValue != null)
                {
                    lbStatus.Text = "Sẵn sàng";
                    lbStatus.BackColor = Color.LightGreen;
                    isEnable = true;
                }
                else
                {
                    lbStatus.Text = "Đang chờ";
                    lbStatus.BackColor = Color.LightYellow;
                }
            }
            else
            {
                lbStatus.Text = "Tạm dừng";
                lbStatus.BackColor = Color.Tomato;
            }
        }

        private void gridLookUpEditMerc_EditValueChanged(object sender, EventArgs e)
        {
            getStatus();
            if (sender is GridLookUpEdit edit)
                if (edit.EditValue is int idmer)
                {
                    Changed();
                    if (this.idCell > 0)
                        if (gridLookUpEditModel.EditValue != null && gridLookUpEditMerc.EditValue != null)
                            if (gridLookUpEditModel.EditValue is int idmol)
                            {
                                using (AirSupplyPDCEntities db_ = new AirSupplyPDCEntities())
                                {
                                    tb_Cell _Cell = db_.tb_Cell.FirstOrDefault(x => x.ID_ == this.idCell);
                                    if (_Cell != null)
                                    {
                                        itemPart[] itemParts = db_.tb_SettingPart.Where(x => x.ID_AREA == _Cell.ID_AREA && x.ID_MER == idmer && x.ID_MODEL == idmol).ToArray().Select(x => new itemPart() { PartAdd = x.PARTID, Margin = new Padding(0) }).ToArray();
                                        //for (int i = 0; i < itemParts.Length; i++)
                                        Processing.SetFlowLayoutPanel(flowLayoutPanel, true, itemParts);
                                    }
                                }
                            }
                }
                else
                {
                    Processing.SetFlowLayoutPanel(flowLayoutPanel, true, new UserControl[0]);
                }
        }
    }
}
