using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutonomousVehicle.SenseAndAct.Driving
{
    public interface IDrivingStrategy
    {
        void Start();
        void Stop();
    }
}
