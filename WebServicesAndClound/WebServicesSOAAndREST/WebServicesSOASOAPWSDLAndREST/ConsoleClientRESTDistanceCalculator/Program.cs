using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

public class Program
{
    static void Main()
    {
        Console.WriteLine("Please enter start point coordinates separated by space");
        string[] startPointCoordinates = Console.ReadLine().Split(' ');

        Console.WriteLine("Please enter end point coordinates separated by space");
        string[] endPointCoordinates = Console.ReadLine().Split(' ');

        WebClient client = new WebClient();
        var distance = client.DownloadString(String.Format("http://localhost:56935/api/point?x1={0}&y1={1}&x2={2}&y2={3}",
            startPointCoordinates[0],
            startPointCoordinates[1],
            endPointCoordinates[0],
            endPointCoordinates[1]));

        Console.WriteLine(distance);
    }
}