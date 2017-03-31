using Gma.System.MouseKeyHook;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace xWin.Forms.ButtonMaps
{
    public partial class ShortcutMapping : Form
    {
        private IKeyboardMouseEvents m_GlobalHook;
        public List<Keys> shortcut { get; set; }
        private bool clearText = false;

        public ShortcutMapping()
        {
            InitializeComponent();
            shortcutTextbox.Text = "";
            shortcut = new List<Keys>();
        }

        public void Subscribe()
        {
            m_GlobalHook = Hook.GlobalEvents();
            m_GlobalHook.KeyDown += GlobalHookKeyDown;
            m_GlobalHook.KeyUp += GlobalHookKeyUp;
        }

        public void Unsubscribe()
        {
            m_GlobalHook.KeyDown -= GlobalHookKeyDown;
            m_GlobalHook.KeyUp -= GlobalHookKeyUp;
            m_GlobalHook.Dispose();
        }

        private void GlobalHookKeyDown(object sender, KeyEventArgs e)
        {
            // Clear the textbox when starting entering new shortcut
            if (clearText == true)
            {
                shortcutTextbox.Text = "";
                shortcut = new List<Keys>();
                clearText = false;
            }
            if (shortcut.Contains(e.KeyCode) == false)
            {
                shortcut.Add(e.KeyCode);
                PrintShortcutInTextbox(e.KeyCode);
            }
            e.Handled = true;
            e.SuppressKeyPress = true;
        }

        private void GlobalHookKeyUp(object sender, KeyEventArgs e)
        {
            clearText = true;
        }

        private void ShortcutMapping_Load(object sender, EventArgs e)
        {
            Subscribe();
        }

        private void PrintShortcutInTextbox(Keys key)
        {
            switch (key)
            {
                case Keys.None:
                    {
                        // do nothing
                        break;
                    }
                case Keys.LShiftKey:
                case Keys.RShiftKey:
                case Keys.Shift:
                case Keys.ShiftKey:
                    {
                        shortcutTextbox.Text += "Shift" + "\r\n";
                        break;
                    }
                case Keys.Control:
                case Keys.ControlKey:
                case Keys.LControlKey:
                case Keys.RControlKey:
                    {
                        shortcutTextbox.Text += "Ctrl" + "\r\n";
                        break;
                    }
                case Keys.Alt:
                case Keys.Menu:
                case Keys.LMenu:
                case Keys.RMenu:
                    {
                        shortcutTextbox.Text += "Alt" + "\r\n";
                        break;
                    }
                case Keys.LWin:
                case Keys.RWin:
                    {
                        shortcutTextbox.Text += "Win" + "\r\n";
                        break;
                    }
                case Keys.Enter:
                    {
                        shortcutTextbox.Text += "Enter" + "\r\n";
                        break;
                    }
                default:
                    {
                        shortcutTextbox.Text += key.ToString() + "\r\n";
                        break;
                    }
            }
        }

        private void buttonDone_Click(object sender, EventArgs e)
        {
            this.Close();
            Unsubscribe();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            shortcut = new List<Keys>();
            this.Close();
            Unsubscribe();
        }

    }
}