namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeMembershipType : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "MembershipTypeId" });
            RenameColumn(table: "dbo.Customers", name: "MembershipTypeId", newName: "MembershipType_Id1");
            AddColumn("dbo.Customers", "MembershipType_Id", c => c.Short(nullable: false));
            AlterColumn("dbo.Customers", "MembershipType_Id1", c => c.Short());
            CreateIndex("dbo.Customers", "MembershipType_Id1");
            AddForeignKey("dbo.Customers", "MembershipType_Id1", "dbo.MembershipTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "MembershipType_Id1", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "MembershipType_Id1" });
            AlterColumn("dbo.Customers", "MembershipType_Id1", c => c.Short(nullable: false));
            DropColumn("dbo.Customers", "MembershipType_Id");
            RenameColumn(table: "dbo.Customers", name: "MembershipType_Id1", newName: "MembershipTypeId");
            CreateIndex("dbo.Customers", "MembershipTypeId");
            AddForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes", "Id", cascadeDelete: true);
        }
    }
}
