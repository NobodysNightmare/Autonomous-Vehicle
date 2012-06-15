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
        public int MinimumDrivingDistance { get; set; }
        public int ReversalDistance { get; set; }

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
        private IDistanceCollection Distances;

        private Timer RefreshTimer;

        public SimpleDistanceDrivingStrategy(IEngine engine, IDistanceCollection distances)
        {
            Engine = engine;
            Distances = distances;
            InitializePropertyDefaults();
            RefreshTimer = new Timer(100);
            RefreshTimer.Elapsed += TakeDrivingDecisions;
        }

        private void InitializePropertyDefaults()
        {
            ForwardVelocity = 1.0;
            ReverseVelocity = 1.0;
            MinimumDrivingDistance = 120;
            ReversalDistance = 0;
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
            var distance = Distances.ClosestDistanceInMillimeters;

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
