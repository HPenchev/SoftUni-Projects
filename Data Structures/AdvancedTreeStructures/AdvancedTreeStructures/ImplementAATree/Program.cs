using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementAATree
{
    class Program
    {
        private static Random rnd = new Random();

        static void Main(string[] args)
        {
            AATree<int> tree = new AATree<int>();
            List<int> numbers = new List<int>();

            //tree.Add(59);
            //tree.Add(5);

            for (int i = 0; i < 20; i++)
            {
                tree.PrintToConsole();
                if (i % 3 == 2)
                {
                    int position = rnd.Next(numbers.Count());
                    int num = numbers[position];
                    numbers.RemoveAt(position);
                    tree.Delete(num);
                }

                else
                {
                    int num = rnd.Next(100);
                    if (tree.Add(num))
                    {
                        numbers.Add(num);
                    }
                }
                Console.Clear();
            }            
        }
    }
}
