using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace DistanceCalculatorSOAPService
{    
    [ServiceContract]
    public interface IDistanceService
    {
        [OperationContract]
        double CalculateDistance(Point first, Point second);
    }
}
