using System;
using System.Collections;
using System.Collections.Generic;

public class ReversedList<T> : IEnumerable<T>
{
    const int DefaultCapacity = 1;

    private T[] elements = new T[DefaultCapacity];

    public int Count { get; private set; }

    public int Capacity
    {
        get
        {
            return this.elements.Length;
        }
    }

    public T this[int index]
    {
        get
        {
            if (index < 0 || index > this.Count - 1)
            {
                throw new IndexOutOfRangeException("Requested index is out of range");
            }

            return this.elements[this.Count - 1 - index];
        }
    }

    public void Add(T element)
    {
        if (this.Count >= this.Capacity)
        {
            this.Growth();
        }

        this.elements[Count] = element;
        this.Count++;
    }

    public void Remove(int index)
    {
        if (index < 0 || index > this.Count - 1)
        {
            throw new IndexOutOfRangeException("Requested index is out of range");
        }

        for (int i = this.Count - index; i < Count; i++)
        {
            this.elements[i - 1] = this.elements[i];
        }

        this.Count--;
    }

    private void Growth()
    {
        T[] newArray = new T[2 * this.Capacity];

        for (int i = 0; i < Capacity; i++)
        {
            newArray[i] = this.elements[i];
        }

        this.elements = newArray;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for(int i = this.Count - 1; i >= 0; i--)
        {
            yield return this.elements[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {        
        return this.GetEnumerator();
    }
}


