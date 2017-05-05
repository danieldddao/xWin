using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace xWin.GUI
{
    public partial class StringListControl : UserControl
    {
        public StringListControl()
        {
            InitializeComponent();
        }
        public StringListControl(int count) : this()
        {
            for(int i = 0; i < count; ++i)
            {
                StringArray.Controls.Add(new TextBox());
            }
        }
    }
}
