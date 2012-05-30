using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutonomousVehicle.SenseAndAct
{
    public class RadialDistanceMeasure
    {
        public double Angle { get; private set; }
        public double Distance { get; set; }
        public RadialDistanceMeasure LeftNeighbour { get; private set; }
        public RadialDistanceMeasure RightNeighbour { get; private set; }
    }

    public class RadialDistanceMap
    {
        public double MinimumAngle { get; private set; }
        public double MaximumAngle { get; private set; }

        public RadialDistanceMap(double minAngle, double maxAngle, double stepSize)
        {

        }
    }
}
