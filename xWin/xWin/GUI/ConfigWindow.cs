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

namespace xWin.GUI
{
    public partial class ConfigWindow : Form
    {
        
        private ConfigWindow()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        public ConfigWindow(List<string> l) : this()
        {

            io = new IO<Configuration>(l,IO<Configuration>.CONFIGURATION_EXT);
            cio = new IO<TypingControl>(l,IO<TypingControl>.TYPINGCONTROL_EXT);
            tc = new TypingControl();
            lockbinding = new GamepadFlags(0);
        }
        private IO<Configuration> io;
        private IO<TypingControl> cio;
        //the container for config elements
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.flowLayoutPanel1.Controls.Add(new Binding());
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void stick_regions(RepeatedField <uint> rf, int i)
        {
            rf = new RepeatedField<uint>();
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
            rf = new RepeatedField<uint>();
            if (i == 0)
                return;
            uint total = 255 - (uint)dz;
            for (int j = 0; j < i; ++j)
                rf.Add(total / (uint)i);
            for (int j = 0; j < total % i; ++j)
                ++rf[j];
        }

        private void button3_Click(object sender, EventArgs e)
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
                Description = Description.Text
            };
            stick_regions(bc.LeftStick.Regions, (int)LeftStickRegions.Value);
            stick_regions(bc.RightStick.Regions, (int)RightStickRegions.Value);
            trigger_regions(bc.LeftTrigger.Regions, (int)LeftTriggerRegions.Value, (uint)TriggerThreshold.Value);
            trigger_regions(bc.RightTrigger.Regions, (int)RightTriggerRegions.Value, (uint)TriggerThreshold.Value);
            foreach(var binding in flowLayoutPanel1.Controls.OfType<Binding>())
            {
                if (binding.ButtonBox.Text.Length == 0)
                    continue;
                if (binding.KeyBox.Text.Length == 0)
                    continue;
                var b = new Behavior();
                switch(binding.BehaviorPick.Text)
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
            var c = new Configuration
            {
                Basic = bc,
                Typing = tc,
                Name = bc.Name,
                Description = bc.Description,
                Togglestop = (int)lockbinding
            };
            try
            {
                io.WriteToFile(c, c.Name);
            }
            catch(Exception exc)
            {
                Console.WriteLine(exc.Message);
                MessageBox.Show("Failed to write file", "Didn't Write",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private TypingControl tc;
        //open keyboard set
        private void button4_Click(object sender, EventArgs e)
        {
            var FD = new OpenFileDialog();
            if (FD.ShowDialog() == DialogResult.OK)
            {
                string fileToOpen = FD.FileName;

                tc = cio.ReadFromFile(fileToOpen);
                TCName.Text = tc.Name;
                TCDescription.Text = tc.Description;
            }
        }

        private GamepadFlags lockbinding;
        private void EditButtons_Click(object sender, EventArgs e)
        {
            var d = new ButtonSelectWindow(lockbinding);
            d.ShowDialog();
            lockbinding = d.b;
            ButtonTextBox.Text = d.strmade;
        }
    }
}
