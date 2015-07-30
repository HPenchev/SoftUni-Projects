using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

class Program
{
    static void Main()
    {
        var migrationStrategy = new MigrateDatabaseToLatestVersion<NewsDB, Configuration>();
        Database.SetInitializer(migrationStrategy);

        var context = new NewsDB();

        var news = context.News.First();

        Console.WriteLine(news.NewsContent);

        Console.WriteLine("Please add news update: ");
        //string input = Console.ReadLine();

        news.NewsContent = Console.ReadLine();
        Console.ReadLine();
        try 
        {
            context.SaveChanges();
        }
        catch(DbUpdateConcurrencyException e)
        {
            Console.WriteLine("A concurrency poblem occuret. It seems the data has been changed. Please try again");
            Main();
        }
        
    }
}