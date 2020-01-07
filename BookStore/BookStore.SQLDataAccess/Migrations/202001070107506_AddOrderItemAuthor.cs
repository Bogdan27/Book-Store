namespace BookStore.SQLDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrderItemAuthor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderItems", "Author", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderItems", "Author");
        }
    }
}
