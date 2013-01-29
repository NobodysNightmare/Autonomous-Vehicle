using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutonomousVehicle.SenseAndAct.Distance
{
    public class RadialDistanceMeasure
    {
        public double Angle { get; private set; }
        public Distance Distance { get; internal set; }
        public RadialDistanceMeasure LeftNeighbour { get; internal set; }
        public RadialDistanceMeasure RightNeighbour { get; internal set; }

        internal RadialDistanceMeasure(double angle)
        {
            Angle = angle;
        }

        internal void defineLeftNeighbour(RadialDistanceMeasure neighbour)
        {
            LeftNeighbour = neighbour;
            if (neighbour != null)
                neighbour.RightNeighbour = this;
        }
    }

    public class RadialDistanceMap : IEnumerable<RadialDistanceMeasure>
    {
        public RadialDistanceMeasure Left { get; private set; }
        public RadialDistanceMeasure Right { get; private set; }

        public Distance ClosestDistance
        {
            get
            {
                return this.Min(measure => measure.Distance);
            }
        }

        public Distance FarthestDistance
        {
            get
            {
                return this.Max(measure => measure.Distance);
            }
        }

        public RadialDistanceMap(double minimumAngle, double maximumAngle, double stepSize)
        {
            RadialDistanceMeasure lastMeasure = null;
            for (double angle = minimumAngle; angle < maximumAngle; angle += stepSize)
            {
                var currentMeasure = new RadialDistanceMeasure(angle);
                currentMeasure.defineLeftNeighbour(lastMeasure);
                lastMeasure = currentMeasure;

                if (angle == minimumAngle)
                    Left = currentMeasure;
            }
            Right = new RadialDistanceMeasure(maximumAngle);
            if (Left == null)
                Left = Right;
            Right.defineLeftNeighbour(lastMeasure);
        }

        public IEnumerator<RadialDistanceMeasure> GetEnumerator()
        {
            var currentItem = Left;
            while (currentItem != null)
            {
                yield return currentItem;
                currentItem = currentItem.RightNeighbour;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
