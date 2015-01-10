using System;



class Program
{
    static void Main()
    {
        Console.WriteLine("please enter a point x");
        float x = float.Parse(Console.ReadLine());
        Console.WriteLine("please enter a point y");
        float y = float.Parse(Console.ReadLine());
        Console.WriteLine("please enter a point z");
        float z = float.Parse(Console.ReadLine());
        Point3D point = new Point3D(x, y, z);
        Console.WriteLine("Current point coordinates:");
        Console.WriteLine(point.ToString());
        Console.WriteLine("Starting point coordinates:");
        Console.WriteLine(Point3D.StartingPoints);


    }
}

