namespace xWin.GUI
{
    partial class Binding
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
            this.EditButtons = new System.Windows.Forms.Button();
            this.ClearButtons = new System.Windows.Forms.Button();
            this.BehaviorSelect = new System.Windows.Forms.ComboBox();
            this.EditKeybinds = new System.Windows.Forms.Button();
            this.ToggleBox = new System.Windows.Forms.CheckBox();
            this.DeleteSelf = new System.Windows.Forms.Button();
            this.ButtonTextBox = new System.Windows.Forms.TextBox();
            this.KeybindTextBox = new System.Windows.Forms.TextBox();
            this.ClearKeybinds = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Controls.Add(this.ButtonTextBox);
            this.flowLayoutPanel1.Controls.Add(this.EditButtons);
            this.flowLayoutPanel1.Controls.Add(this.ClearButtons);
            this.flowLayoutPanel1.Controls.Add(this.BehaviorSelect);
            this.flowLayoutPanel1.Controls.Add(this.KeybindTextBox);
            this.flowLayoutPanel1.Controls.Add(this.EditKeybinds);
            this.flowLayoutPanel1.Controls.Add(this.ClearKeybinds);
            this.flowLayoutPanel1.Controls.Add(this.ToggleBox);
            this.flowLayoutPanel1.Controls.Add(this.DeleteSelf);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(551, 30);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // EditButtons
            // 
            this.EditButtons.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.EditButtons.Location = new System.Drawing.Point(109, 3);
            this.EditButtons.Name = "EditButtons";
            this.EditButtons.Size = new System.Drawing.Size(21, 21);
            this.EditButtons.TabIndex = 1;
            this.EditButtons.Text = "+";
            this.EditButtons.UseVisualStyleBackColor = false;
            this.EditButtons.Click += new System.EventHandler(this.button2_Click);
            // 
            // ClearButtons
            // 
            this.ClearButtons.BackColor = System.Drawing.Color.Red;
            this.ClearButtons.Location = new System.Drawing.Point(136, 3);
            this.ClearButtons.Name = "ClearButtons";
            this.ClearButtons.Size = new System.Drawing.Size(21, 21);
            this.ClearButtons.TabIndex = 9;
            this.ClearButtons.Text = "C";
            this.ClearButtons.UseVisualStyleBackColor = false;
            this.ClearButtons.Click += new System.EventHandler(this.button4_Click);
            // 
            // BehaviorSelect
            // 
            this.BehaviorSelect.FormattingEnabled = true;
            this.BehaviorSelect.Items.AddRange(new object[] {
            "On Press",
            "On Hold",
            "On Release",
            "On Stay Released"});
            this.BehaviorSelect.Location = new System.Drawing.Point(163, 3);
            this.BehaviorSelect.Name = "BehaviorSelect";
            this.BehaviorSelect.Size = new System.Drawing.Size(121, 21);
            this.BehaviorSelect.TabIndex = 13;
            this.BehaviorSelect.Text = "On Hold";
            this.BehaviorSelect.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // EditKeybinds
            // 
            this.EditKeybinds.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.EditKeybinds.Location = new System.Drawing.Point(396, 3);
            this.EditKeybinds.Name = "EditKeybinds";
            this.EditKeybinds.Size = new System.Drawing.Size(21, 21);
            this.EditKeybinds.TabIndex = 14;
            this.EditKeybinds.Text = "+";
            this.EditKeybinds.UseVisualStyleBackColor = false;
            this.EditKeybinds.Click += new System.EventHandler(this.button3_Click);
            // 
            // ToggleBox
            // 
            this.ToggleBox.AutoSize = true;
            this.ToggleBox.Location = new System.Drawing.Point(450, 3);
            this.ToggleBox.Name = "ToggleBox";
            this.ToggleBox.Size = new System.Drawing.Size(59, 17);
            this.ToggleBox.TabIndex = 8;
            this.ToggleBox.Text = "Toggle";
            this.ToggleBox.UseVisualStyleBackColor = true;
            this.ToggleBox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // DeleteSelf
            // 
            this.DeleteSelf.Location = new System.Drawing.Point(515, 3);
            this.DeleteSelf.Name = "DeleteSelf";
            this.DeleteSelf.Size = new System.Drawing.Size(23, 21);
            this.DeleteSelf.TabIndex = 16;
            this.DeleteSelf.Text = "X";
            this.DeleteSelf.UseVisualStyleBackColor = true;
            this.DeleteSelf.Click += new System.EventHandler(this.button6_Click);
            // 
            // ButtonTextBox
            // 
            this.ButtonTextBox.Location = new System.Drawing.Point(3, 3);
            this.ButtonTextBox.MaximumSize = new System.Drawing.Size(100, 20);
            this.ButtonTextBox.MinimumSize = new System.Drawing.Size(100, 20);
            this.ButtonTextBox.Name = "ButtonTextBox";
            this.ButtonTextBox.ReadOnly = true;
            this.ButtonTextBox.Size = new System.Drawing.Size(100, 20);
            this.ButtonTextBox.TabIndex = 17;
            // 
            // KeybindTextBox
            // 
            this.KeybindTextBox.Location = new System.Drawing.Point(290, 3);
            this.KeybindTextBox.MaximumSize = new System.Drawing.Size(100, 20);
            this.KeybindTextBox.MinimumSize = new System.Drawing.Size(100, 20);
            this.KeybindTextBox.Name = "KeybindTextBox";
            this.KeybindTextBox.ReadOnly = true;
            this.KeybindTextBox.Size = new System.Drawing.Size(100, 20);
            this.KeybindTextBox.TabIndex = 18;
            // 
            // ClearKeybinds
            // 
            this.ClearKeybinds.BackColor = System.Drawing.Color.Red;
            this.ClearKeybinds.Location = new System.Drawing.Point(423, 3);
            this.ClearKeybinds.Name = "ClearKeybinds";
            this.ClearKeybinds.Size = new System.Drawing.Size(21, 21);
            this.ClearKeybinds.TabIndex = 15;
            this.ClearKeybinds.Text = "C";
            this.ClearKeybinds.UseVisualStyleBackColor = false;
            this.ClearKeybinds.Click += new System.EventHandler(this.button5_Click);
            // 
            // Binding
            // 
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "Binding";
            this.Size = new System.Drawing.Size(551, 30);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button EditButtons;
        private System.Windows.Forms.CheckBox ToggleBox;
        private System.Windows.Forms.Button ClearButtons;
        private System.Windows.Forms.ComboBox BehaviorSelect;
        private System.Windows.Forms.Button EditKeybinds;
        private System.Windows.Forms.Button DeleteSelf;
        private System.Windows.Forms.TextBox ButtonTextBox;
        private System.Windows.Forms.TextBox KeybindTextBox;
        private System.Windows.Forms.Button ClearKeybinds;
    }
}
