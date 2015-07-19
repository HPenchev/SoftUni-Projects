using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int index = 0;
        Queue<int> numbers = new Queue<int>(new int[] { n });
        int currentNumber;

        while (index < 50)
        {
            currentNumber = numbers.Dequeue();

            numbers.Enqueue(currentNumber + 1);
            numbers.Enqueue(2 * currentNumber + 1);
            numbers.Enqueue(currentNumber + 2);

            Console.Write(currentNumber + " ");
            index++;
        }

        Console.ReadLine();
    }
}