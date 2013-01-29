using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tinkerforge;

namespace AutonomousVehicle.SenseAndAct.Distance
{
    public class CachedDistanceIRSensor : IDistanceSensor
    {
        public Distance Distance { get; private set; }

        public CachedDistanceIRSensor(BrickletDistanceIR bricklet)
        {
            bricklet.Distance += UpdateDistance;
        }

        private void UpdateDistance(BrickletDistanceIR sender, int distance)
        {
            Distance = Distance.FromMillimeters(distance);
        }
    }
}
