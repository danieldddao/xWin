using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using xWin.Forms.ButtonMaps;
using xWin.Library;

namespace xWin.Forms.AutoCompleteForms
{
    public partial class QuickTypeBarCustomization : Form
    {
        public List<Keys> qtButton1Shortcut = new List<Keys>();
        private List<Keys> qtTmpButton1Shortcut = new List<Keys>();

        public List<Keys> qtButton2Shortcut = new List<Keys>();
        private List<Keys> qtTmpButton2Shortcut = new List<Keys>();

        public List<Keys> qtButton3Shortcut = new List<Keys>();
        private List<Keys> qtTmpButton3Shortcut = new List<Keys>();

        public bool usingShortcuts = false;
        private bool usingShortcutsTmp = false;

        public int quickTypeTimerInterval = 5000;
        private int quickTypeTimerIntervalTmp = 5000;

        public QuickTypeBarCustomization(List<Keys> button1Shortcut, List<Keys> button2Shortcut, List<Keys> button3Shortcut, bool shortcuts, int interval)
        {
            InitializeComponent();;

            qtButton1Shortcut = button1Shortcut;
            qtButton2Shortcut = button2Shortcut;
            qtButton3Shortcut = button3Shortcut;

            qtTmpButton1Shortcut = qtButton1Shortcut;
            qtTmpButton2Shortcut = qtButton2Shortcut;
            qtTmpButton3Shortcut = qtButton3Shortcut;

            usingShortcuts = shortcuts;
            usingShortcutsTmp = usingShortcuts;

            quickTypeTimerInterval = interval;
            quickTypeTimerIntervalTmp = quickTypeTimerInterval;
        }

        private void QuickTypeBarCustomization_Load(object sender, EventArgs e)
        {
            UpdateForm();
        }

        private void UpdateForm()
        {
            try
            {
                if (qtTmpButton1Shortcut.Count == 0)
                {
                    quickTypeButton1TextBox.Text = "None";
                }
                else
                {
                    quickTypeButton1TextBox.Text = "";
                    string shortcut = "";
                    for (int i=0; i<qtTmpButton1Shortcut.Count; i++)
                    {
                        if (i == qtTmpButton1Shortcut.Count-1) { shortcut += qtTmpButton1Shortcut[i].ToString(); }
                        else shortcut += qtTmpButton1Shortcut[i] + " + ";
                    }
                    quickTypeButton1TextBox.Text = shortcut;
                }

                if (qtTmpButton2Shortcut.Count == 0)
                {
                    quickTypeButton2TextBox.Text = "None";
                }
                else
                {
                    quickTypeButton2TextBox.Text = "";
                    string shortcut = "";
                    for (int i = 0; i < qtTmpButton2Shortcut.Count; i++)
                    {
                        if (i == qtTmpButton2Shortcut.Count - 1) { shortcut += qtTmpButton2Shortcut[i].ToString(); }
                        else shortcut += qtTmpButton2Shortcut[i] + " + ";
                    }
                    quickTypeButton2TextBox.Text = shortcut;
                }

                if (qtTmpButton3Shortcut.Count == 0)
                {
                    quickTypeButton3TextBox.Text = "None";
                }
                else
                {
                    quickTypeButton3TextBox.Text = "";
                    string shortcut = "";
                    for (int i = 0; i < qtTmpButton3Shortcut.Count; i++)
                    {
                        if (i == qtTmpButton3Shortcut.Count - 1) { shortcut += qtTmpButton3Shortcut[i].ToString(); }
                        else shortcut += qtTmpButton3Shortcut[i] + " + ";
                    }
                    quickTypeButton3TextBox.Text = shortcut;
                }

                if (usingShortcutsTmp)
                {
                    usingShortcutsCheckBox.Checked = true;
                }
                else
                {
                    usingShortcutsCheckBox.Checked = false;
                }

                quickBarHideTimeTextBox.Text = "" + quickTypeTimerIntervalTmp/1000;
            }
            catch (Exception ex)
            {
                Log.GetLogger().Error(ex);
            }
        }

        private void quickTypeButton1_Click(object sender, EventArgs e)
        {
            try
            {
                ShortcutMapping shortcutM = new ShortcutMapping();
                shortcutM.Text = "Set shortcut for suggestion 1";
                shortcutM.SetLabel("Enter Your Shortcut below:");
                shortcutM.ShowDialog();
                // If suggestion 2's shortcut is the same as new shortcut
                if (shortcutM.shortcut.Count != 0 && (shortcutM.shortcut.Count == qtTmpButton2Shortcut.Count) && !shortcutM.shortcut.Except(qtTmpButton2Shortcut).Any())
                {
                    MessageBox.Show("Shortcut already assigned to suggestion 2");
                }
                // If suggestion 3's shortcut is the same as new shortcut
                else if (shortcutM.shortcut.Count != 0 && (shortcutM.shortcut.Count == qtTmpButton3Shortcut.Count) && !shortcutM.shortcut.Except(qtTmpButton3Shortcut).Any())
                {
                    MessageBox.Show("Shortcut already assigned to suggestion 3");
                }
                else if (shortcutM.shortcut.Count > 0)
                {
                    qtTmpButton1Shortcut = shortcutM.shortcut;
                }
                UpdateForm();
            }
            catch (Exception ex)
            {
                Log.GetLogger().Error(ex);
            }
        }

