﻿namespace xWin.GUI
{
    partial class ConfigWindow
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.LeftStickRegions = new System.Windows.Forms.NumericUpDown();
            this.RightStickRegions = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.RightTriggerRegions = new System.Windows.Forms.NumericUpDown();
            this.LeftTriggerRegions = new System.Windows.Forms.NumericUpDown();
            this.LeftRadio = new System.Windows.Forms.RadioButton();
            this.RightRadio = new System.Windows.Forms.RadioButton();
            this.ControlMouse = new System.Windows.Forms.GroupBox();
            this.NoneRadio = new System.Windows.Forms.RadioButton();
            this.TriggerThreshold = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.ConfigName = new System.Windows.Forms.TextBox();
            this.Description = new System.Windows.Forms.TextBox();
            this.numericUpDown6 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown7 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown8 = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.Delay = new System.Windows.Forms.NumericUpDown();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Period = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.TCName = new System.Windows.Forms.TextBox();
            this.TCDescription = new System.Windows.Forms.TextBox();
            this.ButtonTextBox = new System.Windows.Forms.TextBox();
            this.EditButtons = new System.Windows.Forms.Button();
            this.StopBindingText = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.LeftStickRegions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightStickRegions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightTriggerRegions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftTriggerRegions)).BeginInit();
            this.ControlMouse.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TriggerThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown8)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Delay)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Period)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.StopBindingText.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(75, 13);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(581, 346);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(75, 365);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Add New Binding";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // LeftStickRegions
            // 
            this.LeftStickRegions.Location = new System.Drawing.Point(6, 39);
            this.LeftStickRegions.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.LeftStickRegions.Name = "LeftStickRegions";
            this.LeftStickRegions.Size = new System.Drawing.Size(39, 20);
            this.LeftStickRegions.TabIndex = 2;
            // 
            // RightStickRegions
            // 
            this.RightStickRegions.Location = new System.Drawing.Point(52, 39);
            this.RightStickRegions.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.RightStickRegions.Name = "RightStickRegions";
            this.RightStickRegions.Size = new System.Drawing.Size(39, 20);
            this.RightStickRegions.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Left         Right";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Left         Right";
            // 
            // RightTriggerRegions
            // 
            this.RightTriggerRegions.Location = new System.Drawing.Point(51, 41);
            this.RightTriggerRegions.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.RightTriggerRegions.Name = "RightTriggerRegions";
            this.RightTriggerRegions.Size = new System.Drawing.Size(39, 20);
            this.RightTriggerRegions.TabIndex = 10;
            // 
            // LeftTriggerRegions
            // 
            this.LeftTriggerRegions.Location = new System.Drawing.Point(6, 41);
            this.LeftTriggerRegions.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.LeftTriggerRegions.Name = "LeftTriggerRegions";
            this.LeftTriggerRegions.Size = new System.Drawing.Size(39, 20);
            this.LeftTriggerRegions.TabIndex = 9;
            // 
            // LeftRadio
            // 
            this.LeftRadio.AutoSize = true;
            this.LeftRadio.Location = new System.Drawing.Point(6, 42);
            this.LeftRadio.Name = "LeftRadio";
            this.LeftRadio.Size = new System.Drawing.Size(70, 17);
            this.LeftRadio.TabIndex = 13;
            this.LeftRadio.TabStop = true;
            this.LeftRadio.Text = "Left Stick";
            this.LeftRadio.UseVisualStyleBackColor = true;
            // 
            // RightRadio
            // 
            this.RightRadio.AutoSize = true;
            this.RightRadio.Location = new System.Drawing.Point(6, 65);
            this.RightRadio.Name = "RightRadio";
            this.RightRadio.Size = new System.Drawing.Size(77, 17);
            this.RightRadio.TabIndex = 14;
            this.RightRadio.TabStop = true;
            this.RightRadio.Text = "Right Stick";
            this.RightRadio.UseVisualStyleBackColor = true;
            // 
            // ControlMouse
            // 
            this.ControlMouse.Controls.Add(this.NoneRadio);
            this.ControlMouse.Controls.Add(this.LeftRadio);
            this.ControlMouse.Controls.Add(this.RightRadio);
            this.ControlMouse.Location = new System.Drawing.Point(13, 401);
            this.ControlMouse.Name = "ControlMouse";
            this.ControlMouse.Size = new System.Drawing.Size(101, 96);
            this.ControlMouse.TabIndex = 16;
            this.ControlMouse.TabStop = false;
            this.ControlMouse.Text = "Control Mouse";
            // 
            // NoneRadio
            // 
            this.NoneRadio.AutoSize = true;
            this.NoneRadio.Checked = true;
            this.NoneRadio.Location = new System.Drawing.Point(6, 19);
            this.NoneRadio.Name = "NoneRadio";
            this.NoneRadio.Size = new System.Drawing.Size(51, 17);
            this.NoneRadio.TabIndex = 15;
            this.NoneRadio.TabStop = true;
            this.NoneRadio.Text = "None";
            this.NoneRadio.UseVisualStyleBackColor = true;
            // 
            // TriggerThreshold
            // 
            this.TriggerThreshold.Location = new System.Drawing.Point(6, 76);
            this.TriggerThreshold.Maximum = new decimal(new int[] {
            254,
            0,
            0,
            0});
            this.TriggerThreshold.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.TriggerThreshold.Name = "TriggerThreshold";
            this.TriggerThreshold.Size = new System.Drawing.Size(84, 20);
            this.TriggerThreshold.TabIndex = 17;
            this.TriggerThreshold.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Threshold (1-254)";
            // 
            // ConfigName
            // 
            this.ConfigName.AcceptsReturn = true;
            this.ConfigName.Location = new System.Drawing.Point(434, 401);
            this.ConfigName.Name = "ConfigName";
            this.ConfigName.Size = new System.Drawing.Size(100, 20);
            this.ConfigName.TabIndex = 19;
            this.ConfigName.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Description
            // 
            this.Description.Location = new System.Drawing.Point(434, 439);
            this.Description.Name = "Description";
            this.Description.Size = new System.Drawing.Size(163, 20);
            this.Description.TabIndex = 20;
            // 
            // numericUpDown6
            // 
            this.numericUpDown6.Location = new System.Drawing.Point(79, 19);
            this.numericUpDown6.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.numericUpDown6.Name = "numericUpDown6";
            this.numericUpDown6.Size = new System.Drawing.Size(50, 20);
            this.numericUpDown6.TabIndex = 21;
            this.numericUpDown6.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // numericUpDown7
            // 
            this.numericUpDown7.Location = new System.Drawing.Point(79, 45);
            this.numericUpDown7.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.numericUpDown7.Name = "numericUpDown7";
            this.numericUpDown7.Size = new System.Drawing.Size(50, 20);
            this.numericUpDown7.TabIndex = 22;
            this.numericUpDown7.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // numericUpDown8
            // 
            this.numericUpDown8.Location = new System.Drawing.Point(79, 71);
            this.numericUpDown8.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.numericUpDown8.Name = "numericUpDown8";
            this.numericUpDown8.Size = new System.Drawing.Size(50, 20);
            this.numericUpDown8.TabIndex = 23;
            this.numericUpDown8.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.numericUpDown6);
            this.groupBox2.Controls.Add(this.numericUpDown8);
            this.groupBox2.Controls.Add(this.numericUpDown7);
            this.groupBox2.Location = new System.Drawing.Point(12, 494);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(142, 100);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Mouse Speed";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 78);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "Precision";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "Turbo";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Normal";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.LeftStickRegions);
            this.groupBox3.Controls.Add(this.RightStickRegions);
            this.groupBox3.Location = new System.Drawing.Point(129, 401);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(95, 67);
            this.groupBox3.TabIndex = 25;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Stick Regions";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.TriggerThreshold);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.LeftTriggerRegions);
            this.groupBox4.Controls.Add(this.RightTriggerRegions);
            this.groupBox4.Location = new System.Drawing.Point(240, 401);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(107, 100);
            this.groupBox4.TabIndex = 26;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Trigger Regions";
            this.groupBox4.Enter += new System.EventHandler(this.groupBox4_Enter);
            // 
            // Delay
            // 
            this.Delay.Location = new System.Drawing.Point(74, 27);
            this.Delay.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.Delay.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Delay.Name = "Delay";
            this.Delay.Size = new System.Drawing.Size(120, 20);
            this.Delay.TabIndex = 27;
            this.Delay.Value = new decimal(new int[] {
            400,
            0,
            0,
            0});
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.Period);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.Delay);
            this.groupBox5.Location = new System.Drawing.Point(160, 507);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(200, 77);
            this.groupBox5.TabIndex = 28;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Repeat Press";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "Period";
            // 
            // Period
            // 
            this.Period.Location = new System.Drawing.Point(74, 49);
            this.Period.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.Period.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Period.Name = "Period";
            this.Period.Size = new System.Drawing.Size(120, 20);
            this.Period.TabIndex = 29;
            this.Period.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Delay";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(363, 404);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 29;
            this.label9.Text = "Name:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(554, 399);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(129, 23);
            this.button2.TabIndex = 30;
            this.button2.Text = "Load From File";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(608, 437);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 31;
            this.button3.Text = "Save";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(363, 444);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 13);
            this.label10.TabIndex = 32;
            this.label10.Text = "Description";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.TCDescription);
            this.groupBox6.Controls.Add(this.TCName);
            this.groupBox6.Controls.Add(this.label13);
            this.groupBox6.Controls.Add(this.label12);
            this.groupBox6.Controls.Add(this.label11);
            this.groupBox6.Controls.Add(this.button6);
            this.groupBox6.Controls.Add(this.button5);
            this.groupBox6.Controls.Add(this.button4);
            this.groupBox6.Location = new System.Drawing.Point(366, 489);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(372, 121);
            this.groupBox6.TabIndex = 33;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Typing Configuraiton";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 54);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(60, 13);
            this.label13.TabIndex = 36;
            this.label13.Text = "Description";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(52, 28);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(0, 13);
            this.label12.TabIndex = 35;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 28);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 13);
            this.label11.TabIndex = 34;
            this.label11.Text = "Name:";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(237, 82);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(129, 23);
            this.button6.TabIndex = 33;
            this.button6.Text = "Edit";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(237, 51);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(129, 23);
            this.button5.TabIndex = 32;
            this.button5.Text = "Create New";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(237, 19);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(129, 23);
            this.button4.TabIndex = 31;
            this.button4.Text = "Load From File";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // TCName
            // 
            this.TCName.AcceptsReturn = true;
            this.TCName.Location = new System.Drawing.Point(68, 25);
            this.TCName.Name = "TCName";
            this.TCName.Size = new System.Drawing.Size(100, 20);
            this.TCName.TabIndex = 39;
            // 
            // TCDescription
            // 
            this.TCDescription.Location = new System.Drawing.Point(68, 51);
            this.TCDescription.Name = "TCDescription";
            this.TCDescription.Size = new System.Drawing.Size(163, 20);
            this.TCDescription.TabIndex = 40;
            // 
            // ButtonTextBox
            // 
            this.ButtonTextBox.Location = new System.Drawing.Point(6, 13);
            this.ButtonTextBox.MaximumSize = new System.Drawing.Size(100, 20);
            this.ButtonTextBox.MinimumSize = new System.Drawing.Size(100, 20);
            this.ButtonTextBox.Name = "ButtonTextBox";
            this.ButtonTextBox.ReadOnly = true;
            this.ButtonTextBox.Size = new System.Drawing.Size(100, 20);
            this.ButtonTextBox.TabIndex = 35;
            // 
            // EditButtons
            // 
            this.EditButtons.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.EditButtons.Location = new System.Drawing.Point(128, 13);
            this.EditButtons.Name = "EditButtons";
            this.EditButtons.Size = new System.Drawing.Size(21, 21);
            this.EditButtons.TabIndex = 34;
            this.EditButtons.Text = "+";
            this.EditButtons.UseVisualStyleBackColor = false;
            this.EditButtons.Click += new System.EventHandler(this.EditButtons_Click);
            // 
            // StopBindingText
            // 
            this.StopBindingText.Controls.Add(this.EditButtons);
            this.StopBindingText.Controls.Add(this.ButtonTextBox);
            this.StopBindingText.Location = new System.Drawing.Point(211, 361);
            this.StopBindingText.Name = "StopBindingText";
            this.StopBindingText.Size = new System.Drawing.Size(200, 34);
            this.StopBindingText.TabIndex = 36;
            this.StopBindingText.TabStop = false;
            this.StopBindingText.Text = "StopBinding";
            // 
            // ConfigWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 611);
            this.Controls.Add(this.StopBindingText);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.Description);
            this.Controls.Add(this.ConfigName);
            this.Controls.Add(this.ControlMouse);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "ConfigWindow";
            this.Text = "ConfigWindow";
            ((System.ComponentModel.ISupportInitialize)(this.LeftStickRegions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightStickRegions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightTriggerRegions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftTriggerRegions)).EndInit();
            this.ControlMouse.ResumeLayout(false);
            this.ControlMouse.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TriggerThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown8)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Delay)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Period)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.StopBindingText.ResumeLayout(false);
            this.StopBindingText.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown LeftStickRegions;
        private System.Windows.Forms.NumericUpDown RightStickRegions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown RightTriggerRegions;
        private System.Windows.Forms.NumericUpDown LeftTriggerRegions;
        private System.Windows.Forms.RadioButton LeftRadio;
        private System.Windows.Forms.RadioButton RightRadio;
        private System.Windows.Forms.GroupBox ControlMouse;
        private System.Windows.Forms.RadioButton NoneRadio;
        private System.Windows.Forms.NumericUpDown TriggerThreshold;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox ConfigName;
        private System.Windows.Forms.TextBox Description;
        private System.Windows.Forms.NumericUpDown numericUpDown6;
        private System.Windows.Forms.NumericUpDown numericUpDown7;
        private System.Windows.Forms.NumericUpDown numericUpDown8;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.NumericUpDown Delay;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown Period;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox TCDescription;
        private System.Windows.Forms.TextBox TCName;
        private System.Windows.Forms.TextBox ButtonTextBox;
        private System.Windows.Forms.Button EditButtons;
        private System.Windows.Forms.GroupBox StopBindingText;
    }
}