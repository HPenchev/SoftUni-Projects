using ConsoleClientSOAPDistanceCalculator.ServiceReferenceDistanceCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClientSOAPDistanceCalculator
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Please enter X and Y for start point separated by space:");
            string[] input = Console.ReadLine().Split(' ');
            Point start = new Point() { X = int.Parse(input[0]), Y = int.Parse(input[1]) };

            Console.WriteLine("Please enter X and Y for end point separated by space:");
            input = Console.ReadLine().Split(' ');
            Point end = new Point() { X = int.Parse(input[0]), Y = int.Parse(input[1]) };

            DistanceServiceClient client = new DistanceServiceClient();
            double distance = client.CalculateDistance(start, end);

            Console.WriteLine(distance);
        }
    }
}
