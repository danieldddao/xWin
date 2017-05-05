using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BasicControl.Types;

namespace xWin.GUI
{
    public partial class KeyboardSelectWindow : Form
    {
        public KeyboardSelectWindow(string s)
        {
            strrep = "";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            InitializeComponent();
            a = new Actions();
            foreach(var box in Keys.Controls.OfType<CheckBox>())
            {
                switch(box.Name)
                {
                    case "Escape":
                        box.Text = "Esc";
                        break;
                    case "Oemtilde":
                        box.Text = "`";
                        break;

                    case "Oem1":
                        box.Text = "1";
                        break;
                    case "Oem2":
                        box.Text = "2";
                        break;
                    case "Oem3":
                        box.Text = "3";
                        break;
                    case "Oem4":
                        box.Text = "4";
                        break;
                    case "Oem5":
                        box.Text = "5";
                        break;
                    case "Oem6":
                        box.Text = "6";
                        break;
                    case "Oem7":
                        box.Text = "7";
                        break;
                    case "Oem8":
                        box.Text = "8";
                        break;
                    case "Oem9":
                        box.Text = "9";
                        break;
                    case "Oem0":
                        box.Text = "0";
                        break;
                    case "OemMinus":
                        box.Text = "-";
                        break;
                    case "Oemplus":
                        box.Text = "=";
                        break;
                    case "OemOpenBrackets":
                        box.Text = "[";
                        break;
                    case "OemCloseBrackets":
                        box.Text = "]";
                        break;
                    case "OemPipe":
                        box.Text = "\\";
                        break;
                    case "OemSemicolon":
                        box.Text = ";";
                        break;
                    case "OemQuotes":
                        box.Text = "\'";
                        break;
                    case "LShiftKey":
                        box.Text = "LShift";
                        break;
                    case "Oemcomma":
                        box.Text = ",";
                        break;
                    case "OemPeriod":
                        box.Text = ".";
                        break;
                    case "OemQuestion":
                        box.Text = "?";
                        break;
                    case "RshiftKey":
                        box.Text = "Rshift";
                        break;
                    case "LControlKey":
                        box.Text = "LCTRL";
                        break;
                    case "LMenu":
                        box.Text = "LAlt";
                        break;
                    case "RMenu":
                        box.Text = "RAlt";
                        break;
                    case "RControlKey":
                        box.Text = "RCTRL";
                        break;
                    case "Up":
                        box.Text = "↑";
                        break;
                    case "Down":
                        box.Text = "↓";
                        break;
                    case "Left":
                        box.Text = "←";
                        break;
                    case "Right":
                        box.Text = "→";
                        break;
                    case "PrintScreen":
                        box.Text = "📷";
                        break;
                    case "Scroll":
                        box.Text = "🔒";
                        break;
                    case "Pause":
                        box.Text = "⏸️";
                        break;
                    case "Insert":
                        box.Text = "INS";
                        break;
                    case "Delete":
                        box.Text = "DEL";
                        break;
                    case "End":
                        box.Text = "🔚";
                        break;
                    case "Home":
                        box.Text = "🏠";
                        break;
                    case "PageUp":
                        box.Text = "⏫";
                        break;
                    case "PageDown":
                        box.Text = "⏬";
                        break;
                    case "NumPad0":
                        box.Text = "0";
                        break;
                    case "NumPad1":
                        box.Text = "1";
                        break;
                    case "NumPad2":
                        box.Text = "2";
                        break;
                    case "NumPad3":
                        box.Text = "3";
                        break;
                    case "NumPad4":
                        box.Text = "4";
                        break;
                    case "NumPad5":
                        box.Text = "5";
                        break;
                    case "NumPad6":
                        box.Text = "6";
                        break;
                    case "NumPad7":
                        box.Text = "7";
                        break;
                    case "NumPad8":
                        box.Text = "8";
                        break;
                    case "NumPad9":
                        box.Text = "9";
                        break;
                    case "Decimal":
                        box.Text = ".";
                        break;
                    case "Add":
                        box.Text = "+";
                        break;
                    case "Subtract":
                        box.Text = "-";
                        break;
                    case "Multiply":
                        box.Text = "*";
                        break;
                    case "Divide":
                        box.Text = "/";
                        break;
                    default:
                        box.Text = box.Name;
                        break;
                }
            }
            //var ss = s.Split(',');
            if(s != "")
                foreach(var ss in s.Split(','))
                {
                    ((CheckBox)(this.Controls.Find(ss, true)[0])).CheckState = CheckState.Checked;
                }
        }

        public Actions a;
        public string strrep;
        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void KeyboardSelectWindow_Load(object sender, EventArgs e)
        {

        }

        private void MouseUp_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Turbo_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Precision_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void addkey(CheckBox cb)
        {
            if(cb.Checked)
            {
                Keys k;
                Enum.TryParse(cb.Name, out k);
                strrep += cb.Name + ",";
                a.Keybinds.Add((int)k);
            }
        }

        private void addsa(CheckBox cb)
        {
            if (cb.Checked)
            {
                SpecialAction k;
                Enum.TryParse(cb.Name, out k);
                strrep += cb.Name + ",";
                a.SpecialActions.Add(k);
            }
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            a = new Actions
            {
                Keybinds = { },
                SpecialActions = { }
            };
            foreach (var box in Keys.Controls.OfType<CheckBox>())
            {
                addkey(box);
            }
            foreach(var box in Mouse.Controls.OfType<CheckBox>())
            {
                switch(box.Name)
                {
                    case "LButton":
                    case "RButton":
                    case "MButton":
                        addkey(box);
                        break;
                    default:
                        addsa(box);
                        break;

                }
            }
            foreach (var box in Other.Controls.OfType<CheckBox>())
            {
                addsa(box);
            }
            strrep = strrep.TrimEnd(',');
            this.Close();
        }
    }
}
