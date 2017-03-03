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
    public partial class ButtonOptions : Form
    {
        public ButtonOptions()
        {
            InitializeComponent();
        }

        private void mapKeyboard_Click(object sender, EventArgs e)
        {
            KeyboardMapping kb = new KeyboardMapping();
            kb.ShowDialog(); 
        }

        private void mapShortcut_Click(object sender, EventArgs e)
        {

        }

        private void openApplication_Click(object sender, EventArgs e)
        {

        }

        private void mapText_Click(object sender, EventArgs e)
        {

        }
    }
}
