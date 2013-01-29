using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tinkerforge;
using System.Timers;
using AutonomousVehicle.SenseAndAct.Distance;

namespace AutonomousVehicle.SenseAndAct.Driving
{
    public class SimpleDistanceDrivingStrategy : IDrivingStrategy
    {
        public double ForwardVelocity { get; set; }
        public double ReverseVelocity { get; set; }

        //FIXME: why does this need full qualification?
        public AutonomousVehicle.SenseAndAct.Distance.Distance MinimumDrivingDistance { get; set; }
        public AutonomousVehicle.SenseAndAct.Distance.Distance ReversalDistance { get; set; }

        public double RefreshInterval
        {
            get
            {
                return RefreshTimer.Interval;
            }
            set
            {
                RefreshTimer.Interval = value;
            }
        }

        private IEngine Engine;
        private IDistanceSensor DistanceSensor;

        private Timer RefreshTimer;

        public SimpleDistanceDrivingStrategy(IEngine engine, IDistanceSensor distanceSensor)
        {
            Engine = engine;
            DistanceSensor = distanceSensor;
            InitializePropertyDefaults();
            RefreshTimer = new Timer(100);
            RefreshTimer.Elapsed += TakeDrivingDecisions;
        }

        private void InitializePropertyDefaults()
        {
            ForwardVelocity = 1.0;
            ReverseVelocity = 1.0;
            MinimumDrivingDistance = 12.Centimeters();
            ReversalDistance = 0.Centimeters();
        }

        public void Start()
        {
            StopDriving();
            Engine.IsEnabled = true;
            RefreshTimer.Enabled = true;
        }

        public void Stop()
        {
            RefreshTimer.Enabled = false;
            StopDriving();
            Engine.IsEnabled = false;
        }

        private void TakeDrivingDecisions(object sender, ElapsedEventArgs e)
        {
            var distance = DistanceSensor.Distance;

            if (distance >= MinimumDrivingDistance)
            {
                DriveForward();
            }
            else if (distance <= ReversalDistance)
            {
                DriveBackwards();
            }
            else
            {
                StopDriving();
            }
        }

        private void DriveForward()
        {
            Engine.Direction = EngineDirection.Forward;
            Engine.RelativeSpeed = ForwardVelocity;
        }

        private void DriveBackwards()
        {
            Engine.Direction = EngineDirection.Backward;
            Engine.RelativeSpeed = ReverseVelocity;
        }

        private void StopDriving()
        {
            Engine.RelativeSpeed = 0.0;
        }
    }
}
