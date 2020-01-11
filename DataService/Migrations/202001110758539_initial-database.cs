namespace DataService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialdatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Article",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(maxLength: 200, unicode: false),
                        Title = c.String(nullable: false),
                        Date = c.DateTime(nullable: false, storeType: "date"),
                        TypeId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ArticleType", t => t.TypeId)
                .Index(t => t.TypeId);
            
            CreateTable(
                "dbo.ArticleEmployee",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ArticleId = c.Int(),
                        EmployeeId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Article", t => t.ArticleId)
                .ForeignKey("dbo.Employee", t => t.EmployeeId)
                .Index(t => t.ArticleId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(maxLength: 50, unicode: false),
                        Name = c.String(),
                        RoleId = c.Int(),
                        OrganizationId = c.Int(),
                        IsActive = c.Boolean(nullable: false),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Organization", t => t.OrganizationId)
                .ForeignKey("dbo.Position", t => t.RoleId)
                .Index(t => t.RoleId)
                .Index(t => t.OrganizationId);
            
            CreateTable(
                "dbo.Deduction",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Month = c.Int(),
                        Year = c.Int(),
                        DeductionTypeId = c.Int(),
                        EmployeeId = c.Int(),
                        ArticleTypeId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ArticleType", t => t.ArticleTypeId)
                .ForeignKey("dbo.DeductionType", t => t.DeductionTypeId)
                .ForeignKey("dbo.Employee", t => t.EmployeeId)
                .Index(t => t.DeductionTypeId)
                .Index(t => t.EmployeeId)
                .Index(t => t.ArticleTypeId);
            
            CreateTable(
                "dbo.ArticleType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 200),
                        Code = c.String(maxLength: 10, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ArticlePointType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ArticleTypeId = c.Int(nullable: false),
                        PointTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PointType", t => t.PointTypeId)
                .ForeignKey("dbo.ArticleType", t => t.ArticleTypeId)
                .Index(t => t.ArticleTypeId)
                .Index(t => t.PointTypeId);
            
            CreateTable(
                "dbo.PointType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Code = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Point",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ArticleEmployeeId = c.Int(),
                        Point = c.Int(),
                        Type = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ArticleEmployee", t => t.ArticleEmployeeId)
                .ForeignKey("dbo.PointType", t => t.Type)
                .Index(t => t.ArticleEmployeeId)
                .Index(t => t.Type);
            
            CreateTable(
                "dbo.Criteria",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DisplayName = c.String(),
                        ArticleTypeId = c.Int(),
                        Unit = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ArticleType", t => t.ArticleTypeId)
                .Index(t => t.ArticleTypeId);
            
            CreateTable(
                "dbo.CriteriaValue",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CriteriaId = c.Int(),
                        Value = c.Double(),
                        Unit = c.Int(),
                        ConfigurationId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Configuration", t => t.ConfigurationId)
                .ForeignKey("dbo.Criteria", t => t.CriteriaId)
                .Index(t => t.CriteriaId)
                .Index(t => t.ConfigurationId);
            
            CreateTable(
                "dbo.Configuration",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Month = c.Int(),
                        Year = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DeductionType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(maxLength: 20),
                        Amount = c.Double(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Organization",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsActive = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Position",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 200),
                        Code = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BusinessLog",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Message = c.String(nullable: false),
                        ActorId = c.Int(nullable: false),
                        Type = c.String(),
                        Status = c.String(nullable: false),
                        LoggedOnDate = c.DateTime(nullable: true, defaultValueSql: "getutcdate()"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MenuItem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Level = c.Int(nullable: false),
                        ParentName = c.String(maxLength: 30),
                        Order = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RoleHasMenuItem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleId = c.Int(nullable: false),
                        MenuItemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Role", t => t.RoleId)
                .ForeignKey("dbo.MenuItem", t => t.MenuItemId)
                .Index(t => t.RoleId)
                .Index(t => t.MenuItemId);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 200),
                        Code = c.String(nullable: false, maxLength: 6),
                        Name = c.String(nullable: false, maxLength: 50),
                        RoleId = c.Int(nullable: false),
                        StatusId = c.Int(nullable: false),
                        LastLoginTime = c.DateTime(),
                        CreateDate = c.DateTime(),
                        LastUpdateDate = c.DateTime(),
                        LastUpdateBy = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Role", t => t.RoleId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.SystemLog",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Caller = c.String(),
                        Level = c.String(),
                        Type = c.String(),
                        Message = c.String(),
                        StackTrace = c.String(),
                        InnerException = c.String(),
                        AdditionalInfo = c.String(),
                        LoggedOnDate = c.DateTime(nullable: true, defaultValueSql:"getutcdate()"),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RoleHasMenuItem", "MenuItemId", "dbo.MenuItem");
            DropForeignKey("dbo.User", "RoleId", "dbo.Role");
            DropForeignKey("dbo.RoleHasMenuItem", "RoleId", "dbo.Role");
            DropForeignKey("dbo.Employee", "RoleId", "dbo.Position");
            DropForeignKey("dbo.Employee", "OrganizationId", "dbo.Organization");
            DropForeignKey("dbo.Deduction", "EmployeeId", "dbo.Employee");
            DropForeignKey("dbo.Deduction", "DeductionTypeId", "dbo.DeductionType");
            DropForeignKey("dbo.Deduction", "ArticleTypeId", "dbo.ArticleType");
            DropForeignKey("dbo.CriteriaValue", "CriteriaId", "dbo.Criteria");
            DropForeignKey("dbo.CriteriaValue", "ConfigurationId", "dbo.Configuration");
            DropForeignKey("dbo.Criteria", "ArticleTypeId", "dbo.ArticleType");
            DropForeignKey("dbo.ArticlePointType", "ArticleTypeId", "dbo.ArticleType");
            DropForeignKey("dbo.Point", "Type", "dbo.PointType");
            DropForeignKey("dbo.Point", "ArticleEmployeeId", "dbo.ArticleEmployee");
            DropForeignKey("dbo.ArticlePointType", "PointTypeId", "dbo.PointType");
            DropForeignKey("dbo.Article", "TypeId", "dbo.ArticleType");
            DropForeignKey("dbo.ArticleEmployee", "EmployeeId", "dbo.Employee");
            DropForeignKey("dbo.ArticleEmployee", "ArticleId", "dbo.Article");
            DropIndex("dbo.User", new[] { "RoleId" });
            DropIndex("dbo.RoleHasMenuItem", new[] { "MenuItemId" });
            DropIndex("dbo.RoleHasMenuItem", new[] { "RoleId" });
            DropIndex("dbo.CriteriaValue", new[] { "ConfigurationId" });
            DropIndex("dbo.CriteriaValue", new[] { "CriteriaId" });
            DropIndex("dbo.Criteria", new[] { "ArticleTypeId" });
            DropIndex("dbo.Point", new[] { "Type" });
            DropIndex("dbo.Point", new[] { "ArticleEmployeeId" });
            DropIndex("dbo.ArticlePointType", new[] { "PointTypeId" });
            DropIndex("dbo.ArticlePointType", new[] { "ArticleTypeId" });
            DropIndex("dbo.Deduction", new[] { "ArticleTypeId" });
            DropIndex("dbo.Deduction", new[] { "EmployeeId" });
            DropIndex("dbo.Deduction", new[] { "DeductionTypeId" });
            DropIndex("dbo.Employee", new[] { "OrganizationId" });
            DropIndex("dbo.Employee", new[] { "RoleId" });
            DropIndex("dbo.ArticleEmployee", new[] { "EmployeeId" });
            DropIndex("dbo.ArticleEmployee", new[] { "ArticleId" });
            DropIndex("dbo.Article", new[] { "TypeId" });
            DropTable("dbo.SystemLog");
            DropTable("dbo.User");
            DropTable("dbo.Role");
            DropTable("dbo.RoleHasMenuItem");
            DropTable("dbo.MenuItem");
            DropTable("dbo.BusinessLog");
            DropTable("dbo.Position");
            DropTable("dbo.Organization");
            DropTable("dbo.DeductionType");
            DropTable("dbo.Configuration");
            DropTable("dbo.CriteriaValue");
            DropTable("dbo.Criteria");
            DropTable("dbo.Point");
            DropTable("dbo.PointType");
            DropTable("dbo.ArticlePointType");
            DropTable("dbo.ArticleType");
            DropTable("dbo.Deduction");
            DropTable("dbo.Employee");
            DropTable("dbo.ArticleEmployee");
            DropTable("dbo.Article");
        }
    }
}
