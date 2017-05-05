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

namespace xWin.GUI
{
    public partial class TierSelector : UserControl
    {
        private TierSelector()
        {
            InitializeComponent();
        }

        public int ls_regions = 0;
        public int rs_regions = 0;
        public int lt_regions = 0;
        public int rt_regions = 0;
        public GamepadFlags gf;

        public TextBox ButtonBox;
        public TierSelector(GamepadFlags g, int ls, int rs, int lt, int rt) :this()
        {
            ls_regions = ls;
            rs_regions = rs;
            lt_regions = lt;
            rt_regions = rt;
            gf = g;
            ButtonBox = this.textbox;
            ButtonBox.Text = g.SpecialString();
            
        }
        private void DeleteThis_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }

        private void Up_Click(object sender, EventArgs e)
        {
            var f = this.Parent;
            var t = f.Controls.IndexOf(this);
            if (t > 0)
                f.Controls.SetChildIndex(this, t - 1);
            return;
        }

        private void down_Click(object sender, EventArgs e)
        {
            var f = this.Parent;
            
            var t = f.Controls.IndexOf(this);
            var m = f.Controls.Count;
            if (t < m - 1)
                f.Controls.SetChildIndex(this, t + 1);
            return;
        }

        private void ConfigSelector_Click(object sender, EventArgs e)
        {
            var d = new ButtonSelectWindow(gf, lt_regions, rt_regions, ls_regions, rs_regions);
            d.ShowDialog();
            gf = d.b;
            textbox.Text = gf.SpecialString();
        }

        private void textbox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
