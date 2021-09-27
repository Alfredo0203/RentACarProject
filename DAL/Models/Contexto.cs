using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DAL.Models
{
    public partial class Contexto : DbContext
    {
        public Contexto()
            : base("name=Contexto")
        {
        }

        public virtual DbSet<Administradores> Administradores { get; set; }
        public virtual DbSet<Autos> Autos { get; set; }
        public virtual DbSet<Carrito> Carrito { get; set; }
        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Compras> Compras { get; set; }
        public virtual DbSet<DetalleCompras> DetalleCompras { get; set; }
        public virtual DbSet<HistorialAlquiler> HistorialAlquiler { get; set; }
        public virtual DbSet<Marcas> Marcas { get; set; }
        public virtual DbSet<Modelos> Modelos { get; set; }
        public virtual DbSet<Notificaciones> Notificaciones { get; set; }
        public virtual DbSet<Proveedores> Proveedores { get; set; }
  

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Administradores>()
                .Property(e => e.Nombre)
                .IsFixedLength();

            modelBuilder.Entity<Administradores>()
                .Property(e => e.Apellido)
                .IsFixedLength();

            modelBuilder.Entity<Administradores>()
                .Property(e => e.Correo)
                .IsFixedLength();

            modelBuilder.Entity<Administradores>()
                .Property(e => e.Contra)
                .IsFixedLength();
            modelBuilder.Entity<Autos>()
                .Property(e => e.Placa)
                .IsFixedLength();

            modelBuilder.Entity<Autos>()
                .Property(e => e.Color)
                .IsFixedLength();

            modelBuilder.Entity<Autos>()
                .Property(e => e.Categoria)
                .IsFixedLength();

            modelBuilder.Entity<Autos>()
                .Property(e => e.Imagen)
                .IsFixedLength();

            modelBuilder.Entity<Autos>()
                .Property(e => e.Gif)
                .IsFixedLength();

            modelBuilder.Entity<Autos>()
                .Property(e => e.Estado)
                .IsFixedLength();

            modelBuilder.Entity<Autos>()
                .HasMany(e => e.Carrito)
                .WithRequired(e => e.Autos)
                .HasForeignKey(e => e.FkAuto);

            modelBuilder.Entity<Autos>()
                .HasMany(e => e.HistorialAlquiler)
                .WithRequired(e => e.Autos)
                .HasForeignKey(e => e.FkAuto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Clientes>()
                .Property(e => e.NombreCliente)
                .IsFixedLength();

            modelBuilder.Entity<Clientes>()
                .Property(e => e.Apellido)
                .IsFixedLength();

            modelBuilder.Entity<Clientes>()
                .Property(e => e.Correo)
                .IsFixedLength();

            modelBuilder.Entity<Clientes>()
                .Property(e => e.Contra)
                .IsFixedLength();

            modelBuilder.Entity<Clientes>()
                .Property(e => e.Estado)
                .IsFixedLength();

            modelBuilder.Entity<Clientes>()
                .HasMany(e => e.Carrito)
                .WithRequired(e => e.Clientes)
                .HasForeignKey(e => e.FkCliente);

            modelBuilder.Entity<Clientes>()
                .HasMany(e => e.HistorialAlquiler)
                .WithRequired(e => e.Clientes)
                .HasForeignKey(e => e.FkCliente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Clientes>()
                .HasMany(e => e.Notificaciones)
                .WithRequired(e => e.Clientes)
                .HasForeignKey(e => e.FkCliente);

            modelBuilder.Entity<Compras>()
                .HasMany(e => e.DetalleCompras)
                .WithRequired(e => e.Compras)
                .HasForeignKey(e => e.FkCompra)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DetalleCompras>()
                .Property(e => e.Marca)
                .IsFixedLength();

            modelBuilder.Entity<DetalleCompras>()
                .Property(e => e.Modelo)
                .IsFixedLength();

            modelBuilder.Entity<Marcas>()
                .Property(e => e.NombreMarca)
                .IsFixedLength();

            modelBuilder.Entity<Marcas>()
                .HasMany(e => e.Autos)
                .WithRequired(e => e.Marcas)
                .HasForeignKey(e => e.FkMarca);

            modelBuilder.Entity<Marcas>()
                .HasMany(e => e.Modelos)
                .WithRequired(e => e.Marcas)
                .HasForeignKey(e => e.FkMarca);

            modelBuilder.Entity<Modelos>()
                .Property(e => e.NombreModelo)
                .IsUnicode(false);

            modelBuilder.Entity<Modelos>()
                .HasMany(e => e.Autos)
                .WithRequired(e => e.Modelos)
                .HasForeignKey(e => e.FKModelo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Notificaciones>()
                .Property(e => e.Descripcion)
                .IsFixedLength();

            modelBuilder.Entity<Proveedores>()
                .Property(e => e.NombreProveedor)
                .IsUnicode(false);

            modelBuilder.Entity<Proveedores>()
                .Property(e => e.direccion)
                .IsUnicode(false);

            modelBuilder.Entity<Proveedores>()
                .HasMany(e => e.Compras)
                .WithRequired(e => e.Proveedores)
                .HasForeignKey(e => e.FkProveedor);
        }
    }
}
