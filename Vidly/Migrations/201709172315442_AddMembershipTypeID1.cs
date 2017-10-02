namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMembershipTypeID1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "MembershipType_Id1", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "MembershipType_Id1" });
            RenameColumn(table: "dbo.Customers", name: "MembershipType_Id1", newName: "MembershipTypeId");
            AlterColumn("dbo.Customers", "MembershipTypeId", c => c.Short(nullable: true));
            CreateIndex("dbo.Customers", "MembershipTypeId");
            AddForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes", "Id", cascadeDelete: true);
            DropColumn("dbo.Customers", "MembershipType_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "MembershipType_Id", c => c.Short(nullable: false));
            DropForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "MembershipTypeId" });
            AlterColumn("dbo.Customers", "MembershipTypeId", c => c.Short());
            RenameColumn(table: "dbo.Customers", name: "MembershipTypeId", newName: "MembershipType_Id1");
            CreateIndex("dbo.Customers", "MembershipType_Id1");
            AddForeignKey("dbo.Customers", "MembershipType_Id1", "dbo.MembershipTypes", "Id");
        }
    }
}
