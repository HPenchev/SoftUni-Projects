using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main()
    {
        Console.WriteLine("How many bits to you want to have in the array?");
        int numberOfBits = int.Parse(Console.ReadLine());
        BitArray array = new BitArray(numberOfBits);
        while(true)
        {
            Console.WriteLine("Would you like to read a bit? Y/N");
            string checker = Console.ReadLine();
            if(checker=="Y"||checker=="y")
            {
                Console.WriteLine("Please enter the position of the bit you want to read");
                int bit = int.Parse(Console.ReadLine());
                Console.WriteLine(array[bit]);
            }
            Console.WriteLine("Would you like to change a bit? Y/N");
            checker = Console.ReadLine();
            if (checker == "Y" || checker == "y")
            {
                Console.WriteLine("Please enter the position of the bit you want to change");
                int bit = int.Parse(Console.ReadLine());
                Console.WriteLine("Please enter the new value of the bit");
                int value = int.Parse(Console.ReadLine());
                array[bit] = value;
            }

            Console.WriteLine("Would you like to read the final number? Y/N");
            checker = Console.ReadLine();
            if (checker == "Y" || checker == "y") break;
        }
        Console.WriteLine(array.ToString());

    }
}

