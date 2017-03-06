namespace xWin.Forms
{
    partial class xWinPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(xWinPanel));
            this.ControllerPanel = new System.Windows.Forms.TabControl();
            this.controllersPanel = new System.Windows.Forms.TabPage();
            this.Controller4 = new System.Windows.Forms.Button();
            this.Controller3 = new System.Windows.Forms.Button();
            this.Controller2 = new System.Windows.Forms.Button();
            this.Controller1 = new System.Windows.Forms.Button();
            this.options = new System.Windows.Forms.TabPage();
            this.ControllerPanel.SuspendLayout();
            this.controllersPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ControllerPanel
            // 
            this.ControllerPanel.Controls.Add(this.controllersPanel);
            this.ControllerPanel.Controls.Add(this.options);
            this.ControllerPanel.Location = new System.Drawing.Point(20, 21);
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
            this.controllersPanel.Name = "controllersPanel";
            this.controllersPanel.Padding = new System.Windows.Forms.Padding(3);
            this.controllersPanel.Size = new System.Drawing.Size(1192, 676);
            this.controllersPanel.TabIndex = 0;
            this.controllersPanel.Text = "Controllers";
            this.controllersPanel.UseVisualStyleBackColor = true;
            // 
            // Controller4
            // 
            this.Controller4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(51)))));
            this.Controller4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Controller4.Location = new System.Drawing.Point(705, 373);
            this.Controller4.Name = "Controller4";
            this.Controller4.Size = new System.Drawing.Size(303, 136);
            this.Controller4.TabIndex = 7;
            this.Controller4.Text = "Controller 4  \r\nNot Connected";
            this.Controller4.UseVisualStyleBackColor = false;
            this.Controller4.UseWaitCursor = true;
            this.Controller4.Click += new System.EventHandler(this.Controller4_Click);
            // 
            // Controller3
            // 
            this.Controller3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(51)))));
            this.Controller3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.Controller3.Location = new System.Drawing.Point(220, 373);
            this.Controller3.Name = "Controller3";
            this.Controller3.Size = new System.Drawing.Size(302, 136);
            this.Controller3.TabIndex = 6;
            this.Controller3.Text = "Controller 3 \r\nNot Connected";
            this.Controller3.UseVisualStyleBackColor = false;
            this.Controller3.Click += new System.EventHandler(this.Controller3_Click);
            // 
            // Controller2
            // 
            this.Controller2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(51)))));
            this.Controller2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Controller2.Location = new System.Drawing.Point(705, 112);
            this.Controller2.Name = "Controller2";
            this.Controller2.Size = new System.Drawing.Size(303, 136);
            this.Controller2.TabIndex = 5;
            this.Controller2.Text = "Controller 2  \r\nNot Connected";
            this.Controller2.UseVisualStyleBackColor = false;
            this.Controller2.Click += new System.EventHandler(this.Controller2_Click);
            // 
            // Controller1
            // 
            this.Controller1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(51)))));
            this.Controller1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.Controller1.Location = new System.Drawing.Point(220, 112);
            this.Controller1.Name = "Controller1";
            this.Controller1.Size = new System.Drawing.Size(302, 136);
            this.Controller1.TabIndex = 4;
            this.Controller1.Text = "Controller 1 \r\nNot Connected";
            this.Controller1.UseVisualStyleBackColor = false;
            this.Controller1.Click += new System.EventHandler(this.Controller1_Click);
            // 
            // options
            // 
            this.options.Location = new System.Drawing.Point(8, 39);
            this.options.Name = "options";
            this.options.Padding = new System.Windows.Forms.Padding(3);
            this.options.Size = new System.Drawing.Size(1192, 676);
            this.options.TabIndex = 1;
            this.options.Text = "Options";
            this.options.UseVisualStyleBackColor = true;
            // 
            // xWinPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1247, 766);
            this.Controls.Add(this.ControllerPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "xWinPanel";
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
        private System.Windows.Forms.TabPage options;
    }
}