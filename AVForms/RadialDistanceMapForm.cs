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

        public RadialDistanceMapForm()
        {
            InitializeComponent();
            DistanceMap = new RadialDistanceMap(-45, 45, 45); //test setup ^^
        }

        private void RadialDistanceMapForm_Paint(object sender, PaintEventArgs e)
        {
            int borderLength = Math.Min(this.Width - 1, this.Height - 1);
            var boundingRect = new Rectangle(0, 0, borderLength, borderLength);
            //background
            e.Graphics.FillEllipse(Brushes.White, boundingRect);

            e.Graphics.FillPie(Brushes.Green, boundingRect, (float)DistanceMap.Left.Angle - 90, (float)(DistanceMap.Right.Angle - DistanceMap.Left.Angle));

            //border
            e.Graphics.DrawEllipse(Pens.Black, boundingRect);
        }
    }
}
