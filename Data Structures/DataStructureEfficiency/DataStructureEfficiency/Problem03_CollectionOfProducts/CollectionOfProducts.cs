using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace Problem03_CollectionOfProducts
{
    class CollectionOfProducts
    {
        private Dictionary<int, Product> productsById = new Dictionary<int, Product>();
        private OrderedDictionary<decimal, HashSet<Product>> productsByPrice =
            new OrderedDictionary<decimal, HashSet<Product>>();
        private Dictionary<string, SortedSet<Product>> productsByTitle =
            new Dictionary<string, SortedSet<Product>>();
        private Dictionary<string, SortedSet<Product>> productsByTitleAndPrice =
            new Dictionary<string, SortedSet<Product>>();
        private Dictionary<string, OrderedDictionary<decimal, HashSet<Product>>>
            productsByTitleAndPriceRange =
            new Dictionary<string, OrderedDictionary<decimal, HashSet<Product>>>();
        private Dictionary<string, SortedSet<Product>> productsBySupplierAndPrice =
            new Dictionary<string, SortedSet<Product>>();
        private Dictionary<string, OrderedDictionary<decimal, HashSet<Product>>>
            productsBySupplierAndPriceRange =
            new Dictionary<string, OrderedDictionary<decimal, HashSet<Product>>>();

        public void Add(Product product)
        {
            if (this.productsById.ContainsKey(product.Id))
            {
                this.Remove(product.Id);
            }

            this.productsById.Add(product.Id, product);

            if (!this.productsByPrice.ContainsKey(product.Price))
            {
                this.productsByPrice.Add(product.Price, new HashSet<Product>());
            }

            this.productsByPrice[product.Price].Add(product);

            if (!this.productsByTitle.ContainsKey(product.Title))
            {
                this.productsByTitle.Add(product.Title, new SortedSet<Product>());
            }

            this.productsByTitle[product.Title].Add(product);

            string titleAndPrice = CombineKeys(product.Title, product.Price.ToString());
            if (!this.productsByTitleAndPrice.ContainsKey(titleAndPrice))
            {
                this.productsByTitleAndPrice.Add(titleAndPrice, new SortedSet<Product>());
            }

            this.productsByTitleAndPrice[titleAndPrice].Add(product);

            if (!this.productsByTitleAndPriceRange.ContainsKey(product.Title))
            {
                this.productsByTitleAndPriceRange.Add(product.Title,
                    new OrderedDictionary<decimal, HashSet<Product>>());
            }

            var productsByPrice = this.productsByTitleAndPriceRange[product.Title];
            if (!productsByPrice.ContainsKey(product.Price))
            {
                productsByPrice.Add(product.Price, new HashSet<Product>());
            }

            productsByPrice[product.Price].Add(product);

            var pricesInRange = this.productsByTitleAndPriceRange[product.Title];
            pricesInRange[product.Price].Remove(product);

            string supplierAndPrice = CombineKeys(product.Supplier, product.Price.ToString());
            if (!this.productsBySupplierAndPrice.ContainsKey(supplierAndPrice))
            {
                this.productsBySupplierAndPrice.Add(supplierAndPrice, new SortedSet<Product>());
            }

            this.productsBySupplierAndPrice[supplierAndPrice].Add(product);

            if (!this.productsBySupplierAndPriceRange.ContainsKey(product.Supplier))
            {
                this.productsBySupplierAndPriceRange.Add(product.Supplier,
                    new OrderedDictionary<decimal, HashSet<Product>>());
            }

            var pricesInRangeBySupplier = this.productsBySupplierAndPriceRange[product.Supplier];
            if (!pricesInRangeBySupplier.ContainsKey(product.Price))
            {
                pricesInRangeBySupplier.Add(product.Price, new HashSet<Product>());
            }

            pricesInRangeBySupplier[product.Price].Add(product);

        }

        public bool Remove(int id)
        {
            if (!this.productsById.ContainsKey(id))
            {
                return false;
            }

            var product = this.productsById[id];

            this.productsById.Remove(id);

            this.productsByPrice[product.Price].Remove(product);

            this.productsByTitle[product.Title].Remove(product);

            string titleAndPrice = CombineKeys(product.Title, product.Price.ToString());
            this.productsByTitleAndPrice[titleAndPrice].Remove(product);

            var productsInPriceRange = this.productsByTitleAndPriceRange[product.Title];
            productsInPriceRange[product.Price].Remove(product);

            string supplierAndPrice = CombineKeys(product.Supplier, product.Price.ToString());
            this.productsBySupplierAndPrice.Remove(supplierAndPrice);

            productsInPriceRange = this.productsBySupplierAndPriceRange[product.Supplier];
            productsInPriceRange[product.Price].Remove(product);

            return true;
        }

        public ICollection<Product> FindByPriceRange(decimal startPrice, decimal endPrice)
        {
            var productSets = this.productsByPrice.Range(startPrice, true, endPrice, true).Values;
            var orderedProducts = new List<Product>();

            foreach (var set in productSets)
            {
                orderedProducts.AddRange(set);
            }

            orderedProducts.Sort();

            return orderedProducts;
        }

        public ICollection<Product> FindByTitle(string title)
        {
            if (this.productsByTitle.ContainsKey(title))
            {
                return this.productsByTitle[title];
            }

            return new List<Product>();
        }

        public ICollection<Product> FindByTitleAndPrice(string title, decimal price)
        {
            string titleAndPrice = CombineKeys(title, price.ToString());
            if (this.productsByTitleAndPrice.ContainsKey(titleAndPrice))
            {
                return this.productsByTitleAndPrice[titleAndPrice];
            }

            return new List<Product>();
        }

        public ICollection<Product> FindByTiteAndPriceRange(
            string title,
            decimal startPrice,
            decimal endPrice)
        {

            if (!this.productsByTitleAndPriceRange.ContainsKey(title))
            {
                return new List<Product>();
            }

            var productsByTitle = this.productsByTitleAndPriceRange[title]
                .Range(startPrice, true, endPrice, true).Values;
            List<Product> products = new List<Product>();

            foreach (var productSet in productsByTitle)
            {
                products.AddRange(productSet);
            }

            products.Sort();

            return products;
        }

        public ICollection<Product> FindProductsBySupplierAndPrice(string supplier, decimal price)
        {
            string supplierAndPrice = CombineKeys(supplier, price.ToString());
            if (this.productsBySupplierAndPrice.ContainsKey(supplierAndPrice))
            {
                return this.productsBySupplierAndPrice[supplierAndPrice];
            }

            return new List<Product>();
        }

        public ICollection<Product> FindProductsBySupplierAndPriceRange(
            string supplier,
            decimal startPrice,
            decimal endPrice)
        {
            if (!this.productsBySupplierAndPriceRange.ContainsKey(supplier))
            {
                return new List<Product>();
            }

            var productsBySupplier = this.productsBySupplierAndPriceRange[supplier]
                .Range(startPrice, true, endPrice, true).Values;
            List<Product> products = new List<Product>();

            foreach (var productSet in productsBySupplier)
            {
                products.AddRange(productSet);
            }

            products.Sort();

            return products;
        }

        private static string CombineKeys(string first, string second)
        {
            return first + "|" + second;
        }
    }
}
