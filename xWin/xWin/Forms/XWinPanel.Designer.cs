namespace xWin.Forms
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ControllerPanel.SuspendLayout();
            this.controllersPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ControllerPanel
            // 
            this.ControllerPanel.Controls.Add(this.controllersPanel);
            this.ControllerPanel.Controls.Add(this.Settings);
            this.ControllerPanel.Location = new System.Drawing.Point(20, 21);
            this.ControllerPanel.Margin = new System.Windows.Forms.Padding(4);
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
            this.controllersPanel.Margin = new System.Windows.Forms.Padding(4);
            this.controllersPanel.Name = "controllersPanel";
            this.controllersPanel.Padding = new System.Windows.Forms.Padding(4);
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
            this.Controller4.Margin = new System.Windows.Forms.Padding(4);
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
            this.Controller3.Margin = new System.Windows.Forms.Padding(4);
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
            this.Controller2.Margin = new System.Windows.Forms.Padding(4);
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
            this.Controller1.Margin = new System.Windows.Forms.Padding(4);
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
            this.Settings.Margin = new System.Windows.Forms.Padding(4);
            this.Settings.Name = "Settings";
            this.Settings.Padding = new System.Windows.Forms.Padding(4);
            this.Settings.Size = new System.Drawing.Size(1192, 676);
            this.Settings.TabIndex = 1;
            this.Settings.Text = "Settings";
            this.Settings.UseVisualStyleBackColor = true;
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
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "XWinPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XWin Panel";
            this.Load += new System.EventHandler(this.XWinPanel_Load);
            this.ControllerPanel.ResumeLayout(false);
            this.controllersPanel.ResumeLayout(false);
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
    }
}