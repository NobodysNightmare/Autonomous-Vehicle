using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tinkerforge;

namespace AutonomousVehicle.SenseAndAct.Distance
{
    public class ClosestDistanceSensorCollection : IDistanceSensor
    {
        public Distance Distance
        {
            get
            {
                return Sensors.Min(sensor => sensor.Distance);
            }
        }

        private List<IDistanceSensor> Sensors = new List<IDistanceSensor>();

        public void AddSensor(IDistanceSensor sensor)
        {
            Sensors.Add(sensor);
        }
    }
}
