namespace JCMovies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCustomerBirthdate : DbMigration
    {
        public override void Up()
        {
           // Sql("Update customers set Birthdate=Now.adddays(365) where id=1");
        }
        
        public override void Down()
        {
        }
    }
}
