using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using xWin.Library;
using static BasicControl.Types;
using Google.Protobuf.Collections;

namespace xWin.GUI
{
    public partial class Binding : UserControl
    {
        private Binding()
        {
            InitializeComponent();
            ButtonBox = this.ButtonTextBox;
            KeyBox = this.KeybindTextBox;
            BehaviorPick = this.BehaviorSelect;
        }

        public int ls_regions = 0;
        public int rs_regions = 0;
        public int lt_regions = 0;
        public int rt_regions = 0;

        public GamepadFlags gf;
        public Actions a;

        public TextBox ButtonBox, KeyBox;
        public ComboBox BehaviorPick;

        public Binding(int ls,int rs,int lt,int rt) : this()
        {
            ls_regions = ls;
            rs_regions = rs;
            lt_regions = lt;
            rt_regions = rt;
            gf = new GamepadFlags(0);
            a = new Actions();
        }
        public Binding(GamepadFlags g, Actions a, string str, int ls, int rs, int lt, int rt) : this(ls,rs,lt,rt)
        {
            gf = g;
            ButtonTextBox.Text = gf.SpecialString();
            this.a = a;
            KeybindTextBox.Text = action_parse(this.a);
            BehaviorSelect.SelectedIndex = BehaviorSelect.FindStringExact(str);
        }
        //remove button
        private void button6_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }
        //drop down of all buttons and regions selected
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //add another button/region
        private void button2_Click(object sender, EventArgs e)
        {
            var d = new ButtonSelectWindow(gf,lt_regions,rt_regions, ls_regions, rs_regions);
            d.ShowDialog();
            gf = d.b;
            ButtonTextBox.Text = d.b.SpecialString();
            
        }
        //clear all buttons/regions
        private void button4_Click(object sender, EventArgs e)
        {
            gf = new GamepadFlags(0);
            ButtonTextBox.Text = "";
        }
        //the state its bound to
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //clear keys/special actions
        private void button5_Click(object sender, EventArgs e)
        {
            a = new Actions();
            KeybindTextBox.Text = "";
        }
        //add key/special action
        private void button3_Click(object sender, EventArgs e)
        {
            var d = new KeyboardSelectWindow(a);
            d.ShowDialog();
            a = d.a;
            a = a;
            KeybindTextBox.Text = d.strrep;
        }

        private void ButtonTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        //make it a toggle
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
        
        private string action_parse(Actions A)
        {
            string str = "";
            foreach(var a in A.Keybinds)
            {
                str += ((Keys)a).ToString();
            }
            foreach(var a in A.SpecialActions)
            {
                str += a.ToString();
            }
            str += a.Exe == null ? "" : a.Exe;
            return str;
        }
    }
}
