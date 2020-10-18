namespace ICA1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstone : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Branch_tbl",
                c => new
                    {
                        BranchNO = c.String(nullable: false, maxLength: 128),
                        Street = c.String(),
                        City = c.String(),
                        Postcode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BranchNO);
            
            CreateTable(
                "dbo.Owner_tbl",
                c => new
                    {
                        OwnerNo = c.String(nullable: false, maxLength: 128),
                        Fname = c.String(),
                        Lname = c.String(),
                        Address = c.String(),
                        TelNo = c.String(),
                    })
                .PrimaryKey(t => t.OwnerNo);
            
            CreateTable(
                "dbo.Rent_tbl",
                c => new
                    {
                        PropertyNO = c.String(nullable: false, maxLength: 128),
                        Street = c.String(),
                        City = c.String(),
                        Ptype = c.String(),
                        Rooms = c.Int(nullable: false),
                        RefOwnerNo = c.String(maxLength: 128),
                        RefStaffNo = c.String(maxLength: 128),
                        RefBranchNo = c.String(maxLength: 128),
                        rent1 = c.String(),
                    })
                .PrimaryKey(t => t.PropertyNO)
                .ForeignKey("dbo.Branch_tbl", t => t.RefBranchNo)
                .ForeignKey("dbo.Owner_tbl", t => t.RefOwnerNo)
                .ForeignKey("dbo.staff_tbl", t => t.RefStaffNo)
                .Index(t => t.RefOwnerNo)
                .Index(t => t.RefStaffNo)
                .Index(t => t.RefBranchNo);
            
            CreateTable(
                "dbo.staff_tbl",
                c => new
                    {
                        StaffNO = c.String(nullable: false, maxLength: 128),
                        Fname = c.String(),
                        Lname = c.String(),
                        Position = c.String(),
                        DOB = c.DateTime(nullable: false, storeType: "date"),
                        Salary = c.Double(nullable: false),
                        BranchNoRef = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.StaffNO)
                .ForeignKey("dbo.Branch_tbl", t => t.BranchNoRef)
                .Index(t => t.BranchNoRef);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rent_tbl", "RefStaffNo", "dbo.staff_tbl");
            DropForeignKey("dbo.staff_tbl", "BranchNoRef", "dbo.Branch_tbl");
            DropForeignKey("dbo.Rent_tbl", "RefOwnerNo", "dbo.Owner_tbl");
            DropForeignKey("dbo.Rent_tbl", "RefBranchNo", "dbo.Branch_tbl");
            DropIndex("dbo.staff_tbl", new[] { "BranchNoRef" });
            DropIndex("dbo.Rent_tbl", new[] { "RefBranchNo" });
            DropIndex("dbo.Rent_tbl", new[] { "RefStaffNo" });
            DropIndex("dbo.Rent_tbl", new[] { "RefOwnerNo" });
            DropTable("dbo.staff_tbl");
            DropTable("dbo.Rent_tbl");
            DropTable("dbo.Owner_tbl");
            DropTable("dbo.Branch_tbl");
        }
    }
}
