using System;
using System.Collections.Generic;
using System.Linq;

public class SequenceCounter
{
    public static void Main()
    {
        List<int> numbers = new List<int> { 12, 2, 7, 4, 3, 3, 8 };
        PrintNumbers(FindLongestSequence(numbers));

        numbers = new List<int> { 2, 2, 2, 3, 3, 3 };
        PrintNumbers(FindLongestSequence(numbers));

        numbers = new List<int> { 4, 4, 5, 5, 5 };
        PrintNumbers(FindLongestSequence(numbers));

        numbers = new List<int> { 1, 2, 3 };
        PrintNumbers(FindLongestSequence(numbers));

        numbers = new List<int> { 0 };
        PrintNumbers(FindLongestSequence(numbers));

        Console.ReadLine();
    }
    
    public static List<int> FindLongestSequence(List<int> numbers)
    {
        int longestSequenceLength = 1;
        int longestSequenceStartPosition = 0;
        int length = numbers.Count;
        int currentSequenceLength = 1;
        int currentSequenceStartingPosition = 0;
        int currentNumber = numbers[0];        

        for (int i = 1; i < length; i++)
        {
            if (numbers[i] == currentNumber)
            {
                currentSequenceLength++;
                if (currentSequenceLength > longestSequenceLength)
                {
                    longestSequenceLength = currentSequenceLength;
                    longestSequenceStartPosition = currentSequenceStartingPosition;
                }                               
            }
            else
            {
                currentSequenceStartingPosition = i;
                currentSequenceLength = 1;
                currentNumber = numbers[i];
            }             
        }

        List<int> longestSequence = numbers.GetRange(longestSequenceStartPosition, longestSequenceLength);
        return longestSequence;
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