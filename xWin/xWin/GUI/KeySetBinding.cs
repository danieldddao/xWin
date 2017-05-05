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
    public partial class KeySetBinding : UserControl
    {
        private KeySetBinding()
        {
            InitializeComponent();
            KeysetBox = this.keysetbox;
            ButtonBox = this.textbox;
        }
        public KeySetBinding(List<string> l, GamepadFlags g, KeyboardSet k, int ls, int rs, int lt, int rt, int t1, int t2) :this()
        {
            ls_regions = ls;
            rs_regions = rs;
            lt_regions = lt;
            rt_regions = rt;
            this.t1 = t1;
            this.t2 = t2;
            gf = g;
            textbox.Text = g.SpecialString();
            ks = k;
            keysetbox.Text = k.Name == null ? "" : k.Name;
            this.l = l;
        }
        public int ls_regions = 0;
        public int rs_regions = 0;
        public int lt_regions = 0;
        public int rt_regions = 0;
        public int t1, t2;
        public GamepadFlags gf;
        public TextBox ButtonBox, KeysetBox;
        public KeyboardSet ks;
        List<string> l;
        private void KeySetSet_Click(object sender, EventArgs e)
        {
            var d = new KeysetWindow(ks, l, t1, t2);
            d.ShowDialog();
            ks = d.keyboardset;
            keysetbox.Text = ks.Name == null ? "" : ks.Name;
        }

        private void keysetbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void ConfigSelector_Click(object sender, EventArgs e)
        {
            var d = new ButtonSelectWindow(gf, lt_regions, rt_regions, ls_regions, rs_regions);
            d.ShowDialog();
            gf = d.b;
            textbox.Text = d.b.SpecialString();
        }
    }
}
