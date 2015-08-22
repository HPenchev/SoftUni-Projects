
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Wintellect.PowerCollections;
namespace ProductsInPriceRange
{
    public class Program
    {
        public const int MaxPriceInCents = 1000;
        public const int ProductMaxIndex = 10;

        public static Random rnd = new Random();

        static void Main()
        {
            OrderedBag<Product> products = new OrderedBag<Product>(new ProductPriceComparer());

            SeedProducts(products);

            Stopwatch sw = new Stopwatch();

            decimal priceOne = (decimal)rnd.Next(MaxPriceInCents) / 100;
            decimal priceTwo = (decimal)rnd.Next(MaxPriceInCents) / 100;

            var firstProduct = products.Where(p => p.Price >= Math.Min(priceOne, priceTwo)).FirstOrDefault();
            var endProduct = products.Where(p => p.Price <= Math.Max(priceOne, priceTwo)).LastOrDefault();

            sw.Start();


            for (int i = 0; i < 20000; i++)
            {
                
                var productRange = GetProductsInRange(
                    products,
                    firstProduct,
                    endProduct,
                    20);
            }

            sw.Stop();
            Console.WriteLine("Elapsed={0}", sw.Elapsed);
        }

        private static void SeedProducts(OrderedBag<Product> products)
        {
            for (int i = 0; i < 500000; i++)
            {
                string name = "Product" + rnd.Next(ProductMaxIndex);
                decimal price = ((decimal)rnd.Next(MaxPriceInCents)) / 100;
                products.Add(new Product(name, price));
            }
        }

        private static IEnumerable<Product> GetProductsInRange(
            OrderedBag<Product> products,
            Product firstProduct, 
            Product endProduct, 
            int numberOfProducts)
        {
            

            if (firstProduct == null || endProduct == null)
            {
                return null;
            }

            return products.Range(firstProduct, true, endProduct, true).Take(numberOfProducts);
        }
    }
}
