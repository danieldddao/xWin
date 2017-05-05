namespace xWin.GUI
{
    partial class TypingConfigWindow
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
            this.Tier1Add = new System.Windows.Forms.Button();
            this.Tier2Add = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.TriggerThreshold = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.LeftTriggerRegions = new System.Windows.Forms.NumericUpDown();
            this.RightTriggerRegions = new System.Windows.Forms.NumericUpDown();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LeftStickRegions = new System.Windows.Forms.NumericUpDown();
            this.RightStickRegions = new System.Windows.Forms.NumericUpDown();
            this.Tier1 = new System.Windows.Forms.FlowLayoutPanel();
            this.Tier2 = new System.Windows.Forms.FlowLayoutPanel();
            this.KeySets = new System.Windows.Forms.FlowLayoutPanel();
            this.AddKeyset = new System.Windows.Forms.Button();
            this.KeyboardActions = new System.Windows.Forms.FlowLayoutPanel();
            this.keysetbox = new System.Windows.Forms.TextBox();
            this.KeySetSet = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.DescriptionBox = new System.Windows.Forms.TextBox();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TriggerThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftTriggerRegions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightTriggerRegions)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LeftStickRegions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightStickRegions)).BeginInit();
            this.SuspendLayout();
            // 
            // Tier1Add
            // 
            this.Tier1Add.Location = new System.Drawing.Point(13, 314);
            this.Tier1Add.Name = "Tier1Add";
            this.Tier1Add.Size = new System.Drawing.Size(75, 23);
            this.Tier1Add.TabIndex = 2;
            this.Tier1Add.Text = "Add";
            this.Tier1Add.UseVisualStyleBackColor = true;
            this.Tier1Add.Click += new System.EventHandler(this.button1_Click);
            // 
            // Tier2Add
            // 
            this.Tier2Add.Location = new System.Drawing.Point(289, 314);
            this.Tier2Add.Name = "Tier2Add";
            this.Tier2Add.Size = new System.Drawing.Size(75, 23);
            this.Tier2Add.TabIndex = 4;
            this.Tier2Add.Text = "Add";
            this.Tier2Add.UseVisualStyleBackColor = true;
            this.Tier2Add.Click += new System.EventHandler(this.Tier2Add_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.TriggerThreshold);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.LeftTriggerRegions);
            this.groupBox4.Controls.Add(this.RightTriggerRegions);
            this.groupBox4.Location = new System.Drawing.Point(416, 363);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(107, 100);
            this.groupBox4.TabIndex = 38;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Trigger Regions";
            // 
            // TriggerThreshold
            // 
            this.TriggerThreshold.Location = new System.Drawing.Point(6, 76);
            this.TriggerThreshold.Maximum = new decimal(new int[] {
            254,
            0,
            0,
            0});
            this.TriggerThreshold.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.TriggerThreshold.Name = "TriggerThreshold";
            this.TriggerThreshold.Size = new System.Drawing.Size(84, 20);
            this.TriggerThreshold.TabIndex = 17;
            this.TriggerThreshold.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Threshold (1-254)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Left         Right";
            // 
            // LeftTriggerRegions
            // 
            this.LeftTriggerRegions.Location = new System.Drawing.Point(6, 41);
            this.LeftTriggerRegions.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.LeftTriggerRegions.Name = "LeftTriggerRegions";
            this.LeftTriggerRegions.Size = new System.Drawing.Size(39, 20);
            this.LeftTriggerRegions.TabIndex = 9;
            this.LeftTriggerRegions.ValueChanged += new System.EventHandler(this.LeftTriggerRegions_ValueChanged);
            // 
            // RightTriggerRegions
            // 
            this.RightTriggerRegions.Location = new System.Drawing.Point(51, 41);
            this.RightTriggerRegions.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.RightTriggerRegions.Name = "RightTriggerRegions";
            this.RightTriggerRegions.Size = new System.Drawing.Size(39, 20);
            this.RightTriggerRegions.TabIndex = 10;
            this.RightTriggerRegions.ValueChanged += new System.EventHandler(this.RightTriggerRegions_ValueChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.LeftStickRegions);
            this.groupBox3.Controls.Add(this.RightStickRegions);
            this.groupBox3.Location = new System.Drawing.Point(416, 492);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(95, 67);
            this.groupBox3.TabIndex = 37;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Stick Regions";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Left         Right";
            // 
            // LeftStickRegions
            // 
            this.LeftStickRegions.Location = new System.Drawing.Point(6, 39);
            this.LeftStickRegions.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.LeftStickRegions.Name = "LeftStickRegions";
            this.LeftStickRegions.Size = new System.Drawing.Size(39, 20);
            this.LeftStickRegions.TabIndex = 2;
            this.LeftStickRegions.ValueChanged += new System.EventHandler(this.LeftStickRegions_ValueChanged);
            // 
            // RightStickRegions
            // 
            this.RightStickRegions.Location = new System.Drawing.Point(52, 39);
            this.RightStickRegions.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.RightStickRegions.Name = "RightStickRegions";
            this.RightStickRegions.Size = new System.Drawing.Size(39, 20);
            this.RightStickRegions.TabIndex = 3;
            this.RightStickRegions.ValueChanged += new System.EventHandler(this.RightStickRegions_ValueChanged);
            // 
            // Tier1
            // 
            this.Tier1.AutoScroll = true;
            this.Tier1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Tier1.Location = new System.Drawing.Point(12, 12);
            this.Tier1.Name = "Tier1";
            this.Tier1.Size = new System.Drawing.Size(271, 296);
            this.Tier1.TabIndex = 39;
            this.Tier1.Paint += new System.Windows.Forms.PaintEventHandler(this.Tier1_Paint_1);
            // 
            // Tier2
            // 
            this.Tier2.AutoScroll = true;
            this.Tier2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Tier2.Location = new System.Drawing.Point(289, 12);
            this.Tier2.Name = "Tier2";
            this.Tier2.Size = new System.Drawing.Size(271, 296);
            this.Tier2.TabIndex = 40;
            this.Tier2.Paint += new System.Windows.Forms.PaintEventHandler(this.Tier2_Paint);
            // 
            // KeySets
            // 
            this.KeySets.AutoScroll = true;
            this.KeySets.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.KeySets.Location = new System.Drawing.Point(566, 49);
            this.KeySets.Name = "KeySets";
            this.KeySets.Size = new System.Drawing.Size(324, 259);
            this.KeySets.TabIndex = 41;
            // 
            // AddKeyset
            // 
            this.AddKeyset.Location = new System.Drawing.Point(566, 314);
            this.AddKeyset.Name = "AddKeyset";
            this.AddKeyset.Size = new System.Drawing.Size(75, 23);
            this.AddKeyset.TabIndex = 42;
            this.AddKeyset.Text = "Add";
            this.AddKeyset.UseVisualStyleBackColor = true;
            this.AddKeyset.Click += new System.EventHandler(this.AddKeyset_Click);
            // 
            // KeyboardActions
            // 
            this.KeyboardActions.AutoScroll = true;
            this.KeyboardActions.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.KeyboardActions.Location = new System.Drawing.Point(12, 363);
            this.KeyboardActions.Name = "KeyboardActions";
            this.KeyboardActions.Size = new System.Drawing.Size(398, 220);
            this.KeyboardActions.TabIndex = 43;
            this.KeyboardActions.Paint += new System.Windows.Forms.PaintEventHandler(this.KeyboardActions_Paint);
            // 
            // keysetbox
            // 
            this.keysetbox.Location = new System.Drawing.Point(708, 20);
            this.keysetbox.Name = "keysetbox";
            this.keysetbox.Size = new System.Drawing.Size(100, 20);
            this.keysetbox.TabIndex = 45;
            // 
            // KeySetSet
            // 
            this.KeySetSet.Location = new System.Drawing.Point(814, 20);
            this.KeySetSet.Name = "KeySetSet";
            this.KeySetSet.Size = new System.Drawing.Size(23, 23);
            this.KeySetSet.TabIndex = 44;
            this.KeySetSet.Text = "K";
            this.KeySetSet.UseVisualStyleBackColor = true;
            this.KeySetSet.Click += new System.EventHandler(this.KeySetSet_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(610, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 46;
            this.label2.Text = "Default Keyset";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(532, 403);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 50;
            this.label3.Text = "Description";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(557, 380);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 49;
            this.label6.Text = "Name";
            // 
            // DescriptionBox
            // 
            this.DescriptionBox.Location = new System.Drawing.Point(599, 403);
            this.DescriptionBox.Name = "DescriptionBox";
            this.DescriptionBox.Size = new System.Drawing.Size(279, 20);
            this.DescriptionBox.TabIndex = 48;
            // 
            // NameBox
            // 
            this.NameBox.Location = new System.Drawing.Point(599, 377);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(100, 20);
            this.NameBox.TabIndex = 47;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(599, 469);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 23);
            this.button1.TabIndex = 51;
            this.button1.Text = "Load From File";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(715, 469);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(110, 23);
            this.button2.TabIndex = 52;
            this.button2.Text = "Save To File";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(664, 536);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(110, 23);
            this.button3.TabIndex = 53;
            this.button3.Text = "Confirm";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // TypingConfigWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 599);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.DescriptionBox);
            this.Controls.Add(this.NameBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.keysetbox);
            this.Controls.Add(this.KeySetSet);
            this.Controls.Add(this.KeyboardActions);
            this.Controls.Add(this.AddKeyset);
            this.Controls.Add(this.KeySets);
            this.Controls.Add(this.Tier2);
            this.Controls.Add(this.Tier1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.Tier2Add);
            this.Controls.Add(this.Tier1Add);
            this.Name = "TypingConfigWindow";
            this.Text = "TypingConfigWindow";
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TriggerThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftTriggerRegions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightTriggerRegions)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LeftStickRegions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightStickRegions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Tier1Add;
        private System.Windows.Forms.Button Tier2Add;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.NumericUpDown TriggerThreshold;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown LeftTriggerRegions;
        private System.Windows.Forms.NumericUpDown RightTriggerRegions;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown LeftStickRegions;
        private System.Windows.Forms.NumericUpDown RightStickRegions;
        private System.Windows.Forms.FlowLayoutPanel Tier1;
        private System.Windows.Forms.FlowLayoutPanel Tier2;
        private System.Windows.Forms.FlowLayoutPanel KeySets;
        private System.Windows.Forms.Button AddKeyset;
        private System.Windows.Forms.FlowLayoutPanel KeyboardActions;
        private System.Windows.Forms.TextBox keysetbox;
        private System.Windows.Forms.Button KeySetSet;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox DescriptionBox;
        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}