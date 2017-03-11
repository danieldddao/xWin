using SharpDX.XInput;
using System;
using System.Windows.Forms;
using xWin.Library;

namespace xWin.Forms
{
    public partial class ButtonOptions : Form
    {
        IXController xController;
        public GamepadButtonFlags currentButton { get; set; }

        public ButtonOptions(IXController controller)
        {
            InitializeComponent();
            this.xController = controller;
            currentButton = GamepadButtonFlags.None;
        }
        
        private void ChangeKeyboardButtonAndCheckbox(bool status)
        {
            mapKeyboard.Enabled = status;
            keyboardCheckBox.Enabled = status;
        }

        private void ChangeAppButtonAndCheckbox(bool status)
        {
            openApplication.Enabled = status;
            openAppCheckBox.Enabled = status;
        }

        private void ChangeShortcutButtonAndCheckbox(bool status)
        {
            mapShortcut.Enabled = status;
            shortcutCheckBox.Enabled = status;
        }

        private void ChangeTextButtonAndCheckbox(bool status)
        {
            mapText.Enabled = status;
            textCheckBox.Enabled = status;
        }

        /*
         * Update the Textbox for each button
         */
        private void UpdateTextBoxes(IXKeyBoard keyboard)
        {
            // check if a key has been assigned to the currentButton
            if (keyboard.KeyToPress == Keys.None)
            {
                keyboardTextBox.Text = "";
                keyboardTextBox.AppendText("Key Mapping: NONE");
                keyboardTextBox.AppendText(Environment.NewLine);
                keyboardTextBox.AppendText("Please choose a key to map button to key!");
            }
            else
            {
                keyboardTextBox.Text = "Key Mapping: " + keyboard.KeyToPress;
            }

            // check if an application has been assigned to the currentButton
            if (keyboard.AppPath == null)
            {
                openAppTextBox.Text = "";
                openAppTextBox.AppendText("Application to open: NONE");
                openAppTextBox.AppendText(Environment.NewLine);
                openAppTextBox.AppendText("Please choose an application to open!");
            }
            else
            {
                openAppTextBox.Text = "Application to open: " + keyboard.AppPath;
            }

            // check if a shortcut has been assigned to the currentButton
            if (keyboard.ShortcutToPress == null)
            {
                shortcutTextBox.Text = "";
                shortcutTextBox.AppendText("Shortcut: NONE");
                shortcutTextBox.AppendText(Environment.NewLine);
                shortcutTextBox.AppendText("Please choose a shortcut!");
            }
            else
            {
                string shortcut = "";
                foreach (Keys key in keyboard.ShortcutToPress)
                {
                    shortcut += key + " ";
                }
                shortcutTextBox.Text = "Shortcut: " + shortcut;
            }

            // check if a text has been assigned to the currentButton
            if (keyboard.StringToPress == null)
            {
                textTextBox.Text = "";
                textTextBox.AppendText("Text: NONE");
                textTextBox.AppendText(Environment.NewLine);
                textTextBox.AppendText("Please enter a text!");
            }
            else
            {
                textTextBox.Text = keyboard.StringToPress;
            }
        }

        /*
         * Update actions on load
         */
        private void ButtonOptions_Load(object sender, EventArgs e)
        {
            IXKeyBoard keyboard = xController.GetKeyBoardForButton(currentButton); // Keyboard corresponding to currentButton
            switch (keyboard.Action)
            {
                case XAction.None:
                    {
                        ChangeKeyboardButtonAndCheckbox(true);
                        ChangeAppButtonAndCheckbox(true);
                        ChangeShortcutButtonAndCheckbox(true);
                        ChangeTextButtonAndCheckbox(true);
                        UpdateTextBoxes(keyboard);
                        break;
                    }
                case XAction.PressKey:
                    {
                        break;
                    }
                case XAction.OpenApp:
                    {
                        break;
                    }
                case XAction.PressShortcut:
                    {
                        break;
                    }
                case XAction.PressKeysFromString:
                    {
                        break;
                    }
            }
        }

        /* Map to Keyboard */
        private void mapKeyboard_Click(object sender, EventArgs e)
        {
            KeyboardMapping kb = new KeyboardMapping();
            kb.ShowDialog(); 
        }

        private void keyboardCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (keyboardCheckBox.Checked)
            {
                ChangeKeyboardButtonAndCheckbox(true);
                ChangeAppButtonAndCheckbox(false);
                ChangeShortcutButtonAndCheckbox(false);
                ChangeTextButtonAndCheckbox(false);
            } 
            else
            {
                ChangeKeyboardButtonAndCheckbox(true);
                ChangeAppButtonAndCheckbox(true);
                ChangeShortcutButtonAndCheckbox(true);
                ChangeTextButtonAndCheckbox(true);
            }
        }

        /* Map to open App */
        private void openApplication_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog.Filter = "Executable Files |*.exe" + "|All Files |*.*";
                DialogResult result = openFileDialog.ShowDialog(); // Show the dialog.
                if (result == DialogResult.OK) // Test result.
                {
                    string file = openFileDialog.FileName;
                    IXKeyBoard xKeyboard = xController.GetKeyBoardForButton(currentButton);
                    xKeyboard.Action = XAction.OpenApp;
                    xKeyboard.AppPath = file;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(" Error when mapping button to application {0}", ex);
            }
        }
        private void openAppCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (openAppCheckBox.Checked)
            {
                ChangeKeyboardButtonAndCheckbox(false);
                ChangeAppButtonAndCheckbox(true);
                ChangeShortcutButtonAndCheckbox(false);
                ChangeTextButtonAndCheckbox(false);
            }
            else
            {
                ChangeKeyboardButtonAndCheckbox(true);
                ChangeAppButtonAndCheckbox(true);
                ChangeShortcutButtonAndCheckbox(true);
                ChangeTextButtonAndCheckbox(true);
            }
        }

        /* Map to Shortcut */
        private void mapShortcut_Click(object sender, EventArgs e)
        {

        }
        private void shortcutCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (shortcutCheckBox.Checked)
            {
                ChangeKeyboardButtonAndCheckbox(false);
                ChangeAppButtonAndCheckbox(false);
                ChangeShortcutButtonAndCheckbox(true);
                ChangeTextButtonAndCheckbox(false);
            }
            else
            {
                ChangeKeyboardButtonAndCheckbox(true);
                ChangeAppButtonAndCheckbox(true);
                ChangeShortcutButtonAndCheckbox(true);
                ChangeTextButtonAndCheckbox(true);
            }
        }

        /* Map to Text */
        private void mapText_Click(object sender, EventArgs e)
        {

        }        
        private void textCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (textCheckBox.Checked)
            {
                ChangeKeyboardButtonAndCheckbox(false);
                ChangeAppButtonAndCheckbox(false);
                ChangeShortcutButtonAndCheckbox(false);
                ChangeTextButtonAndCheckbox(true);
            }
            else
            {
                ChangeKeyboardButtonAndCheckbox(true);
                ChangeAppButtonAndCheckbox(true);
                ChangeShortcutButtonAndCheckbox(true);
                ChangeTextButtonAndCheckbox(true);
            }
        }

    }
}
