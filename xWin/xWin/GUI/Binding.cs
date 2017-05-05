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

namespace xWin.GUI
{
    public partial class Binding : UserControl
    {
        public Binding()
        {
            InitializeComponent();
        }

        public int ls_regions = 0;
        public int rs_regions = 0;
        public int lt_regions = 0;
        public int rt_regions = 0;

        private GamepadFlags gf;
        private Actions a;

        public Binding(int ls,int rs,int lt,int rt) : this()
        {
            ls_regions = ls;
            rs_regions = rs;
            lt_regions = lt;
            rt_regions = rt;
            gf = new GamepadFlags(0);
            a = new Actions();
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
            ButtonTextBox.Text = d.strmade;
            
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
        //the keys and special actions its bound to
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
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
            var d = new KeyboardSelectWindow(KeybindTextBox.Text);
            d.ShowDialog();
            a = d.a;
            KeybindTextBox.Text = d.strrep;
        }
        //make it a toggle
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
