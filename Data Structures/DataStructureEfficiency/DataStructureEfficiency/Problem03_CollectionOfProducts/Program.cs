using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace Problem03_CollectionOfProducts
{
    class Program
    {
        static void Main(string[] args)
        {
            CollectionOfProducts products = new CollectionOfProducts();

            var product = new Product()
            {
                Id = 1,
                Title = "Product1",
                Supplier = "Supplier1",
                Price = 1m
            };

            products.Add(product);

            product = new Product()
            {
                Id = 2,
                Title = "Product1",
                Supplier = "Supplier2",
                Price = 2m
            };

            products.Add(product);

            product = new Product()
            {
                Id = 3,
                Title = "Product2",
                Supplier = "Supplier1",
                Price = 3m
            };

            products.Add(product);

            product = new Product()
            {
                Id = 4,
                Title = "Product2",
                Supplier = "Supplier2",
                Price = 4m
            };

            products.Add(product);

            product = new Product()
            {
                Id = 5,
                Title = "Product2",
                Supplier = "Supplier2",
                Price = 5m
            };

            products.Add(product);

            product = new Product()
            {
                Id = 4,
                Title = "Updted product",
                Supplier = "Supplier2",
                Price = 6m
            };

            products.Add(product);
            products.Remove(4);

            var result = products.FindByPriceRange(3m, 4m);
            result = products.FindByTitle("Product2");
            result = products.FindByTitleAndPrice("Product2", 3m);
            result = products.FindByTiteAndPriceRange("Product2", 3m, 5m);
            result = products.FindProductsBySupplierAndPrice("Supplier2", 4m);
            result = products.FindProductsBySupplierAndPriceRange("Supplier2", 3m, 5m);
        }
    }
}
