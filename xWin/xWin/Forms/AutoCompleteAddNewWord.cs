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
    public partial class AutoCompleteAddNewWord : Form
    {
        public string text { get; set; } = "";
        public AutoCompleteAddNewWord()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {

        }
    }
}
