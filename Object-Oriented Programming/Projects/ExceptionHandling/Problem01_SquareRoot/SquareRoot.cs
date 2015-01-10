using System;


class SquareRoot
{
    static void Main()
    {
        int number = 0;
        try
        {
            number = int.Parse(Console.ReadLine());
            if(number<0) throw new ArgumentException();
        }
        catch (System.SystemException)
        {
            Console.WriteLine("Invalid number");
            throw;
        }
        finally
        {
            Console.WriteLine("Good bye");
        }
        Console.WriteLine(Math.Sqrt(number));
    }
}

