//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AirSupplyPDC
{
    using System;
    using System.Collections.Generic;
    
    public partial class tb_InOutRecord
    {
        public int ID { get; set; }
        public string PARTID { get; set; }
        public int ID_AREA { get; set; }
        public int ID_CABINET { get; set; }
        public int SNP_ { get; set; }
        public bool INOUT_ { get; set; }
        public Nullable<System.DateTime> DATE_ONCONVEYOR { get; set; }
        public Nullable<System.DateTime> DATE_INSTORE { get; set; }
        public Nullable<System.DateTime> DATE_OUTSTORE { get; set; }
    
        public virtual tb_Area tb_Area { get; set; }
        public virtual tb_Cabinet tb_Cabinet { get; set; }
        public virtual tb_Part tb_Part { get; set; }
    }
}
