using System;

public class LinkedQueue<T>
{
    private class QueueNode<T>
    {
        public QueueNode(T value, QueueNode<T> nextNode = null)
        {
            this.Value = value;
            this.NextNode = nextNode;
        }

        public T Value { get; private set; }
        public QueueNode<T> PreviousNode { get; set; }
        public QueueNode<T> NextNode { get; set; }
    }

    private QueueNode<T> head = null;
    private QueueNode<T> tail = null;

    public int Count { get; private set; }

    public void Enqueue(T element)
    {
        QueueNode<T> newNode = new QueueNode<T>(element);
        newNode.NextNode = this.head;
        if (this.tail == null)
        {
            this.tail = newNode;
        }
        else
        {
            this.head.PreviousNode = newNode;
        }        

        this.head = newNode;
        this.Count++;
    }

    public T Dequeue()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("The queue is empty");
        }

        T result = this.tail.Value;

        this.tail = this.tail.PreviousNode;

        this.Count--;

        return result;
    }

    public T[] ToArray()
    {
        QueueNode<T> node = this.tail;

        T[] array = new T[this.Count];
        int counter = 0;

        while(node != null)
        {
            array[counter] = node.Value;
            node = node.PreviousNode;
            counter++;
        }

        return array;
    }
}