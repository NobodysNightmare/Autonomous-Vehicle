using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tinkerforge;

namespace AutonomousVehicle.SenseAndAct
{
    private enum TraversalDirection
    {
        Left, Right
    }

    class RadialDistanceSensor : IDisposable
    {
        public RadialDistanceMap Measurements { get; private set; }

        private BrickServo ServoBrick;
        private byte ServoId;
        private BrickletDistanceIR DistanceSensor;

        private RadialDistanceMeasure NextMeasure;
        private TraversalDirection Direction;

        public RadialDistanceSensor(RadialDistanceMap targetMap, BrickServo servoBrick, byte servoId, BrickletDistanceIR distanceBricklet)
        {
            Measurements = targetMap;
            ServoId = servoId;
            ServoBrick = servoBrick;
            DistanceSensor = distanceBricklet;

            SetupMeasurement();
            SetupServo();
        }

        private void SetupMeasurement()
        {
            NextMeasure = Measurements.Left;
            Direction = TraversalDirection.Right;
        }

        private void SetupServo()
        {
            short leftLimit = ConvertToServoAngle(Measurements.Left.Angle);
            short rightLimit = ConvertToServoAngle(Measurements.Right.Angle);
            ServoBrick.SetDegree(ServoId, leftLimit, rightLimit);

            ServoBrick.RegisterCallback(new BrickServo.PositionReached(OnPositionReached));
            ServoBrick.SetPosition(ServoId, leftLimit);
            ServoBrick.Enable(ServoId);
        }

        private void OnPositionReached(byte servoId, short position)
        {
            if (servoId != ServoId)
                return;

            PerformMeasurement();
        }

        private void PerformMeasurement()
        {
            NextMeasure.DistanceInMillimeters = DistanceSensor.GetDistance();
            ContinueTraversal();
        }

        private void ContinueTraversal()
        {
            RadialDistanceMeasure currentMeasure = NextMeasure;
            if (Direction == TraversalDirection.Left)
                NextMeasure = currentMeasure.LeftNeighbour;
            else
                NextMeasure = currentMeasure.RightNeighbour;

            if (NextMeasure == null)
            {
                Direction = (Direction == TraversalDirection.Left) ? TraversalDirection.Right : TraversalDirection.Left;
                ContinueTraversal();
                return;
            }

            ServoBrick.SetPosition(ServoId, ConvertToServoAngle(NextMeasure.Angle));
        }

        public void Dispose()
        {
            if (ServoBrick != null)
                ServoBrick.Disable(ServoId);
        }

        private static short ConvertToServoAngle(double angleInDegrees)
        {
            return (short)(angleInDegrees * 100);
        }
    }
}
