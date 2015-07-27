using System;
using System.Data.Entity;
using System.Linq;

public class NewsDB : DbContext
{
    public NewsDB()
        : base("name=NewsDB")
    {
    }

    public IDbSet<News> News { get; set; }
}