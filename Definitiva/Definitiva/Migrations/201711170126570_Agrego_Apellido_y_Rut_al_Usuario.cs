namespace Definitiva.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Agrego_Apellido_y_Rut_al_Usuario : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Apellido_User", c => c.String(maxLength: 30));
            AddColumn("dbo.AspNetUsers", "Rut_User", c => c.Int(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Rut_User");
            DropColumn("dbo.AspNetUsers", "Apellido_User");
        }
    }
}
