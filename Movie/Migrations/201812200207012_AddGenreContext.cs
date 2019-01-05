namespace Movie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenreContext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.MovieModels", "GenreId", c => c.Byte(nullable: false));
            CreateIndex("dbo.MovieModels", "GenreId");
            AddForeignKey("dbo.MovieModels", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MovieModels", "GenreId", "dbo.Genres");
            DropIndex("dbo.MovieModels", new[] { "GenreId" });
            DropColumn("dbo.MovieModels", "GenreId");
            DropTable("dbo.Genres");
        }
    }
}
