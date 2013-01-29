using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AutonomousVehicle.SenseAndAct;
using AutonomousVehicle.SenseAndAct.Distance;

namespace AutonomousVehicle.UserControls
{
    public partial class RadialDistanceMapForm : UserControl
    {
        public RadialDistanceMap DistanceMap { get; set; }
        public int MinimumDistanceInMillimeters { get; set; }
        public int MaximumDistanceInMillimeters { get; set; }

        private Rectangle BoundingRect;
        private Point Center;
        private int Radius;

        private double SensorAngle;
        private bool IndicateSensorAngle;

        public RadialDistanceMapForm()
        {
            InitializeComponent();
            DistanceMap = new RadialDistanceMap(0, 0, 1);
            MinimumDistanceInMillimeters = 70;
            MaximumDistanceInMillimeters = 800;
        }

        public void EnableSensorIndicator(RadialDistanceSensor  sensor)
        {
            sensor.UpdatedMeasure += SensorAngleUpdated;
            IndicateSensorAngle = true;
        }

        void SensorAngleUpdated(object sender, UpdatedMeasureEventArgs e)
        {
            SensorAngle = e.Measure.Angle;
            Invalidate();
        }

        private void RadialDistanceMapForm_Paint(object sender, PaintEventArgs e)
        {
            //background
            e.Graphics.FillEllipse(Brushes.White, BoundingRect);

            e.Graphics.FillPie(Brushes.Green, BoundingRect, (float)DistanceMap.Left.Angle - 90, (float)(DistanceMap.Right.Angle - DistanceMap.Left.Angle));

            //minimum distance
            int minimumDistanceOffset = (int)getRadialDistanceFromMillimeters(MinimumDistanceInMillimeters);
            e.Graphics.FillEllipse(Brushes.White, Center.X - minimumDistanceOffset, Center.Y - minimumDistanceOffset, 2 * minimumDistanceOffset, 2 * minimumDistanceOffset);

            //border
            e.Graphics.DrawEllipse(Pens.Black, BoundingRect);

            Point lastPosition = Point.Empty;
            foreach (var currentMeasure in DistanceMap)
            {
                var currentPosition = GetPolarPosition(currentMeasure.Angle, currentMeasure.Distance.InMillimeters);
                if (lastPosition != Point.Empty)
                {
                    e.Graphics.DrawLine(Pens.Black, lastPosition, currentPosition);
                }
                lastPosition = currentPosition;
            }

            if (IndicateSensorAngle)
            {
                e.Graphics.DrawLine(Pens.Blue, Center, GetPolarPosition(SensorAngle, MaximumDistanceInMillimeters));
            }
        }

        private void RadialDistanceMapForm_Resize(object sender, EventArgs e)
        {
            int borderLength = Math.Min(this.Width - 1, this.Height - 1);
            BoundingRect = new Rectangle(0, 0, borderLength, borderLength);
            Radius = borderLength / 2;
            Center = new Point(Radius, Radius);
        }

        private Point GetPolarPosition(double angleInDegrees, int distance)
        {
            double radianAngle = Math.PI * angleInDegrees / 180.0;
            var radialDistance = getRadialDistanceFromMillimeters(distance);

            return new Point(Center.X + (int)Math.Round(Math.Sin(radianAngle) * radialDistance), Center.Y - (int)Math.Round(Math.Cos(radianAngle) * radialDistance));
        }

        private double getRadialDistanceFromMillimeters(int distanceInMillimeters)
        {
            double relativeDistance = (double)distanceInMillimeters / MaximumDistanceInMillimeters;
            relativeDistance = Math.Min(1.0, Math.Max(0.0, relativeDistance));
            return relativeDistance * Radius;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Invalidate();
        }
    }
}
