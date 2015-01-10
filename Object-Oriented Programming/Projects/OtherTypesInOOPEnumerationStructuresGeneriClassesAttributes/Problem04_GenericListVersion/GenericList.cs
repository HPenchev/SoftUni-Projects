using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Version(1, 0)]
class GenericList<T>
{
    const int DefaultCapacity = 16;
    private T[] elements;
    private int count = 0;
    public GenericList(int capacity = DefaultCapacity)
    {
        this.elements = new T[capacity];
    }
    public int Count
    {
        get
        {
            return this.count;
        }
        private set
        {
            this.count = value;
        }
        
    }
    public T this[int index]
    {
        get
        {
            if(index<0||index>=count)
            {
                throw new ArgumentOutOfRangeException ("Invalid index");
            }
            T result = elements[index];
            return result;
        }
        set
        {
            elements[index] = value;
        }
    }
    public void Add(T element)
    {
        if (this.count>=this.elements.Length)
        {
            IncreaseCapacity();
        }
        this.elements[count] = element;
        this.count++;
    }
    public void RemoveAt(int index)
    {
        if (index<0 || index >= this.count)
        {
            throw new IndexOutOfRangeException("Invalid position");
        }
        for (int i = index; i < count-1; i++)
        {
            elements[i] = elements[i + 1];
        }
        this.count--;
    }
    public void Insert(int index, T element)
    {
        if (index < 0 || index > this.count)
        {
            throw new IndexOutOfRangeException("Invalid position");
        }
        if (this.count >= this.elements.Length)
        {
            IncreaseCapacity();
        }
        for (int i = count; i > index; i--)
        {
            elements[i] = elements[i -1];
        }
        elements[index] = element;
        this.count++;
    }
    
    public void Clear()
    {
        this.count = 0;
    }
    public int IndexOf(T value, int startPositin = 0, int lenght = 0)
    {
        if (lenght == 0)
        {
            lenght = this.count - startPositin;
        }
        if (lenght + startPositin > this.count) throw new IndexOutOfRangeException("Index out of range");
        for (int i = startPositin; i < startPositin+lenght; i++)
        {
            if (elements[i].Equals(value)) return i;

        }
        return -1;
    }
    public bool Contains(T value)
    {
        for (int i = 0; i < count; i++)
        {
            if (elements[i].Equals(value)) return true;
        }
        return false;
    }
    public override string ToString()
    {
        string output = "";
        for (int i = 0; i < count; i++)
        {
            output += elements[i] + " ";
            
        }
        return string.Format(output);
    }
    private void IncreaseCapacity()
    {
        T[] temp = new T[2*count];
        for (int i = 0; i < this.count; i++)
        {
            temp[i] = this.elements[i];
           
        }
        this.elements = temp;
    }
    public static T Min<T>(GenericList<T> elements)
    where T : IComparable<T>
    {
        int minPosition = 0;
        for (int i = 1; i < elements.Count; i++)
        {
            if (elements[i].CompareTo(elements[minPosition]) <= 0)
            {
                minPosition = i;
            }
        }
        return elements[minPosition];
    }
    public static T Max<T>(GenericList<T> elements)
    where T : IComparable<T>
    {
        int maxPosition = 0;
        for (int i = 1; i < elements.Count; i++)
        {
            if (elements[i].CompareTo(elements[maxPosition]) >= 0)
            {
                maxPosition = i;
            }
        }
        return elements[maxPosition];
    }

}


