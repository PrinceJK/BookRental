namespace BookRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id, Name) VALUES (1, 'Fiction')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (2, 'Nonfiction')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (3, 'Drama')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (4, 'Poetry')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (5, 'Folktale')");
        }
        
        public override void Down()
        {
        }
    }
}
