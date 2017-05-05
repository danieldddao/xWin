namespace xWin.GUI
{
    partial class PickBinding
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
            this.TextField = new System.Windows.Forms.TextBox();
            this.Pick = new System.Windows.Forms.Button();
            this.Field = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.active = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TextField
            // 
            this.TextField.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TextField.Location = new System.Drawing.Point(89, 3);
            this.TextField.Name = "TextField";
            this.TextField.Size = new System.Drawing.Size(100, 20);
            this.TextField.TabIndex = 0;
            // 
            // Pick
            // 
            this.Pick.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Pick.Location = new System.Drawing.Point(195, 3);
            this.Pick.Name = "Pick";
            this.Pick.Size = new System.Drawing.Size(24, 23);
            this.Pick.TabIndex = 1;
            this.Pick.Text = "+";
            this.Pick.UseVisualStyleBackColor = true;
            this.Pick.Click += new System.EventHandler(this.Pick_Click);
            // 
            // Field
            // 
            this.Field.Location = new System.Drawing.Point(3, 0);
            this.Field.Name = "Field";
            this.Field.Size = new System.Drawing.Size(80, 23);
            this.Field.TabIndex = 2;
            this.Field.Text = "label1";
            this.Field.Click += new System.EventHandler(this.label1_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.Field);
            this.flowLayoutPanel1.Controls.Add(this.TextField);
            this.flowLayoutPanel1.Controls.Add(this.Pick);
            this.flowLayoutPanel1.Controls.Add(this.active);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(360, 29);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // active
            // 
            this.active.FormattingEnabled = true;
            this.active.Items.AddRange(new object[] {
            "Pressed",
            "Held",
            "Released",
            "Stayed"});
            this.active.Location = new System.Drawing.Point(225, 3);
            this.active.Name = "active";
            this.active.Size = new System.Drawing.Size(121, 21);
            this.active.TabIndex = 3;
            this.active.Text = "Pressed";
            // 
            // PickBinding
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "PickBinding";
            this.Size = new System.Drawing.Size(360, 29);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox TextField;
        private System.Windows.Forms.Button Pick;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        public System.Windows.Forms.ComboBox active;
        public System.Windows.Forms.Label Field;
    }
}
