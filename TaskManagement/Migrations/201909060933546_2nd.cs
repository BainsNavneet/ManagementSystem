namespace TaskManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2nd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Projects", "Project_Id", "dbo.Projects");
            DropForeignKey("dbo.Projects", "Task_Id", "dbo.Tasks");
            DropForeignKey("dbo.Projects", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Tasks", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Tasks", "ProjectId", "dbo.Projects");
            DropIndex("dbo.Projects", new[] { "Project_Id" });
            DropIndex("dbo.Projects", new[] { "Task_Id" });
            DropIndex("dbo.Projects", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Tasks", new[] { "ProjectId" });
            DropIndex("dbo.Tasks", new[] { "Project_Id" });
            DropIndex("dbo.Tasks", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Tasks", "ProjectId");
            RenameColumn(table: "dbo.Tasks", name: "Project_Id", newName: "ProjectId");
            CreateTable(
                "dbo.ApplicationUserTasks",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        Task_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.Task_Id })
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.Tasks", t => t.Task_Id, cascadeDelete: true)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.Task_Id);
            
            AddColumn("dbo.Projects", "ProjectName", c => c.String());
            AddColumn("dbo.Projects", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.Projects", "Complitiondate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Tasks", "TaskName", c => c.String());
            AddColumn("dbo.Tasks", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tasks", "Percentage", c => c.Int());
            AlterColumn("dbo.Tasks", "ProjectId", c => c.Int());
            CreateIndex("dbo.Tasks", "ProjectId");
            AddForeignKey("dbo.Tasks", "ProjectId", "dbo.Projects", "Id");
            DropColumn("dbo.Projects", "Name");
            DropColumn("dbo.Projects", "Content");
            DropColumn("dbo.Projects", "DateCreated");
            DropColumn("dbo.Projects", "Project_Id");
            DropColumn("dbo.Projects", "Task_Id");
            DropColumn("dbo.Projects", "ApplicationUser_Id");
            DropColumn("dbo.Tasks", "Name");
            DropColumn("dbo.Tasks", "DateCreated");
            DropColumn("dbo.Tasks", "ApplicationUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tasks", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Tasks", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Tasks", "Name", c => c.String());
            AddColumn("dbo.Projects", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Projects", "Task_Id", c => c.Int());
            AddColumn("dbo.Projects", "Project_Id", c => c.Int());
            AddColumn("dbo.Projects", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Projects", "Content", c => c.String());
            AddColumn("dbo.Projects", "Name", c => c.String());
            DropForeignKey("dbo.Tasks", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.ApplicationUserTasks", "Task_Id", "dbo.Tasks");
            DropForeignKey("dbo.ApplicationUserTasks", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ApplicationUserTasks", new[] { "Task_Id" });
            DropIndex("dbo.ApplicationUserTasks", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Tasks", new[] { "ProjectId" });
            AlterColumn("dbo.Tasks", "ProjectId", c => c.Int(nullable: false));
            DropColumn("dbo.Tasks", "Percentage");
            DropColumn("dbo.Tasks", "Status");
            DropColumn("dbo.Tasks", "TaskName");
            DropColumn("dbo.Projects", "Complitiondate");
            DropColumn("dbo.Projects", "Status");
            DropColumn("dbo.Projects", "ProjectName");
            DropTable("dbo.ApplicationUserTasks");
            RenameColumn(table: "dbo.Tasks", name: "ProjectId", newName: "Project_Id");
            AddColumn("dbo.Tasks", "ProjectId", c => c.Int(nullable: false));
            CreateIndex("dbo.Tasks", "ApplicationUser_Id");
            CreateIndex("dbo.Tasks", "Project_Id");
            CreateIndex("dbo.Tasks", "ProjectId");
            CreateIndex("dbo.Projects", "ApplicationUser_Id");
            CreateIndex("dbo.Projects", "Task_Id");
            CreateIndex("dbo.Projects", "Project_Id");
            AddForeignKey("dbo.Tasks", "ProjectId", "dbo.Projects", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Tasks", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Projects", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Projects", "Task_Id", "dbo.Tasks", "Id");
            AddForeignKey("dbo.Projects", "Project_Id", "dbo.Projects", "Id");
        }
    }
}
