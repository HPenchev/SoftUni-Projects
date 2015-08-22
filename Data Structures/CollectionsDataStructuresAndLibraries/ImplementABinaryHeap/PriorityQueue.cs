using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementABinaryHeap
{
    public class PriorityQueue<T> where T : IComparable
    {
        private const int InitialCapacity = 8;

        private T[] binaryHeap;

        public PriorityQueue(int capacity = InitialCapacity)
        {
            this.binaryHeap = new T[capacity];
        }

        public int Count { get; set; }

        public void Enqueue (T element)
        {
            if (this.binaryHeap.Length == this.Count)
            {
                this.Grow();                
            }

            this.AddToHeap(element, Count);
            this.Count++;
        }

        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty");
                
            }

            T output = this.binaryHeap[0];           
            T newElement = this.binaryHeap[Count - 1];
            this.Count--;
            this.ReorderElements(0, newElement);
            return output;
        }

        private void ReorderElements(int position, T element)
        {
            T elementToCheck;
            int nextPosition;

            int leftChildPosition = 2 * position + 1;
            int rightChildPosition = 2 * position + 2;

            if (leftChildPosition >= this.Count)
            {
                this.binaryHeap[position] = element;
                return;
            }
            else if (rightChildPosition >= this.Count ||
                this.binaryHeap[leftChildPosition].CompareTo(this.binaryHeap[rightChildPosition]) <= 0)
            {
                elementToCheck = this.binaryHeap[leftChildPosition];
                nextPosition = leftChildPosition;
            }
            else 
            {
                elementToCheck = this.binaryHeap[rightChildPosition];
                nextPosition = rightChildPosition;
            }

            if (elementToCheck.CompareTo(element) >= 0)
            {
                this.binaryHeap[position] = element;
                return;
            }
            else
            {
                this.binaryHeap[position] = elementToCheck;
                this.ReorderElements(nextPosition, element);
            }
        }

        private void AddToHeap(T element, int position)
        {
            if (position == 0)
            {
                this.binaryHeap[position] = element;
                return;
            }

            int parentPosition;
            if (position % 2 == 1)
            {
                parentPosition = (position - 1) / 2;
            }
            else
            {
                parentPosition = (position - 2) / 2;
            }

            T parentElement = binaryHeap[parentPosition];

            if (element.CompareTo(parentElement) < 0)
            {
                binaryHeap[position] = parentElement;
                AddToHeap(element, parentPosition);
            }
            else
            {
                binaryHeap[position] = element;
            }
        }

        private void Grow()
        {
            T[] newBibaryHeap = new T[this.binaryHeap.Length * 2];

            for (int i = 0; i < this.binaryHeap.Length; i++)
            {
                newBibaryHeap[i] = this.binaryHeap[i];
            }

            this.binaryHeap = newBibaryHeap;
        }
    }
}
