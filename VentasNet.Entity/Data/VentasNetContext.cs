﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using VentasNet.Entity.Data.Configurations;
using VentasNet.Entity.Models;
#nullable disable

namespace VentasNet.Entity.Data
{
    public partial class VentasNetContext : DbContext
    {
        public VentasNetContext()
        {
        }

        public VentasNetContext(DbContextOptions<VentasNetContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<ProductoVendido> ProductoVendido { get; set; }
        public virtual DbSet<Proveedor> Proveedor { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Venta> Venta { get; set; }
        public virtual DbSet<VwCliente> VwCliente { get; set; }
        public virtual DbSet<VwProducto> VwProducto { get; set; }
        public virtual DbSet<VwProductoVendido> VwProductoVendido { get; set; }
        public virtual DbSet<VwProveedor> VwProveedor { get; set; }
        public virtual DbSet<VwUsuario> VwUsuario { get; set; }
        public virtual DbSet<VwVenta> VwVenta { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Configurations.ClienteConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.ProductoConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.ProductoVendidoConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.ProveedorConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.VentaConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.VwClienteConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.VwProductoConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.VwProductoVendidoConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.VwProveedorConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.VwUsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.VwVentaConfiguration());

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}