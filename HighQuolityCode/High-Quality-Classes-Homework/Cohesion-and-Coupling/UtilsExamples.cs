namespace CohesionAndCoupling
{
    using System;

    public class UtilsExamples
    {
        public static void Main()
        {
            Console.WriteLine(FileNameUtils.GetFileExtension("example"));
            Console.WriteLine(FileNameUtils.GetFileExtension("example.pdf"));
            Console.WriteLine(FileNameUtils.GetFileExtension("example.new.pdf"));

            Console.WriteLine(FileNameUtils.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FileNameUtils.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileNameUtils.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine("Distance in the 2D space = {0:f2}", CalculateDistanceUtils.CalcDistance2D(1, -2, 3, 4));
            Console.WriteLine("Distance in the 3D space = {0:f2}", CalculateDistanceUtils.CalcDistance3D(5, 2, -1, 3, -6, 4));
                       
            Console.WriteLine("Volume = {0:f2}", CalculateDistanceUtils.CalcVolume(3, 4, 5));
            Console.WriteLine("Diagonal XYZ = {0:f2}", CalculateDistanceUtils.CalcDiagonalXYZ(3, 4, 5));
            Console.WriteLine("Diagonal XY = {0:f2}", CalculateDistanceUtils.CalcDiagonalXY(3, 4));
            Console.WriteLine("Diagonal XZ = {0:f2}", CalculateDistanceUtils.CalcDiagonalXZ(3, 5));
            Console.WriteLine("Diagonal YZ = {0:f2}", CalculateDistanceUtils.CalcDiagonalYZ(4, 5));
        }
    }
}
