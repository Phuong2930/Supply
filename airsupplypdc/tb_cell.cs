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
    
    public partial class tb_Cell
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_Cell()
        {
            this.tb_Cabinet = new HashSet<tb_Cabinet>();
            this.tb_SettingCabinetCell = new HashSet<tb_SettingCabinetCell>();
        }
    
        public int ID_ { get; set; }
        public int ID_AREA { get; set; }
        public string NAME_ { get; set; }
        public string BACKGROUND { get; set; }
        public System.DateTime DATE_CREATED { get; set; }
    
        public virtual tb_Area tb_Area { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_Cabinet> tb_Cabinet { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_SettingCabinetCell> tb_SettingCabinetCell { get; set; }
    }
}
