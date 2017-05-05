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
using xWin.Library;
using static TypingControl.Types;

namespace xWin.GUI
{
    public partial class TypingConfigWindow : Form
    {
        private TypingConfigWindow()
        {
            InitializeComponent();
            bindmap = new Dictionary<KeyboardAction, PickBinding>();
            foreach(KeyboardAction k in Enum.GetValues(typeof(KeyboardAction)))
            {
                var p = new PickBinding(k.ToString(), new GamepadFlags(0), ActiveWhen.Pressed, (int)LeftStickRegions.Value, (int)RightStickRegions.Value, (int)LeftTriggerRegions.Value, (int)RightTriggerRegions.Value);
                KeyboardActions.Controls.Add(p);
                bindmap.Add(k,p);
            }
            Tier1.ControlRemoved += new ControlEventHandler(this.Tier_ControlRemoved);
            Tier2.ControlRemoved += new ControlEventHandler(this.Tier_ControlRemoved);
            NameBox.KeyPress += new KeyPressEventHandler(NameBox_KeyPress);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            tc = new TypingControl();
        }
        private Dictionary<KeyboardAction,PickBinding> bindmap;

        public TypingConfigWindow(TypingControl tc, List<string> l) : this()
        {
            this.l = l;
            default_keyset = new KeyboardSet();

            io = new Config.IO<TypingControl>(l, Config.IO<TypingControl>.TYPINGCONTROL_EXT);
            populate(tc);
        }
        public List<string> l;
        public TypingControl tc;
        public KeyboardSet default_keyset;
        Config.IO<TypingControl> io;
        private void Tier1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void update_bindings()
        {
            foreach (TierSelector b in this.Tier1.Controls.OfType<TierSelector>())
            {
                b.ls_regions = (int)LeftStickRegions.Value;
                b.rs_regions = (int)RightStickRegions.Value;
                b.lt_regions = (int)LeftTriggerRegions.Value;
                b.rt_regions = (int)RightTriggerRegions.Value;
            }
            foreach (TierSelector b in this.Tier2.Controls.OfType<TierSelector>())
            {
                b.ls_regions = (int)LeftStickRegions.Value;
                b.rs_regions = (int)RightStickRegions.Value;
                b.lt_regions = (int)LeftTriggerRegions.Value;
                b.rt_regions = (int)RightTriggerRegions.Value;
            }
            foreach(KeySetBinding b in this.KeySets.Controls.OfType<KeySetBinding>())
            {
                b.ls_regions = (int)LeftStickRegions.Value;
                b.rs_regions = (int)RightStickRegions.Value;
                b.lt_regions = (int)LeftTriggerRegions.Value;
                b.rt_regions = (int)RightTriggerRegions.Value;
            }
            foreach(PickBinding b in this.KeyboardActions.Controls.OfType<PickBinding>())
            {
                b.ls_regions = (int)LeftStickRegions.Value;
                b.rs_regions = (int)RightStickRegions.Value;
                b.lt_regions = (int)LeftTriggerRegions.Value;
                b.rt_regions = (int)RightTriggerRegions.Value;
            }
        }


        private void Up(TierSelector ts)
        {
            FlowLayoutPanel f = null;
            if (Tier1.Controls.Contains(ts))
                f = Tier1;
            else if (Tier2.Controls.Contains(ts))
                f = Tier2;
            else return;
            var t = f.Controls.IndexOf(ts);
            if(t > 0)
                f.Controls.SetChildIndex(ts, t - 1);
            return;
        }
        private void Down(TierSelector ts)
        {
            FlowLayoutPanel f = null;
            if (Tier1.Controls.Contains(ts))
                f = Tier1;
            else if (Tier2.Controls.Contains(ts))
                f = Tier2;
            else return;
            var t = f.Controls.IndexOf(ts);
            var m = f.Controls.Count;
            if (t < m-1)
                f.Controls.SetChildIndex(ts, t + 1);
            return;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Tier1.Controls.Add(new TierSelector(new Library.GamepadFlags(0),(int)LeftStickRegions.Value, (int)RightStickRegions.Value, (int)LeftTriggerRegions.Value, (int)RightTriggerRegions.Value));
            update_keysets();
        }

        private void Tier2Add_Click(object sender, EventArgs e)
        {
            Tier2.Controls.Add(new TierSelector(new Library.GamepadFlags(0), (int)LeftStickRegions.Value, (int)RightStickRegions.Value, (int)LeftTriggerRegions.Value, (int)RightTriggerRegions.Value));
            update_keysets();
        }

