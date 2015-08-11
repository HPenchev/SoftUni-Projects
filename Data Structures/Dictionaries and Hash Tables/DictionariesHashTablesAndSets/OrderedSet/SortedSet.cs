using System;
using System.Linq;

public class SortedSet<T> : System.Collections.IEnumerable
    where T : IComparable
{
    private SortedTree<T> tree;
    
    public int Count { get; set; }

    public bool Add(T element)
    {
        bool isAdded;
        if (this.tree == null)
        {
            this.tree = new SortedTree<T>(element);
            isAdded = true;
        }
        else
        {
            isAdded = this.tree.Add(new SortedTree<T>(element));
        }

        if (isAdded)
        {
            this.Count++;
        }

        return isAdded;
    }

    public bool Contains(T element)
    {
        if (this.tree == null)
        {
            return false;
        }
        else
        {
            return this.tree.Contains(element);
        }
    }

    public bool Remove(T element)
    {
        bool isRemoved;
        if (this.tree.Value.Equals(element) && this.tree.Left == null && this.tree.Right == null)
        {
            this.tree = null;
            isRemoved = true;
        }
        else
        {
            isRemoved = this.tree.Remove(element);

            if (this.tree.Value.Equals(element))
            {
                if (this.tree.Right != null)
                {
                    this.tree = this.tree.Right;
                }
                else if (this.tree.Left != null)
                {
                    this.tree = this.tree.Left;
                }
            }
        }

        if (isRemoved)
        {
            this.Count--;
        }
        return isRemoved;
    }


    public System.Collections.Generic.IEnumerator<T> GetEnumerator()
    {
        if (this.tree != null)
        {
            return this.tree.GetEnumerator();
        }
        else
        {
            return Enumerable.Empty<T>().GetEnumerator();
        }
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    protected class SortedTree<T> : System.Collections.IEnumerable
        where T : IComparable
    {
        public SortedTree(T value, SortedTree<T> parent = null)
        {
            this.Value = value;
            this.Parent = parent;
        }

        public T Value { get; set; }

        public SortedTree<T> Parent { get; set; }

        public SortedTree<T> Left { get; set; }

        public SortedTree<T> Right { get; set; }

        public virtual bool Add(SortedTree<T> child)
        {
            if (child.Value.Equals(this.Value))
            {
                return false;
            }
            else if (child.Value.CompareTo(this.Value) < 0)
            {
                if (this.Left == null)
                {
                    this.Left = child;
                    child.Parent = this;
                    return true;
                }
                else
                {
                    return this.Left.Add(child);
                }
            }
            else
            {
                if (this.Right == null)
                {
                    this.Right = child;
                    child.Parent = this;
                    return true;
                }
                else
                {
                    return this.Right.Add(child);
                }
            }
        }

        public bool Contains(T element)
        {
            if (this.Value.Equals(element))
            {
                return true;
            }
            else if (element.CompareTo(this.Value) < 0 && this.Left != null)
            {
                return this.Left.Contains(element);
            }
            else if (element.CompareTo(this.Value) > 0 && this.Right != null)
            {
                return this.Right.Contains(element);
            }
            else
            {
                return false;
            }
        }

        public bool Remove(T element)
        {
            if (this.Value.Equals(element))
            {
                SortedTree<T> nextNode = null;
                if (this.Left == null && this.Right == null && this.Parent == null)
                {
                    throw new InvalidOperationException("Last sorted tree node can't be deleted");
                }
                else if (this.Left == null && this.Right == null)
                {
                    nextNode = null;                    
                }
                else if (this.Left != null && this.Right == null)
                {
                    nextNode = this.Left;
                }
                else
                {
                    nextNode = this.Right;
                    if (this.Left != null)
                    {
                        this.Right.Add(this.Left);
                    }
                }

                if (this.Parent != null && this.Value.CompareTo(this.Parent.Value) < 0)
                {
                    this.Parent.Left = nextNode;
                }
                else if (this.Parent != null)
                {
                    this.Parent.Right = nextNode;
                }

                if (nextNode != null)
                {
                    nextNode.Parent = this.Parent;
                }

                return true;
            }  
            else
            {
                if ( this.Left != null && element.CompareTo(this.Value) < 0)
                {
                    return this.Left.Remove(element);
                }
                else if (this.Right != null && element.CompareTo(this.Value) > 0)
                {
                    return this.Right.Remove(element);
                }
            }

            return false;
        }

        public System.Collections.Generic.IEnumerator<T> GetEnumerator()
        {            
            if (this.Left != null)
            {
                foreach (var item in this.Left)
                {
                    yield return item;
                }
            }

            yield return this.Value;

            if (this.Right != null)
            {
                foreach  (T item in this.Right)
                {
                    yield return item;
                }
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}

