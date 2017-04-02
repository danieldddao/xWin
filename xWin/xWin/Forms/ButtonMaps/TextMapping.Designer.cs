namespace xWin.Forms.ButtonMaps
{
    partial class TextMapping
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TextMapping));
            this.textTextBox = new System.Windows.Forms.TextBox();
            this.TextMappingLabel = new System.Windows.Forms.Label();
            this.doneButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textTextBox
            // 
            this.textTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.textTextBox.Font = new System.Drawing.Font("Arial", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTextBox.Location = new System.Drawing.Point(71, 115);
            this.textTextBox.Multiline = true;
            this.textTextBox.Name = "textTextBox";
            this.textTextBox.Size = new System.Drawing.Size(825, 235);
            this.textTextBox.TabIndex = 9;
            this.textTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textTextBox.TextChanged += new System.EventHandler(this.textTextBox_TextChanged);
            // 
            // TextMappingLabel
            // 
            this.TextMappingLabel.AutoSize = true;
            this.TextMappingLabel.Font = new System.Drawing.Font("Arial", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextMappingLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.TextMappingLabel.Location = new System.Drawing.Point(63, 58);
            this.TextMappingLabel.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.TextMappingLabel.Name = "TextMappingLabel";
            this.TextMappingLabel.Size = new System.Drawing.Size(335, 32);
            this.TextMappingLabel.TabIndex = 320;
            this.TextMappingLabel.Text = "Enter text to map button";
            this.TextMappingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TextMappingLabel.Click += new System.EventHandler(this.TextMappingLabel_Click);
            // 
            // doneButton
            // 
            this.doneButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.doneButton.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.doneButton.Location = new System.Drawing.Point(409, 387);
            this.doneButton.Name = "doneButton";
            this.doneButton.Size = new System.Drawing.Size(189, 66);
            this.doneButton.TabIndex = 321;
            this.doneButton.Text = "Save";
            this.doneButton.UseVisualStyleBackColor = false;
            this.doneButton.Click += new System.EventHandler(this.doneButton_Click);
            // 
            // TextMapping
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 489);
            this.Controls.Add(this.doneButton);
            this.Controls.Add(this.TextMappingLabel);
            this.Controls.Add(this.textTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TextMapping";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TextMapping";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textTextBox;
        private System.Windows.Forms.Label TextMappingLabel;
        private System.Windows.Forms.Button doneButton;
    }
}