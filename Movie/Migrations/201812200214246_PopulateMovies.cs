namespace Movie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMovies : DbMigration
    {
        public override void Up()
        {
            Sql("Insert Into MovieModels (Name, ReleaseDate, DateAdded, NumberInStock, GenreId) Values ('Hangover', '10/01/2011', '01/01/2018', 4, 1)");
            Sql("Insert Into MovieModels (Name, ReleaseDate, DateAdded, NumberInStock, GenreId) Values ('Die Hard', '09/07/2013', '01/01/2018', 2, 3)");
            Sql("Insert Into MovieModels (Name, ReleaseDate, DateAdded, NumberInStock, GenreId) Values ('Nightmare on Elm Street', '05/08/1988', '01/01/2018', 5, 2)");
            Sql("Insert Into MovieModels (Name, ReleaseDate, DateAdded, NumberInStock, GenreId) Values ('The Terminator', '10/01/2015', '01/01/2018', 2, 3)");
            Sql("Insert Into MovieModels (Name, ReleaseDate, DateAdded, NumberInStock, GenreId) Values ('Titanic', '12/12/1997', '01/01/2018', 3, 5)");
        }
        
        public override void Down()
        {
        }
    }
}
