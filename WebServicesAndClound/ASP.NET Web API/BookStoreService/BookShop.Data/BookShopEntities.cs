using System;
using System.Data.Entity;
using System.Linq;
using Microsoft.AspNet.Identity.EntityFramework;
using BooksShopModels;

public class BookShopEntities : IdentityDbContext<ApplicationUser> 
{
    public BookShopEntities()
        : base("name=BookShopEntities")
    {
        var migrationStrategy = new MigrateDatabaseToLatestVersion<BookShopEntities, Configuration>();
        Database.SetInitializer(migrationStrategy);
    }

    public IDbSet<Book> Books { get; set; }

    public IDbSet<Author> Authors { get; set; }

    public IDbSet<Category> Categories { get; set; }

    public IDbSet<Purchase> Purchases { get; set; }

    public static BookShopEntities Create()
    {
        return new BookShopEntities();
    }
}