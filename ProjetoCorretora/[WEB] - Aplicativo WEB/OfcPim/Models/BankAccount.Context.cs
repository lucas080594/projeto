﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BankAccountEntities : DbContext
    {
        public BankAccountEntities()
            : base("name=BankAccountEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<EBRX_BANCO_CONTA> EBRX_BANCO_CONTA { get; set; }
        public virtual DbSet<INSTI_BANCO> INSTI_BANCO { get; set; }
    }
}
