using System.Collections.Generic;

public class Node<T>
{
    public Node(T value, params Node<T>[] children)
    {
        this.Value = value;
        this.Children = new List<Node<T>>();
        foreach (Node<T> node in children)
	    {
            this.Children.Add(node);
            node.Parent = this;
	    }
    }

    public T Value { get; set; }

    public Node<T> Parent { get; set; }

    public IList<Node<T>> Children { get; set; }
}