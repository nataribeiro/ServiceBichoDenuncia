﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BichoDenunciaService.AppCode
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class webserviceEntities : DbContext
    {
        public webserviceEntities()
            : base("name=webserviceEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<denuncia> denuncia { get; set; }
        public DbSet<hashtag> hashtag { get; set; }
        public DbSet<midia> midia { get; set; }
        public DbSet<retorno> retorno { get; set; }
    }
}
