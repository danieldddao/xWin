using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace xWin.Forms
{
    public partial class AutoCompleteAddNewWord : Form
    {
        public string newWord { get; set; } = "";
        public AutoCompleteAddNewWord()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("^[a-zA-Z0-9]+$");
            Match match = regex.Match(wordTextBox.Text);
            if (match.Success)
            {
                newWord = wordTextBox.Text;
                this.Close();
            }
            else
            {
                MessageBox.Show("Please Enter Alphanumeric string!");
            }
        }
    }
}
