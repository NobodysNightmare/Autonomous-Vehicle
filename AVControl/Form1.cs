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
using AutonomousVehicle.SenseAndAct.Distance;
using AutonomousVehicle.SenseAndAct.Driving;

namespace AVControl
{
    public partial class Form1 : Form
    {
        private RadialDistanceSensor Sensor;
        private IPConnection Connection;
        private IDrivingStrategy DrivingStrategy;
        private BrickServo ServoBrick;

        public Form1()
        {
            InitializeComponent();

            ServoBrick = new BrickServo("ap6zRki6edN");
            var distBricklet = new BrickletDistanceIR("8XU");
            Connection = new IPConnection("localhost", 4223);
            Connection.AddDevice(ServoBrick);
            Connection.AddDevice(distBricklet);

            ServoBrick.SetDegree(0, -4500, 4500);
            ServoBrick.SetVelocity(0, 40000);

            ServoBrick.SetDegree(3, -500, 1000);
            ServoBrick.SetVelocity(3, 40000);

            DistanceMapForm.DistanceMap = new RadialDistanceMap(-45, 45, 1);
            //Sensor = new RadialDistanceSensor(DistanceMapForm.DistanceMap, ServoBrick, 0, distBricklet);
            //DistanceMapForm.EnableSensorIndicator(Sensor);

            //var distances = DistanceMapForm.DistanceMap;
            var distances = new ImmediateDistanceSensorCollection();
            distances.AddSensor(distBricklet);

            var engine = new SimpleServoEngine(ServoBrick, 3);
            engine.MaximumForwardSpeed = 150;
            engine.MaximumBackwardSpeed = -175;
            var drivingStrategy = new SimpleDistanceDrivingStrategy(engine, distances);
            drivingStrategy.MinimumDrivingDistance = 300;
            drivingStrategy.ReversalDistance = 100;
            this.DrivingStrategy = drivingStrategy;
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            VoltageLabel.Text = string.Format("{0} mV", ServoBrick.GetExternalInputVoltage());
            CurrentLabel.Text = string.Format("{0} mA", ServoBrick.GetOverallCurrent());
        }
    }
}
