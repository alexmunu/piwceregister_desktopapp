﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace PIWCeRegister.Source.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public partial class piwcldbEntities : DbContext
    {
        public piwcldbEntities()
            : base("name=piwcldbEntities")
        {
                    
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public DbSet<address> addresses { get; set; }
        public DbSet<ch_ministries> ch_ministries { get; set; }
        public DbSet<ch_services> ch_services { get; set; }
        public DbSet<m_occupation> m_occupation { get; set; }
        public DbSet<member> members { get; set; }
        public DbSet<non_member> non_member { get; set; }
        public DbSet<services_types> services_types { get; set; }
    }
}
