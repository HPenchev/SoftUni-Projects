using System;

public class ArrayStack<T>
{
    private const int InitialSize = 16;

    private T[] elements;

    public ArrayStack(int capacity = InitialSize)
    {
        this.elements = new T[capacity];
    }

    public int Count { get; private set; }

    public void Push(T element)
    {
        if (this.Count >= this.elements.Length)
        {
            this.Grow();
        }

        this.elements[this.Count] = element;
        this.Count++;
    }

    public T Pop()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("The stack is empty");
        }

        this.Count--;
        return this.elements[this.Count];
    }

    public T[] ToArray()
    {
        T[] array = new T[this.Count];

        Array.Copy(this.elements, array, this.Count);

        return array;
    }

    private void Grow()
    {
        T[] newArray = new T[2 * this.elements.Length];

        Array.Copy(this.elements, newArray, this.elements.Length);

        this.elements = newArray;
    }
}