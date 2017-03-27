namespace JCMovies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class setMovieGenreRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "genre", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
        }
    }
}
