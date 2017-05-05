using Gma.System.MouseKeyHook;
using Microsoft.Win32;
using SharpDX.XInput;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using xWin.Forms.AutoCompleteForms;
using xWin.GUI;
using xWin.Library;

namespace xWin.Forms
{
    public partial class XWinPanel : Form, log4net.Appender.IAppender
    {
        private bool minimizeToSystemTray = false;
        private string notifications = "";

        public XWinPanel(List<string> l)
        {
            InitializeComponent();

            Thread thread = new Thread(WI.InteractionLoop);
            thread.Start();
            this.l = l;
            ConfigName.Text = Program.config.Name == null ? "" : Program.config.Name;
            ConfigDescription.Text = Program.config.Description == null ? "" : Program.config.Description;
            this.FormClosing += XWinPanel_FormClosing1;
            LXCenter.Text = Program.cc.lx.ToString();
            LYCenter.Text = Program.cc.ly.ToString();
            RXCenter.Text = Program.cc.rx.ToString();
            RYCenter.Text = Program.cc.ry.ToString();
            DeadzonePicker.Value = Program.cc.deadzone;
            T_DeadzonePicker.Value = Program.cc.t_deadzone;
            MouseMode.Checked = Program.dynamicmode;
        }

        private void XWinPanel_FormClosing1(object sender, FormClosingEventArgs e)
        {

            e.Cancel = true;
            MinimizeApplication();
        }

        /* Update Controllers status when loading main panel */
        private void XWinPanel_Load(object sender, EventArgs e)
        {
           // UpdateControllers();

            autoComplete = new AutoComplete();

            //if (autoComplete.enableWordPrediction || autoComplete.enableQuickType) { autoComplete.KeyboardInputsSubscribe(); } // Subscribe to read keyboard inputs
            if (autoComplete.enableWordPrediction) { wordPredictionCheckBox.Checked = true; }
            if (autoComplete.enableQuickType) { quickTypeCheckBox.Checked = true; }
            
            if (KeyLoc.GetValue("XWinMinimizeToSystemTray") == null)
            {
                MinimizeCheckBox.Checked = false;
            }
            else
            {
                MinimizeCheckBox.Checked = true;
            }

            if (KeyLoc.GetValue("XWinStartUp") == null)
            {
                // If the value doesn't exist, the application is not set to run at startup
                StartAtStartupCheckBox.Checked = false;
            }
            else
            {
                // The value exists, the application is set to run at startup
                StartAtStartupCheckBox.Checked = true;
            }
                
            if (KeyLoc.GetValue("XWinStartMinimized") == null)
            {
                // If the value doesn't exist, the application is not set to start minimized
                StartMinimizedCheckBox.Checked = false;
            }
            else
            {
                // The value exists, the application is set to start minimized
                StartMinimizedCheckBox.Checked = true;
                MinimizeApplication();
            }

            if (KeyLoc.GetValue("XWinWordPrediction") == null)
            {
                wordPredictionCheckBox.Checked = false;
            }
            else
            {
                wordPredictionCheckBox.Checked = true;
            }

            if (KeyLoc.GetValue("XWinQuickType") == null)
            {
                quickTypeCheckBox.Checked = false;
            }
            else
            {
                quickTypeCheckBox.Checked = true;
            }

            if (KeyLoc.GetValue("XWinDebugMode") == null)
            {
                // If the value doesn't exist, the debug mode is disabled
                debugModeCheckbox.Checked = false;
                //Log.DisableDebugMode();
            }
            else
            {
                // The value exists, debug mode is enabled
                debugModeCheckbox.Checked = true;
                //Log.EnableDebugMode();
            }

            Log.GetLogger().Info("Application started");
        }

        private void XWinPanel_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (autoComplete.enableQuickType || autoComplete.enableWordPrediction) { autoComplete.KeyboardInputsUnsubscribe(); } // Unsubscribe to unread keyboard inputs

