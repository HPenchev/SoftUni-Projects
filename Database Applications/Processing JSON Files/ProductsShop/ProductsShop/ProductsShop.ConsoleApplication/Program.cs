namespace ProductsShop.ConsoleApplication
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using ProductsShop.Data;
    using ProductsShop.Data.Migrations;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System.Xml.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var migrationStrategy = new MigrateDatabaseToLatestVersion<ProductsShopEntities, Configuration>();
            Database.SetInitializer(migrationStrategy);

            var context = new ProductsShopEntities();

            //Query 1 - Products In Range

            //var products = context.Products
            //    .Where(p => p.Buyer == null && p.Price >= 500m && p.Price <= 1000m)
            //    .OrderBy(p => p.Price)
            //    .Select(p => new
            //                {
            //                    p.Name,
            //                    p.Price,
            //                    Seller = (p.Seller.FirstName != null ? p.Seller.FirstName + " " : "") + p.Seller.LastName
            //                });

            //var json = JsonConvert.SerializeObject(products, Formatting.Indented);

            //Console.WriteLine(json);
            //Console.ReadLine();

            //Query 2 - Successfully Sold Products

            //var sellers = context.Users
            //    .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
            //    .OrderBy(u => u.LastName)
            //    .ThenBy(u => u.FirstName)
            //    .Select(u => new
            //            {
            //                u.FirstName,
            //                u.LastName,
            //                ProductsSold = u.ProductsSold
            //                .Where(p => p.Buyer != null)
            //                .Select(p => new
            //                            {
            //                                p.Name,
            //                                p.Price,
            //                                BuyerFirstName = p.Buyer.FirstName != null ? p.Buyer.FirstName : "",
            //                                BuyerLastName = p.Buyer.LastName
            //                            })
            //    });

            //var json = JsonConvert.SerializeObject(sellers, Formatting.Indented);

            //Console.WriteLine(json);
            //Console.ReadLine();

            //Categories By Products Count

            //var categories = context.Categories
            //    .OrderByDescending(c => c.Products.Count())
            //    .Select(c => new
            //                {
            //                    c.Name,
            //                    ProductsCount = c.Products.Count(),
            //                    AveragePrice = c.Products.Average(p => p.Price),
            //                    TotalRevenye = c.Products.Sum(p => p.Price)
            //                });

            //var json = JsonConvert.SerializeObject(categories, Formatting.Indented);

            //Console.WriteLine(json);
            //Console.ReadLine();

            //Query 4 - Users and Products
            //Unfinished

            var sellers = context.Users
                .Where(u => u.ProductsSold.Count() >= 1)
                .OrderByDescending(u => u.ProductsSold.Count())
                .ThenBy(u => u.LastName)
                .Select(u => new
                             {
                                 u.FirstName,
                                 u.LastName,
                                 u.Age,
                                 ProductsSold = u.ProductsSold.Select(p => new
                                                                             {
                                                                                 p.Name,
                                                                                 p.Price
                                                                             })
                             });          
            
            JArray sellersArray = new JArray();

            foreach (var user in sellers)
            {
                JObject userObject = new JObject();

                if (user.FirstName != null)
                {
                    userObject.Add(new JProperty("@first-name", user.FirstName));
                }

                userObject.Add(new JProperty("@last-name", user.LastName));

                if (user.Age != null)
                {
                    userObject.Add(new JProperty("@age", user.Age));
                }

                JObject soldProducts = new JObject();
                soldProducts.Add(new JProperty("@count", user.ProductsSold.Count()));

                JArray products = new JArray();

                foreach (var product in user.ProductsSold)
                {
                    JObject productObject = new JObject();
                    productObject.Add(new JProperty("@price", product.Price));
                    productObject.Add(new JProperty("@name", product.Name));                    
                    products.Add(productObject);
                }

                soldProducts.Add(new JProperty("product", products));

                userObject.Add(new JProperty ("sold-products", soldProducts));

                sellersArray.Add(userObject);
            }

            JObject users = new JObject();
            users.Add(new JProperty("@count", sellers.Count()));
            users.Add(new JProperty("user", sellersArray));

            JObject main = new JObject();
            main.Add(new JProperty("?xml", 
                new JObject(new JProperty("@version", "1.0"), new JProperty("@encoding", "utf-8"))));
            main.Add(new JProperty("users", users));

            var json = JsonConvert.SerializeObject(main, Formatting.Indented);

            XDocument xmlFromJson = JsonConvert.DeserializeXNode(json);

            xmlFromJson.Save("../../../../../sellers.xml");        



            //Console.WriteLine(main);
        }
    }
}