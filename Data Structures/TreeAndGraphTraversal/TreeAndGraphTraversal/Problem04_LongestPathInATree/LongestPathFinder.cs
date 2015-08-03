using System;
using System.Collections.Generic;
using System.Linq;

public class LongestPathFinder
{
    private static Dictionary<int, List<int>> children = new Dictionary<int, List<int>>();
    private static Dictionary<int, int?> parents = new Dictionary<int, int?>();
    
    public static void Main()
    {
        int numberOfNodes = int.Parse(Console.ReadLine());
        int numberOfEdges = int.Parse(Console.ReadLine());        

        for (int i = 0; i < numberOfEdges; i++)
        {
            string[] input = Console.ReadLine().Split(' ');
            int parent = int.Parse(input[0]);
            int child = int.Parse(input[1]);

            if (!children.ContainsKey(parent))
            {
                children[parent] = new List<int>();
            }

            children[parent].Add(child);

            if (!children.ContainsKey(child))
            {
                children[child] = new List<int>();
            }

            parents[child] = parent;
            
            if (!parents.ContainsKey(parent))
            {
                parents[parent] = null;
            }
        }
        
        List<int> leafs = FindLeafs();
        
        int maxDistance = int.MinValue;

        for (int i = 0; i < leafs.Count - 1; i++)
        {
            for (int j = i + 1; j < leafs.Count; j++)
            {
                int distance = FindDistance(leafs[i], leafs[j]);
                if (distance > maxDistance)
                {
                    maxDistance = distance;
                }
            }
        }

        Console.WriteLine(maxDistance);
    }

    private static int FindDistance(int first, int second)
    {
        //if (children[first].Contains(second))
        //{
        //    return first + second;
        //}
        //else
        //{
        //    if (!searchedChildren.ContainsKey(first))
        //    {
        //        searchedChildren[first] = new List<int>();
        //    }

        //    foreach (int num in children[first])
        //    {
        //        if (!searchedChildren[first].Contains(num))
        //        {
        //            searchedChildren[first].Add(num);
        //            return first + FindDistance(num, second, searchedChildren);
        //        }                
        //    }

        //    if (parents[first] != null)
        //    {
        //        if (!searchedChildren.ContainsKey((int)parents[first]))
        //        {
        //            searchedChildren[(int)parents[first]] = new List<int>();
        //        }

        //        searchedChildren[(int)parents[first]].Add(first);
        //    }

        //    return first + FindDistance((int)parents[first], second, searchedChildren);
        //}

        Dictionary<int, int> previousNodes = FindPaths(first, second);

        int sum = second;
        int currentNode = second;

        while(currentNode != first)
        {
            currentNode = previousNodes[currentNode];
            sum += currentNode;
        }

        return sum;
    }

    private static Dictionary<int, int> FindPaths(int first, int second)
    {
        Dictionary<int, int> previousNodes = new Dictionary<int, int>();
        Queue<int> numbers = new Queue<int>();
        HashSet<int> checkedNodes = new HashSet<int>();

        numbers.Enqueue(first);
        bool isFound = false;
        while (numbers.Any())
        {
            int currentNumber = numbers.Dequeue();
            checkedNodes.Add(currentNumber);

            if (parents[currentNumber] != null && !checkedNodes.Contains((int)parents[currentNumber]))
            {
                numbers.Enqueue((int)parents[currentNumber]);
                previousNodes[(int)parents[currentNumber]] = currentNumber;
                if ((int)parents[currentNumber] == second)
                {
                    isFound = true;
                }
            }

            foreach (int number in children[currentNumber])
            {
                if (!checkedNodes.Contains(number))
                {
                    numbers.Enqueue(number);
                    previousNodes[number] = currentNumber;
                    if (number == second)
                    {
                        isFound = true;
                    }
                }
            }

            if (isFound)
            {
                break;
            }
        }

        return previousNodes;
    }

    private static List<int> FindLeafs()
    {
        List<int> leafs = new List<int>();

        foreach (var numbers in children)
        {
            if (numbers.Value.Count == 0)
            {
                leafs.Add(numbers.Key);
            }
        }

        return leafs;
    }    
}