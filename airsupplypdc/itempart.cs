using AirSupplyPDC.AsynProcess;

namespace AirSupplyPDC
{
    public partial class itemPart : DevExpress.XtraEditors.XtraUserControl
    {
        private string temPartAdd { get; set; } = string.Empty;
        public string PartAdd
        {
            get => temPartAdd;
            set
            {
                temPartAdd = value;
                    Processing.SetLabelValue(lbName, PartAdd);
            }
        }
        public itemPart()
        {
            InitializeComponent();
            this.IsAccessible = false;
            this.lbName.IsAccessible = false;
        }
    }
}