        private void update_keysets()
        {
            foreach(var ksb in KeySets.Controls.OfType<KeySetBinding>())
            {
                ksb.t1 = Tier1.Controls.Count;
                ksb.ks.Count = ksb.t1;
                ksb.t2 = Tier2.Controls.Count;
                ksb.ks.Subcount = ksb.t2;
                while(ksb.ks.Set.Count > ksb.t1) { ksb.ks.Set.RemoveAt(ksb.ks.Set.Count-1); }

                while (ksb.ks.Set.Count < ksb.t1) { ksb.ks.Set.Add(new KeyboardSet.Types.StringChoice()); }
                foreach (var set in ksb.ks.Set)
                {
                    while (set.Subset.Count > ksb.t2) { set.Subset.RemoveAt(set.Subset.Count - 1); }
                    while (set.Subset.Count < ksb.t2) { set.Subset.Add(""); }
                }
            }
        }


        private void LeftStickRegions_ValueChanged(object sender, EventArgs e)
        {
            update_bindings();
        }

        private void RightStickRegions_ValueChanged(object sender, EventArgs e)
        {
            update_bindings();
        }

        private void LeftTriggerRegions_ValueChanged(object sender, EventArgs e)
        {
            update_bindings();
        }

        private void RightTriggerRegions_ValueChanged(object sender, EventArgs e)
        {
            update_bindings();
        }

