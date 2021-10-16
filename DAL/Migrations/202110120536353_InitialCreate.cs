namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Administradores",
                c => new
                    {
                        IdAdministrador = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 55, fixedLength: true),
                        Apellido = c.String(nullable: false, maxLength: 55, fixedLength: true),
                        Correo = c.String(nullable: false, maxLength: 55, fixedLength: true),
                        Contra = c.String(nullable: false, maxLength: 55, fixedLength: true),
                        Edad = c.Int(nullable: false),
                        Telefono = c.Int(nullable: false),
                        Rol = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdAdministrador);
            
            CreateTable(
                "dbo.Autos",
                c => new
                    {
                        IdAuto = c.Int(nullable: false, identity: true),
                        FkMarca = c.Int(nullable: false),
                        FKModelo = c.Int(nullable: false),
                        Placa = c.String(nullable: false, maxLength: 8, fixedLength: true),
                        Color = c.String(nullable: false, maxLength: 10, fixedLength: true),
                        PrecioDia = c.Double(),
                        Categoria = c.String(nullable: false, maxLength: 15, fixedLength: true),
                        Pasajeros = c.Int(),
                        NumeroPuertas = c.Int(),
                        Imagen = c.String(maxLength: 50, fixedLength: true),
                        Gif = c.String(maxLength: 50, fixedLength: true),
                        Estado = c.String(maxLength: 10, fixedLength: true),
                    })
                .PrimaryKey(t => t.IdAuto)
                .ForeignKey("dbo.Marcas", t => t.FkMarca, cascadeDelete: true)
                .ForeignKey("dbo.Modelos", t => t.FKModelo)
                .Index(t => t.FkMarca)
                .Index(t => t.FKModelo);
            
            CreateTable(
                "dbo.Carrito",
                c => new
                    {
                        IdCarrito = c.Int(nullable: false, identity: true),
                        FkCliente = c.Int(nullable: false),
                        FkAuto = c.Int(nullable: false),
                        CantidadDias = c.Int(nullable: false),
                        PrecioTotal = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.IdCarrito)
                .ForeignKey("dbo.Clientes", t => t.FkCliente, cascadeDelete: true)
                .ForeignKey("dbo.Autos", t => t.FkAuto, cascadeDelete: true)
                .Index(t => t.FkCliente)
                .Index(t => t.FkAuto);
            
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        IdCliente = c.Int(nullable: false, identity: true),
                        NombreCliente = c.String(nullable: false, maxLength: 55, fixedLength: true),
                        Apellido = c.String(nullable: false, maxLength: 55, fixedLength: true),
                        Correo = c.String(nullable: false, maxLength: 55, fixedLength: true),
                        Contra = c.String(nullable: false, maxLength: 55, fixedLength: true),
                        Edad = c.Int(nullable: false),
                        Telefono = c.Int(nullable: false),
                        Rol = c.Int(nullable: false),
                        Estado = c.String(maxLength: 20, fixedLength: true),
                    })
                .PrimaryKey(t => t.IdCliente);
            
            CreateTable(
                "dbo.HistorialAlquiler",
                c => new
                    {
                        IdHistorial = c.Int(nullable: false, identity: true),
                        FkCliente = c.Int(nullable: false),
                        FkAuto = c.Int(nullable: false),
                        FechaInicio = c.DateTime(nullable: false, storeType: "date"),
                        FechaEntrega = c.DateTime(nullable: false, storeType: "date"),
                        CantidadDias = c.Int(nullable: false),
                        Averiado = c.Boolean(),
                        PrecioTotal = c.Double(),
                    })
                .PrimaryKey(t => t.IdHistorial)
                .ForeignKey("dbo.Clientes", t => t.FkCliente)
                .ForeignKey("dbo.Autos", t => t.FkAuto)
                .Index(t => t.FkCliente)
                .Index(t => t.FkAuto);
            
            CreateTable(
                "dbo.Notificaciones",
                c => new
                    {
                        IdNotificacion = c.Int(nullable: false, identity: true),
                        FkCliente = c.Int(nullable: false),
                        Descripcion = c.String(maxLength: 50, fixedLength: true),
                    })
                .PrimaryKey(t => t.IdNotificacion)
                .ForeignKey("dbo.Clientes", t => t.FkCliente, cascadeDelete: true)
                .Index(t => t.FkCliente);
            
            CreateTable(
                "dbo.Marcas",
                c => new
                    {
                        IdMarca = c.Int(nullable: false, identity: true),
                        NombreMarca = c.String(nullable: false, maxLength: 55, fixedLength: true),
                    })
                .PrimaryKey(t => t.IdMarca);
            
            CreateTable(
                "dbo.Modelos",
                c => new
                    {
                        IdModelo = c.Int(nullable: false, identity: true),
                        FkMarca = c.Int(nullable: false),
                        NombreModelo = c.String(nullable: false, maxLength: 55, unicode: false),
                    })
                .PrimaryKey(t => t.IdModelo)
                .ForeignKey("dbo.Marcas", t => t.FkMarca, cascadeDelete: true)
                .Index(t => t.FkMarca);
            
            CreateTable(
                "dbo.Compras",
                c => new
                    {
                        IdCompra = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false, storeType: "date"),
                        FkProveedor = c.Int(nullable: false),
                        Total = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.IdCompra)
                .ForeignKey("dbo.Proveedores", t => t.FkProveedor, cascadeDelete: true)
                .Index(t => t.FkProveedor);
            
            CreateTable(
                "dbo.DetalleCompras",
                c => new
                    {
                        IdDetalleCompra = c.Int(nullable: false, identity: true),
                        Marca = c.String(nullable: false, maxLength: 10, fixedLength: true),
                        Modelo = c.String(nullable: false, maxLength: 10, fixedLength: true),
                        PrecioUnitario = c.Double(nullable: false),
                        FkCompra = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdDetalleCompra)
                .ForeignKey("dbo.Compras", t => t.FkCompra)
                .Index(t => t.FkCompra);
            
            CreateTable(
                "dbo.Proveedores",
                c => new
                    {
                        IdProveedor = c.Int(nullable: false, identity: true),
                        NombreProveedor = c.String(nullable: false, maxLength: 55, unicode: false),
                        telefono = c.Int(nullable: false),
                        direccion = c.String(nullable: false, maxLength: 55, unicode: false),
                    })
                .PrimaryKey(t => t.IdProveedor);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Compras", "FkProveedor", "dbo.Proveedores");
            DropForeignKey("dbo.DetalleCompras", "FkCompra", "dbo.Compras");
            DropForeignKey("dbo.Modelos", "FkMarca", "dbo.Marcas");
            DropForeignKey("dbo.Autos", "FKModelo", "dbo.Modelos");
            DropForeignKey("dbo.Autos", "FkMarca", "dbo.Marcas");
            DropForeignKey("dbo.HistorialAlquiler", "FkAuto", "dbo.Autos");
            DropForeignKey("dbo.Carrito", "FkAuto", "dbo.Autos");
            DropForeignKey("dbo.Notificaciones", "FkCliente", "dbo.Clientes");
            DropForeignKey("dbo.HistorialAlquiler", "FkCliente", "dbo.Clientes");
            DropForeignKey("dbo.Carrito", "FkCliente", "dbo.Clientes");
            DropIndex("dbo.DetalleCompras", new[] { "FkCompra" });
            DropIndex("dbo.Compras", new[] { "FkProveedor" });
            DropIndex("dbo.Modelos", new[] { "FkMarca" });
            DropIndex("dbo.Notificaciones", new[] { "FkCliente" });
            DropIndex("dbo.HistorialAlquiler", new[] { "FkAuto" });
            DropIndex("dbo.HistorialAlquiler", new[] { "FkCliente" });
            DropIndex("dbo.Carrito", new[] { "FkAuto" });
            DropIndex("dbo.Carrito", new[] { "FkCliente" });
            DropIndex("dbo.Autos", new[] { "FKModelo" });
            DropIndex("dbo.Autos", new[] { "FkMarca" });
            DropTable("dbo.Proveedores");
            DropTable("dbo.DetalleCompras");
            DropTable("dbo.Compras");
            DropTable("dbo.Modelos");
            DropTable("dbo.Marcas");
            DropTable("dbo.Notificaciones");
            DropTable("dbo.HistorialAlquiler");
            DropTable("dbo.Clientes");
            DropTable("dbo.Carrito");
            DropTable("dbo.Autos");
            DropTable("dbo.Administradores");
        }
    }
}
