//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OfcPim.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class EBRX_TIP_TRAN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EBRX_TIP_TRAN()
        {
            this.EBRX_TRAN = new HashSet<EBRX_TRAN>();
        }
    
        public int COD_INT_ID { get; set; }
        public string DESC_STR_TRAN { get; set; }
        public Nullable<double> PERC_TRAN { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EBRX_TRAN> EBRX_TRAN { get; set; }
    }
}
