namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenreType : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO GenreTypes (Id,Genre) VALUES (1,'Comedy')");
            Sql("INSERT INTO GenreTypes (Id,Genre) VALUES (2,'Action')");
            Sql("INSERT INTO GenreTypes (Id,Genre) VALUES (3,'Family')");
            Sql("INSERT INTO GenreTypes (Id,Genre) VALUES (4,'Adventure')");
            Sql("INSERT INTO GenreTypes (Id,Genre) VALUES (5,'Romance')");
        }
        
        public override void Down()
        {
        }
    }
}
