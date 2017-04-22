namespace xWin.Forms
{
    partial class XWinPanel
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XWinPanel));
            this.ControllerPanel = new System.Windows.Forms.TabControl();
            this.controllersPanel = new System.Windows.Forms.TabPage();
            this.Controller4 = new System.Windows.Forms.Button();
            this.Controller3 = new System.Windows.Forms.Button();
            this.Controller2 = new System.Windows.Forms.Button();
            this.Controller1 = new System.Windows.Forms.Button();
            this.Settings = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonViewDictionary = new System.Windows.Forms.Button();
            this.quickTypeTipsButton = new System.Windows.Forms.Button();
            this.wordPredictionTipsButton = new System.Windows.Forms.Button();
            this.quickTypeCheckBox = new System.Windows.Forms.CheckBox();
            this.wordPredictionCheckBox = new System.Windows.Forms.CheckBox();
            this.labelAutocomplete = new System.Windows.Forms.Label();
            this.log = new System.Windows.Forms.TabPage();
            this.reportError = new System.Windows.Forms.Button();
            this.openLogFileButton = new System.Windows.Forms.Button();
            this.clearLogsButton = new System.Windows.Forms.Button();
            this.debugModeCheckbox = new System.Windows.Forms.CheckBox();
            this.logListView = new System.Windows.Forms.ListView();
            this.dateHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.levelHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ClassHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MessageHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.AutoCompleteTimer = new System.Windows.Forms.Timer(this.components);
            this.QuickTypeBarTimer = new System.Windows.Forms.Timer(this.components);
            this.ControllerPanel.SuspendLayout();
            this.controllersPanel.SuspendLayout();
            this.Settings.SuspendLayout();
            this.panel1.SuspendLayout();
            this.log.SuspendLayout();
            this.SuspendLayout();
            // 
            // ControllerPanel
            // 
            this.ControllerPanel.Controls.Add(this.controllersPanel);
            this.ControllerPanel.Controls.Add(this.Settings);
            this.ControllerPanel.Controls.Add(this.log);
            this.ControllerPanel.Location = new System.Drawing.Point(20, 21);
            this.ControllerPanel.Margin = new System.Windows.Forms.Padding(4);
            this.ControllerPanel.Multiline = true;
            this.ControllerPanel.Name = "ControllerPanel";
            this.ControllerPanel.SelectedIndex = 0;
            this.ControllerPanel.Size = new System.Drawing.Size(1208, 723);
            this.ControllerPanel.TabIndex = 0;
            // 
            // controllersPanel
            // 
            this.controllersPanel.Controls.Add(this.Controller4);
            this.controllersPanel.Controls.Add(this.Controller3);
            this.controllersPanel.Controls.Add(this.Controller2);
            this.controllersPanel.Controls.Add(this.Controller1);
            this.controllersPanel.Location = new System.Drawing.Point(8, 39);
            this.controllersPanel.Margin = new System.Windows.Forms.Padding(4);
            this.controllersPanel.Name = "controllersPanel";
            this.controllersPanel.Padding = new System.Windows.Forms.Padding(4);
            this.controllersPanel.Size = new System.Drawing.Size(1192, 676);
            this.controllersPanel.TabIndex = 0;
            this.controllersPanel.Text = "Controllers";
            this.controllersPanel.UseVisualStyleBackColor = true;
            // 
            // Controller4
            // 
            this.Controller4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(51)))));
            this.Controller4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Controller4.Location = new System.Drawing.Point(704, 373);
            this.Controller4.Margin = new System.Windows.Forms.Padding(4);
            this.Controller4.Name = "Controller4";
            this.Controller4.Size = new System.Drawing.Size(304, 137);
            this.Controller4.TabIndex = 7;
            this.Controller4.Text = "Controller 4";
            this.Controller4.UseVisualStyleBackColor = false;
            this.Controller4.UseWaitCursor = true;
            this.Controller4.Click += new System.EventHandler(this.Controller4_Click);
            // 
            // Controller3
            // 
            this.Controller3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(51)))));
            this.Controller3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.Controller3.Location = new System.Drawing.Point(220, 373);
            this.Controller3.Margin = new System.Windows.Forms.Padding(4);
            this.Controller3.Name = "Controller3";
            this.Controller3.Size = new System.Drawing.Size(302, 137);
            this.Controller3.TabIndex = 6;
            this.Controller3.Text = "Controller 3";
            this.Controller3.UseVisualStyleBackColor = false;
            this.Controller3.Click += new System.EventHandler(this.Controller3_Click);
            // 
            // Controller2
            // 
            this.Controller2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(51)))));
            this.Controller2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Controller2.Location = new System.Drawing.Point(704, 112);
            this.Controller2.Margin = new System.Windows.Forms.Padding(4);
            this.Controller2.Name = "Controller2";
            this.Controller2.Size = new System.Drawing.Size(304, 137);
            this.Controller2.TabIndex = 5;
            this.Controller2.Text = "Controller 2";
            this.Controller2.UseVisualStyleBackColor = false;
            this.Controller2.Click += new System.EventHandler(this.Controller2_Click);
            // 
            // Controller1
            // 
            this.Controller1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(51)))));
            this.Controller1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.Controller1.Location = new System.Drawing.Point(220, 112);
            this.Controller1.Margin = new System.Windows.Forms.Padding(4);
            this.Controller1.Name = "Controller1";
            this.Controller1.Size = new System.Drawing.Size(302, 137);
            this.Controller1.TabIndex = 4;
            this.Controller1.Text = "Controller 1";
            this.Controller1.UseVisualStyleBackColor = false;
            this.Controller1.Click += new System.EventHandler(this.Controller1_Click);
            // 
            // Settings
            // 
            this.Settings.Controls.Add(this.panel1);
            this.Settings.Location = new System.Drawing.Point(8, 39);
            this.Settings.Margin = new System.Windows.Forms.Padding(4);
            this.Settings.Name = "Settings";
            this.Settings.Padding = new System.Windows.Forms.Padding(4);
            this.Settings.Size = new System.Drawing.Size(1192, 676);
            this.Settings.TabIndex = 1;
            this.Settings.Text = "Settings";
            this.Settings.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonViewDictionary);
            this.panel1.Controls.Add(this.quickTypeTipsButton);
            this.panel1.Controls.Add(this.wordPredictionTipsButton);
            this.panel1.Controls.Add(this.quickTypeCheckBox);
            this.panel1.Controls.Add(this.wordPredictionCheckBox);
            this.panel1.Controls.Add(this.labelAutocomplete);
            this.panel1.Location = new System.Drawing.Point(586, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(599, 519);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(436, 360);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "second(s)";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(358, 357);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(53, 31);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(109, 347);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 50);
            this.label1.TabIndex = 5;
            this.label1.Text = "* When not typing, \r\nautomatically hide after";
            // 
            // buttonViewDictionary
            // 
            this.buttonViewDictionary.BackColor = System.Drawing.Color.Transparent;
            this.buttonViewDictionary.BackgroundImage = global::xWin.Properties.Resources.buttonBackground;
            this.buttonViewDictionary.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonViewDictionary.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonViewDictionary.Location = new System.Drawing.Point(202, 97);
            this.buttonViewDictionary.Name = "buttonViewDictionary";
            this.buttonViewDictionary.Size = new System.Drawing.Size(209, 71);
            this.buttonViewDictionary.TabIndex = 4;
            this.buttonViewDictionary.Text = "Manage Dictionary";
            this.buttonViewDictionary.UseVisualStyleBackColor = false;
            this.buttonViewDictionary.Click += new System.EventHandler(this.buttonViewDictionary_Click);
            // 
            // quickTypeTipsButton
            // 
            this.quickTypeTipsButton.AutoSize = true;
            this.quickTypeTipsButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.quickTypeTipsButton.BackColor = System.Drawing.Color.LemonChiffon;
            this.quickTypeTipsButton.Location = new System.Drawing.Point(432, 287);
            this.quickTypeTipsButton.Name = "quickTypeTipsButton";
            this.quickTypeTipsButton.Size = new System.Drawing.Size(56, 35);
            this.quickTypeTipsButton.TabIndex = 3;
            this.quickTypeTipsButton.Text = "tips";
            this.quickTypeTipsButton.UseVisualStyleBackColor = false;
            // 
            // wordPredictionTipsButton
            // 
            this.wordPredictionTipsButton.AutoSize = true;
            this.wordPredictionTipsButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.wordPredictionTipsButton.BackColor = System.Drawing.Color.LemonChiffon;
            this.wordPredictionTipsButton.Location = new System.Drawing.Point(355, 203);
            this.wordPredictionTipsButton.Name = "wordPredictionTipsButton";
            this.wordPredictionTipsButton.Size = new System.Drawing.Size(56, 35);
            this.wordPredictionTipsButton.TabIndex = 1;
            this.wordPredictionTipsButton.Text = "tips";
            this.wordPredictionTipsButton.UseVisualStyleBackColor = false;
            // 
            // quickTypeCheckBox
            // 
            this.quickTypeCheckBox.AutoSize = true;
            this.quickTypeCheckBox.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quickTypeCheckBox.Location = new System.Drawing.Point(44, 293);
            this.quickTypeCheckBox.Name = "quickTypeCheckBox";
            this.quickTypeCheckBox.Size = new System.Drawing.Size(382, 31);
            this.quickTypeCheckBox.TabIndex = 2;
            this.quickTypeCheckBox.Text = "Enable QuickType Suggestions";
            this.quickTypeCheckBox.UseVisualStyleBackColor = true;
            // 
            // wordPredictionCheckBox
            // 
            this.wordPredictionCheckBox.AutoSize = true;
            this.wordPredictionCheckBox.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wordPredictionCheckBox.Location = new System.Drawing.Point(44, 210);
            this.wordPredictionCheckBox.Name = "wordPredictionCheckBox";
            this.wordPredictionCheckBox.Size = new System.Drawing.Size(299, 31);
            this.wordPredictionCheckBox.TabIndex = 1;
            this.wordPredictionCheckBox.Text = "Enable Word Prediction";
            this.wordPredictionCheckBox.UseVisualStyleBackColor = true;
            // 
            // labelAutocomplete
            // 
            this.labelAutocomplete.AutoSize = true;
            this.labelAutocomplete.Font = new System.Drawing.Font("Arial", 13.125F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAutocomplete.ForeColor = System.Drawing.Color.MidnightBlue;
            this.labelAutocomplete.Location = new System.Drawing.Point(167, 39);
            this.labelAutocomplete.Name = "labelAutocomplete";
            this.labelAutocomplete.Size = new System.Drawing.Size(274, 41);
            this.labelAutocomplete.TabIndex = 0;
            this.labelAutocomplete.Text = "Auto-Complete:";
            // 
            // log
            // 
            this.log.Controls.Add(this.reportError);
            this.log.Controls.Add(this.openLogFileButton);
            this.log.Controls.Add(this.clearLogsButton);
            this.log.Controls.Add(this.debugModeCheckbox);
            this.log.Controls.Add(this.logListView);
            this.log.Location = new System.Drawing.Point(8, 39);
            this.log.Margin = new System.Windows.Forms.Padding(4);
            this.log.Name = "log";
            this.log.Padding = new System.Windows.Forms.Padding(4);
            this.log.Size = new System.Drawing.Size(1192, 676);
            this.log.TabIndex = 2;
            this.log.Text = "Log";
            this.log.UseVisualStyleBackColor = true;
            // 
            // reportError
            // 
            this.reportError.BackColor = System.Drawing.Color.OrangeRed;
            this.reportError.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reportError.Location = new System.Drawing.Point(1057, 610);
            this.reportError.Margin = new System.Windows.Forms.Padding(4);
            this.reportError.Name = "reportError";
            this.reportError.Size = new System.Drawing.Size(127, 52);
            this.reportError.TabIndex = 4;
            this.reportError.Text = "Report";
            this.reportError.UseVisualStyleBackColor = false;
            this.reportError.Click += new System.EventHandler(this.reportError_Click);
            // 
            // openLogFileButton
            // 
            this.openLogFileButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.openLogFileButton.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openLogFileButton.Location = new System.Drawing.Point(818, 610);
            this.openLogFileButton.Margin = new System.Windows.Forms.Padding(4);
            this.openLogFileButton.Name = "openLogFileButton";
            this.openLogFileButton.Size = new System.Drawing.Size(214, 52);
            this.openLogFileButton.TabIndex = 3;
            this.openLogFileButton.Text = "Open Log File";
            this.openLogFileButton.UseVisualStyleBackColor = false;
            this.openLogFileButton.Click += new System.EventHandler(this.openLogFileButton_Click);
            // 
            // clearLogsButton
            // 
            this.clearLogsButton.Font = new System.Drawing.Font("Arial", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearLogsButton.Location = new System.Drawing.Point(399, 610);
            this.clearLogsButton.Margin = new System.Windows.Forms.Padding(4);
            this.clearLogsButton.Name = "clearLogsButton";
            this.clearLogsButton.Size = new System.Drawing.Size(351, 52);
            this.clearLogsButton.TabIndex = 2;
            this.clearLogsButton.Text = "Clear All Logs";
            this.clearLogsButton.UseVisualStyleBackColor = true;
            this.clearLogsButton.Click += new System.EventHandler(this.clearLogsButton_Click);
            // 
            // debugModeCheckbox
            // 
            this.debugModeCheckbox.AutoSize = true;
            this.debugModeCheckbox.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.debugModeCheckbox.Location = new System.Drawing.Point(43, 620);
            this.debugModeCheckbox.Margin = new System.Windows.Forms.Padding(4);
            this.debugModeCheckbox.Name = "debugModeCheckbox";
            this.debugModeCheckbox.Size = new System.Drawing.Size(281, 35);
            this.debugModeCheckbox.TabIndex = 1;
            this.debugModeCheckbox.Text = "Enable Debug Mode";
            this.debugModeCheckbox.UseVisualStyleBackColor = true;
            this.debugModeCheckbox.CheckedChanged += new System.EventHandler(this.debugModeCheckbox_CheckedChanged);
            // 
            // logListView
            // 
            this.logListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.dateHeader,
            this.levelHeader,
            this.ClassHeader,
            this.MessageHeader});
            this.logListView.FullRowSelect = true;
            this.logListView.GridLines = true;
            this.logListView.Location = new System.Drawing.Point(0, 0);
            this.logListView.Margin = new System.Windows.Forms.Padding(4);
            this.logListView.Name = "logListView";
            this.logListView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.logListView.Size = new System.Drawing.Size(1188, 591);
            this.logListView.TabIndex = 0;
            this.logListView.UseCompatibleStateImageBehavior = false;
            this.logListView.View = System.Windows.Forms.View.Details;
            // 
            // dateHeader
            // 
            this.dateHeader.Text = "Date";
            this.dateHeader.Width = 171;
            // 
            // levelHeader
            // 
            this.levelHeader.Text = "Level";
            this.levelHeader.Width = 96;
            // 
            // ClassHeader
            // 
            this.ClassHeader.Text = "Class";
            this.ClassHeader.Width = 115;
            // 
            // MessageHeader
            // 
            this.MessageHeader.Text = "Message";
            this.MessageHeader.Width = 763;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // AutoCompleteTimer
            // 
            this.AutoCompleteTimer.Enabled = true;
            this.AutoCompleteTimer.Interval = 10;
            this.AutoCompleteTimer.Tick += new System.EventHandler(this.AutoCompleteTimer_Tick);
            // 
            // QuickTypeBarTimer
            // 
            this.QuickTypeBarTimer.Enabled = true;
            this.QuickTypeBarTimer.Interval = 5000;
            this.QuickTypeBarTimer.Tick += new System.EventHandler(this.QuickTypeBarTimer_Tick);
            // 
            // XWinPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1248, 765);
            this.Controls.Add(this.ControllerPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "XWinPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XWin Panel";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.XWinPanel_FormClosed);
            this.Load += new System.EventHandler(this.XWinPanel_Load);
            this.ControllerPanel.ResumeLayout(false);
            this.controllersPanel.ResumeLayout(false);
            this.Settings.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.log.ResumeLayout(false);
            this.log.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl ControllerPanel;
        private System.Windows.Forms.TabPage controllersPanel;
        private System.Windows.Forms.Button Controller4;
        private System.Windows.Forms.Button Controller3;
        private System.Windows.Forms.Button Controller2;
        private System.Windows.Forms.Button Controller1;
        private System.Windows.Forms.TabPage Settings;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TabPage log;
        private System.Windows.Forms.ListView logListView;
        private System.Windows.Forms.ColumnHeader dateHeader;
        private System.Windows.Forms.ColumnHeader levelHeader;
        private System.Windows.Forms.ColumnHeader ClassHeader;
        private System.Windows.Forms.ColumnHeader MessageHeader;
        private System.Windows.Forms.Button clearLogsButton;
        private System.Windows.Forms.CheckBox debugModeCheckbox;
        private System.Windows.Forms.Button openLogFileButton;
        private System.Windows.Forms.Button reportError;
        private System.Windows.Forms.Timer AutoCompleteTimer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox quickTypeCheckBox;
        private System.Windows.Forms.CheckBox wordPredictionCheckBox;
        private System.Windows.Forms.Label labelAutocomplete;
        private System.Windows.Forms.Button wordPredictionTipsButton;
        private System.Windows.Forms.Button quickTypeTipsButton;
        private System.Windows.Forms.Button buttonViewDictionary;
        private System.Windows.Forms.Timer QuickTypeBarTimer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
    }
}