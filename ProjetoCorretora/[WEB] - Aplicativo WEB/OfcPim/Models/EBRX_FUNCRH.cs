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
    
    public partial class EBRX_FUNCRH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EBRX_FUNCRH()
        {
            this.EBRX_FUNC_PROFILE = new HashSet<EBRX_FUNC_PROFILE>();
        }
    
        public int COD_FUNC { get; set; }
        public string MATRIC_STR_FUNC { get; set; }
        public string NOME_STR_FUNC { get; set; }
        public string SITU_STR_FUNC { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EBRX_FUNC_PROFILE> EBRX_FUNC_PROFILE { get; set; }
    }
}