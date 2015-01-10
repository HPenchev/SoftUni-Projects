using System;



static class DistanceCalculator
{
    public static double CalculateDistance(double x1, double y1, double z1, double x2, double y2, double z2)
    {
        double distance = Math.Sqrt(Math.Pow((x1 - x2), 2) + Math.Pow((y1 - y2), 2) + Math.Pow((z1 - z2), 2));
        return distance;
    }
}

