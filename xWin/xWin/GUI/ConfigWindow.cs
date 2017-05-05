using Google.Protobuf.Collections;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using xWin.Config;
using static BasicControl.Types;
using xWin.Config;
using xWin.Library;
using System.IO;

namespace xWin.GUI
{
    public partial class ConfigWindow : Form
    {
        
        private ConfigWindow()
        {
            InitializeComponent();
            //LeftTriggerRegions += new PropertyValueChangedEventHandler(update_bindings);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            ConfigName.KeyPress += new KeyPressEventHandler(ConfigName_KeyPress);
        }
        public ConfigWindow(Configuration c, List<string> l) : this()
        {
            io = new IO<Configuration>(l,IO<Configuration>.CONFIGURATION_EXT);
            tc = new TypingControl();
            lockbinding = new GamepadFlags(0);
            this.c = c;
            this.l = l;
            if (c.Basic == null)
                c.Basic = new BasicControl();
            populate(c);
        }
        private IO<Configuration> io;
        private IO<TypingControl> cio;
        public Configuration c;
        private List<string> l;
        //the container for config elements
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void update_bindings()
        {
            foreach(Binding b in this.BindingPanel.Controls.OfType<Binding>())
            {
                b.ls_regions = (int)LeftStickRegions.Value;
                b.rs_regions = (int)RightStickRegions.Value;
                b.lt_regions = (int)LeftTriggerRegions.Value;
                b.rt_regions = (int)RightTriggerRegions.Value;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.BindingPanel.Controls.Add(new Binding((int)LeftStickRegions.Value, (int)RightStickRegions.Value,(int)LeftTriggerRegions.Value,(int)RightTriggerRegions.Value));
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void ConfigName_TextChanged(object sender, EventArgs e)
        {

        }
        private void ConfigName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar)) return;
            if (System.IO.Path.GetInvalidFileNameChars().Contains(e.KeyChar))
                e.Handled = true;
        }
        private void stick_regions(RepeatedField <uint> rf, int i)
        {
            //rf = new RepeatedField<uint>();
            if (i == 0)
                return;
            for (int j = 0; j < i; ++j)
                rf.Add(360 / (uint)i);

            for (int j = 0; j < 360 % i; ++j)
                ++rf[j];
            //return rf;
        }
        private void trigger_regions(RepeatedField<uint> rf, int i, uint dz)
        {
            //rf = new RepeatedField<uint>();
            if (i == 0)
                return;
            uint total = 255 - (uint)dz;
            for (int j = 0; j < i; ++j)
                rf.Add(total / (uint)i);
            for (int j = 0; j < total % i; ++j)
                ++rf[j];
        }

        private BasicControl conglomerate_bc()
        {
            var bc = new BasicControl
            {
                Repeatdelay = (ulong)Delay.Value * 1000,
                Repeaterate = (ulong)Period.Value * 1000,
                LeftStick = new Stick
                {
                    ControlMouse = this.LeftRadio.Checked,
                    Regions = { }
                },
                RightStick = new Stick
                {
                    ControlMouse = this.RightRadio.Checked,
                    Regions = { }
                },
                LeftTrigger = new Trigger
                {
                    Deadzone = (uint)TriggerThreshold.Value,
                    Regions = { }
                },
                RightTrigger = new Trigger
                {
                    Deadzone = (uint)TriggerThreshold.Value,
                    Regions = { }
                },
                ButtonMap = { },
                Name = ConfigName.Text,
                Description = Description.Text,
                Dpi = (uint)NormalDPI.Value,
                FastDpi = (uint)FastDPI.Value,
                SlowDpi = (uint)SlowDPI.Value
            };
            stick_regions(bc.LeftStick.Regions, (int)LeftStickRegions.Value);
            stick_regions(bc.RightStick.Regions, (int)RightStickRegions.Value);
            trigger_regions(bc.LeftTrigger.Regions, (int)LeftTriggerRegions.Value, (uint)TriggerThreshold.Value);
            trigger_regions(bc.RightTrigger.Regions, (int)RightTriggerRegions.Value, (uint)TriggerThreshold.Value);
            foreach (var binding in BindingPanel.Controls.OfType<Binding>())
            {
                //binding.a;
                if (binding.ButtonBox.Text.Length == 0)
                    continue;
                if (binding.KeyBox.Text.Length == 0)
                    continue;
                var b = new Behavior();
                switch (binding.BehaviorPick.Text)
                {
                    case "On Hold":
                        b.OnHold = binding.a;
                        b.OnPress = binding.a;
                        break;
                    case "On Press":
                        b.OnPress = binding.a;
                        break;
                    case "On Stay Released":
                        b.OnStay = binding.a;
                        b.OnRelease = binding.a;
                        break;
                    case "On Release":
                        b.OnRelease = binding.a;
                        break;
                }
                bc.ButtonMap.Add((int)binding.gf, b);
            }
            return bc;
        }

