namespace JCMovies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMembershipTypeName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MembershipTypes", "name");
        }
    }
}
