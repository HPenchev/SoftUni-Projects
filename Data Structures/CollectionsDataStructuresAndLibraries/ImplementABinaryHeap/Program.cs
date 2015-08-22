using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementABinaryHeap
{
    class Program
    {
        private static Random rnd = new Random();
        static void Main(string[] args)
        {
            PriorityQueue<int> queue = new PriorityQueue<int>();
            //int n = queue.Dequeue();

            while (true)
            {
                queue.Enqueue(rnd.Next(20));
                queue.Enqueue(rnd.Next(20));
                Console.WriteLine(queue.Dequeue());
            }
        }
    }
}
