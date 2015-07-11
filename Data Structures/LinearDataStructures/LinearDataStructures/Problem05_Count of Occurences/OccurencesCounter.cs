using System;
using System.Collections.Generic;

public class OccurencesCounter
{
    public static void Main()
    {
        int[] numbers = { 3, 4, 4, 2, 3, 3, 4, 3, 2 };
        Dictionary<int, int> occurences = CountOccurences(numbers);
        PrintOccurences(occurences);

        numbers = new int[]{ 1000 };
        occurences = CountOccurences(numbers);
        PrintOccurences(occurences);

        numbers = new int[] { 0, 0, 0 };
        occurences = CountOccurences(numbers);
        PrintOccurences(occurences);

        numbers = new int[] { 7, 6, 5, 5, 6 };
        occurences = CountOccurences(numbers);
        PrintOccurences(occurences);

        Console.ReadLine();
    }

    public static Dictionary<int, int> CountOccurences(int[] numbers)
    {
        Dictionary<int, int> numbersOccurences = new Dictionary<int, int>();

        foreach (int number in numbers)
        {
            if (numbersOccurences.ContainsKey(number))
            {
                numbersOccurences[number] = numbersOccurences[number] + 1;
            }
            else
            {
                numbersOccurences.Add(number, 1);
            }
        }

        return numbersOccurences;
    }

    private static void PrintOccurences(Dictionary<int, int> numbersOccurences)
    {
        foreach (KeyValuePair<int, int> numberCount in numbersOccurences)
        {
            Console.WriteLine(numberCount.Key + " -> " + numberCount.Value + " times");
        }

        Console.WriteLine();
    }
}
