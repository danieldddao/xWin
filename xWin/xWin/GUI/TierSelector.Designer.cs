namespace xWin.GUI
{
    partial class TierSelector
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.textbox = new System.Windows.Forms.TextBox();
            this.ConfigSelector = new System.Windows.Forms.Button();
            this.Up = new System.Windows.Forms.Button();
            this.down = new System.Windows.Forms.Button();
            this.DeleteThis = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.textbox);
            this.flowLayoutPanel1.Controls.Add(this.ConfigSelector);
            this.flowLayoutPanel1.Controls.Add(this.Up);
            this.flowLayoutPanel1.Controls.Add(this.down);
            this.flowLayoutPanel1.Controls.Add(this.DeleteThis);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(238, 28);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // textbox
            // 
            this.textbox.Location = new System.Drawing.Point(3, 3);
            this.textbox.Name = "textbox";
            this.textbox.ReadOnly = true;
            this.textbox.Size = new System.Drawing.Size(100, 20);
            this.textbox.TabIndex = 0;
            this.textbox.TextChanged += new System.EventHandler(this.textbox_TextChanged);
            // 
            // ConfigSelector
            // 
            this.ConfigSelector.Location = new System.Drawing.Point(109, 3);
            this.ConfigSelector.Name = "ConfigSelector";
            this.ConfigSelector.Size = new System.Drawing.Size(23, 23);
            this.ConfigSelector.TabIndex = 1;
            this.ConfigSelector.Text = "+";
            this.ConfigSelector.UseVisualStyleBackColor = true;
            this.ConfigSelector.Click += new System.EventHandler(this.ConfigSelector_Click);
            // 
            // Up
            // 
            this.Up.Location = new System.Drawing.Point(138, 3);
            this.Up.Name = "Up";
            this.Up.Size = new System.Drawing.Size(27, 23);
            this.Up.TabIndex = 3;
            this.Up.Text = "^";
            this.Up.UseVisualStyleBackColor = true;
            this.Up.Click += new System.EventHandler(this.Up_Click);
            // 
            // down
            // 
            this.down.Location = new System.Drawing.Point(171, 3);
            this.down.Name = "down";
            this.down.Size = new System.Drawing.Size(24, 23);
            this.down.TabIndex = 2;
            this.down.Text = "v";
            this.down.UseVisualStyleBackColor = true;
            this.down.Click += new System.EventHandler(this.down_Click);
            // 
            // DeleteThis
            // 
            this.DeleteThis.Location = new System.Drawing.Point(201, 3);
            this.DeleteThis.Name = "DeleteThis";
            this.DeleteThis.Size = new System.Drawing.Size(30, 23);
            this.DeleteThis.TabIndex = 4;
            this.DeleteThis.Text = "X";
            this.DeleteThis.UseVisualStyleBackColor = true;
            this.DeleteThis.Click += new System.EventHandler(this.DeleteThis_Click);
            // 
            // TierSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "TierSelector";
            this.Size = new System.Drawing.Size(238, 28);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TextBox textbox;
        private System.Windows.Forms.Button ConfigSelector;
        private System.Windows.Forms.Button down;
        private System.Windows.Forms.Button Up;
        private System.Windows.Forms.Button DeleteThis;
    }
}