        private void quickTypeButton2_Click(object sender, EventArgs e)
        {
            try
            {
                ShortcutMapping shortcutM = new ShortcutMapping();
                shortcutM.Text = "Set shortcut for suggestion 2";
                shortcutM.SetLabel("Enter Your Shortcut below:");
                shortcutM.ShowDialog();
                // If suggestion 1's shortcut is the same as new shortcut
                if (shortcutM.shortcut.Count != 0 && (shortcutM.shortcut.Count == qtTmpButton1Shortcut.Count) && !shortcutM.shortcut.Except(qtTmpButton1Shortcut).Any())
                {
                    MessageBox.Show("Shortcut already assigned to suggestion 1");
                }
                // If suggestion 3's shortcut is the same as new shortcut
                else if (shortcutM.shortcut.Count != 0 && (shortcutM.shortcut.Count == qtTmpButton3Shortcut.Count) && !shortcutM.shortcut.Except(qtTmpButton3Shortcut).Any())
                {
                    MessageBox.Show("Shortcut already assigned to suggestion 3");
                }
                else if (shortcutM.shortcut.Count > 0)
                {
                    qtTmpButton2Shortcut = shortcutM.shortcut;
                }
                UpdateForm();
            }
            catch (Exception ex)
            {
                Log.GetLogger().Error(ex);
            }
        }

        private void quickTypeButton3_Click(object sender, EventArgs e)
        {
            try
            {
                ShortcutMapping shortcutM = new ShortcutMapping();
                shortcutM.Text = "Set shortcut for suggestion 3";
                shortcutM.SetLabel("Enter Your Shortcut below:");
                shortcutM.ShowDialog();
                // If suggestion 1's shortcut is the same as new shortcut
                if (shortcutM.shortcut.Count != 0 && (shortcutM.shortcut.Count == qtTmpButton1Shortcut.Count) && !shortcutM.shortcut.Except(qtTmpButton1Shortcut).Any())
                {
                    MessageBox.Show("Shortcut already assigned to suggestion 1");
                }
                // If suggestion 2's shortcut is the same as new shortcut
                else if (shortcutM.shortcut.Count != 0 && (shortcutM.shortcut.Count == qtTmpButton2Shortcut.Count) && !shortcutM.shortcut.Except(qtTmpButton2Shortcut).Any())
                {
                    MessageBox.Show("Shortcut already assigned to suggestion 2");
                }
                else if (shortcutM.shortcut.Count > 0)
                {
                    qtTmpButton3Shortcut = shortcutM.shortcut;
                }
                UpdateForm();
            }
            catch (Exception ex)
            {
                Log.GetLogger().Error(ex);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            qtButton1Shortcut = qtTmpButton1Shortcut;
            qtButton2Shortcut = qtTmpButton2Shortcut;
            qtButton3Shortcut = qtTmpButton3Shortcut;
            usingShortcuts = usingShortcutsTmp;
            quickTypeTimerInterval = quickTypeTimerIntervalTmp;
            this.Close();
        }

        private void usingShortcutsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (usingShortcutsCheckBox.Checked)
            {
                usingShortcutsTmp = true;
            }
            else
            {
                usingShortcutsTmp = false;
            }
        }

        private void quickBarHideTimeTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("^[0-9]+$");
                Match match = regex.Match(quickBarHideTimeTextBox.Text);
                if (match.Success)
                {
                    int interval = Int32.Parse(quickBarHideTimeTextBox.Text);
                    if (interval == 0)
                    {
                        quickTypeTimerIntervalTmp = 5000;
                        quickBarHideTimeTextBox.Text = "5";
                        MessageBox.Show("Please enter a positive integer!");
                    }
                    else
                    { quickTypeTimerIntervalTmp = Int32.Parse(quickBarHideTimeTextBox.Text) * 1000; }
                }
                else
                {
                    quickTypeTimerIntervalTmp = 5000;
                    quickBarHideTimeTextBox.Text = "5";
                    MessageBox.Show("Please enter an integer!");
                }

                Log.GetLogger().Info("Set new interval for QuickType bar: " + quickTypeTimerIntervalTmp);
            }
            catch (Exception ex)
            {
                Log.GetLogger().Error(ex);
            }
        }
    }
}
