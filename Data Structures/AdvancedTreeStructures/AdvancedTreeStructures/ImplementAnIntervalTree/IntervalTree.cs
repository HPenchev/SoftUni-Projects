using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementAnIntervalTree
{
    public class IntervalTree<T>
        where T : IComparable
    {
        private IntervalTreeNode<T> root;

        public bool Add(T firstValue, T secondValue)
        {
            var interval = new IntervalTreeNode<T>(firstValue, secondValue);
            if (this.root == null)
            {
                this.root = interval;
                return true;
            }

            else
            {
                return AddInterval(interval, this.root);
            }
        }

        public bool Delete(T valueOne, T valueTwo)
        {
            if (this.root == null)
            {
                return false;
            }

            if (valueOne.CompareTo(valueTwo) > 0)
            {
                T temp = valueTwo;
                valueTwo = valueOne;
                valueOne = temp;
            }

            return this.DeleteFromTree(valueOne, valueTwo, this.root);
        }

        public ICollection<Interval<T>> ReturnIntervalsByPoint(T point)
        {
            ICollection<Interval<T>> intervals = new HashSet<Interval<T>>(); 
            GetAllIntervalsByPoint(point, intervals, this.root);
            if (intervals.Any())
            {
                return intervals;
            }
            else
            {
                return null;
            }
        }

        public ICollection<Interval<T>> ReturnIntervalsByRange(T pointOne, T pointTwo)
        {
            if (pointOne.CompareTo(pointTwo) > 0)
            {
                var temp = pointTwo;
                pointTwo = pointOne;
                pointOne = temp;
            }

            ICollection<Interval<T>> intervals = new HashSet<Interval<T>>();
            GetIntervalsByTwoPoints(pointOne, pointTwo, intervals, this.root);
            if (intervals.Any())
            {
                return intervals;
            }
            else
            {
                return null;
            }
        }

        private static void GetIntervalsByTwoPoints(
            T pointOne,
            T pointTwo,
            ICollection<Interval<T>> intervals, 
            IntervalTreeNode<T> intervalNode)
        {
            if (intervalNode == null)
            {
                return;
            }


            if (intervalNode.StartPoint.CompareTo(pointOne) <= 0 &&
                intervalNode.EndPoint.CompareTo(pointTwo) >= 0)
            {
                intervals.Add(
                    new Interval<T>(intervalNode.StartPoint, intervalNode.EndPoint));
            }

            var intervalsInSets = intervalNode.OverlappingByStartPoint
                .Where(i => i.StartPoint.CompareTo(pointOne) <= 0 &&
                    i.EndPoint.CompareTo(pointTwo) >= 0)
                .ToList();

            foreach (var item in intervalsInSets)
            {
                intervals.Add(new Interval<T>(item.StartPoint, item.EndPoint));
            }

            GetIntervalsByTwoPoints(pointOne, pointTwo, intervals, intervalNode.LeftInterval);
            GetIntervalsByTwoPoints(pointOne, pointTwo, intervals, intervalNode.RightInterval);
        }

        private static void GetAllIntervalsByPoint(
            T point, 
            ICollection<Interval<T>> intervals, 
            IntervalTreeNode<T> intervalNode)
        {
            if (intervalNode == null)
            {
                return;
            }

            if (intervalNode.StartPoint.CompareTo(point) <= 0 && intervalNode.EndPoint.CompareTo(point) >= 0)
            {
                intervals.Add(new Interval<T>(intervalNode.StartPoint, intervalNode.EndPoint));
            }

            var intervalsInSets = intervalNode.OverlappingByStartPoint
                .Where(i => i.StartPoint.CompareTo(point) <= 0 &&
                    i.EndPoint.CompareTo(point) >= 0)
                .ToList();

            foreach (var item in intervalsInSets)
            {
                intervals.Add(new Interval<T>(item.StartPoint, item.EndPoint));
            }

            GetAllIntervalsByPoint(point, intervals, intervalNode.LeftInterval);
            GetAllIntervalsByPoint(point, intervals, intervalNode.RightInterval);
        }

        private bool DeleteFromTree(T valueOne, T valueTwo, IntervalTreeNode<T> interval)
        {
            if (interval == null)
            {
                return false;
            }

            if (valueOne.Equals(interval.StartPoint) && valueTwo.Equals(interval.EndPoint))
            {
                var parent = interval.Parent;
                IntervalTreeNode<T> newInterval = null;

                if (interval.RightInterval != null)
                {
                    newInterval = interval.RightInterval;
                }
                else if (interval.LeftInterval != null)
                {
                    newInterval = interval.LeftInterval;
                }

                if (parent != null)
                {
                    if (parent.LeftInterval == interval)
                    {
                        parent.LeftInterval = newInterval;
                    }
                    else if (parent.RightInterval == interval)
                    {
                        parent.RightInterval = newInterval;
                    }
                }

                if (newInterval == null)
                {
                    newInterval = parent;
                }
                else
                {
                    newInterval.Parent = parent;
                }

                if (this.root == interval)
                {
                    this.root = newInterval;
                }

                if (newInterval == interval.RightInterval)
                {
                    this.AddInterval(interval.LeftInterval, newInterval);
                }                

                foreach (var intervalInSet in interval.OverlappingByStartPoint)
                {
                    this.AddInterval(intervalInSet, this.root);                    
                }

                return true;
            }

            var intervalToRemove =
                interval.OverlappingByStartPoint
                .Where(i => i.StartPoint.Equals(valueOne) && i.EndPoint.Equals(valueTwo))
                .FirstOrDefault();

            if (intervalToRemove != null)
            {
                interval.OverlappingByEndPoint.Remove(intervalToRemove);
                interval.OverlappingByStartPoint.Remove(intervalToRemove);
                return true;
            }

            bool result = this.DeleteFromTree(valueOne, valueTwo, interval.LeftInterval);
            if (result)
            {
                return true;
            }

            result = this.DeleteFromTree(valueOne, valueTwo, interval.RightInterval);
            if (result)
            {
                return true;
            }

            return false;
        }

        private bool AddInterval(IntervalTreeNode<T> intervalToAdd, IntervalTreeNode<T> interval)
        {
            if (intervalToAdd == null)
            {
                return false;
            }

            if (interval == null)
            {
                interval = intervalToAdd;
                if (this.root == null)
                {
                    this.root = intervalToAdd;
                }

                return true;
            }

            if (intervalToAdd.Equals(interval))
            {
                return false;
            }

            if (intervalToAdd.EndPoint.CompareTo(interval.StartPoint) < 0)
            {
                if (interval.LeftInterval == null)
                {
                    interval.LeftInterval = intervalToAdd;
                    intervalToAdd.Parent = interval;
                    return true;
                }
                else
                {
                    return AddInterval(intervalToAdd, interval.LeftInterval);
                }
            }
            else if (intervalToAdd.StartPoint.CompareTo(interval.EndPoint) > 0)
            {
                if (interval.RightInterval == null)
                {
                    interval.RightInterval = intervalToAdd;
                    intervalToAdd.Parent = interval.RightInterval;
                    return true;
                }
                else
                {
                    return AddInterval(intervalToAdd, interval.RightInterval);
                }
            }
            else
            {
                interval.OverlappingByStartPoint.Add(intervalToAdd);
                return interval.OverlappingByEndPoint.Add(intervalToAdd);
            }
        }
    }
}