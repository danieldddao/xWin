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
            var lts = (byte)(((int)b & 0x00300000) >> 20);
            var rts = (byte)(((int)b & 0x00C00000) >> 22);
            var lss = (byte)(((int)b & 0x0F000000) >> 24);
            var rss = (byte)(((int)b & -268435456) >> 28);
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
            this.b = b;
            var s = (short)((int)b & 0x000FFFFF);
            foreach (GamepadButtonFlags gbf in Enum.GetValues(typeof(GamepadButtonFlags)))
            {
                if ((s & (short)gbf) != 0)
                    ((CheckBox)(controllerPanel.Controls.Find(gbf.ToString(), true)[0])).CheckState = CheckState.Checked;
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
        private GamepadButtonFlags gbf;
        private void addflag(CheckBox cb)
        {
            if(cb.Checked)
            {
                GamepadButtonFlags g;
                //Console.WriteLine(cb.Name);
                Enum.TryParse(cb.Name, out g);
                gbf |= g;
            }
        }

        private void confirm_Click(object sender, EventArgs e)
        {
            gbf = 0;
            foreach (var box in controllerPanel.Controls.OfType<CheckBox>())
            {
                addflag(box);
            }
            
            b = new GamepadFlags(gbf, LeftTriggerRegions.SelectedItem.ToString() == "Released",
                                      RightTriggerRegions.SelectedItem.ToString() == "Released",
                                      LeftStickRegions.SelectedItem.ToString() == "Released",
                                      RightStickRegions.SelectedItem.ToString() == "Released",
                                      getregion(LeftTriggerRegions),getregion(RightTriggerRegions),
                                      getregion(LeftStickRegions), getregion(RightStickRegions));
            
            this.Close();
        }

        private byte getregion(ComboBox cb)
        {
            var item = cb.SelectedItem.ToString();
            if (item == "Released" || item == "None")
                return 0;
            var ss = item.Split(' ');
            return byte.Parse(ss[1]);
        } 
    }
}
