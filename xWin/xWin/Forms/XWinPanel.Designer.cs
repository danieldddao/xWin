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
            this.MouseMode = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.T_DeadzonePicker = new System.Windows.Forms.NumericUpDown();
            this.ControllerPanel.SuspendLayout();
            this.controllersPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DeadzonePicker)).BeginInit();
            this.Settings.SuspendLayout();
            this.panel1.SuspendLayout();
            this.log.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.T_DeadzonePicker)).BeginInit();
            this.SuspendLayout();
            // 
            // ControllerPanel
            // 
            this.ControllerPanel.Controls.Add(this.controllersPanel);
            this.ControllerPanel.Controls.Add(this.Settings);
            this.ControllerPanel.Controls.Add(this.log);
            this.ControllerPanel.Location = new System.Drawing.Point(10, 11);
            this.ControllerPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ControllerPanel.Multiline = true;
            this.ControllerPanel.Name = "ControllerPanel";
            this.ControllerPanel.SelectedIndex = 0;
            this.ControllerPanel.Size = new System.Drawing.Size(604, 376);
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
            this.controllersPanel.Location = new System.Drawing.Point(4, 22);
            this.controllersPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.controllersPanel.Name = "controllersPanel";
            this.controllersPanel.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.controllersPanel.Size = new System.Drawing.Size(596, 350);
            this.controllersPanel.TabIndex = 0;
            this.controllersPanel.Text = "Controllers";
            this.controllersPanel.UseVisualStyleBackColor = true;
            // 
            // EditConfig
            // 
            this.EditConfig.Location = new System.Drawing.Point(88, 299);
            this.EditConfig.Name = "EditConfig";
            this.EditConfig.Size = new System.Drawing.Size(75, 23);
            this.EditConfig.TabIndex = 16;
            this.EditConfig.Text = "Edit";
            this.EditConfig.UseVisualStyleBackColor = true;
            this.EditConfig.Click += new System.EventHandler(this.EditConfig_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(46, 275);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Description";
            // 
            // ConfigDescription
            // 
            this.ConfigDescription.Location = new System.Drawing.Point(112, 273);
            this.ConfigDescription.Name = "ConfigDescription";
            this.ConfigDescription.ReadOnly = true;
            this.ConfigDescription.Size = new System.Drawing.Size(100, 20);
            this.ConfigDescription.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(71, 249);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Name";
            // 
            // ConfigName
            // 
            this.ConfigName.Location = new System.Drawing.Point(112, 245);
            this.ConfigName.Name = "ConfigName";
            this.ConfigName.ReadOnly = true;
            this.ConfigName.Size = new System.Drawing.Size(100, 20);
            this.ConfigName.TabIndex = 12;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.MouseMode);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.T_DeadzonePicker);
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
            this.groupBox1.Location = new System.Drawing.Point(196, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(355, 189);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Controller Settings";
            // 
            // updateCC
            // 
            this.updateCC.Location = new System.Drawing.Point(224, 160);
            this.updateCC.Name = "updateCC";
            this.updateCC.Size = new System.Drawing.Size(119, 23);
            this.updateCC.TabIndex = 14;
            this.updateCC.Text = "Update Settings";
            this.updateCC.UseVisualStyleBackColor = true;
            this.updateCC.Click += new System.EventHandler(this.updateCC_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(221, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Right Stick Center";
            // 
            // CalibrateRight
            // 
            this.CalibrateRight.Location = new System.Drawing.Point(224, 97);
            this.CalibrateRight.Name = "CalibrateRight";
            this.CalibrateRight.Size = new System.Drawing.Size(75, 23);
            this.CalibrateRight.TabIndex = 8;
            this.CalibrateRight.Text = "Calibrate";
            this.CalibrateRight.UseVisualStyleBackColor = true;
            this.CalibrateRight.Click += new System.EventHandler(this.CalibrateRight_Click);
            // 
            // RYCenter
            // 
            this.RYCenter.Location = new System.Drawing.Point(243, 71);
            this.RYCenter.Name = "RYCenter";
            this.RYCenter.ReadOnly = true;
            this.RYCenter.Size = new System.Drawing.Size(100, 20);
            this.RYCenter.TabIndex = 12;
            this.RYCenter.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(190, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "X-center";
            // 
            // RXCenter
            // 
            this.RXCenter.Location = new System.Drawing.Point(243, 45);
            this.RXCenter.Name = "RXCenter";
            this.RXCenter.ReadOnly = true;
            this.RXCenter.Size = new System.Drawing.Size(100, 20);
            this.RXCenter.TabIndex = 11;
            this.RXCenter.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(190, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Y-center";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Left Stick Center";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Normal Deadzone";
            // 
            // DeadzonePicker
            // 
            this.DeadzonePicker.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.DeadzonePicker.Location = new System.Drawing.Point(10, 163);
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
            this.DeadzonePicker.Size = new System.Drawing.Size(66, 20);
            this.DeadzonePicker.TabIndex = 5;
            this.DeadzonePicker.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            // 
            // CalibrateLeft
            // 
            this.CalibrateLeft.Location = new System.Drawing.Point(41, 97);
            this.CalibrateLeft.Name = "CalibrateLeft";
            this.CalibrateLeft.Size = new System.Drawing.Size(75, 23);
            this.CalibrateLeft.TabIndex = 0;
            this.CalibrateLeft.Text = "Calibrate";
            this.CalibrateLeft.UseVisualStyleBackColor = true;
            this.CalibrateLeft.Click += new System.EventHandler(this.CalibrateLeft_Click);
            // 
            // LYCenter
            // 
            this.LYCenter.Location = new System.Drawing.Point(60, 71);
            this.LYCenter.Name = "LYCenter";
            this.LYCenter.ReadOnly = true;
            this.LYCenter.Size = new System.Drawing.Size(100, 20);
            this.LYCenter.TabIndex = 4;
            this.LYCenter.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "X-center";
            // 
            // LXCenter
            // 
            this.LXCenter.Location = new System.Drawing.Point(60, 45);
            this.LXCenter.Name = "LXCenter";
            this.LXCenter.ReadOnly = true;
            this.LXCenter.Size = new System.Drawing.Size(100, 20);
            this.LXCenter.TabIndex = 3;
            this.LXCenter.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 74);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "Y-center";
            // 
            // Settings
            // 
            this.Settings.Controls.Add(this.label1);
            this.Settings.Controls.Add(this.NotificationsDropdownList);
            this.Settings.Controls.Add(this.StartMinimizedCheckBox);
            this.Settings.Controls.Add(this.StartAtStartupCheckBox);
            this.Settings.Controls.Add(this.MinimizeCheckBox);
            this.Settings.Controls.Add(this.panel1);
            this.Settings.Location = new System.Drawing.Point(4, 22);
            this.Settings.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Settings.Name = "Settings";
            this.Settings.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Settings.Size = new System.Drawing.Size(596, 350);
            this.Settings.TabIndex = 1;
            this.Settings.Text = "Settings";
            this.Settings.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 159);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 15);
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
            this.NotificationsDropdownList.Location = new System.Drawing.Point(20, 175);
            this.NotificationsDropdownList.Margin = new System.Windows.Forms.Padding(2);
            this.NotificationsDropdownList.Name = "NotificationsDropdownList";
            this.NotificationsDropdownList.Size = new System.Drawing.Size(138, 21);
            this.NotificationsDropdownList.TabIndex = 4;
            this.NotificationsDropdownList.SelectedIndexChanged += new System.EventHandler(this.NotificationsDropdownList_SelectedIndexChanged);
            // 
            // StartMinimizedCheckBox
            // 
            this.StartMinimizedCheckBox.AutoSize = true;
            this.StartMinimizedCheckBox.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartMinimizedCheckBox.Location = new System.Drawing.Point(20, 112);
            this.StartMinimizedCheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.StartMinimizedCheckBox.Name = "StartMinimizedCheckBox";
            this.StartMinimizedCheckBox.Size = new System.Drawing.Size(111, 19);
            this.StartMinimizedCheckBox.TabIndex = 3;
            this.StartMinimizedCheckBox.Text = "Start minimized";
            this.StartMinimizedCheckBox.UseVisualStyleBackColor = true;
            this.StartMinimizedCheckBox.CheckedChanged += new System.EventHandler(this.StartMinimizedCheckBox_CheckedChanged);
            // 
            // StartAtStartupCheckBox
            // 
            this.StartAtStartupCheckBox.AutoSize = true;
            this.StartAtStartupCheckBox.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartAtStartupCheckBox.Location = new System.Drawing.Point(20, 77);
            this.StartAtStartupCheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.StartAtStartupCheckBox.Name = "StartAtStartupCheckBox";
            this.StartAtStartupCheckBox.Size = new System.Drawing.Size(235, 19);
            this.StartAtStartupCheckBox.TabIndex = 2;
            this.StartAtStartupCheckBox.Text = "Start application when Windows starts";
            this.StartAtStartupCheckBox.UseVisualStyleBackColor = true;
            this.StartAtStartupCheckBox.CheckedChanged += new System.EventHandler(this.StartAtStartupCheckBox_CheckedChanged);
            // 
            // MinimizeCheckBox
            // 
            this.MinimizeCheckBox.AutoSize = true;
            this.MinimizeCheckBox.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimizeCheckBox.Location = new System.Drawing.Point(20, 41);
            this.MinimizeCheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MinimizeCheckBox.Name = "MinimizeCheckBox";
            this.MinimizeCheckBox.Size = new System.Drawing.Size(152, 19);
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
            this.panel1.Location = new System.Drawing.Point(282, 41);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 245);
            this.panel1.TabIndex = 0;
            // 
            // customizeQuickTypeBar
            // 
            this.customizeQuickTypeBar.BackColor = System.Drawing.Color.FloralWhite;
            this.customizeQuickTypeBar.Location = new System.Drawing.Point(62, 185);
            this.customizeQuickTypeBar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.customizeQuickTypeBar.Name = "customizeQuickTypeBar";
            this.customizeQuickTypeBar.Size = new System.Drawing.Size(158, 32);
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
            this.buttonViewDictionary.Location = new System.Drawing.Point(101, 50);
            this.buttonViewDictionary.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonViewDictionary.Name = "buttonViewDictionary";
            this.buttonViewDictionary.Size = new System.Drawing.Size(104, 37);
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
            this.quickTypeTipsButton.Location = new System.Drawing.Point(216, 150);
            this.quickTypeTipsButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.quickTypeTipsButton.Name = "quickTypeTipsButton";
            this.quickTypeTipsButton.Size = new System.Drawing.Size(33, 23);
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
            this.wordPredictionTipsButton.Location = new System.Drawing.Point(178, 106);
            this.wordPredictionTipsButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.wordPredictionTipsButton.Name = "wordPredictionTipsButton";
            this.wordPredictionTipsButton.Size = new System.Drawing.Size(33, 23);
            this.wordPredictionTipsButton.TabIndex = 1;
            this.wordPredictionTipsButton.Text = "tips";
            this.wordPredictionTipsButton.UseVisualStyleBackColor = false;
            this.wordPredictionTipsButton.Click += new System.EventHandler(this.wordPredictionTipsButton_Click);
            // 
            // quickTypeCheckBox
            // 
            this.quickTypeCheckBox.AutoSize = true;
            this.quickTypeCheckBox.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quickTypeCheckBox.Location = new System.Drawing.Point(22, 152);
            this.quickTypeCheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.quickTypeCheckBox.Name = "quickTypeCheckBox";
            this.quickTypeCheckBox.Size = new System.Drawing.Size(197, 19);
            this.quickTypeCheckBox.TabIndex = 2;
            this.quickTypeCheckBox.Text = "Enable QuickType Suggestions";
            this.quickTypeCheckBox.UseVisualStyleBackColor = true;
            this.quickTypeCheckBox.CheckedChanged += new System.EventHandler(this.quickTypeCheckBox_CheckedChanged);
            // 
            // wordPredictionCheckBox
            // 
            this.wordPredictionCheckBox.AutoSize = true;
            this.wordPredictionCheckBox.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wordPredictionCheckBox.Location = new System.Drawing.Point(22, 109);
            this.wordPredictionCheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.wordPredictionCheckBox.Name = "wordPredictionCheckBox";
            this.wordPredictionCheckBox.Size = new System.Drawing.Size(155, 19);
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
            this.labelAutocomplete.Location = new System.Drawing.Point(84, 20);
            this.labelAutocomplete.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelAutocomplete.Name = "labelAutocomplete";
            this.labelAutocomplete.Size = new System.Drawing.Size(149, 21);
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
            this.log.Location = new System.Drawing.Point(4, 22);
            this.log.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.log.Name = "log";
            this.log.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.log.Size = new System.Drawing.Size(596, 350);
            this.log.TabIndex = 2;
            this.log.Text = "Log";
            this.log.UseVisualStyleBackColor = true;
            // 
            // reportError
            // 
            this.reportError.BackColor = System.Drawing.Color.OrangeRed;
            this.reportError.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reportError.Location = new System.Drawing.Point(528, 317);
            this.reportError.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.reportError.Name = "reportError";
            this.reportError.Size = new System.Drawing.Size(64, 27);
            this.reportError.TabIndex = 4;
            this.reportError.Text = "Report";
            this.reportError.UseVisualStyleBackColor = false;
            this.reportError.Click += new System.EventHandler(this.reportError_Click);
            // 
            // openLogFileButton
            // 
            this.openLogFileButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.openLogFileButton.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openLogFileButton.Location = new System.Drawing.Point(409, 317);
            this.openLogFileButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.openLogFileButton.Name = "openLogFileButton";
            this.openLogFileButton.Size = new System.Drawing.Size(107, 27);
            this.openLogFileButton.TabIndex = 3;
            this.openLogFileButton.Text = "Open Log File";
            this.openLogFileButton.UseVisualStyleBackColor = false;
            this.openLogFileButton.Click += new System.EventHandler(this.openLogFileButton_Click);
            // 
            // clearLogsButton
            // 
            this.clearLogsButton.Font = new System.Drawing.Font("Arial", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearLogsButton.Location = new System.Drawing.Point(200, 317);
            this.clearLogsButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.clearLogsButton.Name = "clearLogsButton";
            this.clearLogsButton.Size = new System.Drawing.Size(176, 27);
            this.clearLogsButton.TabIndex = 2;
            this.clearLogsButton.Text = "Clear All Logs";
            this.clearLogsButton.UseVisualStyleBackColor = true;
            this.clearLogsButton.Click += new System.EventHandler(this.clearLogsButton_Click);
            // 
            // debugModeCheckbox
            // 
            this.debugModeCheckbox.AutoSize = true;
            this.debugModeCheckbox.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.debugModeCheckbox.Location = new System.Drawing.Point(22, 322);
            this.debugModeCheckbox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.debugModeCheckbox.Name = "debugModeCheckbox";
            this.debugModeCheckbox.Size = new System.Drawing.Size(144, 20);
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
            this.logListView.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.logListView.Name = "logListView";
            this.logListView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.logListView.Size = new System.Drawing.Size(596, 310);
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
            // MouseMode
            // 
            this.MouseMode.AutoSize = true;
            this.MouseMode.Location = new System.Drawing.Point(206, 126);
            this.MouseMode.Name = "MouseMode";
            this.MouseMode.Size = new System.Drawing.Size(137, 17);
            this.MouseMode.TabIndex = 17;
            this.MouseMode.Text = "Dynamic Pointer Speed";
            this.MouseMode.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(103, 147);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(91, 13);
            this.label11.TabIndex = 16;
            this.label11.Text = "Typing Deadzone";
            // 
            // T_DeadzonePicker
            // 
            this.T_DeadzonePicker.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.T_DeadzonePicker.Location = new System.Drawing.Point(116, 163);
            this.T_DeadzonePicker.Maximum = new decimal(new int[] {
            15000,
            0,
            0,
            0});
            this.T_DeadzonePicker.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.T_DeadzonePicker.Name = "T_DeadzonePicker";
            this.T_DeadzonePicker.Size = new System.Drawing.Size(66, 20);
            this.T_DeadzonePicker.TabIndex = 15;
            this.T_DeadzonePicker.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            // 
            // XWinPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 398);
            this.Controls.Add(this.ControllerPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "XWinPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XWin Panel";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.XWinPanel_FormClosed);
            this.Load += new System.EventHandler(this.XWinPanel_Load);
            this.Resize += new System.EventHandler(this.XWinPanel_Resize);
            this.ControllerPanel.ResumeLayout(false);
            this.controllersPanel.ResumeLayout(false);
            this.controllersPanel.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DeadzonePicker)).EndInit();
            this.Settings.ResumeLayout(false);
            this.Settings.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.log.ResumeLayout(false);
            this.log.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.T_DeadzonePicker)).EndInit();
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
        private System.Windows.Forms.CheckBox MouseMode;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown T_DeadzonePicker;
    }
}