namespace JCMovies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newrental : DbMigration
    {
        public override void Up()
        {
           
            
            CreateTable(
                "dbo.Rentals",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DateRented = c.DateTime(nullable: false),
                        DateReturned = c.DateTime(),
                        Customer_id = c.Int(nullable: false),
                        Movie_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Customers", t => t.Customer_id, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.Movie_ID, cascadeDelete: true)
                .Index(t => t.Customer_id)
                .Index(t => t.Movie_ID);
            
           
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Rentals", "Movie_ID", "dbo.Movies");
            DropForeignKey("dbo.Rentals", "Customer_id", "dbo.Customers");
            DropForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Rentals", new[] { "Movie_ID" });
            DropIndex("dbo.Rentals", new[] { "Customer_id" });
            DropIndex("dbo.Customers", new[] { "MembershipTypeId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Rentals");
            DropTable("dbo.Movies");
            DropTable("dbo.MembershipTypes");
            DropTable("dbo.Customers");
        }
    }
}
