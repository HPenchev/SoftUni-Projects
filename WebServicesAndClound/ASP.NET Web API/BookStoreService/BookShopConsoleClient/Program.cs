using System.Data.Entity;
using System.Linq;
using System.Threading;

class Program
{
    static void Main()
    {
        var context = new BookShopEntities();
        var count = context.Books.Count();
        System.Console.WriteLine(count);     
    }
}