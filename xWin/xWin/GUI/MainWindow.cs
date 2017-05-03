using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using xWin.Library;

namespace xWin.GUI
{
    public partial class MainWindow : Form
    {
        public MainWindow(List<string> l)
        {
            InitializeComponent();

            Thread thread = new Thread(WI.InteractionLoop);
            thread.Start();
            this.l = l;
            ConfigName.Text = Program.config.Name == null ? "" : Program.config.Name;
            ConfigDescription.Text = Program.config.Description == null ? "" : Program.config.Description;
        }
        private List<string> l;
        private void MainWindow_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Settings_Enter(object sender, EventArgs e)
        {

        }

        private short lxc, lyc, rxc, ryc;

        private void EditConfig_Click(object sender, EventArgs e)
        {
            var cw = new ConfigWindow(Program.config, l);
            cw.ShowDialog();
            Program.config = cw.c;
            Program.update_config = true;
        }

        private void updateCC_Click(object sender, EventArgs e)
        {
            var cc = Program.cc;
            cc.lx = lxc;
            cc.ly = lyc;
            cc.rx = rxc;
            cc.ry = ryc;
            Program.update_cc = true;
        }

        private void CalibrateRight_Click(object sender, EventArgs e)
        {
            var s = Program.Controller.GetState();
            rxc = s.Gamepad.RightThumbX;
            ryc = s.Gamepad.RightThumbY;
            RXCenter.Text = rxc.ToString();
            RYCenter.Text = ryc.ToString();
        }

        private void CalibrateLeft_Click(object sender, EventArgs e)
        {
            var s = Program.Controller.GetState();
            lxc = s.Gamepad.LeftThumbX;
            lyc = s.Gamepad.LeftThumbY;
            LXCenter.Text = lxc.ToString();
            LYCenter.Text = lyc.ToString();
        }
    }
}
