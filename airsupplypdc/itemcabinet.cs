using AirSupplyPDC.AsynProcess;
using AirSupplyPDC.TCP_IP;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Senders;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirSupplyPDC
{
    public partial class itemCabinet : DevExpress.XtraEditors.XtraUserControl
    {
        public int idcabinet { get; set; }
        public actionCabinet actionCabinet { get; set; }


        public AirSupplyPDCEntities db_ { get; set; }

        public int  giaTriCheckBox = -1;
        public itemCabinet(int idcabinet)
        {
            this.idcabinet = idcabinet;
            InitializeComponent();

            updateCabinetPart();

            //System.Threading.Tasks.Task.Factory.StartNew(() => InitCabinet(null, idcabinet));
        }

        public void InitCabinet(object sender, int idcabinet)
        {
            AirSupplyPDCEntities db_ = null;
            GC.Collect();
            db_ = new AirSupplyPDCEntities();
            tb_Cabinet tb_ = db_.tb_Cabinet.FirstOrDefault(x => x.ID_ == idcabinet);
            if (tb_ != null)
            {
                Processing.SetLabelValue(lbNameLocation, tb_.tb_Location.NAME_);
                Processing.SetLabelValue(lbName, tb_.NAME_);
                Processing.SetValue(spinEditCap, tb_.CAPACITY_);

                if (sender == null || !(sender is ToggleSwitch))
                {
                    Processing.SetToggleValue(toggleSwitchEnable, tb_.ENABLE_);
                }



            }
        }
        public void RefreshCabinet()
        {
            InitCabinet(null, this.idcabinet);
            RemainCabinet(this.idcabinet); ;
        }
        public void RefreshRemainCabinet()
        {
            RemainCabinet(this.idcabinet); ;
        }
        public void RemainCabinet(int idcab)
        {
            AirSupplyPDCEntities db_ = null;
            GC.Collect();
            db_ = new AirSupplyPDCEntities();
            tb_Cabinet tb_ = db_.tb_Cabinet.FirstOrDefault(x => x.ID_ == idcabinet);
            if (tb_ != null)
            {
                if (tb_.CAPACITY_ != flowLayoutPanel.Controls.Count)
                {
                    Processing.SetFlowLayoutPanel(flowLayoutPanel, true, null);
                    itemRemain[] itemRemains = new string[tb_.CAPACITY_].Select(x => new itemRemain() { Margin = new Padding(0) }).ToArray();
                    Processing.SetFlowLayoutPanel(flowLayoutPanel, true, itemRemains);
                }
                actionCabinet = new actionCabinet(tb_);
                if (actionCabinet.tb_PartAllow.Length != flowLayoutPanelPart.Controls.Count)
                {
                    Processing.SetFlowLayoutPanel(flowLayoutPanelPart, true, null);
                    itemPart[] itemParts = new string[actionCabinet.tb_PartAllow.Length].Select(x => new itemPart() { Margin = new Padding(0) }).ToArray(); ;
                    Processing.SetFlowLayoutPanel(flowLayoutPanelPart, true, itemParts);
                }
                tb_Remain[] _Remains = actionCabinet.tb_Remains;
                int numRemain = 0;
                foreach (Control itemctrl in flowLayoutPanel.Controls)
                {
                    if (itemctrl is itemRemain remain)
                    {
                        if (numRemain >= _Remains.Length)
                            remain.RemainAdd = null;
                        else
                            remain.RemainAdd = _Remains[numRemain];
                        numRemain++;
                    }
                }

                string[] _ListParts = actionCabinet.tb_PartAllow;
                if (giaTriCheckBox == 1)
                {
                    using (AirSupplyPDCEntities context = new AirSupplyPDCEntities())
                    {

                        var validParts = context.tb_Part
                                                .Where(x => _ListParts.Contains(x.PARTID) && x.type_part == 1)
                                                .Select(x => x.PARTID)
                                                .ToList();


                        //Loai bo cac PARTID khong ton tai
                        var invalidParts = _ListParts.Except(validParts).ToList();

                        // Chuyen mang sang danh sach
                        List<string> listPart = actionCabinet.tb_PartAllow.ToList();

                        // Xoa ma unit ra khoi danh sach
                        foreach (var invalidPart in invalidParts)
                        {
                            listPart.Remove(invalidPart);
                        }

                        actionCabinet.tb_PartAllow = listPart.ToArray();
                    }

                } else if (giaTriCheckBox == -1)
                {
                    actionCabinet.tb_PartAllow = _ListParts.ToArray();
                }
                else
                {
                    using (AirSupplyPDCEntities context = new AirSupplyPDCEntities())
                    {

                        var validParts = context.tb_Part
                                                .Where(x => _ListParts.Contains(x.PARTID) && x.type_part == 0)
                                                .Select(x => x.PARTID)
                                                .ToList();


                        //Loai bo cac PARTID khong ton tai
                        var invalidParts = _ListParts.Except(validParts).ToList();

                        // Chuyen mang sang danh sach
                        List<string> listPart = actionCabinet.tb_PartAllow.ToList();

                        // Xoa ma unit ra khoi danh sach
                        foreach (var invalidPart in invalidParts)
                        {
                            listPart.Remove(invalidPart);
                        }

                        actionCabinet.tb_PartAllow = listPart.ToArray();
                    }
                }
           
        

                string[] _Parts = actionCabinet.tb_PartAllow;
                int numPart = 0;
                foreach (Control itemctrl in flowLayoutPanelPart.Controls)
                {
                    if (itemctrl is itemPart part)
                    {
                        if (numPart >= _Parts.Length)
                            part.PartAdd = null;
                        else
                            part.PartAdd = _Parts[numPart];
                        numPart++;
                    }
                }
                if (actionCabinet.isUsed)
                {
                    Processing.SetLabelColor(lbCell, Color.LightYellow);
                    if (actionCabinet.tb_CellSelected != null)
                    {
                        Processing.SetLabelValue(lbCell, actionCabinet.tb_CellSelected.NAME_);
                        if (this.InvokeRequired)
                            this.Invoke(new MethodInvoker(() =>
                            {
                                this.layoutControlGroup.AppearanceGroup.BackColor = Processing.GetSystemDrawingColorFromHexString(actionCabinet.tb_CellSelected.BACKGROUND);
                            }));
                        else this.layoutControlGroup.AppearanceGroup.BackColor = Processing.GetSystemDrawingColorFromHexString(actionCabinet.tb_CellSelected.BACKGROUND);
                    }
                    else
                    {
                        Processing.SetLabelValue(lbCell, "COMMON");
                    }
                    if (actionCabinet.IsFull()) Processing.SetLabelColor(lbCell, Color.LightGreen);
                }
                else
                {
                    if (actionCabinet.tb_CellSelected != null)
                    {
                        Processing.SetLabelValue(lbCell, actionCabinet.tb_CellSelected.NAME_);
                    }
                    else
                    {
                        Processing.SetLabelValue(lbCell, "NO USE");
                    }
                    Processing.SetLabelColor(lbCell, Color.LightGray);
                }
                if (actionCabinet.IsMustOut()) Processing.SetLabelColor(lbCell, Color.Tomato);
            }
        }
        public Task TaskRefreshCabinet()
        {
            return Task.Run(() => InitCabinet(null, this.idcabinet));
        }
        private void toggleSwitchEnable_Toggled(object sender, EventArgs e)
        {
            if (sender is ToggleSwitch toggle)
            {
                if (actionCabinet != null)
                    using (AirSupplyPDCEntities db_ = new AirSupplyPDCEntities())
                    {
                        tb_Cabinet tb_ = db_.tb_Cabinet.FirstOrDefault(x => x.ID_ == idcabinet);
                        if (tb_ != null)
                        {
                            if (tb_.ENABLE_ != toggle.IsOn)
                            {
                                tb_.ENABLE_ = toggle.IsOn;
                                db_.SaveChanges();
                                InitCabinet(sender, idcabinet);
                            }
                        }
                    }
            }
        }

        public bool checkCabinet()
        {
            if (idcabinet >= 42 && idcabinet <= 44 || idcabinet >= 10 && idcabinet <= 12)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void updateCabinetPart()
        {
            if (checkCabinet())
            {
                int startX = 5;
                int startY = 5;
                int spacing = 100;
                string[] listText = { "Child part", "Unit" };
                for (int i = 0; i < 2; i++)
                {
                    CheckBox newCheckBox1 = new CheckBox();

                    newCheckBox1.Text = "Child part";
                    newCheckBox1.AutoSize = true;
                    newCheckBox1.Location = new Point(startX + (i * spacing), startY);

                    //Gan them su checkedChanged
                    newCheckBox1.CheckedChanged += NewCheckBox_CheckedChanged;
                    //Them checkbox vao panel
                    pannelSelectPart.Controls.Add(newCheckBox1);

                    CheckBox newCheckBox2 = new CheckBox();

                    newCheckBox2.Text = "Unit";
                    newCheckBox2.AutoSize = true;
                    newCheckBox2.Location = new Point(startX + (i * spacing), startY);

                    //Gan them su checkedChanged
                    newCheckBox1.CheckedChanged += NewCheckBox_CheckedChanged;
                    //Them checkbox vao panel
                    pannelSelectPart.Controls.Add(newCheckBox2);
                }
            }
        }

        private void NewCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox selectedCheckBox = sender as CheckBox;
            if(selectedCheckBox != null)
            {
               string text = selectedCheckBox.Text;
                bool isChecked = selectedCheckBox.Checked;
               if(isChecked)
               {
                    if (text == "Child part")
                    {
                        giaTriCheckBox = 1;
                    }
                    else
                    {
                        giaTriCheckBox = 0;
                    }
               }

                bool allCheked = true;
                bool anyChecked = false;
                foreach(Control control in pannelSelectPart.Controls)
                {
                    if(control is CheckBox checkBox)
                    {
                        if (checkBox.Checked)
                        {
                            anyChecked = true;
                        }
                        else
                        {
                            allCheked = false;
                        }
                    }
                }
                if (!anyChecked)
                {
                    giaTriCheckBox = -1;
                }else if (allCheked)
                {
                    giaTriCheckBox = -1;
                }
                RefreshRemainCabinet();

            }

            
        }

        private void RefreshPartPane()
        {
            flowLayoutPanel.Controls.Clear();

            string[] updateParts = actionCabinet.tb_PartAllow;
            foreach(var part in updateParts)
            {
                itemPart item = new itemPart { Margin = new Padding(0)};
                item.PartAdd = part;
                flowLayoutPanelPart.Controls.Add(item);
            }
        }


        private void panelControl2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
