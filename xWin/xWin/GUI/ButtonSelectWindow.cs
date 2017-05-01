using SharpDX.XInput;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using xWin.Library;

namespace xWin.GUI
{
    public partial class ButtonSelectWindow : Form
    {
        public ButtonSelectWindow()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            b = new GamepadFlags(0);
            strmade = "";
            LeftTriggerRegions.Items.Add("None");
            RightTriggerRegions.Items.Add("None");
            LeftStickRegions.Items.Add("None");
            RightStickRegions.Items.Add("None");
            LeftTriggerRegions.SelectedItem = "None";
            RightTriggerRegions.SelectedItem = "None";
            LeftStickRegions.SelectedItem = "None";
            RightStickRegions.SelectedItem = "None";
            //b = new GamepadFlags(0);
            //strmade = "";
        }
        public ButtonSelectWindow(int lt, int rt, int ls, int rs) : this()
        {
            initialize_regions(LeftStickRegions, ls);
            initialize_regions(RightStickRegions, rs);
            initialize_regions(LeftTriggerRegions,lt);
            initialize_regions(RightTriggerRegions, rt);
        }
        public ButtonSelectWindow(GamepadFlags b, int lt, int rt, int ls, int rs) : this(lt, rt, ls, rs)
        {
            this.b = b;
            var s = (short)((int)b & 0x000FFFFF);
            foreach(GamepadButtonFlags gbf in Enum.GetValues(typeof(GamepadButtonFlags)))
            {
                if ((s & (short)gbf) != 0)
                    ((CheckBox)(controllerPanel.Controls.Find(gbf.ToString(), true)[0])).CheckState = CheckState.Checked;
            }
            var rts = (byte)(((int)b & 0x00300000) >> 40);
            var lts = (byte)(((int)b & 0x00C00000) >> 44);
            var rss = (byte)(((int)b & 0x0F000000) >> 48);
            var lss = (byte)(((int)b & -268435456) >> 56);
            LeftTriggerRegions.SelectedItem = lts <= lt ? "Region " + lts.ToString() : "None";
            RightTriggerRegions.SelectedItem = rts <= rt ? "Region " + rts.ToString() : "None";
            LeftStickRegions.SelectedItem = lss <= ls ? "Region " + lss.ToString() : "None";
            RightStickRegions.SelectedItem = rss <= rs ? "Region " + rss.ToString() : "None";


            LeftTriggerRegions.SelectedItem = (((int)b & 0x00010000) != 0) ? "Released" : LeftTriggerRegions.SelectedItem;
            RightTriggerRegions.SelectedItem = (((int)b & 0x00020000) != 0) ? "Released" : RightTriggerRegions.SelectedItem;
            LeftStickRegions.SelectedItem = (((int)b & 0x00040000) != 0) ? "Released" : LeftStickRegions.SelectedItem;
            RightStickRegions.SelectedItem = (((int)b & 0x00080000) != 0) ? "Released" : RightStickRegions.SelectedItem;
        }
        public ButtonSelectWindow(GamepadFlags b) : this()
        {
            //InitializeComponent();
            this.b = b;
            var s = (GamepadButtonFlags)((int)b & 0x0000FFFF);
            Console.WriteLine("here");

            foreach (CheckBox cb in this.Controls.OfType<CheckBox>())
            {
                try
                {
                    var gbf = (GamepadButtonFlags)Enum.Parse(typeof(GamepadButtonFlags), cb.Name.ToString());
                    if (s.HasFlag(gbf))
                    {
                        cb.Checked = true;
                        cb.CheckState = CheckState.Checked;
                    }
                }
                catch { }
            }

        }
        private void initialize_regions(ComboBox cb, int r)
        {
            cb.Items.Clear();
            cb.Items.Add("None");
            cb.SelectedItem = "None";
            cb.Items.Add("Released");
            for(int i = 1; i <= r; ++i)
            {
                cb.Items.Add("Region " + i.ToString());
            }
        }

        public GamepadFlags b;
        public string strmade;

        private void addflag(GamepadButtonFlags g1, GamepadButtonFlags g2)
        {
            strmade += g2.ToString() + ",";
            g1 |= g2;
        }

        private void confirm_Click(object sender, EventArgs e)
        {
            strmade = "";
            GamepadButtonFlags gbf = 0;
            if (A.CheckState == CheckState.Checked)
                addflag(gbf,GamepadButtonFlags.A);
            if (B.CheckState == CheckState.Checked)
                addflag(gbf,GamepadButtonFlags.B);
            if (X.CheckState == CheckState.Checked)
                addflag(gbf, GamepadButtonFlags.X);
            if (Y.CheckState == CheckState.Checked)
                addflag(gbf, GamepadButtonFlags.Y);

            if (Back.CheckState == CheckState.Checked)
                addflag(gbf, GamepadButtonFlags.Back);
            if (Start.CheckState == CheckState.Checked)
                addflag(gbf, GamepadButtonFlags.Start);

            if (DDown.CheckState == CheckState.Checked)
                addflag(gbf, GamepadButtonFlags.DPadDown);
            if (DUp.CheckState == CheckState.Checked)
                addflag(gbf, GamepadButtonFlags.DPadUp);
            if (DLeft.CheckState == CheckState.Checked)
                addflag(gbf, GamepadButtonFlags.DPadLeft);
            if (DRight.CheckState == CheckState.Checked)
                addflag(gbf, GamepadButtonFlags.DPadRight);

            if (LeftShoulder.CheckState == CheckState.Checked)
                addflag(gbf, GamepadButtonFlags.LeftShoulder);
            if (RightShoulder.CheckState == CheckState.Checked)
                addflag(gbf, GamepadButtonFlags.RightShoulder);
            if (LeftThumb.CheckState == CheckState.Checked)
                addflag(gbf, GamepadButtonFlags.LeftThumb);
            if (RightThumb.CheckState == CheckState.Checked)
                addflag(gbf, GamepadButtonFlags.RightThumb);
            if (LeftTriggerRegions.SelectedItem.ToString() == "Released")
                strmade += "ltc,";
            if (RightTriggerRegions.SelectedItem.ToString() == "Released")
                strmade += "rtc,";
            if (LeftStickRegions.SelectedItem.ToString() == "Released")
                strmade += "lsc,";
            if (RightStickRegions.SelectedItem.ToString() == "Released")
                strmade += "rsc,";

            b = new GamepadFlags(gbf, LeftTriggerRegions.SelectedItem.ToString() == "Released",
                                      RightTriggerRegions.SelectedItem.ToString() == "Released",
                                      LeftStickRegions.SelectedItem.ToString() == "Released",
                                      RightStickRegions.SelectedItem.ToString() == "Released",
                                      getregion(LeftTriggerRegions,"LT"), getregion(RightTriggerRegions, "RT"),
                                      getregion(LeftStickRegions, "LS"), getregion(RightStickRegions, "RS"));
            strmade = strmade.TrimEnd(',');
            this.Close();
        }

        private byte getregion(ComboBox cb, string name)
        {
            var s = cb.SelectedItem.ToString();
            if (s == "Released" || s == "None")
                return 0;
            var ss = s.Split(' ');
            strmade += (name + ss[1] + ",");
            return byte.Parse(ss[1]);
        } 
    }
}
