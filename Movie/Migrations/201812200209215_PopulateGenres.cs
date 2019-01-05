namespace Movie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenres : DbMigration
    {
        public override void Up()
        {
            Sql("Insert Into Genres (Id, Name) Values (1, 'Comedy')");
            Sql("Insert Into Genres (Id, Name) Values (2, 'Horror')");
            Sql("Insert Into Genres (Id, Name) Values (3, 'Action')");
            Sql("Insert Into Genres (Id, Name) Values (4, 'Family')");
            Sql("Insert Into Genres (Id, Name) Values (5, 'Romance')");
        }
        
        public override void Down()
        {
        }
    }
}
