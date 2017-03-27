namespace JCMovies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateMembershipTypeName : DbMigration
    {
        public override void Up()
        {
          Sql("update membershiptypes set name='Pay As You Go' where durationinmonths=0");
          Sql("update membershiptypes set name='Monthly' where durationinmonths=1");
          Sql("update membershiptypes set name='Quarterly' where durationinmonths=3");
          Sql("update membershiptypes set name='Anually' where durationinmonths=12");
            
        }
        
        public override void Down()
        {
        }
    }
}
