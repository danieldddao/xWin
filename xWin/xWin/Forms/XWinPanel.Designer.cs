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
            this.Settings = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.NotificationsDropdownList = new System.Windows.Forms.ComboBox();
            this.StartMinimizedCheckBox = new System.Windows.Forms.CheckBox();
            this.StartAtStartupCheckBox = new System.Windows.Forms.CheckBox();
            this.MinimizeCheckBox = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.customizeQuickTypeBar = new System.Windows.Forms.Button();
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
            this.AutoCompleteTimer = new System.Windows.Forms.Timer(this.components);
            this.QuickTypeBarTimer = new System.Windows.Forms.Timer(this.components);
            this.systemTrayNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.EditConfig = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.ConfigDescription = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ConfigName = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.updateCC = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.CalibrateRight = new System.Windows.Forms.Button();
            this.RYCenter = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.RXCenter = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DeadzonePicker = new System.Windows.Forms.NumericUpDown();
            this.CalibrateLeft = new System.Windows.Forms.Button();
            this.LYCenter = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.LXCenter = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.ControllerPanel.SuspendLayout();
            this.controllersPanel.SuspendLayout();
            this.Settings.SuspendLayout();
            this.panel1.SuspendLayout();
            this.log.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DeadzonePicker)).BeginInit();
            this.SuspendLayout();
            // 
            // ControllerPanel
            // 
            this.ControllerPanel.Controls.Add(this.controllersPanel);
            this.ControllerPanel.Controls.Add(this.Settings);
            this.ControllerPanel.Controls.Add(this.log);
            this.ControllerPanel.Location = new System.Drawing.Point(13, 13);
            this.ControllerPanel.Multiline = true;
            this.ControllerPanel.Name = "ControllerPanel";
            this.ControllerPanel.SelectedIndex = 0;
            this.ControllerPanel.Size = new System.Drawing.Size(805, 463);
            this.ControllerPanel.TabIndex = 0;
            // 
            // controllersPanel
            // 
            this.controllersPanel.Controls.Add(this.EditConfig);
            this.controllersPanel.Controls.Add(this.label9);
            this.controllersPanel.Controls.Add(this.ConfigDescription);
            this.controllersPanel.Controls.Add(this.label8);
            this.controllersPanel.Controls.Add(this.ConfigName);
            this.controllersPanel.Controls.Add(this.groupBox1);
            this.controllersPanel.Location = new System.Drawing.Point(4, 25);
            this.controllersPanel.Name = "controllersPanel";
            this.controllersPanel.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.controllersPanel.Size = new System.Drawing.Size(797, 434);
            this.controllersPanel.TabIndex = 0;
            this.controllersPanel.Text = "Controllers";
            this.controllersPanel.UseVisualStyleBackColor = true;
            // 
            // Settings
            // 
            this.Settings.Controls.Add(this.label1);
            this.Settings.Controls.Add(this.NotificationsDropdownList);
            this.Settings.Controls.Add(this.StartMinimizedCheckBox);
            this.Settings.Controls.Add(this.StartAtStartupCheckBox);
            this.Settings.Controls.Add(this.MinimizeCheckBox);
            this.Settings.Controls.Add(this.panel1);
            this.Settings.Location = new System.Drawing.Point(4, 25);
            this.Settings.Name = "Settings";
            this.Settings.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.Settings.Size = new System.Drawing.Size(797, 434);
            this.Settings.TabIndex = 1;
            this.Settings.Text = "Settings";
            this.Settings.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 196);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Notifications:";
            // 
            // NotificationsDropdownList
            // 
            this.NotificationsDropdownList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.NotificationsDropdownList.FormattingEnabled = true;
            this.NotificationsDropdownList.Items.AddRange(new object[] {
            "None",
            "Notify All",
            "Notify Only Warnings",
            "Notify Only Errors"});
            this.NotificationsDropdownList.Location = new System.Drawing.Point(27, 215);
            this.NotificationsDropdownList.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.NotificationsDropdownList.Name = "NotificationsDropdownList";
            this.NotificationsDropdownList.Size = new System.Drawing.Size(183, 24);
            this.NotificationsDropdownList.TabIndex = 4;
            this.NotificationsDropdownList.SelectedIndexChanged += new System.EventHandler(this.NotificationsDropdownList_SelectedIndexChanged);
            // 
            // StartMinimizedCheckBox
            // 
            this.StartMinimizedCheckBox.AutoSize = true;
            this.StartMinimizedCheckBox.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartMinimizedCheckBox.Location = new System.Drawing.Point(27, 138);
            this.StartMinimizedCheckBox.Name = "StartMinimizedCheckBox";
            this.StartMinimizedCheckBox.Size = new System.Drawing.Size(132, 21);
            this.StartMinimizedCheckBox.TabIndex = 3;
            this.StartMinimizedCheckBox.Text = "Start minimized";
            this.StartMinimizedCheckBox.UseVisualStyleBackColor = true;
            this.StartMinimizedCheckBox.CheckedChanged += new System.EventHandler(this.StartMinimizedCheckBox_CheckedChanged);
            // 
            // StartAtStartupCheckBox
            // 
            this.StartAtStartupCheckBox.AutoSize = true;
            this.StartAtStartupCheckBox.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartAtStartupCheckBox.Location = new System.Drawing.Point(27, 95);
            this.StartAtStartupCheckBox.Name = "StartAtStartupCheckBox";
            this.StartAtStartupCheckBox.Size = new System.Drawing.Size(279, 21);
            this.StartAtStartupCheckBox.TabIndex = 2;
            this.StartAtStartupCheckBox.Text = "Start application when Windows starts";
            this.StartAtStartupCheckBox.UseVisualStyleBackColor = true;
            this.StartAtStartupCheckBox.CheckedChanged += new System.EventHandler(this.StartAtStartupCheckBox_CheckedChanged);
            // 
            // MinimizeCheckBox
            // 
            this.MinimizeCheckBox.AutoSize = true;
            this.MinimizeCheckBox.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimizeCheckBox.Location = new System.Drawing.Point(27, 51);
            this.MinimizeCheckBox.Name = "MinimizeCheckBox";
            this.MinimizeCheckBox.Size = new System.Drawing.Size(183, 21);
            this.MinimizeCheckBox.TabIndex = 1;
            this.MinimizeCheckBox.Text = "Minimize to system tray";
            this.MinimizeCheckBox.UseVisualStyleBackColor = true;
            this.MinimizeCheckBox.CheckedChanged += new System.EventHandler(this.MinimizeCheckBox_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.customizeQuickTypeBar);
            this.panel1.Controls.Add(this.buttonViewDictionary);
            this.panel1.Controls.Add(this.quickTypeTipsButton);
            this.panel1.Controls.Add(this.wordPredictionTipsButton);
            this.panel1.Controls.Add(this.quickTypeCheckBox);
            this.panel1.Controls.Add(this.wordPredictionCheckBox);
            this.panel1.Controls.Add(this.labelAutocomplete);
            this.panel1.Location = new System.Drawing.Point(376, 51);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(399, 301);
            this.panel1.TabIndex = 0;
            // 
            // customizeQuickTypeBar
            // 
            this.customizeQuickTypeBar.BackColor = System.Drawing.Color.FloralWhite;
            this.customizeQuickTypeBar.Location = new System.Drawing.Point(83, 228);
            this.customizeQuickTypeBar.Name = "customizeQuickTypeBar";
            this.customizeQuickTypeBar.Size = new System.Drawing.Size(211, 40);
            this.customizeQuickTypeBar.TabIndex = 7;
            this.customizeQuickTypeBar.Text = "Customize QuickType Bar";
            this.customizeQuickTypeBar.UseVisualStyleBackColor = false;
            this.customizeQuickTypeBar.Click += new System.EventHandler(this.customizeQuickTypeBar_Click);
            // 
            // buttonViewDictionary
            // 
            this.buttonViewDictionary.BackColor = System.Drawing.Color.Transparent;
            this.buttonViewDictionary.BackgroundImage = global::xWin.Properties.Resources.buttonBackground;
            this.buttonViewDictionary.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonViewDictionary.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonViewDictionary.Location = new System.Drawing.Point(135, 61);
            this.buttonViewDictionary.Name = "buttonViewDictionary";
            this.buttonViewDictionary.Size = new System.Drawing.Size(139, 45);
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
            this.quickTypeTipsButton.Location = new System.Drawing.Point(288, 184);
            this.quickTypeTipsButton.Name = "quickTypeTipsButton";
            this.quickTypeTipsButton.Size = new System.Drawing.Size(40, 27);
            this.quickTypeTipsButton.TabIndex = 3;
            this.quickTypeTipsButton.Text = "tips";
            this.quickTypeTipsButton.UseVisualStyleBackColor = false;
            this.quickTypeTipsButton.Click += new System.EventHandler(this.quickTypeTipsButton_Click);
            // 
            // wordPredictionTipsButton
            // 
            this.wordPredictionTipsButton.AutoSize = true;
            this.wordPredictionTipsButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.wordPredictionTipsButton.BackColor = System.Drawing.Color.LemonChiffon;
            this.wordPredictionTipsButton.Location = new System.Drawing.Point(237, 131);
            this.wordPredictionTipsButton.Name = "wordPredictionTipsButton";
            this.wordPredictionTipsButton.Size = new System.Drawing.Size(40, 27);
            this.wordPredictionTipsButton.TabIndex = 1;
            this.wordPredictionTipsButton.Text = "tips";
            this.wordPredictionTipsButton.UseVisualStyleBackColor = false;
            this.wordPredictionTipsButton.Click += new System.EventHandler(this.wordPredictionTipsButton_Click);
            // 
            // quickTypeCheckBox
            // 
            this.quickTypeCheckBox.AutoSize = true;
            this.quickTypeCheckBox.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quickTypeCheckBox.Location = new System.Drawing.Point(29, 187);
            this.quickTypeCheckBox.Name = "quickTypeCheckBox";
            this.quickTypeCheckBox.Size = new System.Drawing.Size(233, 21);
            this.quickTypeCheckBox.TabIndex = 2;
            this.quickTypeCheckBox.Text = "Enable QuickType Suggestions";
            this.quickTypeCheckBox.UseVisualStyleBackColor = true;
            this.quickTypeCheckBox.CheckedChanged += new System.EventHandler(this.quickTypeCheckBox_CheckedChanged);
            // 
            // wordPredictionCheckBox
            // 
            this.wordPredictionCheckBox.AutoSize = true;
            this.wordPredictionCheckBox.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wordPredictionCheckBox.Location = new System.Drawing.Point(29, 134);
            this.wordPredictionCheckBox.Name = "wordPredictionCheckBox";
            this.wordPredictionCheckBox.Size = new System.Drawing.Size(184, 21);
            this.wordPredictionCheckBox.TabIndex = 1;
            this.wordPredictionCheckBox.Text = "Enable Word Prediction";
            this.wordPredictionCheckBox.UseVisualStyleBackColor = true;
            this.wordPredictionCheckBox.CheckedChanged += new System.EventHandler(this.wordPredictionCheckBox_CheckedChanged);
            // 
            // labelAutocomplete
            // 
            this.labelAutocomplete.AutoSize = true;
            this.labelAutocomplete.Font = new System.Drawing.Font("Arial", 13.125F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAutocomplete.ForeColor = System.Drawing.Color.MidnightBlue;
            this.labelAutocomplete.Location = new System.Drawing.Point(112, 24);
            this.labelAutocomplete.Name = "labelAutocomplete";
            this.labelAutocomplete.Size = new System.Drawing.Size(171, 26);
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
            this.log.Location = new System.Drawing.Point(4, 25);
            this.log.Name = "log";
            this.log.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.log.Size = new System.Drawing.Size(797, 434);
            this.log.TabIndex = 2;
            this.log.Text = "Log";
            this.log.UseVisualStyleBackColor = true;
            // 
            // reportError
            // 
            this.reportError.BackColor = System.Drawing.Color.OrangeRed;
            this.reportError.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reportError.Location = new System.Drawing.Point(704, 390);
            this.reportError.Name = "reportError";
            this.reportError.Size = new System.Drawing.Size(85, 33);
            this.reportError.TabIndex = 4;
            this.reportError.Text = "Report";
            this.reportError.UseVisualStyleBackColor = false;
            this.reportError.Click += new System.EventHandler(this.reportError_Click);
            // 
            // openLogFileButton
            // 
            this.openLogFileButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.openLogFileButton.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openLogFileButton.Location = new System.Drawing.Point(545, 390);
            this.openLogFileButton.Name = "openLogFileButton";
            this.openLogFileButton.Size = new System.Drawing.Size(143, 33);
            this.openLogFileButton.TabIndex = 3;
            this.openLogFileButton.Text = "Open Log File";
            this.openLogFileButton.UseVisualStyleBackColor = false;
            this.openLogFileButton.Click += new System.EventHandler(this.openLogFileButton_Click);
            // 
            // clearLogsButton
            // 
            this.clearLogsButton.Font = new System.Drawing.Font("Arial", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearLogsButton.Location = new System.Drawing.Point(267, 390);
            this.clearLogsButton.Name = "clearLogsButton";
            this.clearLogsButton.Size = new System.Drawing.Size(235, 33);
            this.clearLogsButton.TabIndex = 2;
            this.clearLogsButton.Text = "Clear All Logs";
            this.clearLogsButton.UseVisualStyleBackColor = true;
            this.clearLogsButton.Click += new System.EventHandler(this.clearLogsButton_Click);
            // 
            // debugModeCheckbox
            // 
            this.debugModeCheckbox.AutoSize = true;
            this.debugModeCheckbox.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.debugModeCheckbox.Location = new System.Drawing.Point(29, 396);
            this.debugModeCheckbox.Name = "debugModeCheckbox";
            this.debugModeCheckbox.Size = new System.Drawing.Size(179, 23);
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
            this.logListView.Name = "logListView";
            this.logListView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.logListView.Size = new System.Drawing.Size(793, 380);
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
            // AutoCompleteTimer
            // 
            this.AutoCompleteTimer.Enabled = true;
            this.AutoCompleteTimer.Interval = 10;
            // 
            // QuickTypeBarTimer
            // 
            this.QuickTypeBarTimer.Enabled = true;
            this.QuickTypeBarTimer.Interval = 5000;
            // 
            // systemTrayNotifyIcon
            // 
            this.systemTrayNotifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.systemTrayNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("systemTrayNotifyIcon.Icon")));
            this.systemTrayNotifyIcon.Text = "XWin";
            this.systemTrayNotifyIcon.DoubleClick += new System.EventHandler(this.systemTrayNotifyIcon_DoubleClick);
            // 
            // EditConfig
            // 
            this.EditConfig.Location = new System.Drawing.Point(118, 368);
            this.EditConfig.Margin = new System.Windows.Forms.Padding(4);
            this.EditConfig.Name = "EditConfig";
            this.EditConfig.Size = new System.Drawing.Size(100, 28);
            this.EditConfig.TabIndex = 16;
            this.EditConfig.Text = "Edit";
            this.EditConfig.UseVisualStyleBackColor = true;
            this.EditConfig.Click += new System.EventHandler(this.EditConfig_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(62, 339);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 17);
            this.label9.TabIndex = 15;
            this.label9.Text = "Description";
            // 
            // ConfigDescription
            // 
            this.ConfigDescription.Location = new System.Drawing.Point(150, 336);
            this.ConfigDescription.Margin = new System.Windows.Forms.Padding(4);
            this.ConfigDescription.Name = "ConfigDescription";
            this.ConfigDescription.ReadOnly = true;
            this.ConfigDescription.Size = new System.Drawing.Size(132, 22);
            this.ConfigDescription.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(95, 306);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 17);
            this.label8.TabIndex = 13;
            this.label8.Text = "Name";
            // 
            // ConfigName
            // 
            this.ConfigName.Location = new System.Drawing.Point(150, 302);
            this.ConfigName.Margin = new System.Windows.Forms.Padding(4);
            this.ConfigName.Name = "ConfigName";
            this.ConfigName.ReadOnly = true;
            this.ConfigName.Size = new System.Drawing.Size(132, 22);
            this.ConfigName.TabIndex = 12;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.updateCC);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.CalibrateRight);
            this.groupBox1.Controls.Add(this.RYCenter);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.RXCenter);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.DeadzonePicker);
            this.groupBox1.Controls.Add(this.CalibrateLeft);
            this.groupBox1.Controls.Add(this.LYCenter);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.LXCenter);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Location = new System.Drawing.Point(261, 38);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(473, 233);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Controller Settings";
            // 
            // updateCC
            // 
            this.updateCC.Location = new System.Drawing.Point(299, 197);
            this.updateCC.Margin = new System.Windows.Forms.Padding(4);
            this.updateCC.Name = "updateCC";
            this.updateCC.Size = new System.Drawing.Size(159, 28);
            this.updateCC.TabIndex = 14;
            this.updateCC.Text = "Update Settings";
            this.updateCC.UseVisualStyleBackColor = true;
            this.updateCC.Click += new System.EventHandler(this.updateCC_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(295, 36);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 17);
            this.label5.TabIndex = 13;
            this.label5.Text = "Right Stick Center";
            // 
            // CalibrateRight
            // 
            this.CalibrateRight.Location = new System.Drawing.Point(299, 119);
            this.CalibrateRight.Margin = new System.Windows.Forms.Padding(4);
            this.CalibrateRight.Name = "CalibrateRight";
            this.CalibrateRight.Size = new System.Drawing.Size(100, 28);
            this.CalibrateRight.TabIndex = 8;
            this.CalibrateRight.Text = "Calibrate";
            this.CalibrateRight.UseVisualStyleBackColor = true;
            this.CalibrateRight.Click += new System.EventHandler(this.CalibrateRight_Click);
            // 
            // RYCenter
            // 
            this.RYCenter.Location = new System.Drawing.Point(324, 87);
            this.RYCenter.Margin = new System.Windows.Forms.Padding(4);
            this.RYCenter.Name = "RYCenter";
            this.RYCenter.ReadOnly = true;
            this.RYCenter.Size = new System.Drawing.Size(132, 22);
            this.RYCenter.TabIndex = 12;
            this.RYCenter.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(253, 59);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "X-center";
            // 
            // RXCenter
            // 
            this.RXCenter.Location = new System.Drawing.Point(324, 55);
            this.RXCenter.Margin = new System.Windows.Forms.Padding(4);
            this.RXCenter.Name = "RXCenter";
            this.RXCenter.ReadOnly = true;
            this.RXCenter.Size = new System.Drawing.Size(132, 22);
            this.RXCenter.TabIndex = 11;
            this.RXCenter.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(253, 91);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 17);
            this.label7.TabIndex = 10;
            this.label7.Text = "Y-center";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(51, 36);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Left Stick Center";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(80, 177);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Stick Deadzone";
            // 
            // DeadzonePicker
            // 
            this.DeadzonePicker.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.DeadzonePicker.Location = new System.Drawing.Point(80, 201);
            this.DeadzonePicker.Margin = new System.Windows.Forms.Padding(4);
            this.DeadzonePicker.Maximum = new decimal(new int[] {
            15000,
            0,
            0,
            0});
            this.DeadzonePicker.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.DeadzonePicker.Name = "DeadzonePicker";
            this.DeadzonePicker.Size = new System.Drawing.Size(88, 22);
            this.DeadzonePicker.TabIndex = 5;
            this.DeadzonePicker.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            // 
            // CalibrateLeft
            // 
            this.CalibrateLeft.Location = new System.Drawing.Point(55, 119);
            this.CalibrateLeft.Margin = new System.Windows.Forms.Padding(4);
            this.CalibrateLeft.Name = "CalibrateLeft";
            this.CalibrateLeft.Size = new System.Drawing.Size(100, 28);
            this.CalibrateLeft.TabIndex = 0;
            this.CalibrateLeft.Text = "Calibrate";
            this.CalibrateLeft.UseVisualStyleBackColor = true;
            this.CalibrateLeft.Click += new System.EventHandler(this.CalibrateLeft_Click);
            // 
            // LYCenter
            // 
            this.LYCenter.Location = new System.Drawing.Point(80, 87);
            this.LYCenter.Margin = new System.Windows.Forms.Padding(4);
            this.LYCenter.Name = "LYCenter";
            this.LYCenter.ReadOnly = true;
            this.LYCenter.Size = new System.Drawing.Size(132, 22);
            this.LYCenter.TabIndex = 4;
            this.LYCenter.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 59);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "X-center";
            // 
            // LXCenter
            // 
            this.LXCenter.Location = new System.Drawing.Point(80, 55);
            this.LXCenter.Margin = new System.Windows.Forms.Padding(4);
            this.LXCenter.Name = "LXCenter";
            this.LXCenter.ReadOnly = true;
            this.LXCenter.Size = new System.Drawing.Size(132, 22);
            this.LXCenter.TabIndex = 3;
            this.LXCenter.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 91);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 17);
            this.label10.TabIndex = 2;
            this.label10.Text = "Y-center";
            // 
            // XWinPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 490);
            this.Controls.Add(this.ControllerPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "XWinPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XWin Panel";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.XWinPanel_FormClosed);
            this.Load += new System.EventHandler(this.XWinPanel_Load);
            this.Resize += new System.EventHandler(this.XWinPanel_Resize);
            this.ControllerPanel.ResumeLayout(false);
            this.controllersPanel.ResumeLayout(false);
            this.controllersPanel.PerformLayout();
            this.Settings.ResumeLayout(false);
            this.Settings.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.log.ResumeLayout(false);
            this.log.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DeadzonePicker)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl ControllerPanel;
        private System.Windows.Forms.TabPage controllersPanel;
        private System.Windows.Forms.TabPage Settings;
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
        private System.Windows.Forms.Button customizeQuickTypeBar;
        private System.Windows.Forms.CheckBox MinimizeCheckBox;
        private System.Windows.Forms.NotifyIcon systemTrayNotifyIcon;
        private System.Windows.Forms.CheckBox StartAtStartupCheckBox;
        private System.Windows.Forms.CheckBox StartMinimizedCheckBox;
        private System.Windows.Forms.ComboBox NotificationsDropdownList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button EditConfig;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox ConfigDescription;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox ConfigName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button updateCC;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button CalibrateRight;
        private System.Windows.Forms.TextBox RYCenter;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox RXCenter;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown DeadzonePicker;
        private System.Windows.Forms.Button CalibrateLeft;
        private System.Windows.Forms.TextBox LYCenter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox LXCenter;
        private System.Windows.Forms.Label label10;
    }
}