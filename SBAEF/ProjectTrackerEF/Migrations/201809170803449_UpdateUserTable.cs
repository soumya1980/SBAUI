namespace ProjectTrackerEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUserTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Task_Task_ID", c => c.Int());
            CreateIndex("dbo.Users", "Task_Task_ID");
            AddForeignKey("dbo.Users", "Task_Task_ID", "dbo.Tasks", "Task_ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Task_Task_ID", "dbo.Tasks");
            DropIndex("dbo.Users", new[] { "Task_Task_ID" });
            DropColumn("dbo.Users", "Task_Task_ID");
        }
    }
}
