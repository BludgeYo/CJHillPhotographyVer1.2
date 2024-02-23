namespace CJHillPhotography.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmigrationInitalState : DbMigration
    {
        public override void Up()
        {

            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CartItems", "ImageId", "dbo.Images");
            DropIndex("dbo.CartItems", new[] { "ImageId" });
            DropTable("dbo.Users");
            DropTable("dbo.Images");
            DropTable("dbo.CartItems");
        }
    }
}
