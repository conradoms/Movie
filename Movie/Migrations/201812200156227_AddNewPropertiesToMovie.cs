namespace Movie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewPropertiesToMovie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MovieModels", "ReleaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.MovieModels", "DateAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.MovieModels", "NumberInStock", c => c.Byte(nullable: false));
            AlterColumn("dbo.MovieModels", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MovieModels", "Name", c => c.String());
            DropColumn("dbo.MovieModels", "NumberInStock");
            DropColumn("dbo.MovieModels", "DateAdded");
            DropColumn("dbo.MovieModels", "ReleaseDate");
        }
    }
}
