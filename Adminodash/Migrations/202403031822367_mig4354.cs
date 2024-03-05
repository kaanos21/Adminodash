namespace Adminodash.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig4354 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PageVisits",
                c => new
                    {
                        PageId = c.Int(nullable: false, identity: true),
                        PageName = c.String(),
                        PageViews = c.Int(nullable: false),
                        PageValue = c.Int(nullable: false),
                        BounceRate = c.Double(nullable: false),
                        PageStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PageId);
            
            CreateTable(
                "dbo.ProjectCategories",
                c => new
                    {
                        ProjectCategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.ProjectCategoryId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        ProjectName = c.String(),
                        ProjectDescription = c.String(),
                        ProjectCategoryId = c.Int(nullable: false),
                        ProjectStatusId = c.Int(nullable: false),
                        ProjectProgress = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectId)
                .ForeignKey("dbo.ProjectCategories", t => t.ProjectCategoryId, cascadeDelete: true)
                .ForeignKey("dbo.ProjectStatus", t => t.ProjectStatusId, cascadeDelete: true)
                .Index(t => t.ProjectCategoryId)
                .Index(t => t.ProjectStatusId);
            
            CreateTable(
                "dbo.ProjectStatus",
                c => new
                    {
                        ProjectStatusId = c.Int(nullable: false, identity: true),
                        ProjectStatusName = c.String(),
                    })
                .PrimaryKey(t => t.ProjectStatusId);
            
            CreateTable(
                "dbo.StatusWorkers",
                c => new
                    {
                        StatusWorkerId = c.Int(nullable: false, identity: true),
                        StatusActivity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StatusWorkerId);
            
            CreateTable(
                "dbo.Workers",
                c => new
                    {
                        WorkerId = c.Int(nullable: false, identity: true),
                        WorkerNameSurname = c.String(),
                        StatusWorkerId = c.String(),
                        WorkerSalary = c.String(),
                        WorkerDescription = c.String(),
                        statusworker_StatusWorkerId = c.Int(),
                    })
                .PrimaryKey(t => t.WorkerId)
                .ForeignKey("dbo.StatusWorkers", t => t.statusworker_StatusWorkerId)
                .Index(t => t.statusworker_StatusWorkerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Workers", "statusworker_StatusWorkerId", "dbo.StatusWorkers");
            DropForeignKey("dbo.Projects", "ProjectStatusId", "dbo.ProjectStatus");
            DropForeignKey("dbo.Projects", "ProjectCategoryId", "dbo.ProjectCategories");
            DropIndex("dbo.Workers", new[] { "statusworker_StatusWorkerId" });
            DropIndex("dbo.Projects", new[] { "ProjectStatusId" });
            DropIndex("dbo.Projects", new[] { "ProjectCategoryId" });
            DropTable("dbo.Workers");
            DropTable("dbo.StatusWorkers");
            DropTable("dbo.ProjectStatus");
            DropTable("dbo.Projects");
            DropTable("dbo.ProjectCategories");
            DropTable("dbo.PageVisits");
        }
    }
}
