using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tinkerforge;

namespace AutonomousVehicle.SenseAndAct.Distance
{
    public class ImmediateDistanceIRSensor : IDistanceSensor
    {
        private BrickletDistanceIR Bricklet;

        public Distance Distance
        {
            get
            {
                return Distance.FromMillimeters(Bricklet.GetDistance());
            }
        }

        public ImmediateDistanceIRSensor(BrickletDistanceIR bricklet)
        {
            Bricklet = bricklet;
        }
    }
}
