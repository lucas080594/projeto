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
    
    public partial class INSTI_BANCO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public INSTI_BANCO()
        {
            this.EBRX_BANCO_CONTA = new HashSet<EBRX_BANCO_CONTA>();
        }
    
        public int BANCO_INT_ID { get; set; }
        public string NOME_STR_BANK { get; set; }
        public string CNPJ_STR_BANK { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EBRX_BANCO_CONTA> EBRX_BANCO_CONTA { get; set; }
    }
}
