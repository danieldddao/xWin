using System;
using System.Threading;
using System.Windows.Forms;
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
        private char[] shiftedKeys = {'!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '+', '{', '}', '|', ':', '"', '<', '>', '?'};
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
                Console.WriteLine("Error When Pressing Key (byte): {0}", key);
                Console.WriteLine(e);
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
                Console.WriteLine("Error When Pressing Key: {0}", key);
                Console.WriteLine(e);
                return false;
            }
        }

        /*
         * Press and Release the key where key is a char
         */
        public bool PressKey(char key)
        {
            try
            {
                const byte VK_SHIFT = 0x10;
                if (char.IsUpper(key) || Array.IndexOf(shiftedKeys, key) > -1) // If key is uppercase or shifted key, also press and release shift key
                {
                    systemWrapper.Press(VK_SHIFT);
                    systemWrapper.Press((byte)systemWrapper.ScanKey(key));
                    systemWrapper.Release((byte)systemWrapper.ScanKey(key));
                    systemWrapper.Release(VK_SHIFT);
                }
                else
                {
                    systemWrapper.Press((byte)systemWrapper.ScanKey(key));
                    systemWrapper.Release((byte)systemWrapper.ScanKey(key));
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error When Pressing Key: {0}", key);
                Console.WriteLine(e);
                return false;
            }
        }

        /*
         * Convert the input string to keys and press them
         */
        public bool PressKeysFromString(string s)
        {
            try
            {
                const byte VK_SHIFT = 0x10;
                char[] array = s.ToCharArray(); // Convert String to array of characters
                for (int i = 0; i < array.Length; i++)
                {
                    char c = array[i];
                    if (char.IsUpper(c) || Array.IndexOf(shiftedKeys, c) > -1) // If c is uppercase or shifted key, also press and release shift key
                    {
                        systemWrapper.Press(VK_SHIFT);
                        systemWrapper.Press((byte)systemWrapper.ScanKey(c));
                        systemWrapper.Release((byte)systemWrapper.ScanKey(c));
                        systemWrapper.Release(VK_SHIFT);
                    }
                    else
                    {
                        systemWrapper.Press((byte)systemWrapper.ScanKey(c));
                        systemWrapper.Release((byte)systemWrapper.ScanKey(c));
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error When Mapping String to Keys: {0}", s);
                Console.WriteLine(e);
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
                foreach (Keys k in shortcut)
                { systemWrapper.Press((byte)k); }

                foreach (Keys k in shortcut)
                { systemWrapper.Release((byte)k); }

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error When Pressing Shortcut: {0}", shortcut);
                Console.WriteLine(e);
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
                    Console.WriteLine("Application doesn't exist {0}", path);
                    return false;
                }
                systemWrapper.StartProcess(path);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error When Opening Application: {0}", path);
                Console.WriteLine(e);
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
                            if (KeyToPress != 0) { PressKey(KeyToPress); }
                            break;
                        }
                    case XAction.PressKeysFromString:
                        {
                            if (StringToPress != null) { PressKeysFromString(StringToPress); }
                            break;
                        }
                    case XAction.PressShortcut:
                        {
                            if (ShortcutToPress != null) { PressShortcut(ShortcutToPress); }
                            break;
                        }
                    case XAction.OpenApp:
                        {
                            if (AppPath != null) { OpenApplication(AppPath); }
                            break;
                        }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error when executing action {0} : {0}", Action, e);
            }
        }
    }

}
