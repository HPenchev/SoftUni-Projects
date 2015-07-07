using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Please enter a sequence of numbers separated by space. Press ENTER when done");
        string numbersInput = Console.ReadLine();
        string[] numbersAsStrings = numbersInput.Split(' ');
        List<int> numbers = new List<int>();

        foreach (string num in numbersAsStrings)
        {
            numbers.Add(int.Parse(num));
        }

        Console.WriteLine(numbers.Sum());
        Console.WriteLine(numbers.Average());
        Console.ReadLine();
    }
}