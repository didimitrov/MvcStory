namespace MvcStory.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RatingNDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stories", "ReleaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Stories", "Rating", c => c.Byte(nullable: false));
            AddColumn("dbo.Stories", "Photo", c => c.String());
            AlterColumn("dbo.Stories", "Title", c => c.String(nullable: false, maxLength: 60));
            AlterColumn("dbo.Stories", "Text", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Stories", "Text", c => c.String());
            AlterColumn("dbo.Stories", "Title", c => c.String());
            DropColumn("dbo.Stories", "Photo");
            DropColumn("dbo.Stories", "Rating");
            DropColumn("dbo.Stories", "ReleaseDate");
        }
    }
}
