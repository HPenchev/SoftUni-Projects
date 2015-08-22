using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Globalization;
using System.IO;
using System.Linq;

public sealed class Configuration : DbMigrationsConfiguration<BookShopEntities>
{
    private static Random random = new Random();

    public Configuration()
    {
        AutomaticMigrationsEnabled = true;
        ContextKey = "BookShopEntities";
    }

    //Paths of seeding files are hardcoded. You can move Seed Data to C:// or update seed data paths
    protected override void Seed(BookShopEntities context)
    {
        if (!context.Authors.Any())
        {
            SeedAuthors(context);
            context.SaveChanges();
        }

        if (!context.Categories.Any())
        {
            SeedCategories(context);
            context.SaveChanges();
        }

        if (!context.Books.Any())
        {
            SeedBooks(context);
            context.SaveChanges();
        }
    }

    private void SeedAuthors(BookShopEntities context)
    {
        using (var reader = new StreamReader("C://Seed Data//authors.txt"))
        {
            var line = reader.ReadLine();
            line = reader.ReadLine();
            while (line != null)
            {
                var data = line.Split(new[] { ' ' });
                string firstName = null;
                string lastName = null;
                if (data.Length > 1)
                {
                    firstName = data[0];
                    lastName = data[1];
                }
                else
                {
                    lastName = data[0];
                }

                context.Authors.Add(new Author()
                {
                    FirstName = firstName,
                    LastName = lastName
                });

                line = reader.ReadLine();
            }
        }
    }

    private void SeedCategories(BookShopEntities context)
    {
        using (var reader = new StreamReader("C://Seed Data//categories.txt"))
        {
            var line = reader.ReadLine();
            line = reader.ReadLine();
            while (line != null)
            {
                context.Categories.Add(new Category()
                {
                    Name = line
                });

                line = reader.ReadLine();
            }
        }
    }

    private void SeedBooks(BookShopEntities context)
    {
        int[] authors = context.Authors.Select(a => a.Id).ToArray();

        //int count = authors.Count;

        using (var reader = new StreamReader("C://Seed Data//books.txt"))
        {
            var line = reader.ReadLine();
            line = reader.ReadLine();
            while (line != null)
            {
                var data = line.Split(new[] { ' ' }, 6);
                var authorIndex = random.Next(0, authors.Length);
                var author = authors[authorIndex];
                var edition = (EditionType)int.Parse(data[0]);
                var releaseDate = DateTime.ParseExact(data[1], "d/M/yyyy", CultureInfo.InvariantCulture);
                var copies = int.Parse(data[2]);
                var price = decimal.Parse(data[3]);
                var ageRestriction = (AgeRestriction)int.Parse(data[4]);
                var title = data[5];

                context.Books.Add(new Book()
                {
                    Author = context.Authors.Find(author),
                    Edition = edition,
                    ReleaseDate = releaseDate,
                    Copies = copies,
                    Price = price,
                    Title = title,
                    AgeRestriction = ageRestriction
                });

                line = reader.ReadLine();
            }
        }

    }
}