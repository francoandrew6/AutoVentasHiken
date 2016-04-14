namespace AutoVentasHiken.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DB_AutoHiken : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Archivoes",
                c => new
                    {
                        id_Archivo = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        contentType = c.String(),
                        tipo = c.Int(nullable: false),
                        contenido = c.Binary(),
                        id_Vehiculo = c.Int(),
                        id_Usuario = c.Int(),
                    })
                .PrimaryKey(t => t.id_Archivo)
                .ForeignKey("dbo.Usuarios", t => t.id_Usuario)
                .ForeignKey("dbo.Vehiculoes", t => t.id_Vehiculo)
                .Index(t => t.id_Vehiculo)
                .Index(t => t.id_Usuario);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        id_Usuario = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false),
                        correo = c.String(nullable: false),
                        telefono = c.Int(nullable: false),
                        direccion = c.String(nullable: false),
                        contrasena = c.String(nullable: false),
                        compararContraseña = c.String(nullable: false),
                        id_Rol = c.Int(),
                    })
                .PrimaryKey(t => t.id_Usuario)
                .ForeignKey("dbo.Rols", t => t.id_Rol)
                .Index(t => t.id_Rol);
            
            CreateTable(
                "dbo.Compras",
                c => new
                    {
                        id_Compra = c.Int(nullable: false, identity: true),
                        id_Vehiculo = c.Int(nullable: false),
                        id_Usuario = c.Int(nullable: false),
                        fechaCompra = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id_Compra)
                .ForeignKey("dbo.Usuarios", t => t.id_Usuario, cascadeDelete: true)
                .ForeignKey("dbo.Vehiculoes", t => t.id_Vehiculo, cascadeDelete: true)
                .Index(t => t.id_Vehiculo)
                .Index(t => t.id_Usuario);
            
            CreateTable(
                "dbo.Vehiculoes",
                c => new
                    {
                        id_Vehiculo = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false),
                        precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        descripcion = c.String(),
                        cantidad = c.String(nullable: false),
                        id_Combustible = c.Int(nullable: false),
                        id_Marca = c.Int(nullable: false),
                        id_TipoVehiculo = c.Int(nullable: false),
                        id_StockVehiculo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_Vehiculo)
                .ForeignKey("dbo.Combustibles", t => t.id_Combustible, cascadeDelete: true)
                .ForeignKey("dbo.Marcas", t => t.id_Marca, cascadeDelete: true)
                .ForeignKey("dbo.StockVehiculoes", t => t.id_StockVehiculo, cascadeDelete: true)
                .ForeignKey("dbo.TipoVehiculoes", t => t.id_TipoVehiculo, cascadeDelete: true)
                .Index(t => t.id_Combustible)
                .Index(t => t.id_Marca)
                .Index(t => t.id_TipoVehiculo)
                .Index(t => t.id_StockVehiculo);
            
            CreateTable(
                "dbo.Combustibles",
                c => new
                    {
                        id_Combustible = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        descripcion = c.String(),
                    })
                .PrimaryKey(t => t.id_Combustible);
            
            CreateTable(
                "dbo.Marcas",
                c => new
                    {
                        id_Marca = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        descripcion = c.String(),
                    })
                .PrimaryKey(t => t.id_Marca);
            
            CreateTable(
                "dbo.StockVehiculoes",
                c => new
                    {
                        id_StockVehiculo = c.Int(nullable: false, identity: true),
                        modelo = c.String(),
                        disponible = c.String(),
                    })
                .PrimaryKey(t => t.id_StockVehiculo);
            
            CreateTable(
                "dbo.TipoVehiculoes",
                c => new
                    {
                        id_TipoVehiculo = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        descripcion = c.String(),
                    })
                .PrimaryKey(t => t.id_TipoVehiculo);
            
            CreateTable(
                "dbo.Rols",
                c => new
                    {
                        id_Rol = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        descripcion = c.String(),
                    })
                .PrimaryKey(t => t.id_Rol);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Usuarios", "id_Rol", "dbo.Rols");
            DropForeignKey("dbo.Vehiculoes", "id_TipoVehiculo", "dbo.TipoVehiculoes");
            DropForeignKey("dbo.Vehiculoes", "id_StockVehiculo", "dbo.StockVehiculoes");
            DropForeignKey("dbo.Vehiculoes", "id_Marca", "dbo.Marcas");
            DropForeignKey("dbo.Compras", "id_Vehiculo", "dbo.Vehiculoes");
            DropForeignKey("dbo.Vehiculoes", "id_Combustible", "dbo.Combustibles");
            DropForeignKey("dbo.Archivoes", "id_Vehiculo", "dbo.Vehiculoes");
            DropForeignKey("dbo.Compras", "id_Usuario", "dbo.Usuarios");
            DropForeignKey("dbo.Archivoes", "id_Usuario", "dbo.Usuarios");
            DropIndex("dbo.Vehiculoes", new[] { "id_StockVehiculo" });
            DropIndex("dbo.Vehiculoes", new[] { "id_TipoVehiculo" });
            DropIndex("dbo.Vehiculoes", new[] { "id_Marca" });
            DropIndex("dbo.Vehiculoes", new[] { "id_Combustible" });
            DropIndex("dbo.Compras", new[] { "id_Usuario" });
            DropIndex("dbo.Compras", new[] { "id_Vehiculo" });
            DropIndex("dbo.Usuarios", new[] { "id_Rol" });
            DropIndex("dbo.Archivoes", new[] { "id_Usuario" });
            DropIndex("dbo.Archivoes", new[] { "id_Vehiculo" });
            DropTable("dbo.Rols");
            DropTable("dbo.TipoVehiculoes");
            DropTable("dbo.StockVehiculoes");
            DropTable("dbo.Marcas");
            DropTable("dbo.Combustibles");
            DropTable("dbo.Vehiculoes");
            DropTable("dbo.Compras");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Archivoes");
        }
    }
}