            systemTrayNotifyIcon.Visible = false;
        }
        /*
        private void UpdateControllers()
        {
            // Check status of each controller and update the button accordingly
            if (XCon1.IsConnected())
            {
                Controller1.Text = "Controller 1 \nConnected";
                Controller1.BackColor = Color.FromArgb(46, 204, 113);

                //Log.GetLogger().Debug("Previously Connected " + XCon1.IsPreviouslyConnected);
                if (!XCon1.IsPreviouslyConnected) { Log.GetLogger().Info("Controller 1 Connected"); }
                XCon1.IsPreviouslyConnected = true;
            }
            else
            {
                Controller1.Text = "Controller 1 \nDisconnected";
                Controller1.BackColor = Color.FromArgb(255, 0, 51);
                if (XCon1Thread.IsAlive) { XCon1Thread.Abort(); }

                //Log.GetLogger().Debug("Previously Connected " + XCon1.IsPreviouslyConnected);
                if (XCon1.IsPreviouslyConnected) { Log.GetLogger().Info("Controller 1 Disconnected"); }
                XCon1.IsPreviouslyConnected = false;
            }

            if (XCon2.IsConnected())
            {
                Controller2.Text = "Controller 2 \nConnected";
                Controller2.BackColor = Color.FromArgb(46, 204, 113);

                //Log.GetLogger().Debug("Previously Connected " + XCon2.IsPreviouslyConnected);
                if (!XCon2.IsPreviouslyConnected) { Log.GetLogger().Info("Controller 2 Connected"); }
                XCon2.IsPreviouslyConnected = true;
            }
            else
            {
                Controller2.Text = "Controller 2 \nDisconnected";
                Controller2.BackColor = Color.FromArgb(255, 0, 51);
                if (XCon2Thread.IsAlive) { XCon2Thread.Abort(); }
                //Log.GetLogger().Debug("Previously Connected " + XCon2.IsPreviouslyConnected);
                if (XCon2.IsPreviouslyConnected) { Log.GetLogger().Info("Controller 2 Disconnected"); }
                XCon2.IsPreviouslyConnected = false;
            }

            if (XCon3.IsConnected())
            {
                Controller3.Text = "Controller 3 \nConnected";
                Controller3.BackColor = Color.FromArgb(46, 204, 113);

                //Log.GetLogger().Debug("Previously Connected " + XCon3.IsPreviouslyConnected);
                if (!XCon3.IsPreviouslyConnected) { Log.GetLogger().Info("Controller 3 Connected"); }
                XCon3.IsPreviouslyConnected = true;
            }
            else
            {
                Controller3.Text = "Controller 3 \nDisconnected";
                Controller3.BackColor = Color.FromArgb(255, 0, 51);
                if (XCon3Thread.IsAlive) { XCon3Thread.Abort(); }
                //Log.GetLogger().Debug("Previously Connected " + XCon3.IsPreviouslyConnected);
                if (XCon3.IsPreviouslyConnected) { Log.GetLogger().Info("Controller 3 Disconnected"); }
                XCon3.IsPreviouslyConnected = false;
            }

            if (XCon4.IsConnected())
            {
                Controller4.Text = "Controller 4 \nConnected";
                Controller4.BackColor = Color.FromArgb(46, 204, 113);

                //Log.GetLogger().Debug("Previously Connected " + XCon4.IsPreviouslyConnected);
                if (!XCon4.IsPreviouslyConnected) { Log.GetLogger().Info("Controller 4 Connected"); }
                XCon4.IsPreviouslyConnected = true;
            }
            else
            {
                Controller4.Text = "Controller 4 \nDisconnected";
                Controller4.BackColor = Color.FromArgb(255, 0, 51);
                if (XCon4Thread.IsAlive) { XCon4Thread.Abort(); }
                //Log.GetLogger().Debug("Previously Connected " + XCon4.IsPreviouslyConnected);
                if (XCon4.IsPreviouslyConnected) { Log.GetLogger().Info("Controller 4 Disconnected"); }
                XCon4.IsPreviouslyConnected = false;
            }
        }
        */
        
