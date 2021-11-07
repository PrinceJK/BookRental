namespace BookRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenre1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "Publisheddate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Books", "ReleaseDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "ReleaseDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Books", "Publisheddate");
        }
    }
}