        private void AddKeyset_Click(object sender, EventArgs e)
        {
            KeySets.Controls.Add(new KeySetBinding(l,new GamepadFlags(0), new KeyboardSet(), (int)LeftStickRegions.Value, (int)RightStickRegions.Value, (int)LeftTriggerRegions.Value, (int)RightTriggerRegions.Value, Tier1.Controls.Count, Tier2.Controls.Count));
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void KeySetSet_Click(object sender, EventArgs e)
        {
            var d = new KeysetWindow(default_keyset, l, Tier1.Controls.Count, Tier2.Controls.Count);
            d.ShowDialog();
            default_keyset = d.keyboardset;
            keysetbox.Text = default_keyset.Name == null ? "" : default_keyset.Name;
        }

        private void Tier2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Tier_ControlRemoved(object sender, ControlEventArgs e)
        {
            update_keysets();
        }

        private void populate(TypingControl tc)
        {

            if (tc.LeftStick == null)
                tc.LeftStick = new Stick { Regions = { } };
            if (tc.RightStick == null)
                tc.RightStick = new Stick { Regions = { } };
            if (tc.LeftTrigger == null)
                tc.LeftTrigger = new Trigger { Deadzone = 1, Regions = { } };
            if (tc.RightTrigger == null)
                tc.RightTrigger = new Trigger { Deadzone = 1, Regions = { } };
            LeftStickRegions.Value = tc.LeftStick.Regions.Count;
            RightStickRegions.Value = tc.RightStick.Regions.Count;
            LeftTriggerRegions.Value = tc.LeftTrigger.Regions.Count;
            RightTriggerRegions.Value = tc.RightTrigger.Regions.Count;
            TriggerThreshold.Value = tc.RightTrigger.Deadzone;
            NameBox.Text = tc.Name == null ? "" : tc.Name;
            DescriptionBox.Text = tc.Description == null ? "" : tc.Name;
            Tier1.Controls.Clear();
            Tier2.Controls.Clear();
            KeySets.Controls.Clear();
            foreach (var b in tc.Tier1)
            {
                Tier1.Controls.Add(new TierSelector(new GamepadFlags(b), (int)LeftStickRegions.Value, (int)RightStickRegions.Value, (int)LeftTriggerRegions.Value, (int)RightTriggerRegions.Value));
            }

            foreach (var b in tc.Tier2)
            {
                Tier2.Controls.Add(new TierSelector(new GamepadFlags(b), (int)LeftStickRegions.Value, (int)RightStickRegions.Value, (int)LeftTriggerRegions.Value, (int)RightTriggerRegions.Value));
            }
            if (tc.Base == null)
                tc.Base = new KeyboardSet();
            default_keyset = tc.Base;
            keysetbox.Text = default_keyset.Name == null ? "" : default_keyset.Name;
            foreach(var b in tc.KeyboardSelect)
            {
                KeySets.Controls.Add(new KeySetBinding(l, new GamepadFlags(b.Key), b.Value, (int)LeftStickRegions.Value, (int)RightStickRegions.Value, (int)LeftTriggerRegions.Value, (int)RightTriggerRegions.Value, Tier1.Controls.Count, Tier2.Controls.Count));
            }
            Console.WriteLine(bindmap.Keys.ToArray().ToString());
            foreach(var pb in tc.Bindings)
            {
                Console.WriteLine(pb.Value.Binding.ToString());
                var dd = new GamepadFlags(pb.Key);
                foreach(var b in KeyboardActions.Controls.OfType<PickBinding>())
                {
                    Console.WriteLine(b.Name);
                    if(b.Field.Text == pb.Value.Binding.ToString())
                    {
                        b.gf = dd;
                        b.ButtonBox.Text = dd.SpecialString();
                        b.active.SelectedIndex = b.active.FindStringExact(pb.Value.WhenActive.ToString());
                        break;
                    }
                }
               // bindmap[pb.Value.Binding].gf = dd;

                //bindmap[pb.Value.Binding].ButtonBox.Text = dd.SpecialString();
                //bindmap[pb.Value.Binding].active.SelectedIndex = bindmap[pb.Value.Binding].active.FindStringExact(pb.Value.WhenActive.ToString());
            }
        }
        private void stick_regions(RepeatedField<uint> rf, int i)
        {
            //Console.WriteLine(i.ToString());
            //rf = new RepeatedField<uint>();
            if (i == 0)
                return;
            for (int j = 0; j < i; ++j)
                rf.Add(360 / (uint)i);

            for (int j = 0; j < 360 % i; ++j)
                ++rf[j];
            //Console.WriteLine(rf.ToString());
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
        private TypingControl conglomerate()
        {

            var tc = new TypingControl
            {
                Name = NameBox.Text == null ? "" : NameBox.Text,
                Description = DescriptionBox.Text == null ? "" : DescriptionBox.Text,
                Bindings = { },
                Base = default_keyset,
                KeyboardSelect = { },
                LeftStick = new Stick
                {
                    Regions = { }
                },
                RightStick = new Stick
                {
                    Regions = { }
                },
                LeftTrigger = new Trigger
                {
                    Deadzone = (uint)TriggerThreshold.Value
                },
                RightTrigger = new Trigger
                {
                    Deadzone = (uint)TriggerThreshold.Value
                },
                Tier1 = { },
                Tier2 = { }                
            };
            stick_regions(tc.LeftStick.Regions, (int)LeftStickRegions.Value);
            stick_regions(tc.RightStick.Regions, (int)RightStickRegions.Value);
            trigger_regions(tc.LeftTrigger.Regions, (int)LeftTriggerRegions.Value, (uint)TriggerThreshold.Value);
            trigger_regions(tc.RightTrigger.Regions, (int)RightTriggerRegions.Value, (uint)TriggerThreshold.Value);
            foreach(var b in Tier1.Controls.OfType<TierSelector>())
            {
                tc.Tier1.Add((int)b.gf);
            }
            foreach (var b in Tier2.Controls.OfType<TierSelector>())
            {
                tc.Tier2.Add((int)b.gf);
            }
            foreach(var b in KeySets.Controls.OfType<KeySetBinding>())
            {
                tc.KeyboardSelect.Add((int)b.gf, b.ks);
            }
            foreach(var b in this.KeyboardActions.Controls.OfType<PickBinding>())
            {
                if(b.gf != new GamepadFlags(0))
                {
                    KeyboardAction ka;
                    Enum.TryParse(b.Field.Text, out ka);
                    ActiveWhen active;
                    Enum.TryParse(b.active.Text.ToString(), out active);
                    if (tc.Bindings.ContainsKey((int)b.gf))
                        continue;
                    tc.Bindings.Add((int)b.gf, new KeyboardActionContainer
                                                {
                                                    Binding = ka,
                                                    WhenActive = active
                                                });
                }
            }
            
            return tc;
        }

        private void KeyboardActions_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Tier1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog FD = CustomFileDialog.Get(io.SearchPaths[0], "TypingConfiguration", io.ext);
            //FD.FileOk += new CancelEventHandler(open_KeyboardSetOk);
            if (FD.ShowDialog() == DialogResult.OK)
            {
                string fileToOpen = FD.FileName;
                var tc = io.ReadFromFile(fileToOpen);
                NameBox.Text = tc.Name == null ? "" : tc.Name;
                DescriptionBox.Text = tc.Description ==  null ? "" : tc.Description;
                populate(tc);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var tc = conglomerate();
            if (tc.Name.Length == 0)
            {
                MessageBox.Show("No Name Specified");
                return;
            }
            if (io.CheckExists(tc.Name))
            {
                if (MessageBox.Show("Overwrite Existing Version?", "File Already Exists", MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    return;
                }
            }
            io.WriteToFile(tc, tc.Name);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tc = conglomerate();
            this.Close();
        }

        private void NameBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar)) return;
            if (System.IO.Path.GetInvalidFileNameChars().Contains(e.KeyChar))
                e.Handled = true;
        }
    }
}
