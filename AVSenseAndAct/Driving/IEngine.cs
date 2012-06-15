using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutonomousVehicle.SenseAndAct.Driving
{
    public enum EngineDirection
    {
        Forward, Backward
    }

    public interface IEngine
    {
        EngineDirection Direction { get; set; }
        
        /// <summary>
        /// Gets or sets the relative speed of the engine
        /// 0.0 means the engine is standing still
        /// 1.0 means the engine is running at full speed
        /// </summary>
        /// <remarks>The engine should only run if it is enabled</remarks>
        double RelativeSpeed { get; set; }

        /// <summary>
        /// Get or sets if the engine is enabled. It will only start running if it is enabled.
        /// Disabling an engine means that it can also be disabled physically, some engines
        /// might lose breaking capabilities when disabled.
        /// </summary>
        bool IsEnabled { get; set; }
    }
}
