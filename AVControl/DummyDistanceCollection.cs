using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutonomousVehicle.SenseAndAct.Distance;

namespace AutonomousVehicle.GUI
{
    class DummyDistanceCollection : IDistanceCollection
    {
        public Distance ClosestDistance
        {
            get { return 0.Millimeters(); }
        }

        public Distance FarthestDistance
        {
            get { return 0.Millimeters(); }
        }
    }
}
