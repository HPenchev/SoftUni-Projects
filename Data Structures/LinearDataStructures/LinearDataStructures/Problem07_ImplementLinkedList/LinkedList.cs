using System;
using System.Collections.Generic;
using System.Collections;

public class LinkedList<T> : IEnumerable<T>
{
    private class ListNode<T>
    {
        public ListNode(T value)
        {
            this.Value = value;
        }

        public T Value { get; private set; }
        public ListNode<T> NextNode { get; set; }
    }

    private ListNode<T> head;
    private ListNode<T> tail;

    public int Count { get; private set; }

    public void Add(T element)
    {
        ListNode<T> node = new ListNode<T>(element);

        if (this.Count == 0)
        {
            this.head = this.tail = node;
        }
        else
        {
            this.tail.NextNode = node;
            this.tail = node;
        }

        this.Count++;
    }

    public void Remove(int index)
    {
        if (index < 0 || index > this.Count - 1)
        {
            throw new IndexOutOfRangeException("There is no element on index");
        }

        ListNode<T> previousNode = null;
        ListNode<T> node = this.head;
        int counter = 0;

        while(counter < index)
        {
            previousNode = node;
            node = node.NextNode;
            counter++;
        }

        if (previousNode == null)
        {
            this.head = node.NextNode;
        }
        else
        {
            if (this.tail = node.NextNode)
            {
                this.tail = previousNode;
            }

            previousNode.NextNode = node.NextNode;
        }
        
        Count--;
    }

    public IEnumerator<T> GetEnumerator()
    {
        ListNode<T> currentNode = this.head;
        while (currentNode != null)
        {
            yield return currentNode.Value;
            currentNode = currentNode.NextNode;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public int FirstIndexOf(T element)
    {
        int counter = 0;
        foreach (T elementInCollection in this)
        {
            if (elementInCollection.Equals(element))
            {
                return counter;
            }

            counter++;
        }

        return -1;
    }

    public int LastIndexOf(T element)
    {
        int index = -1;
        int counter = 0;

        foreach (T item in this)
        {
            if (item.Equals(element))
            {
                index = counter;
            }

            counter++;
        }

        return index;
    }
}
