namespace Karma.Services.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Badges",
                c => new
                    {
                        BadgeId = c.Long(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Description = c.String(storeType: "ntext"),
                        PublishState = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BadgeId)
                .Index(t => t.PublishState);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        Name = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.UserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.IdentityUser_Id)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.UserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.Users", t => t.IdentityUser_Id)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.Quests",
                c => new
                    {
                        QuestId = c.Long(nullable: false),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "ServiceTableColumn",
                                    new AnnotationValues(oldValue: null, newValue: "CreatedAt")
                                },
                            }),
                        Deleted = c.Boolean(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "ServiceTableColumn",
                                    new AnnotationValues(oldValue: null, newValue: "Deleted")
                                },
                            }),
                        Id = c.String(maxLength: 36,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "ServiceTableColumn",
                                    new AnnotationValues(oldValue: null, newValue: "Id")
                                },
                            }),
                        UpdatedAt = c.DateTimeOffset(precision: 7,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "ServiceTableColumn",
                                    new AnnotationValues(oldValue: null, newValue: "UpdatedAt")
                                },
                            }),
                        Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion",
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "ServiceTableColumn",
                                    new AnnotationValues(oldValue: null, newValue: "Version")
                                },
                            }),
                        Title = c.String(nullable: false),
                        Descriptions = c.String(storeType: "ntext"),
                        CreatorId = c.String(nullable: false, maxLength: 128),
                        ActorId = c.String(nullable: false, maxLength: 128),
                        DueDate = c.DateTimeOffset(nullable: false, precision: 7),
                        QuestState = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.QuestId)
                .ForeignKey("dbo.Users", t => t.ActorId)
                .ForeignKey("dbo.Users", t => t.CreatorId)
                .Index(t => t.CreatedAt)
                .Index(t => t.Id)
                .Index(t => t.CreatorId)
                .Index(t => t.ActorId)
                .Index(t => t.QuestState);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.IdentityUser_Id)
                .Index(t => t.RoleId)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.BadgeUsers",
                c => new
                    {
                        Badge_BadgeId = c.Long(nullable: false),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Badge_BadgeId, t.User_Id })
                .ForeignKey("dbo.Badges", t => t.Badge_BadgeId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.Badge_BadgeId)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRoles", "IdentityUser_Id", "dbo.Users");
            DropForeignKey("dbo.UserLogins", "IdentityUser_Id", "dbo.Users");
            DropForeignKey("dbo.UserClaims", "IdentityUser_Id", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.BadgeUsers", "User_Id", "dbo.Users");
            DropForeignKey("dbo.BadgeUsers", "Badge_BadgeId", "dbo.Badges");
            DropForeignKey("dbo.Quests", "CreatorId", "dbo.Users");
            DropForeignKey("dbo.Quests", "ActorId", "dbo.Users");
            DropIndex("dbo.BadgeUsers", new[] { "User_Id" });
            DropIndex("dbo.BadgeUsers", new[] { "Badge_BadgeId" });
            DropIndex("dbo.Roles", "RoleNameIndex");
            DropIndex("dbo.UserRoles", new[] { "IdentityUser_Id" });
            DropIndex("dbo.UserRoles", new[] { "RoleId" });
            DropIndex("dbo.Quests", new[] { "QuestState" });
            DropIndex("dbo.Quests", new[] { "ActorId" });
            DropIndex("dbo.Quests", new[] { "CreatorId" });
            DropIndex("dbo.Quests", new[] { "Id" });
            DropIndex("dbo.Quests", new[] { "CreatedAt" });
            DropIndex("dbo.UserLogins", new[] { "IdentityUser_Id" });
            DropIndex("dbo.UserClaims", new[] { "IdentityUser_Id" });
            DropIndex("dbo.Users", "UserNameIndex");
            DropIndex("dbo.Badges", new[] { "PublishState" });
            DropTable("dbo.BadgeUsers");
            DropTable("dbo.Roles");
            DropTable("dbo.UserRoles");
            DropTable("dbo.Quests",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "CreatedAt",
                        new Dictionary<string, object>
                        {
                            { "ServiceTableColumn", "CreatedAt" },
                        }
                    },
                    {
                        "Deleted",
                        new Dictionary<string, object>
                        {
                            { "ServiceTableColumn", "Deleted" },
                        }
                    },
                    {
                        "Id",
                        new Dictionary<string, object>
                        {
                            { "ServiceTableColumn", "Id" },
                        }
                    },
                    {
                        "UpdatedAt",
                        new Dictionary<string, object>
                        {
                            { "ServiceTableColumn", "UpdatedAt" },
                        }
                    },
                    {
                        "Version",
                        new Dictionary<string, object>
                        {
                            { "ServiceTableColumn", "Version" },
                        }
                    },
                });
            DropTable("dbo.UserLogins");
            DropTable("dbo.UserClaims");
            DropTable("dbo.Users");
            DropTable("dbo.Badges");
        }
    }
}
