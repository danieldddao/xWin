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
            this.SuspendLayout();
            // 
            // mapKeyboard
            // 
            this.mapKeyboard.CausesValidation = false;
            this.mapKeyboard.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mapKeyboard.Location = new System.Drawing.Point(63, 77);
            this.mapKeyboard.Name = "mapKeyboard";
            this.mapKeyboard.Size = new System.Drawing.Size(212, 78);
            this.mapKeyboard.TabIndex = 0;
            this.mapKeyboard.Text = "Keyboard";
            this.mapKeyboard.UseVisualStyleBackColor = true;
            this.mapKeyboard.Click += new System.EventHandler(this.mapKeyboard_Click);
            // 
            // openApplication
            // 
            this.openApplication.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openApplication.Location = new System.Drawing.Point(63, 209);
            this.openApplication.Name = "openApplication";
            this.openApplication.Size = new System.Drawing.Size(212, 78);
            this.openApplication.TabIndex = 1;
            this.openApplication.Text = "Open Application";
            this.openApplication.UseVisualStyleBackColor = true;
            this.openApplication.Click += new System.EventHandler(this.openApplication_Click);
            // 
            // mapShortcut
            // 
            this.mapShortcut.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mapShortcut.Location = new System.Drawing.Point(63, 338);
            this.mapShortcut.Name = "mapShortcut";
            this.mapShortcut.Size = new System.Drawing.Size(212, 78);
            this.mapShortcut.TabIndex = 2;
            this.mapShortcut.Text = "Shortcut";
            this.mapShortcut.UseVisualStyleBackColor = true;
            this.mapShortcut.Click += new System.EventHandler(this.mapShortcut_Click);
            // 
            // mapText
            // 
            this.mapText.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mapText.Location = new System.Drawing.Point(63, 461);
            this.mapText.Name = "mapText";
            this.mapText.Size = new System.Drawing.Size(212, 78);
            this.mapText.TabIndex = 3;
            this.mapText.Text = "Text";
            this.mapText.UseVisualStyleBackColor = true;
            this.mapText.Click += new System.EventHandler(this.mapText_Click);
            // 
            // ButtonOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 613);
            this.Controls.Add(this.mapText);
            this.Controls.Add(this.mapShortcut);
            this.Controls.Add(this.openApplication);
            this.Controls.Add(this.mapKeyboard);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ButtonOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ButtonOptions";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button mapKeyboard;
        private System.Windows.Forms.Button openApplication;
        private System.Windows.Forms.Button mapShortcut;
        private System.Windows.Forms.Button mapText;
    }
}