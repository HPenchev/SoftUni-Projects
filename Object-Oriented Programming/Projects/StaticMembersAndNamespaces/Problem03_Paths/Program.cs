using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main()
    {
       Console.WriteLine(Storage.ReadPath());

       List<Point3D> points = new List<Point3D>();
       while(true)
           {
               Console.WriteLine("Please enter three points separated by a space or type \"Exit\" to exit");
               string line = Console.ReadLine();
               if (line == "Exit" || line == "exit") break;
               string[] numbers = line.Split(' ');
               float x = float.Parse(numbers[0]);
               float y = float.Parse(numbers[1]);
               float z = float.Parse(numbers[2]);
               Point3D point = new Point3D(x, y, z);
               points.Add(point);
           }
       Path3D path = new Path3D(points);
       Storage.WritePath(path);
    }
    
}

