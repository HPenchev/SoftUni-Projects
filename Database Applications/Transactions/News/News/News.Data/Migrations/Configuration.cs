using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

internal sealed class Configuration : DbMigrationsConfiguration<NewsDB>
{
    public Configuration()
    {
        AutomaticMigrationsEnabled = true;
    }

    protected override void Seed(NewsDB context)
    {
        if (context.News.Any())
        {
            return;
        }

        for (int i = 0; i < 20; i++)
        {
            var news = new News();
            news.NewsContent = "some content" + i;
            context.News.Add(news);
        }
    }
}