﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MobileHis.Data.DataEntities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Sys_mHisEntities : DbContext
    {
        public Sys_mHisEntities()
            : base("name=Sys_mHisEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<domain2plugin> domain2plugin { get; set; }
        public virtual DbSet<domains> domains { get; set; }
        public virtual DbSet<plugins> plugins { get; set; }
    }
}
