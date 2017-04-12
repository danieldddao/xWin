﻿namespace xWin.Forms
{
    partial class XWinPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XWinPanel));
            this.ControllerPanel = new System.Windows.Forms.TabControl();
            this.controllersPanel = new System.Windows.Forms.TabPage();
            this.Controller4 = new System.Windows.Forms.Button();
            this.Controller3 = new System.Windows.Forms.Button();
            this.Controller2 = new System.Windows.Forms.Button();
            this.Controller1 = new System.Windows.Forms.Button();
            this.Settings = new System.Windows.Forms.TabPage();
            this.log = new System.Windows.Forms.TabPage();
            this.openLogFileButton = new System.Windows.Forms.Button();
            this.clearLogsButton = new System.Windows.Forms.Button();
            this.debugModeCheckbox = new System.Windows.Forms.CheckBox();
            this.logListView = new System.Windows.Forms.ListView();
            this.dateHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.levelHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ClassHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MessageHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ControllerPanel.SuspendLayout();
            this.controllersPanel.SuspendLayout();
            this.log.SuspendLayout();
            this.SuspendLayout();
            // 
            // ControllerPanel
            // 
            this.ControllerPanel.Controls.Add(this.controllersPanel);
            this.ControllerPanel.Controls.Add(this.Settings);
            this.ControllerPanel.Controls.Add(this.log);
            this.ControllerPanel.Location = new System.Drawing.Point(20, 21);
            this.ControllerPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ControllerPanel.Multiline = true;
            this.ControllerPanel.Name = "ControllerPanel";
            this.ControllerPanel.SelectedIndex = 0;
            this.ControllerPanel.Size = new System.Drawing.Size(1208, 723);
            this.ControllerPanel.TabIndex = 0;
            // 
            // controllersPanel
            // 
            this.controllersPanel.Controls.Add(this.Controller4);
            this.controllersPanel.Controls.Add(this.Controller3);
            this.controllersPanel.Controls.Add(this.Controller2);
            this.controllersPanel.Controls.Add(this.Controller1);
            this.controllersPanel.Location = new System.Drawing.Point(8, 39);
            this.controllersPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.controllersPanel.Name = "controllersPanel";
            this.controllersPanel.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.controllersPanel.Size = new System.Drawing.Size(1192, 676);
            this.controllersPanel.TabIndex = 0;
            this.controllersPanel.Text = "Controllers";
            this.controllersPanel.UseVisualStyleBackColor = true;
            // 
            // Controller4
            // 
            this.Controller4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(51)))));
            this.Controller4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Controller4.Location = new System.Drawing.Point(704, 373);
            this.Controller4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Controller4.Name = "Controller4";
            this.Controller4.Size = new System.Drawing.Size(304, 137);
            this.Controller4.TabIndex = 7;
            this.Controller4.Text = "Controller 4";
            this.Controller4.UseVisualStyleBackColor = false;
            this.Controller4.UseWaitCursor = true;
            this.Controller4.Click += new System.EventHandler(this.Controller4_Click);
            // 
            // Controller3
            // 
            this.Controller3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(51)))));
            this.Controller3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.Controller3.Location = new System.Drawing.Point(220, 373);
            this.Controller3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Controller3.Name = "Controller3";
            this.Controller3.Size = new System.Drawing.Size(302, 137);
            this.Controller3.TabIndex = 6;
            this.Controller3.Text = "Controller 3";
            this.Controller3.UseVisualStyleBackColor = false;
            this.Controller3.Click += new System.EventHandler(this.Controller3_Click);
            // 
            // Controller2
            // 
            this.Controller2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(51)))));
            this.Controller2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Controller2.Location = new System.Drawing.Point(704, 112);
            this.Controller2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Controller2.Name = "Controller2";
            this.Controller2.Size = new System.Drawing.Size(304, 137);
            this.Controller2.TabIndex = 5;
            this.Controller2.Text = "Controller 2";
            this.Controller2.UseVisualStyleBackColor = false;
            this.Controller2.Click += new System.EventHandler(this.Controller2_Click);
            // 
            // Controller1
            // 
            this.Controller1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(51)))));
            this.Controller1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.Controller1.Location = new System.Drawing.Point(220, 112);
            this.Controller1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Controller1.Name = "Controller1";
            this.Controller1.Size = new System.Drawing.Size(302, 137);
            this.Controller1.TabIndex = 4;
            this.Controller1.Text = "Controller 1";
            this.Controller1.UseVisualStyleBackColor = false;
            this.Controller1.Click += new System.EventHandler(this.Controller1_Click);
            // 
            // Settings
            // 
            this.Settings.Location = new System.Drawing.Point(8, 39);
            this.Settings.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Settings.Name = "Settings";
            this.Settings.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Settings.Size = new System.Drawing.Size(1192, 676);
            this.Settings.TabIndex = 1;
            this.Settings.Text = "Settings";
            this.Settings.UseVisualStyleBackColor = true;
            // 
            // log
            // 
            this.log.Controls.Add(this.openLogFileButton);
            this.log.Controls.Add(this.clearLogsButton);
            this.log.Controls.Add(this.debugModeCheckbox);
            this.log.Controls.Add(this.logListView);
            this.log.Location = new System.Drawing.Point(8, 39);
            this.log.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.log.Name = "log";
            this.log.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.log.Size = new System.Drawing.Size(1192, 676);
            this.log.TabIndex = 2;
            this.log.Text = "Log";
            this.log.UseVisualStyleBackColor = true;
            // 
            // openLogFileButton
            // 
            this.openLogFileButton.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.openLogFileButton.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openLogFileButton.Location = new System.Drawing.Point(934, 610);
            this.openLogFileButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.openLogFileButton.Name = "openLogFileButton";
            this.openLogFileButton.Size = new System.Drawing.Size(214, 52);
            this.openLogFileButton.TabIndex = 3;
            this.openLogFileButton.Text = "Open Log File";
            this.openLogFileButton.UseVisualStyleBackColor = false;
            this.openLogFileButton.Click += new System.EventHandler(this.openLogFileButton_Click);
            // 
            // clearLogsButton
            // 
            this.clearLogsButton.Font = new System.Drawing.Font("Arial", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearLogsButton.Location = new System.Drawing.Point(372, 610);
            this.clearLogsButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.clearLogsButton.Name = "clearLogsButton";
            this.clearLogsButton.Size = new System.Drawing.Size(474, 52);
            this.clearLogsButton.TabIndex = 2;
            this.clearLogsButton.Text = "Clear All Logs";
            this.clearLogsButton.UseVisualStyleBackColor = true;
            this.clearLogsButton.Click += new System.EventHandler(this.clearLogsButton_Click);
            // 
            // debugModeCheckbox
            // 
            this.debugModeCheckbox.AutoSize = true;
            this.debugModeCheckbox.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.debugModeCheckbox.Location = new System.Drawing.Point(36, 623);
            this.debugModeCheckbox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.debugModeCheckbox.Name = "debugModeCheckbox";
            this.debugModeCheckbox.Size = new System.Drawing.Size(281, 35);
            this.debugModeCheckbox.TabIndex = 1;
            this.debugModeCheckbox.Text = "Enable Debug Mode";
            this.debugModeCheckbox.UseVisualStyleBackColor = true;
            this.debugModeCheckbox.CheckedChanged += new System.EventHandler(this.debugModeCheckbox_CheckedChanged);
            // 
            // logListView
            // 
            this.logListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.dateHeader,
            this.levelHeader,
            this.ClassHeader,
            this.MessageHeader});
            this.logListView.FullRowSelect = true;
            this.logListView.GridLines = true;
            this.logListView.Location = new System.Drawing.Point(0, 0);
            this.logListView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.logListView.Name = "logListView";
            this.logListView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.logListView.Size = new System.Drawing.Size(1188, 591);
            this.logListView.TabIndex = 0;
            this.logListView.UseCompatibleStateImageBehavior = false;
            this.logListView.View = System.Windows.Forms.View.Details;
            // 
            // dateHeader
            // 
            this.dateHeader.Text = "Date";
            this.dateHeader.Width = 171;
            // 
            // levelHeader
            // 
            this.levelHeader.Text = "Level";
            this.levelHeader.Width = 96;
            // 
            // ClassHeader
            // 
            this.ClassHeader.Text = "Class";
            this.ClassHeader.Width = 115;
            // 
            // MessageHeader
            // 
            this.MessageHeader.Text = "Message";
            this.MessageHeader.Width = 763;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // XWinPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1248, 765);
            this.Controls.Add(this.ControllerPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "XWinPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XWin Panel";
            this.Load += new System.EventHandler(this.XWinPanel_Load);
            this.ControllerPanel.ResumeLayout(false);
            this.controllersPanel.ResumeLayout(false);
            this.log.ResumeLayout(false);
            this.log.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl ControllerPanel;
        private System.Windows.Forms.TabPage controllersPanel;
        private System.Windows.Forms.Button Controller4;
        private System.Windows.Forms.Button Controller3;
        private System.Windows.Forms.Button Controller2;
        private System.Windows.Forms.Button Controller1;
        private System.Windows.Forms.TabPage Settings;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TabPage log;
        private System.Windows.Forms.ListView logListView;
        private System.Windows.Forms.ColumnHeader dateHeader;
        private System.Windows.Forms.ColumnHeader levelHeader;
        private System.Windows.Forms.ColumnHeader ClassHeader;
        private System.Windows.Forms.ColumnHeader MessageHeader;
        private System.Windows.Forms.Button clearLogsButton;
        private System.Windows.Forms.CheckBox debugModeCheckbox;
        private System.Windows.Forms.Button openLogFileButton;
    }
}