namespace AVControl
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.MinDistanceLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.DistanceMapForm = new AutonomousVehicle.UserControls.RadialDistanceMapForm();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.StopButton = new System.Windows.Forms.Button();
            this.StartButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.CurrentLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.VoltageLabel = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ForwardSpeedBar = new System.Windows.Forms.TrackBar();
            this.ForwardSpeedLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.BackwardSpeedLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.BackwardSpeedBar = new System.Windows.Forms.TrackBar();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ForwardSpeedBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BackwardSpeedBar)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.MinDistanceLabel);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.DistanceMapForm);
            this.groupBox1.Location = new System.Drawing.Point(12, 201);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(290, 189);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Obstacles";
            // 
            // MinDistanceLabel
            // 
            this.MinDistanceLabel.AutoSize = true;
            this.MinDistanceLabel.Location = new System.Drawing.Point(250, 159);
            this.MinDistanceLabel.Name = "MinDistanceLabel";
            this.MinDistanceLabel.Size = new System.Drawing.Size(35, 13);
            this.MinDistanceLabel.TabIndex = 8;
            this.MinDistanceLabel.Text = "--- mm";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(185, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Closest";
            // 
            // DistanceMapForm
            // 
            this.DistanceMapForm.Location = new System.Drawing.Point(6, 19);
            this.DistanceMapForm.MaximumDistanceInMillimeters = 800;
            this.DistanceMapForm.MinimumDistanceInMillimeters = 70;
            this.DistanceMapForm.Name = "DistanceMapForm";
            this.DistanceMapForm.Size = new System.Drawing.Size(153, 153);
            this.DistanceMapForm.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BackwardSpeedLabel);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.BackwardSpeedBar);
            this.groupBox2.Controls.Add(this.ForwardSpeedLabel);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.ForwardSpeedBar);
            this.groupBox2.Controls.Add(this.StopButton);
            this.groupBox2.Controls.Add(this.StartButton);
            this.groupBox2.Location = new System.Drawing.Point(497, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 228);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Engine";
            // 
            // StopButton
            // 
            this.StopButton.Location = new System.Drawing.Point(45, 57);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(115, 23);
            this.StopButton.TabIndex = 1;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(45, 19);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(115, 23);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Voltage:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.CurrentLabel);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.VoltageLabel);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(12, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 100);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Power";
            // 
            // CurrentLabel
            // 
            this.CurrentLabel.AutoSize = true;
            this.CurrentLabel.Location = new System.Drawing.Point(71, 39);
            this.CurrentLabel.Name = "CurrentLabel";
            this.CurrentLabel.Size = new System.Drawing.Size(34, 13);
            this.CurrentLabel.TabIndex = 6;
            this.CurrentLabel.Text = "--- mA";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Current:";
            // 
            // VoltageLabel
            // 
            this.VoltageLabel.AutoSize = true;
            this.VoltageLabel.Location = new System.Drawing.Point(71, 16);
            this.VoltageLabel.Name = "VoltageLabel";
            this.VoltageLabel.Size = new System.Drawing.Size(34, 13);
            this.VoltageLabel.TabIndex = 4;
            this.VoltageLabel.Text = "--- mV";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ForwardSpeedBar
            // 
            this.ForwardSpeedBar.LargeChange = 50;
            this.ForwardSpeedBar.Location = new System.Drawing.Point(6, 110);
            this.ForwardSpeedBar.Maximum = 1000;
            this.ForwardSpeedBar.Name = "ForwardSpeedBar";
            this.ForwardSpeedBar.Size = new System.Drawing.Size(188, 45);
            this.ForwardSpeedBar.SmallChange = 5;
            this.ForwardSpeedBar.TabIndex = 2;
            this.ForwardSpeedBar.TickFrequency = 50;
            this.ForwardSpeedBar.Scroll += new System.EventHandler(this.ForwardSpeedBar_Scroll);
            // 
            // ForwardSpeedLabel
            // 
            this.ForwardSpeedLabel.AutoSize = true;
            this.ForwardSpeedLabel.Location = new System.Drawing.Point(101, 142);
            this.ForwardSpeedLabel.Name = "ForwardSpeedLabel";
            this.ForwardSpeedLabel.Size = new System.Drawing.Size(33, 13);
            this.ForwardSpeedLabel.TabIndex = 8;
            this.ForwardSpeedLabel.Text = "0.0 %";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Forward Speed:";
            // 
            // BackwardSpeedLabel
            // 
            this.BackwardSpeedLabel.AutoSize = true;
            this.BackwardSpeedLabel.Location = new System.Drawing.Point(101, 204);
            this.BackwardSpeedLabel.Name = "BackwardSpeedLabel";
            this.BackwardSpeedLabel.Size = new System.Drawing.Size(33, 13);
            this.BackwardSpeedLabel.TabIndex = 11;
            this.BackwardSpeedLabel.Text = "0.0 %";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 204);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Backward Speed:";
            // 
            // BackwardSpeedBar
            // 
            this.BackwardSpeedBar.LargeChange = 25;
            this.BackwardSpeedBar.Location = new System.Drawing.Point(6, 172);
            this.BackwardSpeedBar.Maximum = 500;
            this.BackwardSpeedBar.Name = "BackwardSpeedBar";
            this.BackwardSpeedBar.Size = new System.Drawing.Size(188, 45);
            this.BackwardSpeedBar.SmallChange = 5;
            this.BackwardSpeedBar.TabIndex = 9;
            this.BackwardSpeedBar.TickFrequency = 25;
            this.BackwardSpeedBar.Scroll += new System.EventHandler(this.BackwardSpeedBar_Scroll);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 402);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Simple Vehicle Control";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ForwardSpeedBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BackwardSpeedBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AutonomousVehicle.UserControls.RadialDistanceMapForm DistanceMapForm;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label VoltageLabel;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label CurrentLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label MinDistanceLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label ForwardSpeedLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar ForwardSpeedBar;
        private System.Windows.Forms.Label BackwardSpeedLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TrackBar BackwardSpeedBar;
    }
}

