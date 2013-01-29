using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tinkerforge;

namespace AutonomousVehicle.SenseAndAct.Distance
{
    /// <summary>
    /// Provides immediate access to the current distance of a BrickletDistanceIR.
    /// This means whenever the Distance is queried, this will result in a network call to the Bricklet.
    /// </summary>
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
