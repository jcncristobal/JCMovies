namespace JCMovies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateDOB : DbMigration
    {
        public override void Up()
        {
            Sql("update customers set dateofbirth='02/23/1985' where id=2");
        }
        
        public override void Down()
        {
        }
    }
}
