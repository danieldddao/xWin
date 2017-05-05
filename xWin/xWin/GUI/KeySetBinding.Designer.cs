namespace xWin.GUI
{
    partial class KeySetBinding
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
            this.keysetbox = new System.Windows.Forms.TextBox();
            this.KeySetSet = new System.Windows.Forms.Button();
            this.active = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.textbox);
            this.flowLayoutPanel1.Controls.Add(this.ConfigSelector);
            this.flowLayoutPanel1.Controls.Add(this.active);
            this.flowLayoutPanel1.Controls.Add(this.keysetbox);
            this.flowLayoutPanel1.Controls.Add(this.KeySetSet);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(405, 31);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // textbox
            // 
            this.textbox.Location = new System.Drawing.Point(3, 3);
            this.textbox.Name = "textbox";
            this.textbox.Size = new System.Drawing.Size(100, 20);
            this.textbox.TabIndex = 2;
            // 
            // ConfigSelector
            // 
            this.ConfigSelector.Location = new System.Drawing.Point(109, 3);
            this.ConfigSelector.Name = "ConfigSelector";
            this.ConfigSelector.Size = new System.Drawing.Size(23, 23);
            this.ConfigSelector.TabIndex = 3;
            this.ConfigSelector.Text = "+";
            this.ConfigSelector.UseVisualStyleBackColor = true;
            this.ConfigSelector.Click += new System.EventHandler(this.ConfigSelector_Click);
            // 
            // keysetbox
            // 
            this.keysetbox.Location = new System.Drawing.Point(265, 3);
            this.keysetbox.Name = "keysetbox";
            this.keysetbox.Size = new System.Drawing.Size(100, 20);
            this.keysetbox.TabIndex = 4;
            this.keysetbox.TextChanged += new System.EventHandler(this.keysetbox_TextChanged);
            // 
            // KeySetSet
            // 
            this.KeySetSet.Location = new System.Drawing.Point(371, 3);
            this.KeySetSet.Name = "KeySetSet";
            this.KeySetSet.Size = new System.Drawing.Size(23, 23);
            this.KeySetSet.TabIndex = 3;
            this.KeySetSet.Text = "K";
            this.KeySetSet.UseVisualStyleBackColor = true;
            this.KeySetSet.Click += new System.EventHandler(this.KeySetSet_Click);
            // 
            // active
            // 
            this.active.FormattingEnabled = true;
            this.active.Items.AddRange(new object[] {
            "Pressed",
            "Held",
            "Released",
            "Stayed"});
            this.active.Location = new System.Drawing.Point(138, 3);
            this.active.Name = "active";
            this.active.Size = new System.Drawing.Size(121, 21);
            this.active.TabIndex = 5;
            this.active.Text = "Pressed";
            // 
            // KeySetBinding
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "KeySetBinding";
            this.Size = new System.Drawing.Size(405, 31);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TextBox textbox;
        private System.Windows.Forms.Button ConfigSelector;
        private System.Windows.Forms.TextBox keysetbox;
        private System.Windows.Forms.Button KeySetSet;
        private System.Windows.Forms.ComboBox active;
    }
}
