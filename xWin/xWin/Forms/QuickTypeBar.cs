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
    public partial class QuickTypeBar : Form
    {
        public QuickTypeBar()
        {
            InitializeComponent();

        }

        public void SetQuickTypeButton1(string text)
        {
            quickTypeButton1.Text = text;
        }
        public void SetQuickTypeButton2(string text)
        {
            quickTypeButton2.Text = text;
        }
        public void SetQuickTypeButton3(string text)
        {
            quickTypeButton3.Text = text;
        }

        private void quickTypeButton1_Click(object sender, EventArgs e)
        {

        }

        private void quickTypeButton2_Click(object sender, EventArgs e)
        {

        }

        private void quickTypeButton3_Click(object sender, EventArgs e)
        {

        }
    }
}
