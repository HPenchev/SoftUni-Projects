using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsInPriceRange
{
    public class Product
    {
        public Product(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public override bool Equals(object obj)
        {
            var newObject = obj as Product;
            if (newObject == null)
            {
                return false;
            }

            return this.Name == newObject.Name && this.Price == newObject.Price;
        }

        public static bool operator == (Product a, Product b)
        {
            if (System.Object.ReferenceEquals(a, b))
            {
                return true;
            }

            if (((object)a == null) ^ ((object)b == null))
            {
                return false;
            }

            return a.Equals(b);
        }

        public static bool operator !=(Product a, Product b)
        {
            return !(a==b);
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() ^ this.Price.GetHashCode();
        }
    }
}
