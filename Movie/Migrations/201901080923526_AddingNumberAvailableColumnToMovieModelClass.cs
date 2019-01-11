namespace Movie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingNumberAvailableColumnToMovieModelClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MovieModels", "NumberAvailable", c => c.Byte(nullable: false));
            Sql("UPDATE MovieModels SET NumberAvailable = NumberInStock");
        }
        
        public override void Down()
        {
            DropColumn("dbo.MovieModels", "NumberAvailable");
        }
    }
}
