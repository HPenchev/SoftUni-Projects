using System;
using System.Collections.Generic;
using System.Linq;

public class RemoveOddOccurences
{
    public static void Main()
    {
        List<int> numbers = new List<int>(new int[] {1, 2, 3, 4, 1});
        numbers = RemoveOddOccurencesInList(numbers);
        PrintNumbers(numbers);

        numbers = new List<int>(new int[] { 1, 2, 3, 4, 5, 3, 6, 7, 6, 7, 6 });
        numbers = RemoveOddOccurencesInList(numbers);
        PrintNumbers(numbers);

        numbers = new List<int>(new int[] { 1, 2, 1, 2, 1, 2 });
        numbers = RemoveOddOccurencesInList(numbers);
        PrintNumbers(numbers);

        numbers = new List<int>(new int[] { 3, 7, 3, 3, 4, 3, 4, 3, 7 });
        numbers = RemoveOddOccurencesInList(numbers);
        PrintNumbers(numbers);

        numbers = new List<int>(new int[] { 1, 1 });
        numbers = RemoveOddOccurencesInList(numbers);
        PrintNumbers(numbers);

        Console.ReadLine();
    }

    public static List<int> RemoveOddOccurencesInList(List<int> numbers)
    {
        Dictionary<int, int> numbersCounts = new Dictionary<int, int>();
        foreach (int number in numbers)
        {
            if (numbersCounts.ContainsKey(number))
            {
                numbersCounts[number] = numbersCounts[number] + 1;
            }
            else
            {
                numbersCounts.Add(number, 1);
            }
        }

        foreach (KeyValuePair<int, int> numberCount in numbersCounts)
        {
           if (numberCount.Value % 2 ==1)
           {
               numbers.RemoveAll(num => num == numberCount.Key);
           }
        }

        return numbers;
    }


    private static void PrintNumbers(List<int> numbers)
    {
        foreach (int num in numbers)
        {
            Console.Write(num + " ");
        }	 

        Console.WriteLine();
	}    
}
