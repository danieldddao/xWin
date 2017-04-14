using SharpDX.XInput;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using xWin.Forms.ButtonMaps;
using xWin.Library;

namespace xWin.Forms
{
    public partial class ButtonOptions : Form
    {
        IXController xController;
        public GamepadButtonFlags currentButton { get; set; }
        private List<CheckBox> checkboxes = new List<CheckBox>();

        public ButtonOptions(IXController controller)
        {
            InitializeComponent();
            this.xController = controller;
            currentButton = GamepadButtonFlags.None;
            checkboxes.Add(keyboardCheckBox);
            checkboxes.Add(openAppCheckBox);
            checkboxes.Add(shortcutCheckBox);
            checkboxes.Add(textCheckBox);
        }

        /*
         * Update the Textbox for each button
         */
        private void UpdateTextBoxes(IXKeyBoard keyboard)
        {
            try
            {
                switch ((Keys)keyboard.KeyToPress)
                {
                    case Keys.None:
                        {
                            keyboardTextBox.Text = "";
                            keyboardTextBox.AppendText("Key Mapping: NONE");
                            keyboardTextBox.AppendText(Environment.NewLine);
                            keyboardTextBox.AppendText("Please choose a key to map button to key!");
                            break;
                        }
                    case Keys.LShiftKey:
                    case Keys.RShiftKey:
                    case Keys.Shift:
                    case Keys.ShiftKey:
                        {
                            keyboardTextBox.Text = "Key Mapping: Shift";
                            break;
                        }
                    case Keys.Control:
                    case Keys.ControlKey:
                    case Keys.LControlKey:
                    case Keys.RControlKey:
                        {
                            keyboardTextBox.Text = "Key Mapping: Ctrl";
                            break;
                        }
                    case Keys.Alt:
                    case Keys.Menu:
                    case Keys.LMenu:
                    case Keys.RMenu:
                        {
                            keyboardTextBox.Text = "Key Mapping: Alt";
                            break;
                        }
                    case Keys.LWin:
                    case Keys.RWin:
                        {
                            keyboardTextBox.Text = "Key Mapping: Win";
                            break;
                        }
                    case Keys.Enter:
                        {
                            keyboardTextBox.Text = "Key Mapping: Enter";
                            break;
                        }
                    default:
                        {
                            keyboardTextBox.Text = "Key Mapping: " + (Keys)keyboard.KeyToPress;
                            break;
                        }
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
                    string shortcutString = "";
                    Keys[] shortcut = keyboard.ShortcutToPress;
                    for (int i = 0; i < shortcut.Length; i++)
                    {
                        String key = "";
                        switch (shortcut[i])
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
                                    key = "Shift";
                                    break;
                                }
                            case Keys.Control:
                            case Keys.ControlKey:
                            case Keys.LControlKey:
                            case Keys.RControlKey:
                                {
                                    key = "Ctrl";
                                    break;
                                }
                            case Keys.Alt:
                            case Keys.Menu:
                            case Keys.LMenu:
                            case Keys.RMenu:
                                {
                                    key = "Alt";
                                    break;
                                }
                            case Keys.LWin:
                            case Keys.RWin:
                                {
                                    key = "Win";
                                    break;
                                }
                            case Keys.Enter:
                                {
                                    key = "Enter";
                                    break;
                                }
                            default:
                                {
                                    key = shortcut[i].ToString();
                                    break;
                                }
                        }

                        if (i == shortcut.Length - 1) // if key in shortcut is the last key
                        {
                            shortcutString += key;
                        }
                        else
                        {
                            shortcutString += key + " + ";
                        }
                    }
                    shortcutTextBox.Text = "Shortcut: " + shortcutString;
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
                    textTextBox.Text = "Text: " + keyboard.StringToPress;
                }
            }
            catch (Exception e)
            {
                Log.GetLogger().Error(e);
            }
        }

        private void RefreshButtonsAndTextboxes()
        {
            try
            {
                if (currentButton != GamepadButtonFlags.None)
                {
                    IXKeyBoard keyboard = xController.GetKeyBoardForButton(currentButton); // Keyboard corresponding to currentButton
                    UpdateTextBoxes(keyboard);

                    switch (keyboard.Action)
                    {
                        case XAction.None:
                            {
                                foreach (CheckBox checkbox in checkboxes)
                                { checkbox.Checked = false; }
                               
                                break;
                            }
                        case XAction.PressKey:
                            {
                                foreach (CheckBox checkbox in checkboxes)
                                {
                                    if (checkbox == keyboardCheckBox) { checkbox.Checked = true; }
                                    else { checkbox.Checked = false; }
                                }
                                
                                break;
                            }
                        case XAction.OpenApp:
                            {
                                foreach (CheckBox checkbox in checkboxes)
                                {
                                    if (checkbox == openAppCheckBox) { checkbox.Checked = true; }
                                    else { checkbox.Checked = false; }
                                }
                                
                                break;
                            }
                        case XAction.PressShortcut:
                            {
                                foreach (CheckBox checkbox in checkboxes)
                                {
                                    if (checkbox == shortcutCheckBox) { checkbox.Checked = true; }
                                    else { checkbox.Checked = false; }
                                }
                                
                                break;
                            }
                        case XAction.PressKeysFromString:
                            {
                                foreach (CheckBox checkbox in checkboxes)
                                {
                                    if (checkbox == textCheckBox) { checkbox.Checked = true; }
                                    else { checkbox.Checked = false; }
                                }
                                
                                break;
                            }
                    }
                }
            }
            catch (Exception e)
            {
                Log.GetLogger().Error(e);
            }
        }

        private void RefreshCurrentActionTextbox()
        {
            try
            {
                if (currentButton != GamepadButtonFlags.None)
                {
                    IXKeyBoard keyboard = xController.GetKeyBoardForButton(currentButton); // Keyboard corresponding to currentButton
                    currentActionTextbox.Text = "Button " + currentButton + " currently maps to:";
                    switch (keyboard.Action)
                    {
                        case XAction.None:
                            {
                                currentActionTextbox.AppendText(Environment.NewLine);
                                currentActionTextbox.AppendText("NONE");

                                break;
                            }
                        case XAction.PressKey:
                            {
                                currentActionTextbox.AppendText(Environment.NewLine);
                                currentActionTextbox.AppendText("Keyboard");

                                break;
                            }
                        case XAction.OpenApp:
                            {
                                currentActionTextbox.AppendText(Environment.NewLine);
                                currentActionTextbox.AppendText("Open Application");

                                break;
                            }
                        case XAction.PressShortcut:
                            {
                                currentActionTextbox.AppendText(Environment.NewLine);
                                currentActionTextbox.AppendText("Shortcut");

                                break;
                            }
                        case XAction.PressKeysFromString:
                            {
                                currentActionTextbox.AppendText(Environment.NewLine);
                                currentActionTextbox.AppendText("Text");

                                break;
                            }
                    }
                }
            }
            catch (Exception e)
            {
                Log.GetLogger().Error(e);
            }
        }

        /*
         * Update buttons, textboxes, keyboard, etc. on load
         */
        private void ButtonOptions_Load(object sender, EventArgs e)
        {
            RefreshButtonsAndTextboxes();
            RefreshCurrentActionTextbox();
        }

        /* Map to Keyboard */
        private void mapKeyboard_Click(object sender, EventArgs e)
        {
            try
            {
                KeyboardMapping keyboardMapping = new KeyboardMapping();
                keyboardMapping.ShowDialog();
                IXKeyBoard keyboard = xController.GetKeyBoardForButton(currentButton);
                keyboard.Action = XAction.PressKey;
                keyboard.KeyToPress = keyboardMapping.CurrentKey;
                RefreshButtonsAndTextboxes();
                RefreshCurrentActionTextbox();
                Log.GetLogger().Info("Successfully mapped button " + currentButton + " to key " + (Keys)keyboard.KeyToPress);
            }
            catch (Exception ex)
            {
                Log.GetLogger().Error(ex);
            }
        }

        private void keyboardCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                IXKeyBoard keyboard = xController.GetKeyBoardForButton(currentButton);
                if (!keyboardCheckBox.Checked)
                {
                    // Set keyboard action to None
                    keyboard.Action = XAction.None;
                    Log.GetLogger().Info("keyboard option is unchecked");
                }
                else
                {
                    foreach (CheckBox checkbox in checkboxes)
                    {
                        if (checkbox != keyboardCheckBox) { checkbox.Checked = false; }
                    }

                    // Set keyboard action to pressKey
                    keyboard.Action = XAction.PressKey;
                    Log.GetLogger().Info("keyboard option is checked");
                }
                RefreshCurrentActionTextbox();
            }
            catch (Exception ex)
            {
                Log.GetLogger().Error(ex);
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
                    IXKeyBoard keyboard = xController.GetKeyBoardForButton(currentButton);
                    keyboard.Action = XAction.OpenApp;
                    keyboard.AppPath = file;
                    RefreshButtonsAndTextboxes();
                    RefreshCurrentActionTextbox();
                    Log.GetLogger().Info("Successfully mapped button " + currentButton + " to open app " + keyboard.AppPath);
                }
            }
            catch (Exception ex)
            {
                Log.GetLogger().Error(ex);
            }
        }
        private void openAppCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                IXKeyBoard keyboard = xController.GetKeyBoardForButton(currentButton);
                if (!openAppCheckBox.Checked)
                {
                    // Set keyboard action to None
                    keyboard.Action = XAction.None;
                    Log.GetLogger().Info("openApp option is unchecked");
                }
                else
                {
                    foreach (CheckBox checkbox in checkboxes)
                    {
                        if (checkbox != openAppCheckBox) { checkbox.Checked = false; }
                    }

                    // Set keyboard action to pressKey
                    keyboard.Action = XAction.OpenApp;
                    Log.GetLogger().Info("openApp option is checked");
                }
                RefreshCurrentActionTextbox();
            }
            catch (Exception ex)
            {
                Log.GetLogger().Error(ex);
            }
        }

        /* Map to Shortcut */
        private void mapShortcut_Click(object sender, EventArgs e)
        {
            try
            {
                ShortcutMapping shortcutMapping = new ShortcutMapping();
                shortcutMapping.ShowDialog();
                IXKeyBoard keyboard = xController.GetKeyBoardForButton(currentButton);
                if (shortcutMapping.shortcut.Count > 0)
                {
                    keyboard.Action = XAction.PressShortcut;
                    keyboard.ShortcutToPress = shortcutMapping.shortcut.ToArray();
                }
                RefreshButtonsAndTextboxes();
                RefreshCurrentActionTextbox();
                Log.GetLogger().Info("Successfully mapped button " + currentButton + " to shortcut " + keyboard.ShortcutToPress);
            }
            catch (Exception ex)
            {
                Log.GetLogger().Error(ex);
            }
        }
        private void shortcutCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                IXKeyBoard keyboard = xController.GetKeyBoardForButton(currentButton);
                if (!shortcutCheckBox.Checked)
                {
                    // Set keyboard action to None
                    keyboard.Action = XAction.None;
                    Log.GetLogger().Info("Shortcut option is unchecked");
                }
                else
                {
                    foreach (CheckBox checkbox in checkboxes)
                    {
                        if (checkbox != shortcutCheckBox) { checkbox.Checked = false; }
                    }

                    // Set keyboard action to pressKey
                    keyboard.Action = XAction.PressShortcut;
                    Log.GetLogger().Info("Shortcut option is unchecked");
                }
                RefreshCurrentActionTextbox();
            }
            catch (Exception ex)
            {
                Log.GetLogger().Error(ex);
            }
        }

        /* Map to Text */
        private void mapText_Click(object sender, EventArgs e)
        {
            try
            {
                // Show TextMapping dialog
                TextMapping textMapping = new TextMapping(currentButton);
                textMapping.Text = "Map button '" + currentButton + "' to text";
                textMapping.ShowDialog();
                if (textMapping.textToMap != null)
                {
                    IXKeyBoard keyboard = xController.GetKeyBoardForButton(currentButton);
                    keyboard.Action = XAction.PressKeysFromString;
                    keyboard.StringToPress = textMapping.textToMap;

                    RefreshButtonsAndTextboxes();
                    RefreshCurrentActionTextbox();
                    Log.GetLogger().Info("Successfully mapped button " + currentButton + " to text: " + keyboard.StringToPress);
                }
                else
                {
                    MessageBox.Show("Text can't be empty");
                }
                
            }
            catch (Exception ex)
            {
                Log.GetLogger().Error(ex);
            }
        }
        private void textCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                IXKeyBoard keyboard = xController.GetKeyBoardForButton(currentButton);
                if (!textCheckBox.Checked)
                {
                    // Set keyboard action to None
                    keyboard.Action = XAction.None;
                    Log.GetLogger().Info("Text option is unchecked");
                }
                else
                {
                    foreach (CheckBox checkbox in checkboxes)
                    {
                        if (checkbox != textCheckBox) { checkbox.Checked = false; }
                    }

                    // Set keyboard action to pressKey
                    keyboard.Action = XAction.PressKeysFromString;
                    Log.GetLogger().Info("Text option is checked");
                }
                RefreshCurrentActionTextbox();
            }
            catch (Exception ex)
            {
                Log.GetLogger().Error(ex);
            }
        }

    }
}
