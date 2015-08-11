using System;

public class Program
{
    private static Random rnd = new Random();

    static void Main()
    {
        System.Collections.Generic.List<int> numbers = new System.Collections.Generic.List<int>();

        for (int i = 0; i < 10; i++)
        {
            numbers.Add(i);
        }

        SortedSet<int> set = new SortedSet<int>();

        //while (numbers.Count > 0)
        //{
        //    int position = rnd.Next(numbers.Count);
        //    int num = numbers[position];
        //    set.Add(num);
        //    numbers.RemoveAt(position);
        //}

        set.Add(17);
        //set.Add(9);
        //set.Add(19);
        //set.Add(6);
        //set.Add(12);
        //set.Add(25);

        set.Remove(17);

        foreach (int num in set)
        {
            Console.WriteLine(num + " ");
        }

        Console.ReadLine();

        
    }
}