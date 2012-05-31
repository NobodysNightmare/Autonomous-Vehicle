using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AutonomousVehicle.SenseAndAct;

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

        public RadialDistanceMapForm()
        {
            InitializeComponent();
            DistanceMap = new RadialDistanceMap(0, 0, 1);
            MinimumDistanceInMillimeters = 70;
            MaximumDistanceInMillimeters = 800;
        }

        private void RadialDistanceMapForm_Paint(object sender, PaintEventArgs e)
        {
            //background
            e.Graphics.FillEllipse(Brushes.White, BoundingRect);

            e.Graphics.FillPie(Brushes.Green, BoundingRect, (float)DistanceMap.Left.Angle - 90, (float)(DistanceMap.Right.Angle - DistanceMap.Left.Angle));
            //TODO: fill white pie tp display minimum distance

            //border
            e.Graphics.DrawEllipse(Pens.Black, BoundingRect);

            Point lastPosition = Point.Empty;
            foreach (var currentMeasure in DistanceMap)
            {
                var currentPosition = GetPolarPosition(currentMeasure.Angle, currentMeasure.DistanceInMillimeters);
                if (lastPosition != Point.Empty)
                {
                    e.Graphics.DrawLine(Pens.Black, lastPosition, currentPosition);
                }
                lastPosition = currentPosition;
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
            double relativeDistance = (double)distance / MaximumDistanceInMillimeters;
            relativeDistance = Math.Min(1.0, Math.Max(0.0, relativeDistance));

            return new Point(Center.X + (int)Math.Round(Math.Sin(radianAngle) * Radius * relativeDistance), Center.Y - (int)Math.Round(Math.Cos(radianAngle) * Radius * relativeDistance));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Invalidate();
        }
    }
}
