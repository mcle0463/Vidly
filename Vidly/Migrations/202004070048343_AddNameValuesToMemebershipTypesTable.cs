namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNameValuesToMemebershipTypesTable : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET MembershipTypes.[Name] = 'Pay as you go' WHERE Id = 1");
            Sql("UPDATE MembershipTypes SET MembershipTypes.[Name] = 'Monthly' WHERE Id = 2");
        }
        
        public override void Down()
        {
        }
    }
}