        /*
         * For Logging
         */
        delegate void UniversalVoidDelegate();
        /// Call form control action from different thread
        public static void ControlInvike(Control control, Action function)
        {
            if (control.IsDisposed || control.Disposing)
                return;

            if (control.InvokeRequired)
            {
                control.Invoke(new UniversalVoidDelegate(() => ControlInvike(control, function)));
                return;
            }
            function();
        }

        public void DoAppend(log4net.Core.LoggingEvent loggingEvent)
        {
            try
            {
                // Notifications
                systemTrayNotifyIcon.BalloonTipTitle = "XWin";
                if (loggingEvent.Level == log4net.Core.Level.Warn)
                    systemTrayNotifyIcon.BalloonTipIcon = ToolTipIcon.Warning;
                else if (loggingEvent.Level == log4net.Core.Level.Error)
                    systemTrayNotifyIcon.BalloonTipIcon = ToolTipIcon.Error;
                else
                    systemTrayNotifyIcon.BalloonTipIcon = ToolTipIcon.Info;

                switch (notifications)
                {
                    case "all":
                        systemTrayNotifyIcon.BalloonTipText = loggingEvent.MessageObject.ToString();
                        systemTrayNotifyIcon.ShowBalloonTip(50);
                        systemTrayNotifyIcon.Visible = true;
                        break;
                    case "warnings":
                        if (loggingEvent.Level == log4net.Core.Level.Warn)
                        {
                            systemTrayNotifyIcon.BalloonTipText = loggingEvent.MessageObject.ToString();
                            systemTrayNotifyIcon.ShowBalloonTip(50);
                            systemTrayNotifyIcon.Visible = true;
                        }
                        break;
                    case "errors":
                        if (loggingEvent.Level == log4net.Core.Level.Error)
                        {
                            systemTrayNotifyIcon.BalloonTipText = loggingEvent.MessageObject.ToString();
                            systemTrayNotifyIcon.ShowBalloonTip(50);
                            systemTrayNotifyIcon.Visible = true;
                        }
                        break;
                    default:
                        break;
                }

                // Log
                ListViewItem list = new ListViewItem(loggingEvent.TimeStamp.ToString());
                if (loggingEvent.Level == log4net.Core.Level.Error)
                {
                    list.BackColor = Color.DarkRed;
                    list.ForeColor = Color.White;
                }
                else if (loggingEvent.Level == log4net.Core.Level.Debug)
                {
                    list.BackColor = Color.LightSkyBlue;
                    list.ForeColor = Color.Black;
                }
                else if (loggingEvent.Level == log4net.Core.Level.Warn)
                {
                    list.BackColor = Color.Yellow;
                    list.ForeColor = Color.Black;
                }
                else
                {
                    list.BackColor = Color.White;
                    list.ForeColor = Color.Black;
                }
                list.SubItems.Add(loggingEvent.Level.Name);
                list.SubItems.Add(loggingEvent.LoggerName.Substring(loggingEvent.LoggerName.LastIndexOf("xWin")));
                list.SubItems.Add(loggingEvent.MessageObject.ToString());
                logListView.Sorting = System.Windows.Forms.SortOrder.Descending;
                ControlInvike(logListView, () => logListView.Items.Add(list));                
            }
            catch (Exception e)
            {
                Log.GetLogger().Error(e);
            }
        }

