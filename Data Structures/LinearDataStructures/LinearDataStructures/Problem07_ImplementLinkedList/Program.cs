using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem08_ImplementLinkedList
{
    class Program
    {
        static void Main()
        {
            LinkedList<int> numbers = new LinkedList<int>();

            for (int i = 0; i < 10; i++)
            {
                numbers.Add(i);
            }
                        
            numbers.Remove(0);

            

            for (int i = 0; i < 10; i++)
            {
                numbers.Add(i);
            }

            foreach (var num in numbers)
            {
                Console.Write(num + " ");
            }

            Console.WriteLine("\n" + numbers.FirstIndexOf(2));
            Console.WriteLine("\n" + numbers.LastIndexOf(6));
            Console.ReadLine();
        }
    }
}
