using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    private static Dictionary<int, Tree<int>> nodesByValye = new Dictionary<int, Tree<int>>();

    static void Main()
    {
        Console.WriteLine("Please enter nodes'count:");
        int nodesCount = int.Parse(Console.ReadLine());
        Console.WriteLine("Please enter pairs:");

        for (int i = 1; i < nodesCount; i++)
        {
            string[] input = Console.ReadLine().Split(' ');

            int parentValue = int.Parse(input[0]);
            Tree<int> parentTree = GetNodeByValue(parentValue);

            int childValue = int.Parse(input[1]);
            Tree<int> childTree = GetNodeByValue(childValue);

            parentTree.Children.Add(childTree);
            childTree.Parent = parentTree;
        }

        Console.WriteLine("Root: " + FindRootNode().Value);

        IEnumerable<Tree<int>> middleNodes = FindMiddleNodes();
        Console.WriteLine("Middle nodes: ");
        foreach (var node in middleNodes)
        {
            Console.Write(node.Value + " ");
        }

        IEnumerable<Tree<int>> leafNodes = FindLeafNodes();
        Console.WriteLine("Leaf nodes: ");
        foreach (var node in leafNodes)
        {
            Console.Write(node.Value + " ");
        }

        Console.ReadLine();
    }

    public static Tree<int> GetNodeByValue(int value)
    {
        if (!nodesByValye.ContainsKey(value))
        {
            nodesByValye[value] = new Tree<int>(value);
        }

        return nodesByValye[value];
    }

    public static Tree<int> FindRootNode()
    {
        return nodesByValye.Values.FirstOrDefault(n => n.Parent == null);
    }

    public static IEnumerable<Tree<int>> FindLeafNodes()
    {
        return nodesByValye.Values.Where(n => n.Children.Count() == 0).OrderBy(a => a.Value).ToList();
    }

    public static IEnumerable<Tree<int>> FindMiddleNodes()
    {
        return nodesByValye.Values
            .Where(n => n.Children.Count() != 0 && n.Parent != null)
            .OrderBy(a => a.Value)
            .ToList();
    }
}