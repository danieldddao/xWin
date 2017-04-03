using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace xWin.Library
{
    public partial class KeyboardWindow : Form
    {
        private XController c;
        System.Windows.Forms.Timer fadeTimer = new System.Windows.Forms.Timer();
        
        Dictionary<string, bool> buttonHold = new Dictionary<string, bool> {};
        bool selectionMade = false;
        public KeyboardWindow(XController c)
        {
            this.c = c;
            buttonHold.Add("A", false);
            buttonHold.Add("B", false);
            buttonHold.Add("X", false);
            buttonHold.Add("Y", false);
            buttonHold.Add("START", false);
            buttonHold.Add("BACK", false);
            buttonHold.Add("LEFT_S", false);
            buttonHold.Add("RIGHT_S", false);
            buttonHold.Add("LEFT_T", false);
            buttonHold.Add("RIGHT_T", false);
            buttonHold.Add("DPAD_UP", false);
            buttonHold.Add("DPAD_RIGHT", false);
            buttonHold.Add("DPAD_LEFT", false);
            buttonHold.Add("DPAD_DOWN", false);
            InitializeComponent();
        }
        private void CloseButton_Click(object sender,EventArgs e)
        {
            Close();
        }

        private void KeyboardWindow_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            Opacity = 0;
            Size = new Size(600, 600);
            this.OnePadPanel.Visible = true;
            this.OnePadPanel.Location = new Point(0, 0);
            this.FourPadPanel.Visible = false;
            this.FourPadPanel.Location = new Point(0, 0);
            if (System.Windows.Forms.Cursor.Position.X - this.Width - 20 <= SystemInformation.VirtualScreen.Left && System.Windows.Forms.Cursor.Position.Y - this.Height - 20 <= SystemInformation.VirtualScreen.Top)
                Location = new Point(SystemInformation.VirtualScreen.Left, SystemInformation.VirtualScreen.Top);
            else if (System.Windows.Forms.Cursor.Position.X - this.Width - 20 <= SystemInformation.VirtualScreen.Left)
                Location = new Point(SystemInformation.VirtualScreen.Left, System.Windows.Forms.Cursor.Position.Y - this.Height - 20);
            else if (System.Windows.Forms.Cursor.Position.Y - this.Height - 20 <= SystemInformation.VirtualScreen.Top)
                Location = new Point(System.Windows.Forms.Cursor.Position.X - this.Width - 20, SystemInformation.VirtualScreen.Top);
            else Location = new Point(System.Windows.Forms.Cursor.Position.X - this.Width - 20, System.Windows.Forms.Cursor.Position.Y - this.Height - 20);
            fadeTimer.Interval = 10;
            fadeTimer.Tick += new EventHandler(fadeInOpen);
            fadeTimer.Start();
        }

        private void fadeInOpen(object sender, EventArgs e)
        {
            if(Opacity >= .9)
            {
                fadeTimer.Stop();
                fadeTimer.Dispose();
            }
            else
            {
                Opacity += .05;
            }
        }

        private void fadeOutClose(object sender, EventArgs e)
        {
            if(Opacity <= 0)
            {
                fadeTimer.Stop();
                Close();
            }
            else
            {
                Opacity -= .05;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (System.Windows.Forms.Cursor.Position.X - this.Width * 2 / 3 - 20 <= SystemInformation.VirtualScreen.Left && System.Windows.Forms.Cursor.Position.Y - this.Height * 2 / 3 - 20 <= SystemInformation.VirtualScreen.Top)
                Location = new Point(SystemInformation.VirtualScreen.Left, SystemInformation.VirtualScreen.Top);
            else if (System.Windows.Forms.Cursor.Position.X - this.Width * 2 / 3 - 20 <= SystemInformation.VirtualScreen.Left)
                Location = new Point(SystemInformation.VirtualScreen.Left, System.Windows.Forms.Cursor.Position.Y - this.Height * 2 / 3 - 20);
            else if (System.Windows.Forms.Cursor.Position.Y - this.Height * 2 / 3 - 20 <= SystemInformation.VirtualScreen.Top)
                Location = new Point(System.Windows.Forms.Cursor.Position.X - this.Width * 2 / 3 - 20, SystemInformation.VirtualScreen.Top);
            else Location = new Point(System.Windows.Forms.Cursor.Position.X - this.Width * 2 / 3 - 20, System.Windows.Forms.Cursor.Position.Y - this.Height * 2 / 3 - 20);
            if (c.ButtonsPressed()["LEFT_S"] && !buttonHold["LEFT_S"])
            {
                buttonHold["LEFT_S"] = true;
                if (this.OnePadPanel.Visible)
                {
                    fadeTimer.Tick += new EventHandler(fadeOutClose);
                    fadeTimer.Start();
                }
                else if(this.FourPadPanel.Visible && selectionMade)
                {
                    selectionMade = false;
                    this.DownPad.Visible = true;
                    this.UpPad.Visible = true;
                    this.LeftPad.Visible = true;
                    this.LeftPadUp.Visible = true;
                    this.LeftPadRight.Visible = true;
                    this.LeftPadDown.Visible = true;
                    this.LeftPadLeft.Visible = true;
                    this.DownPadUp.Visible = true;
                    this.DownPadRight.Visible = true;
                    this.DownPadDown.Visible = true;
                    this.DownPadLeft.Visible = true;
                    this.UpPadUp.Visible = true;
                    this.UpPadRight.Visible = true;
                    this.UpPadDown.Visible = true;
                    this.UpPadLeft.Visible = true;
                    this.RightPad.Visible = true;
                    this.RightPadUp.Visible = true;
                    this.RightPadRight.Visible = true;
                    this.RightPadDown.Visible = true;
                    this.RightPadLeft.Visible = true;
                }
                else
                {
                    switchPanel("back");
                }
            }
            if (!c.ButtonsPressed()["LEFT_S"]) buttonHold["LEFT_S"] = false;
            if (c.ButtonsPressed()["DPAD_RIGHT"] && !buttonHold["DPAD_RIGHT"])
            {
                if (OnePadPanel.Visible)
                {
                    switchPanel("right");
                }
                else if (FourPadPanel.Visible && !selectionMade)
                {
                    this.DownPad.Visible = false;
                    this.UpPad.Visible = false;
                    this.LeftPad.Visible = false;
                    this.LeftPadUp.Visible = false;
                    this.LeftPadRight.Visible = false;
                    this.LeftPadDown.Visible = false;
                    this.LeftPadLeft.Visible = false;
                    this.DownPadUp.Visible = false;
                    this.DownPadRight.Visible = false;
                    this.DownPadDown.Visible = false;
                    this.DownPadLeft.Visible = false;
                    this.UpPadUp.Visible = false;
                    this.UpPadRight.Visible = false;
                    this.UpPadDown.Visible = false;
                    this.UpPadLeft.Visible = false;
                    selectionMade = true;
                }
                else if (FourPadPanel.Visible && selectionMade)
                {
                    if (c.GetLeftTrigger() > 150)
                    {
                        System.Windows.Forms.SendKeys.Send("+(a)");
                    }
                    else
                    {
                        System.Windows.Forms.SendKeys.Send("a");
                    }
                }
                buttonHold["DPAD_RIGHT"] = true;
            }
            if (c.ButtonsPressed()["BACK"] && !buttonHold["BACK"])
            {
                System.Windows.Forms.SendKeys.Send("{BS}");
                Thread.Sleep(60);
                buttonHold["BACK"] = true;
            }
            else
            {
                buttonHold["BACK"] = false;
            }
            if(!c.ButtonsPressed()["DPAD_RIGHT"]) buttonHold["DPAD_RIGHT"] = false;
            if (fadeTimer.Enabled)
            {
                Console.WriteLine("enabled " + (++count));
            }
        }
        int count = 0;
        private void switchPanel(String choice)
        {
            switch (choice)
            {
                case "right":
                    this.OnePadPanel.Visible = false;
                    this.FourPadPanel.Visible = true;
                    break;
                case "down":
                    break;
                case "left":
                    break;
                case "up":
                    break;
                case "back":
                    this.FourPadPanel.Visible = false;
                    this.OnePadPanel.Visible = true;
                    break;
            }
        }
    }
}