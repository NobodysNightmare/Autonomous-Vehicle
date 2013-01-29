using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutonomousVehicle.SenseAndAct.Distance
{
    public struct Distance
    {
        private int DistanceInMillimeters;

        public int InMillimeters
        {
            get
            {
                return DistanceInMillimeters;
            }
        }

        public double InCentimeters
        {
            get
            {
                return DistanceInMillimeters / 10.0;
            }
        }

        public double InMeters
        {
            get
            {
                return DistanceInMillimeters / 1000.0;
            }
        }

        private Distance(int distanceInMillimeters)
        {
            DistanceInMillimeters = distanceInMillimeters;
        }

        public override string ToString()
        {
            return string.Format("{0} mm", DistanceInMillimeters); //TODO: different output depending on distance
        }

        public static Distance operator +(Distance left, Distance right)
        {
            return new Distance(left.InMillimeters + right.InMillimeters);
        }

        public static Distance operator -(Distance left, Distance right)
        {
            return new Distance(left.InMillimeters - right.InMillimeters);
        }

        public static Distance operator *(int left, Distance right)
        {
            return new Distance(left * right.InMillimeters);
        }

        public static Distance operator *(Distance left, int right)
        {
            return new Distance(left.InMillimeters * right);
        }

        public static Distance operator /(Distance left, int right)
        {
            return new Distance(left.InMillimeters / right);
        }

        public static bool operator <(Distance left, Distance right)
        {
            return left.InMillimeters < right.InMillimeters;
        }

        public static bool operator <=(Distance left, Distance right)
        {
            return left.InMillimeters <= right.InMillimeters;
        }

        public static bool operator >(Distance left, Distance right)
        {
            return left.InMillimeters > right.InMillimeters;
        }

        public static bool operator >=(Distance left, Distance right)
        {
            return left.InMillimeters >= right.InMillimeters;
        }

        public static Distance FromMillimeters(int millimeters)
        {
            return new Distance(millimeters);
        }

        public static Distance FromCentimeters(double centimeters)
        {
            return new Distance((int)Math.Round((centimeters * 10)));
        }

        public static Distance FromMeters(double meters)
        {
            return new Distance((int)Math.Round((meters * 1000)));
        }
    }
}
