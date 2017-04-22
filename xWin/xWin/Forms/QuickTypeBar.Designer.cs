namespace xWin.Forms
{
    partial class QuickTypeBar
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
            this.quickTypeButton3 = new xWin.Library.QuickTypeButton();
            this.quickTypeButton2 = new xWin.Library.QuickTypeButton();
            this.quickTypeButton1 = new xWin.Library.QuickTypeButton();
            this.SuspendLayout();
            // 
            // quickTypeButton3
            // 
            this.quickTypeButton3.BackColor = System.Drawing.Color.White;
            this.quickTypeButton3.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.quickTypeButton3.FlatAppearance.BorderSize = 5;
            this.quickTypeButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.quickTypeButton3.Font = new System.Drawing.Font("Arial", 19.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quickTypeButton3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.quickTypeButton3.Location = new System.Drawing.Point(339, 1);
            this.quickTypeButton3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.quickTypeButton3.Name = "quickTypeButton3";
            this.quickTypeButton3.Size = new System.Drawing.Size(170, 54);
            this.quickTypeButton3.TabIndex = 2;
            this.quickTypeButton3.UseVisualStyleBackColor = false;
            this.quickTypeButton3.Click += new System.EventHandler(this.quickTypeButton3_Click);
            // 
            // quickTypeButton2
            // 
            this.quickTypeButton2.BackColor = System.Drawing.Color.White;
            this.quickTypeButton2.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.quickTypeButton2.FlatAppearance.BorderSize = 5;
            this.quickTypeButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.quickTypeButton2.Font = new System.Drawing.Font("Arial", 19.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quickTypeButton2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.quickTypeButton2.Location = new System.Drawing.Point(170, 1);
            this.quickTypeButton2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.quickTypeButton2.Name = "quickTypeButton2";
            this.quickTypeButton2.Size = new System.Drawing.Size(170, 54);
            this.quickTypeButton2.TabIndex = 1;
            this.quickTypeButton2.UseVisualStyleBackColor = false;
            this.quickTypeButton2.Click += new System.EventHandler(this.quickTypeButton2_Click);
            // 
            // quickTypeButton1
            // 
            this.quickTypeButton1.BackColor = System.Drawing.Color.White;
            this.quickTypeButton1.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.quickTypeButton1.FlatAppearance.BorderSize = 5;
            this.quickTypeButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.quickTypeButton1.Font = new System.Drawing.Font("Arial", 19.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quickTypeButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.quickTypeButton1.Location = new System.Drawing.Point(0, 1);
            this.quickTypeButton1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.quickTypeButton1.Name = "quickTypeButton1";
            this.quickTypeButton1.Size = new System.Drawing.Size(170, 54);
            this.quickTypeButton1.TabIndex = 0;
            this.quickTypeButton1.UseVisualStyleBackColor = false;
            this.quickTypeButton1.Click += new System.EventHandler(this.quickTypeButton1_Click);
            // 
            // QuickTypeBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(524, 70);
            this.Controls.Add(this.quickTypeButton3);
            this.Controls.Add(this.quickTypeButton2);
            this.Controls.Add(this.quickTypeButton1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "QuickTypeBar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QuickTypeBar";
            this.TransparencyKey = System.Drawing.Color.Black;
            this.ResumeLayout(false);

        }

        #endregion

        private Library.QuickTypeButton quickTypeButton1;
        private Library.QuickTypeButton quickTypeButton2;
        private Library.QuickTypeButton quickTypeButton3;
    }
}