using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        var context = new NewsDB();

        var news = context.News.First();

        Console.WriteLine(news.NewsContent);

        Console.WriteLine("Please add news update: ");
        string input = Console.ReadLine();

        news.NewsContent = input;
        context.SaveChanges();
    }
}