namespace xWin.GUI
{
    partial class MainWindow
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
            this.CalibrateLeft = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LXCenter = new System.Windows.Forms.TextBox();
            this.LYCenter = new System.Windows.Forms.TextBox();
            this.Settings = new System.Windows.Forms.GroupBox();
            this.DeadzonePicker = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.CalibrateRight = new System.Windows.Forms.Button();
            this.RYCenter = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.RXCenter = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.updateCC = new System.Windows.Forms.Button();
            this.ConfigName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ConfigDescription = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.EditConfig = new System.Windows.Forms.Button();
            this.Settings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DeadzonePicker)).BeginInit();
            this.SuspendLayout();
            // 
            // CalibrateLeft
            // 
            this.CalibrateLeft.Location = new System.Drawing.Point(41, 97);
            this.CalibrateLeft.Name = "CalibrateLeft";
            this.CalibrateLeft.Size = new System.Drawing.Size(75, 23);
            this.CalibrateLeft.TabIndex = 0;
            this.CalibrateLeft.Text = "Calibrate";
            this.CalibrateLeft.UseVisualStyleBackColor = true;
            this.CalibrateLeft.Click += new System.EventHandler(this.CalibrateLeft_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "X-center";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Y-center";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // LXCenter
            // 
            this.LXCenter.Location = new System.Drawing.Point(60, 45);
            this.LXCenter.Name = "LXCenter";
            this.LXCenter.ReadOnly = true;
            this.LXCenter.Size = new System.Drawing.Size(100, 20);
            this.LXCenter.TabIndex = 3;
            this.LXCenter.Text = "0";
            // 
            // LYCenter
            // 
            this.LYCenter.Location = new System.Drawing.Point(60, 71);
            this.LYCenter.Name = "LYCenter";
            this.LYCenter.ReadOnly = true;
            this.LYCenter.Size = new System.Drawing.Size(100, 20);
            this.LYCenter.TabIndex = 4;
            this.LYCenter.Text = "0";
            // 
            // Settings
            // 
            this.Settings.Controls.Add(this.updateCC);
            this.Settings.Controls.Add(this.label5);
            this.Settings.Controls.Add(this.CalibrateRight);
            this.Settings.Controls.Add(this.RYCenter);
            this.Settings.Controls.Add(this.label6);
            this.Settings.Controls.Add(this.RXCenter);
            this.Settings.Controls.Add(this.label7);
            this.Settings.Controls.Add(this.label4);
            this.Settings.Controls.Add(this.label3);
            this.Settings.Controls.Add(this.DeadzonePicker);
            this.Settings.Controls.Add(this.CalibrateLeft);
            this.Settings.Controls.Add(this.LYCenter);
            this.Settings.Controls.Add(this.label1);
            this.Settings.Controls.Add(this.LXCenter);
            this.Settings.Controls.Add(this.label2);
            this.Settings.Location = new System.Drawing.Point(161, 12);
            this.Settings.Name = "Settings";
            this.Settings.Size = new System.Drawing.Size(355, 189);
            this.Settings.TabIndex = 5;
            this.Settings.TabStop = false;
            this.Settings.Text = "Controller Settings";
            this.Settings.Enter += new System.EventHandler(this.Settings_Enter);
            // 
            // DeadzonePicker
            // 
            this.DeadzonePicker.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.DeadzonePicker.Location = new System.Drawing.Point(60, 163);
            this.DeadzonePicker.Maximum = new decimal(new int[] {
            15000,
            0,
            0,
            0});
            this.DeadzonePicker.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.DeadzonePicker.Name = "DeadzonePicker";
            this.DeadzonePicker.Size = new System.Drawing.Size(66, 20);
            this.DeadzonePicker.TabIndex = 5;
            this.DeadzonePicker.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Stick Deadzone";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Left Stick Center";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(221, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Right Stick Center";
            // 
            // CalibrateRight
            // 
            this.CalibrateRight.Location = new System.Drawing.Point(224, 97);
            this.CalibrateRight.Name = "CalibrateRight";
            this.CalibrateRight.Size = new System.Drawing.Size(75, 23);
            this.CalibrateRight.TabIndex = 8;
            this.CalibrateRight.Text = "Calibrate";
            this.CalibrateRight.UseVisualStyleBackColor = true;
            this.CalibrateRight.Click += new System.EventHandler(this.CalibrateRight_Click);
            // 
            // RYCenter
            // 
            this.RYCenter.Location = new System.Drawing.Point(243, 71);
            this.RYCenter.Name = "RYCenter";
            this.RYCenter.ReadOnly = true;
            this.RYCenter.Size = new System.Drawing.Size(100, 20);
            this.RYCenter.TabIndex = 12;
            this.RYCenter.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(190, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "X-center";
            // 
            // RXCenter
            // 
            this.RXCenter.Location = new System.Drawing.Point(243, 45);
            this.RXCenter.Name = "RXCenter";
            this.RXCenter.ReadOnly = true;
            this.RXCenter.Size = new System.Drawing.Size(100, 20);
            this.RXCenter.TabIndex = 11;
            this.RXCenter.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(190, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Y-center";
            // 
            // updateCC
            // 
            this.updateCC.Location = new System.Drawing.Point(224, 160);
            this.updateCC.Name = "updateCC";
            this.updateCC.Size = new System.Drawing.Size(119, 23);
            this.updateCC.TabIndex = 14;
            this.updateCC.Text = "Update Settings";
            this.updateCC.UseVisualStyleBackColor = true;
            this.updateCC.Click += new System.EventHandler(this.updateCC_Click);
            // 
            // ConfigName
            // 
            this.ConfigName.Location = new System.Drawing.Point(78, 227);
            this.ConfigName.Name = "ConfigName";
            this.ConfigName.ReadOnly = true;
            this.ConfigName.Size = new System.Drawing.Size(100, 20);
            this.ConfigName.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(37, 230);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Name";
            // 
            // ConfigDescription
            // 
            this.ConfigDescription.Location = new System.Drawing.Point(78, 254);
            this.ConfigDescription.Name = "ConfigDescription";
            this.ConfigDescription.ReadOnly = true;
            this.ConfigDescription.Size = new System.Drawing.Size(100, 20);
            this.ConfigDescription.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 257);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Description";
            // 
            // EditConfig
            // 
            this.EditConfig.Location = new System.Drawing.Point(54, 280);
            this.EditConfig.Name = "EditConfig";
            this.EditConfig.Size = new System.Drawing.Size(75, 23);
            this.EditConfig.TabIndex = 10;
            this.EditConfig.Text = "Edit";
            this.EditConfig.UseVisualStyleBackColor = true;
            this.EditConfig.Click += new System.EventHandler(this.EditConfig_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 394);
            this.Controls.Add(this.EditConfig);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.ConfigDescription);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.ConfigName);
            this.Controls.Add(this.Settings);
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.Settings.ResumeLayout(false);
            this.Settings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DeadzonePicker)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CalibrateLeft;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox LXCenter;
        private System.Windows.Forms.TextBox LYCenter;
        private System.Windows.Forms.GroupBox Settings;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown DeadzonePicker;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button CalibrateRight;
        private System.Windows.Forms.TextBox RYCenter;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox RXCenter;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button updateCC;
        private System.Windows.Forms.TextBox ConfigName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox ConfigDescription;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button EditConfig;
    }
}