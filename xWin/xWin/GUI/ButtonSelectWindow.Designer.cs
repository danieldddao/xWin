namespace xWin.GUI
{
    partial class ButtonSelectWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ButtonSelectWindow));
            this.controllerPanel = new System.Windows.Forms.Panel();
            this.confirm = new System.Windows.Forms.Button();
            this.LeftStickRegions = new System.Windows.Forms.ComboBox();
            this.RightStickRegions = new System.Windows.Forms.ComboBox();
            this.RightTriggerRegions = new System.Windows.Forms.ComboBox();
            this.LeftTriggerRegions = new System.Windows.Forms.ComboBox();
            this.LeftThumb = new System.Windows.Forms.CheckBox();
            this.RightThumb = new System.Windows.Forms.CheckBox();
            this.Start = new System.Windows.Forms.CheckBox();
            this.Back = new System.Windows.Forms.CheckBox();
            this.Y = new System.Windows.Forms.CheckBox();
            this.B = new System.Windows.Forms.CheckBox();
            this.X = new System.Windows.Forms.CheckBox();
            this.A = new System.Windows.Forms.CheckBox();
            this.DLeft = new System.Windows.Forms.CheckBox();
            this.DDown = new System.Windows.Forms.CheckBox();
            this.DRight = new System.Windows.Forms.CheckBox();
            this.DUp = new System.Windows.Forms.CheckBox();
            this.RightShoulder = new System.Windows.Forms.CheckBox();
            this.LeftShoulder = new System.Windows.Forms.CheckBox();
            this.controllerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // controllerPanel
            // 
            this.controllerPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("controllerPanel.BackgroundImage")));
            this.controllerPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.controllerPanel.Controls.Add(this.confirm);
            this.controllerPanel.Controls.Add(this.LeftStickRegions);
            this.controllerPanel.Controls.Add(this.RightStickRegions);
            this.controllerPanel.Controls.Add(this.RightTriggerRegions);
            this.controllerPanel.Controls.Add(this.LeftTriggerRegions);
            this.controllerPanel.Controls.Add(this.LeftThumb);
            this.controllerPanel.Controls.Add(this.RightThumb);
            this.controllerPanel.Controls.Add(this.Start);
            this.controllerPanel.Controls.Add(this.Back);
            this.controllerPanel.Controls.Add(this.Y);
            this.controllerPanel.Controls.Add(this.B);
            this.controllerPanel.Controls.Add(this.X);
            this.controllerPanel.Controls.Add(this.A);
            this.controllerPanel.Controls.Add(this.DLeft);
            this.controllerPanel.Controls.Add(this.DDown);
            this.controllerPanel.Controls.Add(this.DRight);
            this.controllerPanel.Controls.Add(this.DUp);
            this.controllerPanel.Controls.Add(this.RightShoulder);
            this.controllerPanel.Controls.Add(this.LeftShoulder);
            this.controllerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controllerPanel.Location = new System.Drawing.Point(0, 0);
            this.controllerPanel.Margin = new System.Windows.Forms.Padding(2);
            this.controllerPanel.Name = "controllerPanel";
            this.controllerPanel.Size = new System.Drawing.Size(502, 332);
            this.controllerPanel.TabIndex = 1;
            // 
            // confirm
            // 
            this.confirm.Location = new System.Drawing.Point(215, 297);
            this.confirm.Name = "confirm";
            this.confirm.Size = new System.Drawing.Size(75, 23);
            this.confirm.TabIndex = 18;
            this.confirm.Text = "CONFIRM";
            this.confirm.UseVisualStyleBackColor = true;
            this.confirm.Click += new System.EventHandler(this.confirm_Click);
            // 
            // LeftStickRegions
            // 
            this.LeftStickRegions.FormattingEnabled = true;
            this.LeftStickRegions.Location = new System.Drawing.Point(55, 151);
            this.LeftStickRegions.Name = "LeftStickRegions";
            this.LeftStickRegions.Size = new System.Drawing.Size(84, 21);
            this.LeftStickRegions.TabIndex = 17;
            // 
            // RightStickRegions
            // 
            this.RightStickRegions.FormattingEnabled = true;
            this.RightStickRegions.Location = new System.Drawing.Point(350, 199);
            this.RightStickRegions.Name = "RightStickRegions";
            this.RightStickRegions.Size = new System.Drawing.Size(84, 21);
            this.RightStickRegions.TabIndex = 16;
            // 
            // RightTriggerRegions
            // 
            this.RightTriggerRegions.FormattingEnabled = true;
            this.RightTriggerRegions.Location = new System.Drawing.Point(378, 3);
            this.RightTriggerRegions.Name = "RightTriggerRegions";
            this.RightTriggerRegions.Size = new System.Drawing.Size(121, 21);
            this.RightTriggerRegions.TabIndex = 15;
            // 
            // LeftTriggerRegions
            // 
            this.LeftTriggerRegions.FormattingEnabled = true;
            this.LeftTriggerRegions.Location = new System.Drawing.Point(3, 3);
            this.LeftTriggerRegions.Name = "LeftTriggerRegions";
            this.LeftTriggerRegions.Size = new System.Drawing.Size(121, 21);
            this.LeftTriggerRegions.TabIndex = 14;
            // 
            // LeftThumb
            // 
            this.LeftThumb.AutoSize = true;
            this.LeftThumb.BackColor = System.Drawing.Color.Transparent;
            this.LeftThumb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LeftThumb.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.LeftThumb.FlatAppearance.BorderSize = 5;
            this.LeftThumb.ForeColor = System.Drawing.Color.Transparent;
            this.LeftThumb.Location = new System.Drawing.Point(110, 105);
            this.LeftThumb.MinimumSize = new System.Drawing.Size(20, 20);
            this.LeftThumb.Name = "LeftThumb";
            this.LeftThumb.Size = new System.Drawing.Size(20, 20);
            this.LeftThumb.TabIndex = 13;
            this.LeftThumb.UseVisualStyleBackColor = false;
            // 
            // RightThumb
            // 
            this.RightThumb.AutoSize = true;
            this.RightThumb.BackColor = System.Drawing.Color.Transparent;
            this.RightThumb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RightThumb.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.RightThumb.FlatAppearance.BorderSize = 5;
            this.RightThumb.ForeColor = System.Drawing.Color.Transparent;
            this.RightThumb.Location = new System.Drawing.Point(308, 172);
            this.RightThumb.MinimumSize = new System.Drawing.Size(20, 20);
            this.RightThumb.Name = "RightThumb";
            this.RightThumb.Size = new System.Drawing.Size(20, 20);
            this.RightThumb.TabIndex = 12;
            this.RightThumb.UseVisualStyleBackColor = false;
            // 
            // Start
            // 
            this.Start.AutoSize = true;
            this.Start.BackColor = System.Drawing.Color.Transparent;
            this.Start.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Start.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.Start.FlatAppearance.BorderSize = 5;
            this.Start.ForeColor = System.Drawing.Color.Transparent;
            this.Start.Location = new System.Drawing.Point(282, 108);
            this.Start.MinimumSize = new System.Drawing.Size(40, 20);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(40, 20);
            this.Start.TabIndex = 11;
            this.Start.UseVisualStyleBackColor = false;
            // 
            // Back
            // 
            this.Back.AutoSize = true;
            this.Back.BackColor = System.Drawing.Color.Transparent;
            this.Back.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Back.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.Back.FlatAppearance.BorderSize = 5;
            this.Back.ForeColor = System.Drawing.Color.Transparent;
            this.Back.Location = new System.Drawing.Point(183, 108);
            this.Back.MinimumSize = new System.Drawing.Size(40, 20);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(40, 20);
            this.Back.TabIndex = 10;
            this.Back.UseVisualStyleBackColor = false;
            // 
            // Y
            // 
            this.Y.AutoSize = true;
            this.Y.BackColor = System.Drawing.Color.Transparent;
            this.Y.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Y.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.Y.FlatAppearance.BorderSize = 5;
            this.Y.ForeColor = System.Drawing.Color.Transparent;
            this.Y.Location = new System.Drawing.Point(365, 78);
            this.Y.MinimumSize = new System.Drawing.Size(36, 36);
            this.Y.Name = "Y";
            this.Y.Size = new System.Drawing.Size(36, 36);
            this.Y.TabIndex = 9;
            this.Y.UseVisualStyleBackColor = false;
            // 
            // B
            // 
            this.B.AutoSize = true;
            this.B.BackColor = System.Drawing.Color.Transparent;
            this.B.Cursor = System.Windows.Forms.Cursors.Hand;
            this.B.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.B.FlatAppearance.BorderSize = 5;
            this.B.ForeColor = System.Drawing.Color.Transparent;
            this.B.Location = new System.Drawing.Point(398, 105);
            this.B.MinimumSize = new System.Drawing.Size(36, 36);
            this.B.Name = "B";
            this.B.Size = new System.Drawing.Size(36, 36);
            this.B.TabIndex = 8;
            this.B.UseVisualStyleBackColor = false;
            // 
            // X
            // 
            this.X.AutoSize = true;
            this.X.BackColor = System.Drawing.Color.Transparent;
            this.X.Cursor = System.Windows.Forms.Cursors.Hand;
            this.X.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.X.FlatAppearance.BorderSize = 5;
            this.X.ForeColor = System.Drawing.Color.Transparent;
            this.X.Location = new System.Drawing.Point(331, 102);
            this.X.MinimumSize = new System.Drawing.Size(36, 36);
            this.X.Name = "X";
            this.X.Size = new System.Drawing.Size(36, 36);
            this.X.TabIndex = 7;
            this.X.UseVisualStyleBackColor = false;
            // 
            // A
            // 
            this.A.AutoSize = true;
            this.A.BackColor = System.Drawing.Color.Transparent;
            this.A.Cursor = System.Windows.Forms.Cursors.Hand;
            this.A.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.A.FlatAppearance.BorderSize = 5;
            this.A.ForeColor = System.Drawing.Color.Transparent;
            this.A.Location = new System.Drawing.Point(364, 133);
            this.A.MinimumSize = new System.Drawing.Size(36, 36);
            this.A.Name = "A";
            this.A.Size = new System.Drawing.Size(36, 36);
            this.A.TabIndex = 6;
            this.A.UseVisualStyleBackColor = false;
            // 
            // DLeft
            // 
            this.DLeft.AutoSize = true;
            this.DLeft.BackColor = System.Drawing.Color.Transparent;
            this.DLeft.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DLeft.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.DLeft.FlatAppearance.BorderSize = 5;
            this.DLeft.ForeColor = System.Drawing.Color.Transparent;
            this.DLeft.Location = new System.Drawing.Point(145, 174);
            this.DLeft.MinimumSize = new System.Drawing.Size(20, 20);
            this.DLeft.Name = "DLeft";
            this.DLeft.Size = new System.Drawing.Size(20, 20);
            this.DLeft.TabIndex = 5;
            this.DLeft.UseVisualStyleBackColor = false;
            // 
            // DDown
            // 
            this.DDown.AutoSize = true;
            this.DDown.BackColor = System.Drawing.Color.Transparent;
            this.DDown.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DDown.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.DDown.FlatAppearance.BorderSize = 5;
            this.DDown.ForeColor = System.Drawing.Color.Transparent;
            this.DDown.Location = new System.Drawing.Point(171, 198);
            this.DDown.MinimumSize = new System.Drawing.Size(20, 20);
            this.DDown.Name = "DDown";
            this.DDown.Size = new System.Drawing.Size(20, 20);
            this.DDown.TabIndex = 4;
            this.DDown.UseVisualStyleBackColor = false;
            // 
            // DRight
            // 
            this.DRight.AutoSize = true;
            this.DRight.BackColor = System.Drawing.Color.Transparent;
            this.DRight.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DRight.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.DRight.FlatAppearance.BorderSize = 5;
            this.DRight.ForeColor = System.Drawing.Color.Transparent;
            this.DRight.Location = new System.Drawing.Point(199, 174);
            this.DRight.MinimumSize = new System.Drawing.Size(20, 20);
            this.DRight.Name = "DRight";
            this.DRight.Size = new System.Drawing.Size(20, 20);
            this.DRight.TabIndex = 3;
            this.DRight.UseVisualStyleBackColor = false;
            // 
            // DUp
            // 
            this.DUp.AutoSize = true;
            this.DUp.BackColor = System.Drawing.Color.Transparent;
            this.DUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DUp.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.DUp.FlatAppearance.BorderSize = 5;
            this.DUp.ForeColor = System.Drawing.Color.Transparent;
            this.DUp.Location = new System.Drawing.Point(171, 150);
            this.DUp.MinimumSize = new System.Drawing.Size(20, 20);
            this.DUp.Name = "DUp";
            this.DUp.Size = new System.Drawing.Size(20, 20);
            this.DUp.TabIndex = 2;
            this.DUp.UseVisualStyleBackColor = false;
            // 
            // RightShoulder
            // 
            this.RightShoulder.AutoSize = true;
            this.RightShoulder.BackColor = System.Drawing.Color.Transparent;
            this.RightShoulder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RightShoulder.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.RightShoulder.FlatAppearance.BorderSize = 5;
            this.RightShoulder.ForeColor = System.Drawing.Color.Transparent;
            this.RightShoulder.Location = new System.Drawing.Point(341, 49);
            this.RightShoulder.MinimumSize = new System.Drawing.Size(70, 25);
            this.RightShoulder.Name = "RightShoulder";
            this.RightShoulder.Size = new System.Drawing.Size(70, 25);
            this.RightShoulder.TabIndex = 1;
            this.RightShoulder.UseVisualStyleBackColor = false;
            // 
            // LeftShoulder
            // 
            this.LeftShoulder.AutoSize = true;
            this.LeftShoulder.BackColor = System.Drawing.Color.Transparent;
            this.LeftShoulder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LeftShoulder.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.LeftShoulder.FlatAppearance.BorderSize = 5;
            this.LeftShoulder.ForeColor = System.Drawing.Color.Transparent;
            this.LeftShoulder.Location = new System.Drawing.Point(95, 49);
            this.LeftShoulder.MinimumSize = new System.Drawing.Size(70, 25);
            this.LeftShoulder.Name = "LeftShoulder";
            this.LeftShoulder.Size = new System.Drawing.Size(70, 25);
            this.LeftShoulder.TabIndex = 0;
            this.LeftShoulder.UseVisualStyleBackColor = false;
            // 
            // ButtonSelectWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 332);
            this.Controls.Add(this.controllerPanel);
            this.Name = "ButtonSelectWindow";
            this.Text = "ButtonSelectWindow";
            this.controllerPanel.ResumeLayout(false);
            this.controllerPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel controllerPanel;
        private System.Windows.Forms.CheckBox Y;
        private System.Windows.Forms.CheckBox B;
        private System.Windows.Forms.CheckBox X;
        private System.Windows.Forms.CheckBox A;
        private System.Windows.Forms.CheckBox DLeft;
        private System.Windows.Forms.CheckBox DDown;
        private System.Windows.Forms.CheckBox DRight;
        private System.Windows.Forms.CheckBox DUp;
        private System.Windows.Forms.CheckBox RightShoulder;
        private System.Windows.Forms.CheckBox LeftShoulder;
        private System.Windows.Forms.CheckBox LeftThumb;
        private System.Windows.Forms.CheckBox RightThumb;
        private System.Windows.Forms.CheckBox Start;
        private System.Windows.Forms.CheckBox Back;
        private System.Windows.Forms.ComboBox LeftStickRegions;
        private System.Windows.Forms.ComboBox RightStickRegions;
        private System.Windows.Forms.ComboBox RightTriggerRegions;
        private System.Windows.Forms.ComboBox LeftTriggerRegions;
        private System.Windows.Forms.Button confirm;
    }
}