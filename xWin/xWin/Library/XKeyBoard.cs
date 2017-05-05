using log4net;
using System;
using System.Threading;
using System.Windows.Forms;
using WindowsInput;
using xWin.Wrapper;

namespace xWin.Library
{
    public interface IXKeyBoard
    {
        XAction Action { get; set; }
        byte KeyToPress { get; set; }
        string StringToPress { get; set; }
        string AppPath { get; set; }
        Keys[] ShortcutToPress { get; set; }
        void Execute();
    }

    public class XKeyBoard : IXKeyBoard
    {
        public XAction Action { get; set; }
        public byte KeyToPress { get; set; }
        public string StringToPress { get; set; }
        public string AppPath { get; set; }
        public Keys[] ShortcutToPress { get; set; }

        private readonly ISystemWrapper systemWrapper;

        public XKeyBoard()
        {
            this.systemWrapper = new SystemWrapper();
            Action = XAction.None;
            KeyToPress = 0;
            StringToPress = null;
            AppPath = null;
            ShortcutToPress = null;
        }

        public XKeyBoard(ISystemWrapper isystemWrapper)
        {
            this.systemWrapper = isystemWrapper;
        }

        /*
         * Press and Release the key where key is a byte
         */
        public bool PressKey(byte key)
        {
            try
            {
                systemWrapper.Press(key);
                Thread.Sleep(100);
                systemWrapper.Release(key);
                return true;
            }
            catch (Exception e)
            {
                Log.GetLogger().Error("Error When Pressing Key " + (Keys) key, e);
                return false;
            }
        }

        /*
         * Press and Release the key where key = System.Windows.Forms.Keys.somekey
         */
        public bool PressKey(Keys key)
        {
            try
            {
                systemWrapper.Press((byte) key);
                Thread.Sleep(100);
                systemWrapper.Release((byte) key);
                return true;
            }
            catch (Exception e)
            {
                Log.GetLogger().Error("Error When Pressing Key " + (Keys) key, e);
                return false;
            }
        }

        /*
         * Convert char to key and press the key
         */
        public bool PressKey(char key)
        {
            try
            {
                systemWrapper.SimulateKeyPress((WindowsInput.Native.VirtualKeyCode) systemWrapper.ScanKey(key));
                return true;
            }
            catch (Exception e)
            {
                Log.GetLogger().Error("Error When Pressing Key " + (Keys) key, e);
                return false;
            }
        }

        /*
         * Press the given WindowsInput.Native.VirtualKeyCode using WindowsInput.InputSimulator
         */
        public bool PressKey(WindowsInput.Native.VirtualKeyCode key)
        {
            try
            {
                systemWrapper.SimulateKeyPress(key);
                Thread.Sleep(100);
                return true;
            }
            catch (Exception e)
            {
                Log.GetLogger().Error(e);
                return false;
            }
        }

        /*
         * Simulate the text entry
         */
        public bool PressKeysFromString(string s)
        {
            try
            {
                //const byte VK_SHIFT = 0x10;
                //char[] array = s.ToCharArray(); // Convert String to array of characters
                //for (int i = 0; i < array.Length; i++)
                //{
                //    char c = array[i];
                //    if (char.IsUpper(c) || Array.IndexOf(shiftedKeys, c) > -1) // If c is uppercase or shifted key, also press and release shift key
                //    {
                //        systemWrapper.Press(VK_SHIFT);
                //        systemWrapper.Press((byte)systemWrapper.ScanKey(c));
                //        systemWrapper.Release((byte)systemWrapper.ScanKey(c));
                //        systemWrapper.Release(VK_SHIFT);
                //    }
                //    else
                //    {
                //        systemWrapper.Press((byte)systemWrapper.ScanKey(c));
                //        systemWrapper.Release((byte)systemWrapper.ScanKey(c));
                //    }
                //}
                systemWrapper.SimulateText(s);
                return true;
            }
            catch (Exception e)
            {
                Log.GetLogger().Error("Error When Mapping String to Keys " + s, e);
                return false;
            }
        }

        /*
         * Press the keyboard shortcut from a given sequence of keys
         */
        public bool PressShortcut(Keys[] shortcut)
        {
            try
            {
                if (shortcut.Length > 0)
                {
                    foreach (Keys k in shortcut)
                    { systemWrapper.SimulateKeyDown((WindowsInput.Native.VirtualKeyCode)k); }

                    for (int i = shortcut.Length - 1; i >= 0; i--)
                    { systemWrapper.SimulateKeyUp((WindowsInput.Native.VirtualKeyCode)shortcut[i]); }
                }

                return true;
            }
            catch (Exception e)
            {
                Log.GetLogger().Error("Error When Pressing Shortcut: " + shortcut, e);
                return false;
            }
        }

        /*
         * Open the application from the given path
         */
        public bool OpenApplication(string path)
        {
            try
            {
                if (!systemWrapper.IsFileExist(path))
                {
                    Log.GetLogger().Warn("Application doesn't exist " + path);
                    return false;
                }
                systemWrapper.StartProcess(path);
                return true;
            }
            catch (Exception e)
            {
                Log.GetLogger().Error("Error When Opening Application: " + path, e);
                return false;
            }
        }

        /*
         * Execute based on the Action
         */
        public void Execute()
        {
            try
            {
                switch (Action)
                {
                    case XAction.None:
                        {
                            // do nothing
                            break;
                        }
                    case XAction.PressKey:
                        {
                            if (KeyToPress != (byte) Keys.None)
                            {
                                PressKey((WindowsInput.Native.VirtualKeyCode) KeyToPress);
                                Log.GetLogger().Info("Pressed Key " + (Keys) KeyToPress);
                            }
                            break;
                        }
                    case XAction.PressKeysFromString:
                        {
                            if (StringToPress != null)
                            {
                                PressKeysFromString(StringToPress);
                                Log.GetLogger().Info("Printed out string  " + StringToPress);

                            }
                            break;
                        }
                    case XAction.PressShortcut:
                        {
                            if (ShortcutToPress != null)
                            {
                                PressShortcut(ShortcutToPress);
                                Log.GetLogger().Info("Executed Shortcut " + string.Join("+ ", ShortcutToPress));
                            }
                            break;
                        }
                    case XAction.OpenApp:
                        {
                            if (AppPath != null)
                            {
                                OpenApplication(AppPath);
                                Log.GetLogger().Info("Opened App " + AppPath);
                            }
                            break;
                        }
                }
                Thread.Sleep(100);
            }
            catch (Exception e)
            {
                Log.GetLogger().Error("Error when executing action " + Action, e);
            }
        }
    }

}
