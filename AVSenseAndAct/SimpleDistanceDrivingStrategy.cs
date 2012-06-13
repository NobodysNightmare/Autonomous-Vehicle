using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tinkerforge;
using System.Timers;

namespace AutonomousVehicle.SenseAndAct
{
    public class SimpleDistanceDrivingStrategy
    {
        public short ForwardVelocity { get; set; }
        public short StopVelocity { get; set; }
        public short ReverseVelocity { get; set; }
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

        private BrickServo ServoBrick;
        private byte ServoId;
        private RadialDistanceMap DistanceMap;

        private Timer RefreshTimer;

        private int CurrentTargetVelocity;

        public SimpleDistanceDrivingStrategy(BrickServo servoBrick, byte servoId, RadialDistanceMap distanceMap)
        {
            ServoBrick = servoBrick;
            ServoId = servoId;
            DistanceMap = distanceMap;
            InitializePropertyDefaults();
            RefreshTimer = new Timer(100);
            RefreshTimer.Elapsed += TakeDrivingDecisions;
        }

        private void InitializePropertyDefaults()
        {
            ForwardVelocity = 200;
            StopVelocity = 0;
            ReverseVelocity = -100;
            MinimumDrivingDistance = 120;
            ReversalDistance = 800;
        }

        public void Start()
        {
            SetVelocity(StopVelocity);
            ServoBrick.Enable(ServoId);
            RefreshTimer.Enabled = true;
        }

        public void Stop()
        {
            RefreshTimer.Enabled = false;
            SetVelocity(StopVelocity); //FIXME: race-condition with timer (timer could still restart motor in its last tick)
            ServoBrick.Disable(ServoId);
        }

        private void TakeDrivingDecisions(object sender, ElapsedEventArgs e)
        {
            var distance = DistanceMap.ClosestDistanceInMillimeters;

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
            SetVelocityIfNeccessary(ForwardVelocity);
        }

        private void DriveBackwards()
        {
            SetVelocityIfNeccessary(ReverseVelocity);
        }

        private void StopDriving()
        {
            SetVelocityIfNeccessary(StopVelocity);
        }

        private void SetVelocityIfNeccessary(short targetVelocity)
        {
            if (CurrentTargetVelocity != targetVelocity)
            {
                SetVelocity(targetVelocity);
            }
        }

        private void SetVelocity(short targetVelocity)
        {
            ServoBrick.SetPosition(ServoId, targetVelocity);
            CurrentTargetVelocity = targetVelocity;
        }
    }
}
