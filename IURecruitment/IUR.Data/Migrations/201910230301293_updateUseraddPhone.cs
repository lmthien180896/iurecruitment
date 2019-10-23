namespace IUR.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateUseraddPhone : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Phone", c => c.String(maxLength: 256));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Phone");
        }
    }
}
