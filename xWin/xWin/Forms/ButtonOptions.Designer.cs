namespace xWin.Forms
{
    partial class ButtonOptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ButtonOptions));
            this.mapKeyboard = new System.Windows.Forms.Button();
            this.openApplication = new System.Windows.Forms.Button();
            this.mapShortcut = new System.Windows.Forms.Button();
            this.mapText = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.keyboardCheckBox = new System.Windows.Forms.CheckBox();
            this.openAppCheckBox = new System.Windows.Forms.CheckBox();
            this.shortcutCheckBox = new System.Windows.Forms.CheckBox();
            this.textCheckBox = new System.Windows.Forms.CheckBox();
            this.keyboardTextBox = new System.Windows.Forms.TextBox();
            this.openAppTextBox = new System.Windows.Forms.TextBox();
            this.shortcutTextBox = new System.Windows.Forms.TextBox();
            this.textTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // mapKeyboard
            // 
            this.mapKeyboard.CausesValidation = false;
            this.mapKeyboard.Enabled = false;
            this.mapKeyboard.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mapKeyboard.Location = new System.Drawing.Point(138, 75);
            this.mapKeyboard.Name = "mapKeyboard";
            this.mapKeyboard.Size = new System.Drawing.Size(212, 78);
            this.mapKeyboard.TabIndex = 0;
            this.mapKeyboard.Text = "Keyboard";
            this.mapKeyboard.UseVisualStyleBackColor = true;
            this.mapKeyboard.Click += new System.EventHandler(this.mapKeyboard_Click);
            // 
            // openApplication
            // 
            this.openApplication.Enabled = false;
            this.openApplication.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openApplication.Location = new System.Drawing.Point(138, 207);
            this.openApplication.Name = "openApplication";
            this.openApplication.Size = new System.Drawing.Size(212, 78);
            this.openApplication.TabIndex = 1;
            this.openApplication.Text = "Open Application";
            this.openApplication.UseVisualStyleBackColor = true;
            this.openApplication.Click += new System.EventHandler(this.openApplication_Click);
            // 
            // mapShortcut
            // 
            this.mapShortcut.Enabled = false;
            this.mapShortcut.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mapShortcut.Location = new System.Drawing.Point(138, 336);
            this.mapShortcut.Name = "mapShortcut";
            this.mapShortcut.Size = new System.Drawing.Size(212, 78);
            this.mapShortcut.TabIndex = 2;
            this.mapShortcut.Text = "Shortcut";
            this.mapShortcut.UseVisualStyleBackColor = true;
            this.mapShortcut.Click += new System.EventHandler(this.mapShortcut_Click);
            // 
            // mapText
            // 
            this.mapText.Enabled = false;
            this.mapText.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mapText.Location = new System.Drawing.Point(138, 459);
            this.mapText.Name = "mapText";
            this.mapText.Size = new System.Drawing.Size(212, 78);
            this.mapText.TabIndex = 3;
            this.mapText.Text = "Text";
            this.mapText.UseVisualStyleBackColor = true;
            this.mapText.Click += new System.EventHandler(this.mapText_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.SupportMultiDottedExtensions = true;
            // 
            // keyboardCheckBox
            // 
            this.keyboardCheckBox.AutoSize = true;
            this.keyboardCheckBox.Enabled = false;
            this.keyboardCheckBox.Location = new System.Drawing.Point(74, 103);
            this.keyboardCheckBox.Name = "keyboardCheckBox";
            this.keyboardCheckBox.Size = new System.Drawing.Size(28, 27);
            this.keyboardCheckBox.TabIndex = 4;
            this.keyboardCheckBox.UseVisualStyleBackColor = true;
            this.keyboardCheckBox.CheckedChanged += new System.EventHandler(this.keyboardCheckBox_CheckedChanged);
            // 
            // openAppCheckBox
            // 
            this.openAppCheckBox.AutoSize = true;
            this.openAppCheckBox.Enabled = false;
            this.openAppCheckBox.Location = new System.Drawing.Point(74, 233);
            this.openAppCheckBox.Name = "openAppCheckBox";
            this.openAppCheckBox.Size = new System.Drawing.Size(28, 27);
            this.openAppCheckBox.TabIndex = 5;
            this.openAppCheckBox.UseVisualStyleBackColor = true;
            this.openAppCheckBox.CheckedChanged += new System.EventHandler(this.openAppCheckBox_CheckedChanged);
            // 
            // shortcutCheckBox
            // 
            this.shortcutCheckBox.AutoSize = true;
            this.shortcutCheckBox.Enabled = false;
            this.shortcutCheckBox.Location = new System.Drawing.Point(74, 364);
            this.shortcutCheckBox.Name = "shortcutCheckBox";
            this.shortcutCheckBox.Size = new System.Drawing.Size(28, 27);
            this.shortcutCheckBox.TabIndex = 6;
            this.shortcutCheckBox.UseVisualStyleBackColor = true;
            this.shortcutCheckBox.CheckedChanged += new System.EventHandler(this.shortcutCheckBox_CheckedChanged);
            // 
            // textCheckBox
            // 
            this.textCheckBox.AutoSize = true;
            this.textCheckBox.Enabled = false;
            this.textCheckBox.Location = new System.Drawing.Point(74, 487);
            this.textCheckBox.Name = "textCheckBox";
            this.textCheckBox.Size = new System.Drawing.Size(28, 27);
            this.textCheckBox.TabIndex = 7;
            this.textCheckBox.UseVisualStyleBackColor = true;
            this.textCheckBox.CheckedChanged += new System.EventHandler(this.textCheckBox_CheckedChanged);
            // 
            // keyboardTextBox
            // 
            this.keyboardTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.keyboardTextBox.Location = new System.Drawing.Point(441, 75);
            this.keyboardTextBox.Multiline = true;
            this.keyboardTextBox.Name = "keyboardTextBox";
            this.keyboardTextBox.ReadOnly = true;
            this.keyboardTextBox.Size = new System.Drawing.Size(653, 78);
            this.keyboardTextBox.TabIndex = 8;
            this.keyboardTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // openAppTextBox
            // 
            this.openAppTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.openAppTextBox.Location = new System.Drawing.Point(441, 207);
            this.openAppTextBox.Multiline = true;
            this.openAppTextBox.Name = "openAppTextBox";
            this.openAppTextBox.ReadOnly = true;
            this.openAppTextBox.Size = new System.Drawing.Size(653, 78);
            this.openAppTextBox.TabIndex = 9;
            this.openAppTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // shortcutTextBox
            // 
            this.shortcutTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.shortcutTextBox.Location = new System.Drawing.Point(441, 336);
            this.shortcutTextBox.Multiline = true;
            this.shortcutTextBox.Name = "shortcutTextBox";
            this.shortcutTextBox.ReadOnly = true;
            this.shortcutTextBox.Size = new System.Drawing.Size(653, 78);
            this.shortcutTextBox.TabIndex = 10;
            this.shortcutTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textTextBox
            // 
            this.textTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.textTextBox.Location = new System.Drawing.Point(441, 459);
            this.textTextBox.Multiline = true;
            this.textTextBox.Name = "textTextBox";
            this.textTextBox.ReadOnly = true;
            this.textTextBox.Size = new System.Drawing.Size(653, 78);
            this.textTextBox.TabIndex = 11;
            this.textTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ButtonOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1155, 613);
            this.Controls.Add(this.textTextBox);
            this.Controls.Add(this.shortcutTextBox);
            this.Controls.Add(this.openAppTextBox);
            this.Controls.Add(this.keyboardTextBox);
            this.Controls.Add(this.textCheckBox);
            this.Controls.Add(this.shortcutCheckBox);
            this.Controls.Add(this.openAppCheckBox);
            this.Controls.Add(this.keyboardCheckBox);
            this.Controls.Add(this.mapText);
            this.Controls.Add(this.mapShortcut);
            this.Controls.Add(this.openApplication);
            this.Controls.Add(this.mapKeyboard);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ButtonOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Button Options";
            this.Load += new System.EventHandler(this.ButtonOptions_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button mapKeyboard;
        private System.Windows.Forms.Button openApplication;
        private System.Windows.Forms.Button mapShortcut;
        private System.Windows.Forms.Button mapText;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.CheckBox keyboardCheckBox;
        private System.Windows.Forms.CheckBox openAppCheckBox;
        private System.Windows.Forms.CheckBox shortcutCheckBox;
        private System.Windows.Forms.CheckBox textCheckBox;
        private System.Windows.Forms.TextBox keyboardTextBox;
        private System.Windows.Forms.TextBox openAppTextBox;
        private System.Windows.Forms.TextBox shortcutTextBox;
        private System.Windows.Forms.TextBox textTextBox;
    }
}