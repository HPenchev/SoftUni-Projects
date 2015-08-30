using News.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;

public sealed class Configuration : DbMigrationsConfiguration<NewsEntities>
{
    public Configuration()
    {
        AutomaticMigrationsEnabled = true;
    }

    protected override void Seed(NewsEntities context)
    {
    }
}
