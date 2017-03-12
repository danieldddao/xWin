using SharpDX.XInput;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace xWin.Forms.ButtonMaps
{
    public partial class TextMapping : Form
    {
        public String textToMap { get; set; } = "";

        public TextMapping (GamepadButtonFlags button)
        {
            InitializeComponent();
            TextMappingLabel.Text = "Enter text to map to button '" + button + "' :";
            TextMappingLabel.TextAlign = ContentAlignment.MiddleCenter;
        }

        private void textTextBox_TextChanged(object sender, EventArgs e)
        {
            textToMap = textTextBox.Text;
        }

        private void doneButton_Click(object sender, EventArgs e)
        {
            this.Close(); // close form when clicking done button
        }

        private void TextMappingLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
