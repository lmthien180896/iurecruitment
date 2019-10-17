namespace IUR.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initializeDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicantDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Fullname = c.String(nullable: false, maxLength: 256),
                        Title = c.String(nullable: false, maxLength: 5),
                        DOB = c.DateTime(nullable: false),
                        PlaceOfBirth = c.String(nullable: false, maxLength: 256),
                        Nationality = c.String(nullable: false, maxLength: 256),
                        ContactAddress = c.String(nullable: false, maxLength: 256),
                        PermanentAddress = c.String(nullable: false, maxLength: 256),
                        Phone = c.String(nullable: false, maxLength: 256),
                        Email = c.String(nullable: false, maxLength: 256),
                        IDCard = c.String(nullable: false, maxLength: 256),
                        IssuedDate = c.DateTime(nullable: false),
                        IssuedPlace = c.String(nullable: false, maxLength: 256),
                        Photo = c.String(nullable: false, maxLength: 256),
                        OtherQuestionId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 256),
                        MetaKeyword = c.String(maxLength: 256),
                        MetaDescription = c.String(maxLength: 256),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CareerObjectives",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Objective = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ApplicantDetails", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.OtherQuestions",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Available = c.String(maxLength: 256),
                        IsApplied = c.Boolean(nullable: false),
                        IsInformed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ApplicantDetails", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.Resumes",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        ResumeUrl = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ApplicantDetails", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.ApplicantJobs",
                c => new
                    {
                        ApplicantID = c.Int(nullable: false),
                        JobID = c.Int(nullable: false),
                        ID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ApplicantDetails", t => t.ApplicantID, cascadeDelete: true)
                .ForeignKey("dbo.Jobs", t => t.ApplicantID, cascadeDelete: true)
                .Index(t => t.ApplicantID);
            
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        TimeType = c.String(nullable: false, maxLength: 50),
                        EmployeeType = c.String(nullable: false, maxLength: 50),
                        DepartmentID = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 256),
                        Requirement = c.String(nullable: false, maxLength: 256),
                        Deadline = c.DateTime(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 256),
                        MetaKeyword = c.String(maxLength: 256),
                        MetaDescription = c.String(maxLength: 256),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Departments", t => t.DepartmentID, cascadeDelete: true)
                .Index(t => t.DepartmentID);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 256),
                        MetaKeyword = c.String(maxLength: 256),
                        MetaDescription = c.String(maxLength: 256),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ComputerSkills",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ApplicantID = c.Int(nullable: false),
                        Software = c.String(maxLength: 256),
                        Level = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ApplicantDetails", t => t.ApplicantID, cascadeDelete: true)
                .Index(t => t.ApplicantID);
            
            CreateTable(
                "dbo.EducationBackground",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ApplicantID = c.Int(nullable: false),
                        Level = c.String(maxLength: 256),
                        School = c.String(maxLength: 256),
                        Country = c.String(maxLength: 256),
                        GraduatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ApplicantDetails", t => t.ApplicantID, cascadeDelete: true)
                .Index(t => t.ApplicantID);
            
            CreateTable(
                "dbo.EmploymentHistories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ApplicantID = c.Int(nullable: false),
                        FromDate = c.DateTime(nullable: false),
                        ToDate = c.DateTime(nullable: false),
                        Company = c.String(maxLength: 256),
                        Position = c.String(maxLength: 256),
                        Description = c.String(maxLength: 256),
                        LeavingReason = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Errors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        StackTrace = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Footers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        Content = c.String(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 256),
                        MetaKeyword = c.String(maxLength: 256),
                        MetaDescription = c.String(maxLength: 256),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ApplicantID = c.Int(nullable: false),
                        Certificate = c.String(maxLength: 256),
                        Level = c.String(maxLength: 256),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 256),
                        MetaKeyword = c.String(maxLength: 256),
                        MetaDescription = c.String(maxLength: 256),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ApplicantDetails", t => t.ApplicantID, cascadeDelete: true)
                .Index(t => t.ApplicantID);
            
            CreateTable(
                "dbo.MenuGroups",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        URL = c.String(nullable: false, maxLength: 256),
                        DisplayOrder = c.Int(),
                        ParentId = c.Int(),
                        GroupID = c.Int(nullable: false),
                        Target = c.String(maxLength: 10),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MenuGroups", t => t.GroupID, cascadeDelete: true)
                .Index(t => t.GroupID);
            
            CreateTable(
                "dbo.OtherSkills",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ApplicantID = c.Int(nullable: false),
                        Skill = c.String(maxLength: 256),
                        Reference = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ApplicantDetails", t => t.ApplicantID, cascadeDelete: true)
                .Index(t => t.ApplicantID);
            
            CreateTable(
                "dbo.Pages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        Alias = c.String(nullable: false, maxLength: 256, unicode: false),
                        Content = c.String(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 256),
                        MetaKeyword = c.String(maxLength: 256),
                        MetaDescription = c.String(maxLength: 256),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.IdentityRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.IdentityRoles", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.SupportOnlines",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Department = c.String(maxLength: 50),
                        Skype = c.String(maxLength: 50),
                        Mobile = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50),
                        Yahoo = c.String(maxLength: 50),
                        Facebook = c.String(maxLength: 50),
                        Status = c.Boolean(nullable: false),
                        DisplayOrder = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SystemConfigs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 50, unicode: false),
                        ValueString = c.String(maxLength: 50),
                        ValueInt = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ApplicationUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FullName = c.String(maxLength: 256),
                        Address = c.String(maxLength: 256),
                        BirthDay = c.DateTime(),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.VisitorStatistics",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        VisitedDate = c.DateTime(nullable: false),
                        IPAddress = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRoles", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserLogins", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserClaims", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserRoles", "IdentityRole_Id", "dbo.IdentityRoles");
            DropForeignKey("dbo.OtherSkills", "ApplicantID", "dbo.ApplicantDetails");
            DropForeignKey("dbo.Menus", "GroupID", "dbo.MenuGroups");
            DropForeignKey("dbo.Languages", "ApplicantID", "dbo.ApplicantDetails");
            DropForeignKey("dbo.EducationBackground", "ApplicantID", "dbo.ApplicantDetails");
            DropForeignKey("dbo.ComputerSkills", "ApplicantID", "dbo.ApplicantDetails");
            DropForeignKey("dbo.ApplicantJobs", "ApplicantID", "dbo.Jobs");
            DropForeignKey("dbo.Jobs", "DepartmentID", "dbo.Departments");
            DropForeignKey("dbo.ApplicantJobs", "ApplicantID", "dbo.ApplicantDetails");
            DropForeignKey("dbo.Resumes", "ID", "dbo.ApplicantDetails");
            DropForeignKey("dbo.OtherQuestions", "ID", "dbo.ApplicantDetails");
            DropForeignKey("dbo.CareerObjectives", "ID", "dbo.ApplicantDetails");
            DropIndex("dbo.IdentityUserLogins", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaims", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRoles", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRoles", new[] { "IdentityRole_Id" });
            DropIndex("dbo.OtherSkills", new[] { "ApplicantID" });
            DropIndex("dbo.Menus", new[] { "GroupID" });
            DropIndex("dbo.Languages", new[] { "ApplicantID" });
            DropIndex("dbo.EducationBackground", new[] { "ApplicantID" });
            DropIndex("dbo.ComputerSkills", new[] { "ApplicantID" });
            DropIndex("dbo.Jobs", new[] { "DepartmentID" });
            DropIndex("dbo.ApplicantJobs", new[] { "ApplicantID" });
            DropIndex("dbo.Resumes", new[] { "ID" });
            DropIndex("dbo.OtherQuestions", new[] { "ID" });
            DropIndex("dbo.CareerObjectives", new[] { "ID" });
            DropTable("dbo.VisitorStatistics");
            DropTable("dbo.IdentityUserLogins");
            DropTable("dbo.IdentityUserClaims");
            DropTable("dbo.ApplicationUsers");
            DropTable("dbo.SystemConfigs");
            DropTable("dbo.SupportOnlines");
            DropTable("dbo.IdentityUserRoles");
            DropTable("dbo.IdentityRoles");
            DropTable("dbo.Pages");
            DropTable("dbo.OtherSkills");
            DropTable("dbo.Menus");
            DropTable("dbo.MenuGroups");
            DropTable("dbo.Languages");
            DropTable("dbo.Footers");
            DropTable("dbo.Errors");
            DropTable("dbo.EmploymentHistories");
            DropTable("dbo.EducationBackground");
            DropTable("dbo.ComputerSkills");
            DropTable("dbo.Departments");
            DropTable("dbo.Jobs");
            DropTable("dbo.ApplicantJobs");
            DropTable("dbo.Resumes");
            DropTable("dbo.OtherQuestions");
            DropTable("dbo.CareerObjectives");
            DropTable("dbo.ApplicantDetails");
        }
    }
}
