using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tinkerforge;

namespace AutonomousVehicle.SenseAndAct.Distance
{
    public class ImmediateDistanceSensorCollection : IDistanceCollection
    {
        public Distance ClosestDistance
        {
            get
            {
                return Sensors.Min(sensor => sensor.GetDistance().Millimeters());
            }
        }

        public Distance FarthestDistance
        {
            get
            {
                return Sensors.Max(sensor => sensor.GetDistance().Millimeters());
            }
        }

        private List<BrickletDistanceIR> Sensors;

        public ImmediateDistanceSensorCollection()
        {
            Sensors = new List<BrickletDistanceIR>();
        }

        public void AddSensor(BrickletDistanceIR sensor)
        {
            Sensors.Add(sensor);
        }
    }
}
