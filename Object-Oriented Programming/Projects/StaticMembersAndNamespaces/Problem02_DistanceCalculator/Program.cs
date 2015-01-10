using System;



class Program
{
    static void Main()
    {
        Console.WriteLine("Please enter coordinates of the first point separated by space:");
        string coordinates = Console.ReadLine();
        string[] tempString = coordinates.Split(' ');
        double x1 = double.Parse(tempString[0]);
        double y1 = double.Parse(tempString[1]);
        double z1 = double.Parse(tempString[2]);
        Console.WriteLine("Please enter coordinates of the second point separated by space:");
        coordinates = Console.ReadLine();
        tempString = coordinates.Split(' ');
        double x2 = double.Parse(tempString[0]);
        double y2 = double.Parse(tempString[1]);
        double z2 = double.Parse(tempString[2]);
        Console.WriteLine(DistanceCalculator.CalculateDistance(x1, y1, z1, x2, y2, z2));
    }
}

