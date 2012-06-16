﻿using System;
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
        private IPConnection Connection;
        private IDrivingStrategy DrivingStrategy;
        private BrickServo ServoBrick;
        private BrickletDistanceIR DistanceBricklet;

        private IDistanceCollection Distances;
        private SimpleServoEngine Engine;

        public Form1()
        {
            InitializeComponent();
            InitializeDevices();
        }

        private void InitializeDevices()
        {
            ServoBrick = new BrickServo("ap6zRki6edN");
            DistanceBricklet = new BrickletDistanceIR("8XU");
            Connection = new IPConnection("localhost", 4223);
            try
            {
                Connection.AddDevice(ServoBrick);
                SetupServoBrick();
            }
            catch (Tinkerforge.TimeoutException)
            {
                //TODO: fallback-setup
            }

            try
            {
                Connection.AddDevice(DistanceBricklet);
                SetupDistanceBricklet();
            }
            catch (Tinkerforge.TimeoutException)
            {
                //TODO: fallback-setup
            }

            var drivingStrategy = new SimpleDistanceDrivingStrategy(Engine, Distances);
            drivingStrategy.MinimumDrivingDistance = 300;
            drivingStrategy.ReversalDistance = 110;
            this.DrivingStrategy = drivingStrategy;
            drivingStrategy.RefreshInterval = 50;
        }

        private void SetupServoBrick()
        {
            ServoBrick.SetDegree(0, -4500, 4500);
            ServoBrick.SetVelocity(0, 40000);

            ServoBrick.SetDegree(3, -500, 1000);
            ServoBrick.SetVelocity(3, 40000);

            Engine = new SimpleServoEngine(ServoBrick, 3);
            Engine.MaximumForwardSpeed = (short)ForwardSpeedBar.Value;
            Engine.MaximumBackwardSpeed = (short)-BackwardSpeedBar.Value;
            StartButton.Enabled = true;
            StopButton.Enabled = true;
            ForwardSpeedBar.Enabled = true;
            BackwardSpeedBar.Enabled = true;
        }

        private void SetupDistanceBricklet()
        {
            //DistanceMapForm.DistanceMap = new RadialDistanceMap(-45, 45, 1);
            //var sensor = new RadialDistanceSensor(DistanceMapForm.DistanceMap, ServoBrick, 0, distBricklet);
            //DistanceMapForm.EnableSensorIndicator(sensor);

            //Distances = DistanceMapForm.DistanceMap;
            var distances = new ImmediateDistanceSensorCollection();
            distances.AddSensor(DistanceBricklet);
            Distances = distances;
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
            MinDistanceLabel.Text = string.Format("{0} mm", Distances.ClosestDistanceInMillimeters);
        }

        private void ForwardSpeedBar_Scroll(object sender, EventArgs e)
        {
            ForwardSpeedLabel.Text = string.Format("{0} %", ForwardSpeedBar.Value / 10.0);
            Engine.MaximumForwardSpeed = (short)ForwardSpeedBar.Value;
        }

        private void BackwardSpeedBar_Scroll(object sender, EventArgs e)
        {
            BackwardSpeedLabel.Text = string.Format("{0} %", BackwardSpeedBar.Value / 5.0);
            Engine.MaximumBackwardSpeed = (short)-BackwardSpeedBar.Value;
        }
    }
}
