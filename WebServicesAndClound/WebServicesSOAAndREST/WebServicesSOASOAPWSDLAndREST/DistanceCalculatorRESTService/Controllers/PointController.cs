using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DistanceCalculatorRESTService.Controllers
{
    public class PointController : ApiController
    {
        public double Get(int x1, int y1, int x2, int y2)
        {
            return Math.Sqrt(Math.Pow((x1 - x2), 2) + Math.Pow((y1 - y2), 2));
        }
    }
}
