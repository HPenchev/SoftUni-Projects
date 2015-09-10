using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem02_ImplementBiDictionary
{
    class BiDictionary<K1, K2, T>
    {
        private Dictionary<K1, List<T>> valuesByFirstKey = 
            new Dictionary<K1, List<T>>();
        private Dictionary<K2, List<T>> valuesBySecondKey = 
            new Dictionary<K2, List<T>>();
        private Dictionary<Tuple<K1, K2>, List<T>> valuesByBothKeys = 
            new Dictionary<Tuple<K1, K2>, List<T>>();

        public void Add(K1 key1, K2 key2, T value)
        {
            var tuple = new Tuple<K1, K2>(key1, key2);
            if (!this.valuesByFirstKey.ContainsKey(key1))
            {
                this.valuesByFirstKey.Add(key1, new List<T>());                
            }

            if (!this.valuesBySecondKey.ContainsKey(key2))
            {
                this.valuesBySecondKey.Add(key2, new List<T>());
            }

            if (!this.valuesByBothKeys.ContainsKey(tuple))
            {
                this.valuesByBothKeys.Add(tuple, new List<T>());
            }

            this.valuesByFirstKey[key1].Add(value);
            this.valuesBySecondKey[key2].Add(value);
            this.valuesByBothKeys[tuple].Add(value);
        }

        public IEnumerable<T> Find (K1 key1, K2 key2)
        {
            Tuple <K1, K2> tuple = new Tuple<K1, K2>(key1, key2);
            if (this.valuesByBothKeys.ContainsKey(tuple))
            {
                return this.valuesByBothKeys[tuple];
            }
            else
            {
                return new List<T>();
            }
        }

        public IEnumerable<T> FindByKey1(K1 key)
        {
            if (this.valuesByFirstKey.ContainsKey(key))
            {
                return this.valuesByFirstKey[key];
            }
            else
            {
                return new List<T>();
            }
        }

        public IEnumerable<T> FindByKey2(K2 key)
        {
            if (this.valuesBySecondKey.ContainsKey(key))
            {
                return this.valuesBySecondKey[key];
            }
            else
            {
                return new List<T>();
            }
        }

        public bool Remove(K1 key1, K2 key2)
        {
            Tuple<K1, K2> tuple = new Tuple<K1,K2>(key1, key2);

            if (!this.valuesByBothKeys.ContainsKey(tuple))
            {
                return false;
            }

            var elements = this.valuesByBothKeys[tuple];

            this.valuesByBothKeys.Remove(tuple);
            foreach (T element in elements)
            {
                this.valuesByFirstKey[key1].Remove(element);
                this.valuesBySecondKey[key2].Remove(element);
            }

            return true;
        }

        private class Tuple<K1, K2>
        {
            public Tuple(K1 key1, K2 key2)
            {
                this.Key1 = key1;
                this.Key2 = key2;
            }

            public K1 Key1 { get; set; }

            public K2 Key2 { get; set; }
            
            public static bool operator ==(Tuple<K1, K2> a, Tuple<K1, K2> b)
            {
                if (System.Object.ReferenceEquals(a, b))
                {
                    return true;
                }
               
                if (((object)a == null) || ((object)b == null))
                {
                    return false;
                }

                return (a.Key1.Equals(b.Key1)) &&
                    (a.Key2.Equals(b.Key2));
            }

            public static bool operator !=(Tuple<K1, K2> a, Tuple<K1, K2> b)
            {
                return !(a == b);
            }


            public override bool Equals(System.Object obj)
            {
                if (obj == null)
                {
                    return false;
                }

                Tuple<K1, K2> otherTuple = obj as Tuple<K1, K2>;
                if (otherTuple == null)
                {
                    return false;
                }

                return (this.Key1.Equals(otherTuple.Key1)) &&
                    (this.Key2.Equals(otherTuple.Key2));
            }

            public override int GetHashCode()
            {
                return this.Key1.GetHashCode() ^ this.Key2.GetHashCode();
            }
        }
    }
}