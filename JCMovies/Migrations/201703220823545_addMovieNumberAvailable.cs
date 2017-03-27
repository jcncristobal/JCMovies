namespace JCMovies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMovieNumberAvailable : DbMigration
    {
        public override void Up()
        {
            Sql("Alter table movies add NumberAvailable INT");
            Sql("Update movies set NumberAvailable = Stocks");
        }
        
        public override void Down()
        {
        }
    }
}
