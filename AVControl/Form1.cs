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
using AutonomousVehicle.GUI;

namespace AVControl
{
    public partial class Form1 : Form
    {
        private IPConnection Connection;
        private IDrivingStrategy DrivingStrategy;
        private BrickServo ServoBrick;
        private BrickletDistanceIR DistanceBricklet;

        private IDistanceSensor Distances;
        private SimpleServoEngine Engine;

        public Form1()
        {
            InitializeComponent();
            InitializeDevices();
        }

        private void InitializeDevices()
        {
            Connection = new IPConnection();
            Connection.Connect("localhost", 4223);
            
            ServoBrick = new BrickServo("ap6zRki6edN", Connection);
            SetupServoBrick();
            DistanceBricklet = new BrickletDistanceIR("8XU", Connection);
            var distanceCollection = new ClosestDistanceSensorCollection();
            distanceCollection.AddSensor(new ImmediateDistanceIRSensor(DistanceBricklet));
            Distances = distanceCollection;

            var drivingStrategy = new SimpleDistanceDrivingStrategy(Engine, Distances);
            drivingStrategy.MinimumDrivingDistance = 30.Centimeters();
            drivingStrategy.ReversalDistance = 11.Centimeters();
            drivingStrategy.RefreshInterval = 10;
            this.DrivingStrategy = drivingStrategy;
        }

        private void SetupServoBrick()
        {
            ServoBrick.SetDegree(0, -4500, 4500);
            ServoBrick.SetVelocity(0, 40000);


            short escMax = 700;
            short escMin = -300;
            ServoBrick.SetDegree(3, escMin, escMax);
            ServoBrick.SetVelocity(3, ushort.MaxValue);
            ForwardSpeedBar.Maximum = escMax;
            BackwardSpeedBar.Maximum = Math.Abs(escMin);

            Engine = new SimpleServoEngine(ServoBrick, 3);
            Engine.MaximumForwardSpeed = (short)ForwardSpeedBar.Value;
            Engine.MaximumBackwardSpeed = (short)-BackwardSpeedBar.Value;
            StartButton.Enabled = true;
            StopButton.Enabled = true;
            ForwardSpeedBar.Enabled = true;
            BackwardSpeedBar.Enabled = true;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            DrivingStrategy.Stop();
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
            MinDistanceLabel.Text =  Distances.Distance.ToString();
        }

        private void ForwardSpeedBar_Scroll(object sender, EventArgs e)
        {
            ForwardSpeedLabel.Text = string.Format("{0} %", Math.Round(ForwardSpeedBar.Value / 7.0, 1));
            Engine.MaximumForwardSpeed = (short)ForwardSpeedBar.Value;
        }

        private void BackwardSpeedBar_Scroll(object sender, EventArgs e)
        {
            BackwardSpeedLabel.Text = string.Format("{0} %", Math.Round(BackwardSpeedBar.Value / 3.0, 1));
            Engine.MaximumBackwardSpeed = (short)-BackwardSpeedBar.Value;
        }
    }
}
