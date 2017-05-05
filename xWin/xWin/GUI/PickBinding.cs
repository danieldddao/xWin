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
using static TypingControl.Types;

namespace xWin.GUI
{
    public partial class PickBinding : UserControl
    {
        public PickBinding()
        {
            InitializeComponent();
        }

        public PickBinding(string title, GamepadFlags g, ActiveWhen a, int ls, int rs, int lt, int rt) :this()
        {
            Field.Text = title;
            ls_regions = ls;
            rs_regions = rs;
            lt_regions = lt;
            rt_regions = rt;
            gf = g;
            TextField.Text = g.SpecialString();
            active.SelectedIndex = active.FindStringExact(a.ToString());
            ButtonBox = TextField;
        }
        public int ls_regions = 0;
        public int rs_regions = 0;
        public int lt_regions = 0;
        public int rt_regions = 0;
        public GamepadFlags gf;
        public TextBox ButtonBox;
        private void Pick_Click(object sender, EventArgs e)
        {
            var d = new ButtonSelectWindow(gf, lt_regions, rt_regions, ls_regions, rs_regions);
            d.ShowDialog();
            gf = d.b;
            TextField.Text = d.b.SpecialString();
        }
        
        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
