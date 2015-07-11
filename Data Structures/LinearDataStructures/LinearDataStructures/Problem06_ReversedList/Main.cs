using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReversedList
{
    public class MainClass
    {
        public static void Main()
        {
            ReversedList<int> numbers = new ReversedList<int>();
            for (int i = 0; i < 10; i++)
            {
                numbers.Add(i);
            }

            foreach (int num in numbers)
            {
                Console.Write(num + " ");
            }


            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    numbers.Remove(i);
                }
            }

            Console.Write("\n" + numbers[0]);

            Console.ReadLine();
        }
    }
}
