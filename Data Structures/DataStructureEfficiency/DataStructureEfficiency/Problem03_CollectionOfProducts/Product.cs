using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem03_CollectionOfProducts
{
    class Product : IComparable
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Supplier { get; set; }

        public decimal Price { get; set; }

        public static bool operator ==(Product a, Product b)
        {
            if (System.Object.ReferenceEquals(a, b))
            {
                return true;
            }

            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }

            return a.Id == b.Id;
        }

        public static bool operator !=(Product a, Product b)
        {
            return !(a == b);
        }

        public override bool Equals(System.Object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Product otherProduct = obj as Product;
            if (otherProduct == null)
            {
                return false;
            }

            return this.Id == otherProduct.Id;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }

            Product otherProduct = obj as Product;

            if (otherProduct != null)
            {
                return this.Id.CompareTo(otherProduct.Id);
            }
            else
            {
                throw new ArgumentException("Object is not a Produt");
            }
        }
    }
}
