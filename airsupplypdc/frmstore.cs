using AirSupplyPDC.AsynProcess;
using AirSupplyPDC.TCP_IP;
using DevExpress.XtraEditors;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace AirSupplyPDC
{
    public partial class frmStore : DevExpress.XtraEditors.XtraForm
    {
        public int idloc { get; set; }

        public List<itemCabinet> controls { get => flowLayoutPanel.Controls.Count > 0 ? flowLayoutPanel.Controls.Cast<itemCabinet>().ToList() : new List<itemCabinet>(); }
        public frmStore(int _Location)
        {
            this.idloc = _Location;
            InitializeComponent();
        }
        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }
        public void InitLocationOri(int _Location, params tb_Cabinet[] _Cabinets)
        {
            using (AirSupplyPDCEntities db_ = new AirSupplyPDCEntities())
            {
                tb_Location loc = db_.tb_Location.FirstOrDefault(x => x.ID_ == _Location);
                if (loc != null)
                {
                    Processing.SetValue(this, loc.NAME_);
                    Processing.SetToggleValue(toggleSwitchEnable, loc.ENABLE_);
                    //string[] data = new string[100];
                    //itemPart[] parts = data.Select(x => new itemPart() { PartAdd = x, Margin = new Padding(0) }).ToArray();
                    //Processing.SetFlowLayoutPanel(flowLayoutPanel, true, parts);
                    //itemCabinet[] itemCabinets = _Cabinets.Select(x => new itemCabinet(x.ID_) { Margin = new Padding(5, 1, 5, 1) }).ToArray();
                    Processing.SetFlowLayoutPanel(flowLayoutPanel, true, _Cabinets.Select(x => new itemCabinet(x.ID_) { Margin = new Padding(0, 1, 0, 1) }).ToArray());
                }
                RunRefeshCabinet();
            }
        }
        public async void InitLocation(int _Location)
        {
            using (AirSupplyPDCEntities db_ = new AirSupplyPDCEntities())
            {
                //tb_Location loc = await db_.tb_Location.FirstOrDefaultAsync(x => x.ID_ == _Location);
                var loc = db_.tb_Location.FirstOrDefault(x => x.ID_ == _Location);
                if (loc != null)
                {
                    //this.Text = loc.NAME_;
                    //tb_Cabinet[] tb_Cabinets = loc.tb_Cabinet.ToArray();
                    //itemCabinet[] itemCabinets = tb_Cabinets.Select(x => new itemCabinet(x.ID_) { }).ToArray();
                    //await Task.Run(() => Processing.SetFlowLayoutPanel(flowLayoutPanel, true, itemCabinets));
                    //await Task.Run(() => RefeshCabinet());
                    //CalPart();
                    Processing.SetValue(this, loc.NAME_);
                    Processing.SetToggleValue(toggleSwitchEnable, loc.ENABLE_);

                    var cabinets = db_.tb_Cabinet.Where(x => x.ID_LOC == _Location).ToArray();
                    Processing.SetFlowLayoutPanel(flowLayoutPanel, true, cabinets.Select(x => new itemCabinet(x.ID_)
                    {
                        Margin = new Padding(5, 1, 5, 1)
                    }).ToArray());
                }
            }
            RunRefeshCabinet();
        }
        public TaskOrder[] TaskRefeshCabinet()
        {
            int i = 0;
            return controls.Select(x => new TaskOrder() { task = x.TaskRefreshCabinet(), id = i++ }).ToArray();
        }
        public void RunRefeshCabinet()
        {
            foreach (itemCabinet item in controls)
            {
                //while (!item.IsHandleCreated)
                //{

                //}
                if (item.IsHandleCreated)
                {
                    item.RefreshCabinet();
                }
               
            }
            CalPart();
        }
        public class PartInfo
        {
            public string Part_ { get; set; }
            public int Oncon_ { get; set; }
            public int Remain_ { get; set; }
            public int Empty_ { get; set; }
        }
        private void CalPart()
        {
            PartInfo[] partInfos = (from d in controls.Where(x => x.actionCabinet != null).Select(x => x.actionCabinet).SelectMany(x => x.remainParts)
                                    group d by d.Part_ into c
                                    select new PartInfo()
                                    {
                                        Part_ = c.Key,
                                        Oncon_ = c.Sum(x => x.Oncon_),
                                        Remain_ = c.Sum(x => x.Remain_),
                                        Empty_ = c.Sum(x => x.Empty_),
                                    }).OrderByDescending(x => x.Empty_).ThenBy(x => x.Part_).ToArray();
            Processing.SetGrid(gridControl, partInfos);
            tb_Remain[] _Remains = controls.Where(x => x.actionCabinet != null && x.actionCabinet.oncon > 0).Select(x => x.actionCabinet).SelectMany(x => x.tb_Remains.Where(y => !y.ISFINISH)).OrderBy(x => x.ONCONVEYOR_DATE).ToArray();
            int number = 5;
            while (number < _Remains.Length)
            {
                number += 5;
            }
            if (flowLayoutPanelOnchange.Controls.Count != number)
            {
                itemRemain[] itemRemains = new string[number - flowLayoutPanelOnchange.Controls.Count].Select(x => new itemRemain() { RemainAdd = null, Margin = new Padding(0) }).ToArray();
                Processing.SetFlowLayoutPanel(flowLayoutPanelOnchange, false, itemRemains);
            }
            int numRemain = 0;
            foreach (Control itemctrl in flowLayoutPanelOnchange.Controls)
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
        }
        public void RefeshCabinet(int idCabinet, string name_)
        {
            if (idCabinet > 0)
            {
                Processing.SetLabelValue(lbCabinet, name_);
                int index = 0;
                foreach (itemCabinet item in controls)
                {
                    index++;
                    if (item.idcabinet == idCabinet)
                    {
                        while (!item.IsHandleCreated)
                        {

                        }
                        Processing.SetFlowLayout(flowLayoutPanel, item);
                        item.RefreshRemainCabinet();
                        break;
                    }
                }
                CalPart();
            }
        }
        public void RefeshCabinet(int[] idCabinet)
        {
            foreach (itemCabinet item in controls)
            {
                if (idCabinet.Any(x => x == item.idcabinet))
                {
                    Processing.SetFlowLayout(flowLayoutPanel, item);
                    item.RefreshRemainCabinet();
                }
            }
            CalPart();
        }
        private void frmStore_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (idloc != 0) e.Cancel = true;
        }

        private void toggleSwitchEnable_Toggled(object sender, System.EventArgs e)
        {
            if (sender is ToggleSwitch toggle)
            {
                using (AirSupplyPDCEntities db_ = new AirSupplyPDCEntities())
                {
                    tb_Location tb_ = db_.tb_Location.FirstOrDefault(x => x.ID_ == idloc);
                    if (tb_ != null)
                    {
                        if (tb_.ENABLE_ != toggle.IsOn)
                        {
                            tb_.ENABLE_ = toggle.IsOn;
                            db_.SaveChanges();
                        }
                    }
                }
            }
        }
    }
}