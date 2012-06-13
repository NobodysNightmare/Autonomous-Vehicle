using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutonomousVehicle.SenseAndAct.Distance
{
    public interface IDistanceCollection
    {
        int ClosestDistanceInMillimeters {get;}
        int FarthestDistanceInMillimeters { get; }
    }
}
