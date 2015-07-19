using System;

public class LinkedStack<T>
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

    private ListNode<T> head = null;

    public int Count { get; private set; }

    public void Push(T element)
    {
        ListNode<T> newElement = new ListNode<T>(element);
        newElement.NextNode = this.head;
        this.head = newElement;
        this.Count++;
    }

    public T Pop()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("The stack is empty");
        }

        T result = this.head.Value;
        this.head = this.head.NextNode;
        this.Count--;

        return result;
    }

    public T[] ToArray()
    {
        T[] array = new T[this.Count];

        ListNode<T> node = this.head;
        int counter = this.Count - 1;

        while(node != null)
        {
            array[counter] = node.Value;
            node = node.NextNode;
            counter--;
        }

        return array;
    }
}