using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementAnIntervalTree
{
    internal class IntervalTreeNode<T>
           where T : IComparable
    {
        private T centrePoint;

        public IntervalTreeNode(T valueOne, T valueTwo)
        {
            if (valueOne.CompareTo(valueTwo) < 0)
            {
                this.StartPoint = valueOne;
                this.EndPoint = valueTwo;
            }
            else
            {
                this.StartPoint = valueTwo;
                this.EndPoint = valueOne;
            }

            this.CentrePoint = valueOne;

            this.OverlappingByStartPoint =
                new SortedSet<IntervalTreeNode<T>>(
                    Comparer<IntervalTreeNode<T>>.Create(
                    (a, b) => a.StartPoint.CompareTo(b.StartPoint)));
            this.OverlappingByEndPoint =
                new SortedSet<IntervalTreeNode<T>>(
                    Comparer<IntervalTreeNode<T>>.Create(
                    (a, b) => a.EndPoint.CompareTo(b.EndPoint)));
        }

        public IntervalTreeNode(T valueOne, T valueTwo, IntervalTreeNode<T> parent)
            : this(valueOne, valueTwo)
        {
            this.Parent = parent;
        }

        public T StartPoint { get; set; }

        public T EndPoint { get; set; }

        public T CentrePoint { get; set; }

        public IntervalTreeNode<T> LeftInterval { get; set; }

        public IntervalTreeNode<T> RightInterval { get; set; }

        public IntervalTreeNode<T> Parent { get; set; }

        public SortedSet<IntervalTreeNode<T>> OverlappingByStartPoint { get; set; }

        public SortedSet<IntervalTreeNode<T>> OverlappingByEndPoint { get; set; }

        public override bool Equals(object obj)
        {
             if (obj == null)
             {
                 return false;
             }

            IntervalTreeNode<T> newInterval = obj as IntervalTreeNode<T>;

            if (newInterval == null)
            {
                return false;
            }

            return newInterval.StartPoint.Equals(this.StartPoint) && 
                newInterval.EndPoint.Equals(this.EndPoint);
        }

        public static bool operator == (IntervalTreeNode<T> a, IntervalTreeNode<T> b)
        {
            if (System.Object.ReferenceEquals(a, b))
            {
                return true;
            }

            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }

            return a.Equals(b);
        }

        public static bool operator != (IntervalTreeNode<T> a, IntervalTreeNode<T> b)
        {
            return !(a == b);
        }
    }
}
