namespace Proyecto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitClean : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cedula = c.String(),
                        Nombre = c.String(),
                        Tipo = c.String(),
                        Correo = c.String(),
                        Telefono = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Facturas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CedulaCliente = c.String(),
                        NombreCliente = c.String(),
                        CodigoProducto = c.String(),
                        NombreProducto = c.String(),
                        FechaFactura = c.String(),
                        CantidadProducto = c.Double(nullable: false),
                        MontoTotal = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Productos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Tipo = c.String(),
                        Promocion = c.String(),
                        Codigo = c.String(),
                        Precio = c.Double(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        FechaRegistro = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Estado = c.String(),
                        Contrasena = c.String(),
                        Genero = c.String(),
                        Cedula = c.String(),
                        FechaRegistro = c.String(),
                        NombreUsuario = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Usuario");
            DropTable("dbo.Productos");
            DropTable("dbo.Facturas");
            DropTable("dbo.Clientes");
        }
    }
}
