namespace JCMovies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addnewdob : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "DateOfBirth", c => c.DateTime());
            DropColumn("dbo.Customers", "BirthDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "BirthDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Customers", "DateOfBirth");
        }
    }
}
