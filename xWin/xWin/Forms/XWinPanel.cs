using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace xWin.Forms
{
    public partial class xWinPanel : Form
    {
        public xWinPanel()
        {
            InitializeComponent();
        }

        private void XWinPanel_Load(object sender, EventArgs e)
        {
            Controller1.Text = "Controller 1 \nConnected";
            Controller1.BackColor = Color.FromArgb(46, 204, 113);
        }

        private void Controller1_Click(object sender, EventArgs e)
        {
            ControllerOptions c = new ControllerOptions();
            c.ShowDialog();
        }

        private void Controller2_Click(object sender, EventArgs e)
        {

        }

        private void Controller3_Click(object sender, EventArgs e)
        {

        }

        private void Controller4_Click(object sender, EventArgs e)
        {

        }
    }
}
