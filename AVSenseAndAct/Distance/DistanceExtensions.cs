using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutonomousVehicle.SenseAndAct.Distance
{
    public static class DistanceExtensions
    {
        public static Distance Millimeters(this int number)
        {
            return Distance.FromMillimeters(number);
        }

        public static Distance Centimeters(this int number)
        {
            return Distance.FromCentimeters(number);
        }

        public static Distance Meters(this int number)
        {
            return Distance.FromMeters(number);
        }
    }
}
