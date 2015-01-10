using System;


namespace Problem01_GalacticGPS
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Please enter latitude:");
            double latitude = double.Parse(Console.ReadLine());
            Console.WriteLine("Please enter longtitude:");
            double longtitude = double.Parse(Console.ReadLine());
            Console.WriteLine("Please enter planet:");
            Planet planet = (Planet)Enum.Parse(typeof(Planet), Console.ReadLine());

            Location location = new Location(latitude, longtitude, planet);
            Console.WriteLine(location.ToString());
        }
    }
}
