using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace xWin.Forms.CharacterWheels
{
    public partial class CharacterWheel8Section : Form
    {
        public CharacterWheel8Section()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (System.Windows.Forms.Cursor.Position.X - this.Width * 2 / 3 - 20 <= SystemInformation.VirtualScreen.Left && System.Windows.Forms.Cursor.Position.Y - this.Height * 2 / 3 - 20 <= SystemInformation.VirtualScreen.Top)
                Location = new Point(SystemInformation.VirtualScreen.Left, SystemInformation.VirtualScreen.Top);
            else if (System.Windows.Forms.Cursor.Position.X - this.Width * 2 / 3 - 20 <= SystemInformation.VirtualScreen.Left)
                Location = new Point(SystemInformation.VirtualScreen.Left, System.Windows.Forms.Cursor.Position.Y - this.Height * 2 / 3 - 20);
            else if (System.Windows.Forms.Cursor.Position.Y - this.Height * 2 / 3 - 20 <= SystemInformation.VirtualScreen.Top)
                Location = new Point(System.Windows.Forms.Cursor.Position.X - this.Width * 2 / 3 - 20, SystemInformation.VirtualScreen.Top);
            else Location = new Point(System.Windows.Forms.Cursor.Position.X - this.Width * 2 / 3 - 20, System.Windows.Forms.Cursor.Position.Y - this.Height * 2 / 3 - 20);
        }

        private void CharacterWheel8Section_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            if (System.Windows.Forms.Cursor.Position.X - this.Width - 20 <= SystemInformation.VirtualScreen.Left && System.Windows.Forms.Cursor.Position.Y - this.Height - 20 <= SystemInformation.VirtualScreen.Top)
                Location = new Point(SystemInformation.VirtualScreen.Left, SystemInformation.VirtualScreen.Top);
            else if (System.Windows.Forms.Cursor.Position.X - this.Width - 20 <= SystemInformation.VirtualScreen.Left)
                Location = new Point(SystemInformation.VirtualScreen.Left, System.Windows.Forms.Cursor.Position.Y - this.Height - 20);
            else if (System.Windows.Forms.Cursor.Position.Y - this.Height - 20 <= SystemInformation.VirtualScreen.Top)
                Location = new Point(System.Windows.Forms.Cursor.Position.X - this.Width - 20, SystemInformation.VirtualScreen.Top);
            else Location = new Point(System.Windows.Forms.Cursor.Position.X - this.Width - 20, System.Windows.Forms.Cursor.Position.Y - this.Height - 20);
        }
    }
}
