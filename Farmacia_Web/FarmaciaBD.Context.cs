﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Farmacia_Web
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class FarmaciaEntities : DbContext
    {
        public FarmaciaEntities()
            : base("name=FarmaciaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ARTICULO> ARTICULO { get; set; }
        public virtual DbSet<CATEGORIA> CATEGORIA { get; set; }
        public virtual DbSet<CLIENTE> CLIENTE { get; set; }
        public virtual DbSet<PEDIDO> PEDIDO { get; set; }
        public virtual DbSet<PEDIDO_DETALLE> PEDIDO_DETALLE { get; set; }
    
        public virtual ObjectResult<SP_SEL_CLIENTES_Result> SP_SEL_CLIENTES()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_SEL_CLIENTES_Result>("SP_SEL_CLIENTES");
        }
    }
}
