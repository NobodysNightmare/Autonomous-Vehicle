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
        private SimpleDistanceDrivingStrategy DrivingStrategy;

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

            DistanceMapForm.DistanceMap = new RadialDistanceMap(-45, 45, 1);
            Sensor = new RadialDistanceSensor(DistanceMapForm.DistanceMap, servo, 2, distBricklet);

            DrivingStrategy = new SimpleDistanceDrivingStrategy(servo, 0, DistanceMapForm.DistanceMap);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            DrivingStrategy.Stop();
            Connection.Destroy();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            DrivingStrategy.Start();
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            DrivingStrategy.Stop();
        }
    }
}
