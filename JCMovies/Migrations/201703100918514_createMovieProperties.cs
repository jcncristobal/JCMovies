namespace JCMovies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createMovieProperties : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        type = c.String(),
                        genre = c.String(),
                        ReleaseDate = c.DateTime(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                        Stocks = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Movies");
        }
    }
}
