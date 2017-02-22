using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace xWin.Library
{
    public enum Action
    {
        None,
        PressKey,
        PressKeysFromString,
        PressShortcut,
        OpenApp
    };

    public class XKeyBoard
    {
        const uint KEYEVENTF_EXTENDEDKEY = 0x0001;
        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, uint dwExtraInfo);
        [DllImport("user32.dll")]
        public static extern short VkKeyScan(char s);

        private Action action = Action.None;
        private Keys keyToPress = Keys.None;
        private string stringToPress = null;
        private string appPath = null;
        private Keys[] shortcutToPress = null;

        public void SetAction(Action a)
        {
            this.action = a;
        }

        public void SetKeyToPress(Keys key)
        {
                this.keyToPress = key;
        }

        public void SetStringToPress(string s)
        {
            this.stringToPress = s;
        }

        public void SetAppPath(string path)
        {
            this.appPath = path;
        }
    
        public void SetShortcutToPress(Keys[] shortcut)
        {
            this.shortcutToPress = shortcut;
        }

        /*
         * Execute based on the Action
         */ 
        public void Execute ()
        {
            switch (action)
            {
                case Action.None:
                    {
                        // do nothing
                        break;
                    }
                case Action.PressKey:
                    {
                        if (keyToPress != Keys.None) { PressKey(keyToPress); }
                        break;
                    }
                case Action.PressKeysFromString:
                    {
                        if (stringToPress != null) { PressKeysFromString(stringToPress); }
                        break;
                    }
                case Action.PressShortcut:
                    {
                        if (shortcutToPress != null) { PressShortcut(shortcutToPress); }
                        break;
                    }
                case Action.OpenApp:
                    {
                        if (appPath != null) { OpenApplication(appPath); }
                        break;
                    }
            }
        }

        public void Press(byte key)
        {
            // Presses the key  
            keybd_event(key, 0, KEYEVENTF_EXTENDEDKEY | 0, 0);
        }

        public void Release(byte key)
        {
            // Releases the key  
            keybd_event(key, 0, 2, 0);
        }

        /*
         * Press and Release the key where key = System.Windows.Forms.Keys.somekey
         */
        public bool PressKey(Keys key)
        {
            try
            {
                Press((byte) key);
                Thread.Sleep(100);
                Release((byte)key);
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
                Press((byte) VkKeyScan(key));      
                Thread.Sleep(100);
                Release((byte)VkKeyScan(key));
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
                    if (char.IsUpper(c)) // If c is uppercase, press shift key
                    {
                        Press(VK_SHIFT);
                    } else { }
                    Press((byte)VkKeyScan(c));

                    if (char.IsUpper(c)) // If c is uppercase, release shift key
                    {
                        Release(VK_SHIFT);
                    }
                    Release((byte)VkKeyScan(c));
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
                { Press((byte)k); }
                foreach (Keys k in shortcut)
                { Release((byte)k); }
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
                if (!File.Exists(path))
                {
                    Console.WriteLine("Application doesn't exist {0}", path);
                    return false;
                }
                Process.Start(path);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error When Opening Application: {0}", path);
                Console.WriteLine(e);
                return false;
            }
        }
    }
}
