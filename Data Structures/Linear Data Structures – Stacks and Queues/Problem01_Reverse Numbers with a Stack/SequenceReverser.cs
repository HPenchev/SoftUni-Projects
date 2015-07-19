using System;
using System.Collections.Generic;


class SequenceReverser
{
    static void Main()
    {
        string input = Console.ReadLine();
        string[] inputNumbers = null;

        if (!String.IsNullOrEmpty(input))
        {
            inputNumbers = input.Split(' ');
        }
        else
        {
            inputNumbers = new string[0];
        }

        Stack<int> numbers = new Stack<int>();

        foreach (string number in inputNumbers)
        {
            numbers.Push(int.Parse(number));
        }


        foreach (int number in numbers)
        {
            Console.Write(number + " ");
        }

        Console.ReadLine();
    }
}