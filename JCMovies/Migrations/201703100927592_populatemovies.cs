namespace JCMovies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populatemovies : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into Movies(name,type,genre,releasedate,DateAdded,Stocks) Values('RedBull','New','Comedy','01/20/2001','02/20/2001',10)");
            Sql("Insert into Movies(name,type,genre,releasedate,DateAdded,Stocks) Values('Benq','Old','Fantasy','02/20/2001','03/20/2001',20)");
            Sql("Insert into Movies(name,type,genre,releasedate,DateAdded,Stocks) Values('Hotwheels','Old','Action','03/20/2001','04/20/2001',30)");
            Sql("Insert into Movies(name,type,genre,releasedate,DateAdded,Stocks) Values('Gundam','New','Drama','04/20/2001','05/20/2001',40)");
        }
        
        public override void Down()
        {
        }
    }
}
