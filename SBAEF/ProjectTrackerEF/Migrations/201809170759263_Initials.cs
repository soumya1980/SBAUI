namespace ProjectTrackerEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initials : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ParentTasks",
                c => new
                    {
                        Parent_ID = c.Int(nullable: false, identity: true),
                        Parent_Task = c.String(),
                    })
                .PrimaryKey(t => t.Parent_ID);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Project_ID = c.Int(nullable: false, identity: true),
                        ProjectDesc = c.String(),
                        StartDt = c.DateTime(nullable: false),
                        EndDt = c.DateTime(nullable: false),
                        Priority = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Project_ID);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        Task_ID = c.Int(nullable: false, identity: true),
                        TaskName = c.String(),
                        StartDt = c.DateTime(nullable: false),
                        EndDt = c.DateTime(nullable: false),
                        Priority = c.Int(nullable: false),
                        Status = c.String(),
                        ParentTask_Parent_ID = c.Int(),
                        Project_Project_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Task_ID)
                .ForeignKey("dbo.ParentTasks", t => t.ParentTask_Parent_ID)
                .ForeignKey("dbo.Projects", t => t.Project_Project_ID)
                .Index(t => t.ParentTask_Parent_ID)
                .Index(t => t.Project_Project_ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        User_ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Employee_ID = c.Int(nullable: false),
                        IsMgr = c.Boolean(nullable: false),
                        Project_Project_ID = c.Int(),
                    })
                .PrimaryKey(t => t.User_ID)
                .ForeignKey("dbo.Projects", t => t.Project_Project_ID)
                .Index(t => t.Project_Project_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Project_Project_ID", "dbo.Projects");
            DropForeignKey("dbo.Tasks", "Project_Project_ID", "dbo.Projects");
            DropForeignKey("dbo.Tasks", "ParentTask_Parent_ID", "dbo.ParentTasks");
            DropIndex("dbo.Users", new[] { "Project_Project_ID" });
            DropIndex("dbo.Tasks", new[] { "Project_Project_ID" });
            DropIndex("dbo.Tasks", new[] { "ParentTask_Parent_ID" });
            DropTable("dbo.Users");
            DropTable("dbo.Tasks");
            DropTable("dbo.Projects");
            DropTable("dbo.ParentTasks");
        }
    }
}
