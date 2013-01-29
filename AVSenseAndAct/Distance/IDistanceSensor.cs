using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutonomousVehicle.SenseAndAct.Distance
{
    public interface IDistanceSensor
    {
        Distance Distance { get; }
    }
}
