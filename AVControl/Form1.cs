using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AutonomousVehicle.SenseAndAct;
using Tinkerforge;

namespace AVControl
{
    public partial class Form1 : Form
    {
        private RadialDistanceSensor Sensor;
        private IPConnection Connection;

        public Form1()
        {
            InitializeComponent();

            var servo = new BrickServo("ap6zRki6edN");
            var distBricklet = new BrickletDistanceIR("8XU");
            Connection = new IPConnection("localhost", 4223);
            Connection.AddDevice(servo);
            Connection.AddDevice(distBricklet);

            servo.SetDegree(0, -9000, 9000);
            servo.SetVelocity(0, 2000);

            var map = new RadialDistanceMap(-45, 45, 1);
            this.radialDistanceMapForm1.DistanceMap = map;
            Sensor = new RadialDistanceSensor(map, servo, 0, distBricklet);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Connection.Destroy();
        }
    }
}