        private Configuration conglomerate()
        {
            var bc = conglomerate_bc();
            return new Configuration
            {
                Basic = bc,
                Typing = tc,
                Name = bc.Name,
                Description = bc.Description,
                Togglestop = (int)lockbinding
            };
        }
        //SaveButton
        private void button3_Click(object sender, EventArgs e)
        {
            var c = conglomerate();
            if (c.Name.Length == 0)
            {
                MessageBox.Show("No Name Specified");
                return;
            }
            if(io.CheckExists(c.Name))
            {
                if(MessageBox.Show("Overwrite Existing Version?", "File Already Exists", MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    return;
                }
            }

            io.WriteToFile(c, c.Name);
        }

        private void populate(Configuration c)
        {
            ConfigName.Text = c.Name == null ? "" : c.Name;
            Description.Text = c.Description == null ? "" : c.Description;
            lockbinding = new GamepadFlags(c.Togglestop);
            ButtonTextBox.Text = lockbinding.SpecialString();
            if (c.Typing == null)
                c.Typing = new TypingControl();
            tc = c.Typing;
            TCName.Text = tc.Name == null ? "" : tc.Name;
            TCDescription.Text = tc.Description == null ? "" : tc.Description;
            var b = c.Basic;
            if (b.LeftStick == null)
                b.LeftStick = new Stick { Regions = { } };
            if (b.RightStick == null)
                b.RightStick = new Stick { Regions = { } };
            if (b.LeftTrigger == null)
                b.LeftTrigger = new Trigger {Deadzone=1, Regions = { } };
            if (b.RightTrigger == null)
                b.RightTrigger = new Trigger { Deadzone = 1, Regions = { } };
            LeftStickRegions.Value = b.LeftStick.Regions.Count;
            RightStickRegions.Value = b.RightStick.Regions.Count;
            LeftTriggerRegions.Value = b.LeftTrigger.Regions.Count;
            RightTriggerRegions.Value = b.RightTrigger.Regions.Count;
            TriggerThreshold.Value = b.LeftTrigger.Deadzone;
            Delay.Value = b.Repeatdelay / 1000 == 0 ? 400 : b.Repeatdelay / 1000;
            Period.Value = b.Repeaterate / 1000 == 0 ? 40 : b.Repeaterate / 1000;
            if (b.LeftStick.ControlMouse)
                LeftRadio.Checked = true;
            else if (b.RightStick.ControlMouse)
                RightRadio.Checked = true;
            NormalDPI.Value = b.Dpi;
            FastDPI.Value = b.FastDpi;
            SlowDPI.Value = b.SlowDpi;
            BindingPanel.Controls.Clear();
            foreach(var bb in b.ButtonMap)
            {
                Actions A = new Actions();
                if (bb.Value.OnHold == null)
                    bb.Value.OnHold = new Actions { Keybinds = { }, SpecialActions = { }, Exe = ""};
                if (bb.Value.OnPress == null)
                    bb.Value.OnPress = new Actions { Keybinds = { }, SpecialActions = { }, Exe = "" };
                if (bb.Value.OnRelease == null)
                    bb.Value.OnRelease = new Actions { Keybinds = { }, SpecialActions = { }, Exe = "" };
                if (bb.Value.OnStay == null)
                    bb.Value.OnStay = new Actions { Keybinds = { }, SpecialActions = { }, Exe = "" };
                string str = "On Hold";
                if (bb.Value.OnHold.Keybinds.Count + bb.Value.OnHold.SpecialActions.Count + bb.Value.OnHold.Exe.Length > 0 )
                {
                    A = bb.Value.OnHold;
                }
                else if (bb.Value.OnPress.Keybinds.Count + bb.Value.OnPress.SpecialActions.Count + bb.Value.OnPress.Exe.Length > 0)
                {
                    A = bb.Value.OnPress;
                    str = "On Press";
                }
                else if (bb.Value.OnStay.Keybinds.Count + bb.Value.OnStay.SpecialActions.Count + bb.Value.OnStay.Exe.Length > 0)
                {
                    A = bb.Value.OnStay;
                    str = "On Stay Released";
                }
                else if (bb.Value.OnRelease.Keybinds.Count + bb.Value.OnRelease.SpecialActions.Count + bb.Value.OnRelease.Exe.Length > 0)
                {
                    A = bb.Value.OnRelease;
                    str = "On Release";
                }

                BindingPanel.Controls.Add(new Binding(new GamepadFlags(bb.Key),A,str, (int)LeftStickRegions.Value, (int)RightStickRegions.Value, (int)LeftTriggerRegions.Value, (int)RightTriggerRegions.Value));

            }
        }
        
        private TypingControl tc;

        private GamepadFlags lockbinding;
        private void EditButtons_Click(object sender, EventArgs e)
        {
            var d = new ButtonSelectWindow(lockbinding);
            d.ShowDialog();
            lockbinding = d.b;
            ButtonTextBox.Text = lockbinding.SpecialString();
        }

        //read from file
        private void button2_Click(object sender, EventArgs e)
        {

            var FD = CustomFileDialog.Get(l[0],"Configuration",IO<Configuration>.CONFIGURATION_EXT);
            
            if (FD.ShowDialog() == DialogResult.OK)
            {
                string fileToOpen = FD.FileName;
                c = io.ReadFromFile(fileToOpen);
                TCName.Text = c.Name == null ? "" : c.Name;
                TCDescription.Text = c.Description == null ? "" : c.Description;
                populate(c);
            }
        }

        private void LeftTriggerRegions_ValueChanged(object sender, EventArgs e)
        {
            update_bindings();
        }

        private void RightTriggerRegions_ValueChanged(object sender, EventArgs e)
        {
            update_bindings();
        }

        private void LeftStickRegions_ValueChanged(object sender, EventArgs e)
        {
            update_bindings();
        }

        private void RightStickRegions_ValueChanged(object sender, EventArgs e)
        {
            update_bindings();
        }

        //Edit Typing
        private void button5_Click(object sender, EventArgs e)
        {
            var d = new TypingConfigWindow(tc, l);
            d.ShowDialog();
            tc = d.tc;
            TCName.Text = tc.Name == null ? "" : tc.Name;
            TCDescription.Text = tc.Description == null ? "" : tc.Description;
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            c = conglomerate();
            this.Close();
        }
    }
}
