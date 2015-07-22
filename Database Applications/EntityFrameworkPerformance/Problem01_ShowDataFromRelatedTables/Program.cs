using System;
using System.Data.Entity;
using System.Linq;
using Problem01_ShowDataFromRelatedTables;

class Program
{
    static void Main()
    {
        var context = new AdsEntities();
        //TakeAddsWithoutInclude(context);
        TakeAddsWithInclude(context);
        Console.ReadLine();
    }

    public static void TakeAddsWithoutInclude(AdsEntities context)
    {
        var ads = context.Ads;

        foreach (var ad in ads)
        {
            Console.WriteLine(ad.Title);
            Console.WriteLine("Status: " + ad.AdStatus.Status);
            Console.WriteLine("Category: ");
            if (ad.CategoryId != null)
            {
                Console.Write(ad.Category.Name);
            }

            Console.WriteLine("Town: ");
            if (ad.TownId != null)
            {
                Console.WriteLine(ad.Town.Name);
            }

            Console.WriteLine("User: " + ad.AspNetUser.Name);
            Console.WriteLine();
        }        
    }

    public static void TakeAddsWithInclude(AdsEntities context)
    {
        var ads = context.Ads
            .Include(a => a.AdStatus)
            .Include(a => a.Category)
            .Include(a => a.Town)
            .Include(a => a.AspNetUser);

        foreach (var ad in ads)
        {
            Console.WriteLine(ad.Title);
            Console.WriteLine("Status: " + ad.AdStatus.Status);
            Console.WriteLine("Category: ");
            if (ad.CategoryId != null)
            {
                Console.Write(ad.Category.Name);
            }

            Console.WriteLine("Town: ");
            if (ad.TownId != null)
            {
                Console.WriteLine(ad.Town.Name);
            }

            Console.WriteLine("User: " + ad.AspNetUser.Name);
            Console.WriteLine();
        }
    }
}