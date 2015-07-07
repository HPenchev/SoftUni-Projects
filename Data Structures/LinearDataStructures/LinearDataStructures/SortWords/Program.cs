using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Please enter a sequence of strings separated by space. Press ENTER when ready");
        string stringsInput = Console.ReadLine();
        List<string> strings = stringsInput.Split(' ').ToList();
        strings.Sort();
        foreach (string word in strings)
        {
            Console.Write(word + " ");
        }

        Console.ReadLine();
    }
}