namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeMembershipTypeId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "MembershipType_Id1", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "MembershipType_Id1" });
            RenameColumn(table: "dbo.Customers", name: "MembershipType_Id1", newName: "MembershipTypeId");
            DropPrimaryKey("dbo.MembershipTypes");
            AddColumn("dbo.MembershipTypes", "MembershipTypeId", c => c.Byte(nullable: false));
            AlterColumn("dbo.Customers", "MembershipTypeId", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.MembershipTypes", "MembershipTypeId");
            CreateIndex("dbo.Customers", "MembershipTypeId");
            AddForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes", "MembershipTypeId", cascadeDelete: true);
            DropColumn("dbo.Customers", "MembershipType_Id");
            DropColumn("dbo.MembershipTypes", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MembershipTypes", "Id", c => c.Short(nullable: false, identity: true));
            AddColumn("dbo.Customers", "MembershipType_Id", c => c.Short(nullable: false));
            DropForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "MembershipTypeId" });
            DropPrimaryKey("dbo.MembershipTypes");
            AlterColumn("dbo.Customers", "MembershipTypeId", c => c.Short());
            DropColumn("dbo.MembershipTypes", "MembershipTypeId");
            AddPrimaryKey("dbo.MembershipTypes", "Id");
            RenameColumn(table: "dbo.Customers", name: "MembershipTypeId", newName: "MembershipType_Id1");
            CreateIndex("dbo.Customers", "MembershipType_Id1");
            AddForeignKey("dbo.Customers", "MembershipType_Id1", "dbo.MembershipTypes", "Id");
        }
    }
}
