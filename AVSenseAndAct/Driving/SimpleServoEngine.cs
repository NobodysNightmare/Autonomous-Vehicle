using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tinkerforge;

namespace AutonomousVehicle.SenseAndAct.Driving
{
    public class SimpleServoEngine : IEngine
    {
        private EngineDirection _Direction;
        public EngineDirection Direction
        {
            get
            {
                return _Direction;
            }
            set
            {
                _Direction = value;
                RecalculateSpeed();
            }
        }

        private double _RelativeSpeed;
        public double RelativeSpeed
        {
            get
            {
                return _RelativeSpeed;
            }
            set
            {
                _RelativeSpeed = value;
                RecalculateSpeed();
            }
        }

        private bool _IsEnabled;
        public bool IsEnabled
        {
            get
            {
                return _IsEnabled;
            }
            set
            {
                _IsEnabled = value;
                if (_IsEnabled)
                    ServoBrick.Enable(ServoId);
                else
                    ServoBrick.Disable(ServoId);
            }
        }

        public short MaximumForwardSpeed { get; set; }
        public short MaximumBackwardSpeed { get; set; }

        private BrickServo ServoBrick;
        private byte ServoId;

        private short CurrentTargetSpeed;

        public SimpleServoEngine(BrickServo servoBrick, byte servoId)
        {
            ServoBrick = servoBrick;
            ServoId = servoId;

            IsEnabled = false;

            InitializePropertyDefaults();
        }

        private void InitializePropertyDefaults()
        {
            MaximumForwardSpeed = 100;
            MaximumBackwardSpeed = -100;
        }

        private void RecalculateSpeed()
        {
            short targetSpeed;
            if (Direction == EngineDirection.Backward)
            {
                targetSpeed = (short)Math.Round(RelativeSpeed * MaximumBackwardSpeed);
            }
            else
            {
                targetSpeed = (short)Math.Round(RelativeSpeed * MaximumForwardSpeed);
            }

            SetSpeedIfNeccessary(targetSpeed);
        }

        private void SetSpeedIfNeccessary(short speed)
        {
            if (CurrentTargetSpeed != speed)
            {
                SetSpeed(speed);
            }
        }

        private void SetSpeed(short speed)
        {
            ServoBrick.SetPosition(ServoId, speed);
            CurrentTargetSpeed = speed;
        }
    }
}
