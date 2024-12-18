using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirSupplyPDC.TCP_IP
{
    public class InforCommon
    {
        public int idArea { get; set; } = 0;
        public CellInfor[] cellInfors { get; set; } = new CellInfor[0];
        public tb_SettingPart[] tb_Settings { get; set; } = new tb_SettingPart[0];
        public bool isCondition
        {
            get
                => idArea > 0;
        }
    }
}
