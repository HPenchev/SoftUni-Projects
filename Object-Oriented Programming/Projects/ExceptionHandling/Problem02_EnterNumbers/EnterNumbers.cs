using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main()
    {
        int lowestNumber = 1;
        for (int i = 0; i < 10; i++)
		{   
            int number;
		    try 
	        {	        
		        number = ReadNumber(lowestNumber, 91+i);   
	        }
	        catch (System.SystemException)
            {
		        Console.WriteLine("Please try again:");
                i--;
                continue;
            }
            lowestNumber = number;
		}
    }
    static int ReadNumber(int start, int end)
    {
        int number;
        try
        {
            number = int.Parse(Console.ReadLine());
            if (number < start || number > end) throw new ArgumentOutOfRangeException();
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid format");
            throw;
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Number out of range. Please enter a number between {0} and {1}", start, end);
            throw;
        }
        return number;
    }
}

