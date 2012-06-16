using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutonomousVehicle.SenseAndAct.Distance;

namespace AutonomousVehicle.GUI
{
    class DummyDistanceCollection : IDistanceCollection
    {
        public int ClosestDistanceInMillimeters
        {
            get { return 0; }
        }

        public int FarthestDistanceInMillimeters
        {
            get { return 0; }
        }
    }
}
