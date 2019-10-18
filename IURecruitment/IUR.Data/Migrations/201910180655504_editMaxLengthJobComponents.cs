namespace IUR.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editMaxLengthJobComponents : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Jobs", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Jobs", "Requirement", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Jobs", "Requirement", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.Jobs", "Description", c => c.String(nullable: false, maxLength: 256));
        }
    }
}
