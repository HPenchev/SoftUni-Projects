using System;
using System.Collections.Generic;

public class LongestDanceFinder
{
    private static Dictionary<int, List<int>> friendships = new Dictionary<int, List<int>>();
    static int longestPathLength = 0;
    static int? longestPathEnd = null;

    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());
        
        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split(' ');
            int parentNode = int.Parse(input[0]);
            int childNode = int.Parse(input[1]);

            if (!friendships.ContainsKey(parentNode))
            {
                friendships[parentNode] = new List<int>();
            }

            if (!friendships.ContainsKey(childNode))
            {
                friendships[childNode] = new List<int>();
            }

            friendships[parentNode].Add(childNode);
            friendships[childNode].Add(parentNode);
        }

        FindLongestPathEnd(null, k, 0);

        LinkedList<int> longestPath = ReturnLongestPath(k, (int)longestPathEnd, new LinkedList<int>());

        Console.WriteLine("Longest sequence length: " + longestPathLength);
        foreach (int number in longestPath)
        {
            Console.Write(number + " -> ");
        }
    }

    private static void FindLongestPathEnd(int? currentNodeParent, int currentNode, int currentLength)
    {
        currentLength += 1;
        if (currentLength > longestPathLength)
        {
            longestPathLength = currentLength;
            longestPathEnd = currentNode;
        }

        foreach(int number in friendships[currentNode])
        {
            if (number == currentNodeParent)
            {
                continue;
            }

            FindLongestPathEnd(currentNode, number, currentLength + 1);
        }
    }

    private static LinkedList<int> ReturnLongestPath(int currentNumber, int parent, LinkedList<int> path)
    {
        path.AddLast(currentNumber);

        foreach(int num in friendships[currentNumber])
        {
            if (num != parent)
            {
                path = ReturnLongestPath(num, currentNumber, path);
            }
        }

            
        if (path.Last.Value != (int)longestPathEnd)
        {
            path.RemoveLast();
        }

        return path;
    }
}