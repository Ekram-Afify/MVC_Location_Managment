namespace LocationManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.City",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CityName = c.String(nullable: false),
                        CountryID = c.Int(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Country", t => t.CountryID)
                .Index(t => t.CountryID);
            
            CreateTable(
                "dbo.Country",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CountryName = c.String(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.City", "CountryID", "dbo.Country");
            DropIndex("dbo.City", new[] { "CountryID" });
            DropTable("dbo.Country");
            DropTable("dbo.City");
        }
    }
}
