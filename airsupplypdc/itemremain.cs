using AirSupplyPDC.AsynProcess;
using System.Drawing;

namespace AirSupplyPDC
{
    public partial class itemRemain : DevExpress.XtraEditors.XtraUserControl
    {
        private tb_Remain temRemainAdd { get; set; }
        public tb_Remain RemainAdd
        {
            get => temRemainAdd;
            set
            {
                temRemainAdd = value;
                if (value != null)
                {
                    Processing.SetLabelValue(lbName, value.PARTID);
                    Processing.SetLabelColor(lbName, !value.ISFINISH ? Color.LightGray : Color.LimeGreen);
                }
                else
                {
                    Processing.SetLabelValue(lbName, string.Empty);
                    Processing.SetLabelColor(lbName, Color.White);
                }
            }
        }
        public itemRemain()
        {
            InitializeComponent();
            this.IsAccessible = false;
            this.lbName.IsAccessible = false;
        }
    }
}
