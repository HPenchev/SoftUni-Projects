using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace DistanceCalculatorSOAPService
{
   
    public class ServiceDistanceCalculator : IDistanceService
    {
        public double CalculateDistance(Point first, Point second)
        {
            double distance = Math.Sqrt(Math.Pow((first.X - second.X), 2) + Math.Pow((first.Y - second.Y), 2));
            return distance;
        }
    }
}
