using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tinkerforge;

namespace AutonomousVehicle.SenseAndAct.Distance
{
    /// <summary>
    /// Provides access to the current distance of a BrickletDistanceIR by utilizing callbacks.
    /// Access to the distance does not involve IO, this means there will be no network-lag and there is no
    /// penalty for querying the Distance more often.
    /// </summary>
    /// <remarks>The callback period of the Bricklet needs to be specified externally.</remarks>
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
