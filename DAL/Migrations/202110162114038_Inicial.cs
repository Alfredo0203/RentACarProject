namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Marcas", "LogoMarca", c => c.Binary(nullable: false));
            AlterColumn("dbo.Marcas", "NombreMarca", c => c.String(nullable: false, maxLength: 128, fixedLength: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Marcas", "NombreMarca", c => c.String(nullable: false, maxLength: 55, fixedLength: true));
            DropColumn("dbo.Marcas", "LogoMarca");
        }
    }
}