        private void debugModeCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (debugModeCheckbox.Checked)
                {
                    KeyLoc.SetValue("XWinDebugMode", true);
                    Log.EnableDebugMode();
                }
                else
                {
                    KeyLoc.DeleteValue("XWinDebugMode", false);
                    Log.DisableDebugMode();
                }
            }
            catch (Exception ex)
            {
                Log.GetLogger().Error(ex);
            }
        }

        private void clearLogsButton_Click(object sender, EventArgs e)
        {
            try
            {
                logListView.Items.Clear();
                Log.ClearLogs();
            }
            catch (Exception ex)
            {
                Log.GetLogger().Error(ex);
            }
        }

        private void openLogFileButton_Click(object sender, EventArgs e)
        {
            try
            {
                Log.GetLogger().Info("Opening log file...");
                Log.OpenLogFile();
            }
            catch (Exception ex)
            {
                Log.GetLogger().Error(ex);
            }
        }

        private void reportError_Click(object sender, EventArgs e)
        {
            try
            {
                EmailError emailError = new EmailError();
                if (autoComplete.enableQuickType || autoComplete.enableWordPrediction) { autoComplete.KeyboardInputsUnsubscribe(); }
                emailError.ShowDialog();
                if (autoComplete.enableQuickType || autoComplete.enableWordPrediction) { autoComplete.KeyboardInputsSubscribe(); }
            }
            catch (Exception ex)
            {
                Log.GetLogger().Error(ex);
            }
        }

        /*
         * Code for AutoComplete feature
         */
        AutoComplete autoComplete;

        private void wordPredictionCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (wordPredictionCheckBox.Checked)
            {
                autoComplete.enableWordPrediction = true;
                if (!autoComplete.enableQuickType) // if quicktype is disabled
                {
                    autoComplete.KeyboardInputsSubscribe();
                }
                KeyLoc.SetValue("XWinWordPrediction", true);
                Log.GetLogger().Info("Enabled Word Prediction");
            }
            else
            {
                autoComplete.enableWordPrediction = false;
                if (!autoComplete.enableQuickType) // if quicktype is already disabled
                {
                    autoComplete.KeyboardInputsUnsubscribe();
                    autoComplete.typedWord = "";
                    autoComplete.predictiveSubWord = "";
                }
                KeyLoc.DeleteValue("XWinWordPrediction", false);
                Log.GetLogger().Info("Disabled Word Prediction");
            }
            Log.GetLogger().Debug("Word Prediction option changed to :" + autoComplete.enableWordPrediction);
        }

        private void quickTypeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (quickTypeCheckBox.Checked)
            {
                autoComplete.enableQuickType = true;
                if (!autoComplete.enableWordPrediction) // if word prediction is disabled
                {
                    autoComplete.KeyboardInputsSubscribe();
                }
                KeyLoc.SetValue("XWinQuickType", true);
                Log.GetLogger().Info("Enabled Quicktype suggestions");
            }
            else
            {
                autoComplete.enableQuickType = false;
                if (!autoComplete.enableWordPrediction) // if word prediction is disabled
                {
                    autoComplete.KeyboardInputsUnsubscribe();
                    autoComplete.typedWord = "";
                    autoComplete.predictiveSubWord = "";
                }
                autoComplete.Hide();
                autoComplete.StopTimer();
                KeyLoc.DeleteValue("XWinQuickType", false);
                Log.GetLogger().Info("Disabled Quicktype suggestions");
            }
            Log.GetLogger().Debug("Quicktype option changed to :" + autoComplete.enableQuickType);
        }

        private void buttonViewDictionary_Click(object sender, EventArgs e)
        {
            AutoCompleteDictionary dictionary = new AutoCompleteDictionary();
            if (autoComplete.enableQuickType || autoComplete.enableWordPrediction) { autoComplete.KeyboardInputsUnsubscribe(); }
            dictionary.ShowDialog();
            if (autoComplete.enableQuickType || autoComplete.enableWordPrediction) { autoComplete.KeyboardInputsSubscribe(); }
        }

        private void wordPredictionTipsButton_Click(object sender, EventArgs e)
        {
            WordPredictionTips wordPredictionTips = new WordPredictionTips();
            wordPredictionTips.Show();
        }

        private void quickTypeTipsButton_Click(object sender, EventArgs e)
        {
            QuickTypeSuggesstionsTips quickTypeSuggesstionsTips = new QuickTypeSuggesstionsTips();
            quickTypeSuggesstionsTips.Show();
        }

        private void customizeQuickTypeBar_Click(object sender, EventArgs e)
        {
            QuickTypeBarCustomization qtbar = new QuickTypeBarCustomization(autoComplete.suggestion1Shortcut, autoComplete.suggestion2Shortcut, autoComplete.suggestion3Shortcut, autoComplete.usingShortcuts, autoComplete.quickTypeTimerInterval);
            if (autoComplete.enableQuickType || autoComplete.enableWordPrediction)
            { autoComplete.KeyboardInputsUnsubscribe(); }

            qtbar.ShowDialog();
            if (qtbar.qtButton1Shortcut.Count > 0) { autoComplete.suggestion1Shortcut = qtbar.qtButton1Shortcut; }
            if (qtbar.qtButton2Shortcut.Count > 0) { autoComplete.suggestion2Shortcut = qtbar.qtButton2Shortcut; }
            if (qtbar.qtButton3Shortcut.Count > 0) { autoComplete.suggestion3Shortcut = qtbar.qtButton3Shortcut; }
            autoComplete.usingShortcuts = qtbar.usingShortcuts;
            autoComplete.quickTypeTimerInterval = qtbar.quickTypeTimerInterval;

            if (autoComplete.enableQuickType || autoComplete.enableWordPrediction)
            { autoComplete.KeyboardInputsSubscribe(); }

            Log.GetLogger().Info("Successfully updated the shortcuts for quicktype bar");
            Log.GetLogger().Info("Suggestion 1's shortcut: (" + autoComplete.suggestion1Shortcut.Count + ") " + string.Join("+ ", autoComplete.suggestion1Shortcut.ToArray()));
            Log.GetLogger().Info("Suggestion 2's shortcut: (" + autoComplete.suggestion2Shortcut.Count + ")" + string.Join("+ ", autoComplete.suggestion2Shortcut.ToArray()));
            Log.GetLogger().Info("Suggestion 3's shortcut: (" + autoComplete.suggestion3Shortcut.Count + ")" + string.Join("+ ", autoComplete.suggestion3Shortcut.ToArray()));
        }

        private void MinimizeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (MinimizeCheckBox.Checked)
            {
                minimizeToSystemTray = true;
                KeyLoc.SetValue("XWinMinimizeToSystemTray", true);
            }
            else
            {
                minimizeToSystemTray = false;
                KeyLoc.DeleteValue("XWinMinimizeToSystemTray", false);
            }
        }

        private void MinimizeApplication()
        {
            try
            {
                systemTrayNotifyIcon.BalloonTipText = "XWin Application is minimized...";
                systemTrayNotifyIcon.BalloonTipTitle = "XWin";
                systemTrayNotifyIcon.BalloonTipIcon = ToolTipIcon.Info;
                systemTrayNotifyIcon.ShowBalloonTip(100);
                this.ShowInTaskbar = false;
                systemTrayNotifyIcon.Visible = true;
                this.Hide();
                Log.GetLogger().Info("Minimized Application to system tray!");
            }
            catch (Exception e)
            {
                Log.GetLogger().Error(e);
            }
        }

        // Minimize app to system tray when minimizeToSystemTray is true
        private void XWinPanel_Resize(object sender, EventArgs e)
        {
            try
            {
                bool cursorNotInBar = Screen.GetWorkingArea(this).Contains(Cursor.Position);
                if (minimizeToSystemTray && FormWindowState.Minimized == this.WindowState && cursorNotInBar)
                {
                    MinimizeApplication();
                }
            }
            catch (Exception ex)
            {
                Log.GetLogger().Error(ex);
            }
        }

        // Unminimize app when double click on the xWin icon in system tray
        private void systemTrayNotifyIcon_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Normal;
                this.ShowInTaskbar = true;
                systemTrayNotifyIcon.Visible = false;
                this.Show();
                Log.GetLogger().Info("Unminimized Application to system tray!");
            }
            catch (Exception ex)
            {
                Log.GetLogger().Error(ex);
            }
        }

        /*
         * Start Application when Windows starts 
         */
        RegistryKey KeyLoc = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        private void StartAtStartupCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (StartAtStartupCheckBox.Checked)
                {
                    // Add the value in the registry so that the application runs at startup
                    KeyLoc.SetValue("XWinStartUp", Application.ExecutablePath);
                    Log.GetLogger().Info("Starting Application at startup is enabled!");
                }
                else
                {
                    // Remove the value from the registry so that the application doesn't start
                    KeyLoc.DeleteValue("XWinStartUp", false);
                    Log.GetLogger().Info("Starting Application at startup is disabled!");
                }
            }
            catch (Exception ex)
            {
                Log.GetLogger().Error(ex);
            }
        }

        // Start the app minimized in system tray
        private void StartMinimizedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (StartMinimizedCheckBox.Checked)
                {
                    KeyLoc.SetValue("XWinStartMinimized", true);
                    Log.GetLogger().Info("Start the Application Minimized!");
                }
                else
                {
                    KeyLoc.DeleteValue("XWinStartMinimized", false);
                    Log.GetLogger().Info("Start the Application Unminimized!");
                }
            }
            catch (Exception ex)
            {
                Log.GetLogger().Error(ex);
            }
        }

        private void NotificationsDropdownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch (NotificationsDropdownList.SelectedItem.ToString())
                {
                    case "Notify All":
                        notifications = "all";
                        Log.GetLogger().Info("Notifications option changed to notify all");
                        break;
                    case "Notify Only Warnings":
                        notifications = "warnings";
                        Log.GetLogger().Info("Notifications option changed to notify only warnings");
                        break;
                    case "Notify Only Errors":
                        notifications = "errors";
                        Log.GetLogger().Info("Notifications option changed to notify only errors");
                        break;
                    default:
                        notifications = "none";
                        Log.GetLogger().Info("Notifications option changed to notify None");
                        break;
                }
            }
            catch (Exception ex)
            {
                Log.GetLogger().Error(ex);
            }
        }

        private short lxc, lyc, rxc, ryc;
        private List<string> l;
        private void EditConfig_Click(object sender, EventArgs e)
        {
            var cw = new ConfigWindow(Program.config, l);
            cw.ShowDialog();
            ConfigName.Text = cw.c.Name == null ? "" : cw.c.Name;
            ConfigDescription.Text = cw.c.Description == null ? "" : cw.c.Description;
            Program.config = cw.c;
            Program.update_config = true;
            CharacterWheel.keySet = Program.config.Typing.Base.Set;
        }

        private void CalibrateLeft_Click(object sender, EventArgs e)
        {
            var s = Program.Controller.GetState();
            lxc = s.Gamepad.LeftThumbX;
            lyc = s.Gamepad.LeftThumbY;
            LXCenter.Text = lxc.ToString();
            LYCenter.Text = lyc.ToString();
        }

        private void CalibrateRight_Click(object sender, EventArgs e)
        {
            var s = Program.Controller.GetState();
            rxc = s.Gamepad.RightThumbX;
            ryc = s.Gamepad.RightThumbY;
            RXCenter.Text = rxc.ToString();
            RYCenter.Text = ryc.ToString();
        }

        private void updateCC_Click(object sender, EventArgs e)
        {
            var cc = Program.cc;
            cc.lx = lxc;
            cc.ly = lyc;
            cc.rx = rxc;
            cc.ry = ryc;
            cc.deadzone = (uint)DeadzonePicker.Value;
            cc.t_deadzone = (uint)T_DeadzonePicker.Value;
            Program.dynamicmode = MouseMode.Checked;
            Program.update_cc = true;
        }
        
    }
}
