using System;
using System.Collections.Generic;

public class RootFinder
{
    //private static IDictionary<int, Node<int>> nodesByValue = new Dictionary<int, Node<int>>();

    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int m = int.Parse(Console.ReadLine());
        bool[] hasParent = new bool[n];

        int root = -1;
        for (int i = 0; i < m; i++)
        {
            string input = Console.ReadLine();
            string[] inputStringNumbers = input.Split(' ');
            int childNode = int.Parse(inputStringNumbers[1]);
            hasParent[childNode] = true;
        }

        for (int i = 0; i < n; i++)
        {
            if (!hasParent[i])
            {
                if (root != -1)
                {
                    Console.WriteLine("Multiple root nodes");
                    return;
                }

                root = i;
            }
        }

        if (root != -1)
        {
            Console.WriteLine(root);
        }
        else
        {
            Console.WriteLine("No root node");
        }
    }

    //private static Node<int> TakeNodeByValue(int value)
    //{
    //    if (!nodesByValue.ContainsKey(value))
    //    {
    //        nodesByValue.Add(value, new Node<int>(value));
    //    }

    //    return nodesByValue[value];
    //}
}

