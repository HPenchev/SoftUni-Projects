namespace ProductsShop.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Xml.Linq;
    using PoductsShop.Models;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using Newtonsoft.Json.Linq;
    using System.IO;

    public sealed class Configuration : DbMigrationsConfiguration<ProductsShop.Data.ProductsShopEntities>
    {
        private static Random rnd = new Random();

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "ProductsShop.Data.ProductsShopEntities";
        }

        protected override void Seed(ProductsShop.Data.ProductsShopEntities context)
        {
            if (!context.Users.Any())
            {
                SeedUsers(context);
            }

            if (!context.Products.Any())
            {
                SeedProducts(context);
            }

            if (!context.Categories.Any())
            {
                SeedCategories(context);
            }
        }

        private static void SeedUsers(ProductsShop.Data.ProductsShopEntities context)
        {
            XDocument xmlDoc = XDocument.Load("../../../../../users.xml");

            var users = xmlDoc.Descendants("user");

            foreach (var user in users)
            {
                User databaseUser = new User()
                {
                    FirstName = user.Attribute("first-name") != null ? user.Attribute("first-name").Value : null,
                    LastName = user.Attribute("last-name").Value,
                    Age = user.Attribute("age") != null ? int.Parse(user.Attribute("age").Value) : (int?)null
                };

                context.Users.Add(databaseUser);
            }

            context.SaveChanges();
        }

        private static void SeedProducts(ProductsShop.Data.ProductsShopEntities context)
        {
            string productsPath = "../../../../../products.json";
            string json = null;

            using (StreamReader r = new StreamReader(productsPath))
            {
                json = r.ReadToEnd();                
            }

            var products = JsonConvert.DeserializeObject<HashSet<Product>>(json);

            List<int> userIds = context.Users.Select(u => u.Id).ToList();

            foreach (var product in products)
            {
                int sellerId = userIds[rnd.Next(userIds.Count)];
                product.Seller = context.Users.Find(sellerId);

                int buyerIdPosition = rnd.Next((int)(userIds.Count * 1.7));

                if (buyerIdPosition >= userIds.Count || userIds[buyerIdPosition] == sellerId)
                {
                    product.Buyer = null;
                }
                else
                {
                    int buyerId = userIds[buyerIdPosition];
                    product.Buyer = context.Users.Find(buyerId);
                }

                context.Products.Add(product);
            }

            context.SaveChanges();
        }

        private static void SeedCategories(ProductsShop.Data.ProductsShopEntities context)
        {
            string categoriesPath = "../../../../../categories.json";
            string json = null;

            using (StreamReader r = new StreamReader(categoriesPath))
            {
                json = r.ReadToEnd();
            }

            HashSet<Category> categories = JsonConvert.DeserializeObject<HashSet<Category>>(json);

            List<int> productIds = context.Products.Select(p => p.Id).ToList();

            foreach (var category in categories)
            {                
                int numberOfProdcts = rnd.Next(productIds.Count + 1);

                for (int i = 0; i < numberOfProdcts; i++)
                {
                    int productId = productIds[rnd.Next(productIds.Count)];
                    category.Products.Add(context.Products.Find(productId));
                }

                context.Categories.Add(category);               
            }

            context.SaveChanges();
        }
    }
}