namespace BookRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenre12 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Books", "NumberAvailable");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "NumberAvailable", c => c.Byte(nullable: false));
        }
    }
}
