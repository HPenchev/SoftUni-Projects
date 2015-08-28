using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementAnIntervalTree
{
    class Program
    {
        private static Random rnd = new Random();

        static void Main(string[] args)
        {
            IntervalTree<int> tree = new IntervalTree<int>();

            tree.Add(60, 100);
            tree.Add(20, 50);
            tree.Add(10, 101);
            tree.Add(30, 40);
            tree.Add(10, 15);

            tree.Delete(20, 50);

            var intervals = tree.ReturnIntervalsByRange(13, 15);
	//	OverlappingByEndPoint	Count = 1	System.Collections.Generic.SortedSet<ImplementAnIntervalTree.Interval<int>>
            //for (int i = 0; i < 20; i++)
            //{
            //    int a = rnd.Next(100);
            //    int b = rnd.Next(100);

            //    tree.Add(a, b);
            //}
        }
    }
}