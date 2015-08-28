using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementAnIntervalTree
{
    public class Interval<T>
        where T : IComparable
    {
        public Interval(T valueOne, T valueTwo)
        {
            if (valueOne.CompareTo(valueTwo) > 0)
            {
                T temp = valueTwo;
                valueTwo = valueOne;
                valueOne = temp;
            }

            this.StartPoint = valueOne;
            this.EndPoint = valueTwo;
        }

        public T StartPoint { get; set; }

        public T EndPoint { get; set; }
    }
}