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
    
    public partial class EBRX_SOLICT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EBRX_SOLICT()
        {
            this.EBRX_CLIENT_SOLICIT = new HashSet<EBRX_CLIENT_SOLICIT>();
        }
    
        public int COD_INT_SOL { get; set; }
        public string DESC_NOM_SOL { get; set; }
        public Nullable<double> PRAZO_FLOAT_SOL { get; set; }
        public Nullable<System.DateTime> DT_ATUALIZAC { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EBRX_CLIENT_SOLICIT> EBRX_CLIENT_SOLICIT { get; set; }
    }
}
