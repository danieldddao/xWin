using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using xWin.Wrapper;

namespace xWin.Library
{
    public enum XAction
    {
        None,
        PressKey,
        PressKeysFromString,
        PressShortcut,
        OpenApp
    };

    public class XKeyBoard
    {
        private XAction action = XAction.None;
        private Keys keyToPress = Keys.None;
        private string stringToPress = null;
        private string appPath = null;
        private Keys[] shortcutToPress = null;

        private readonly ISystemWrapper systemWrapper;

        public XKeyBoard()
        {
            this.systemWrapper = new SystemWrapper();
        }

        public XKeyBoard(ISystemWrapper isystemWrapper)
        {
            this.systemWrapper = isystemWrapper;
        }   

        public XAction Action
        {
            get { return this.action; }
            set { this.action = value; }
        }

        public Keys KeyToPress
        {
            get { return this.keyToPress; }
            set { this.keyToPress = value; }
        }

        public string StringToPress
        {
            get { return this.stringToPress; }
            set { this.stringToPress = value; }
        }

        public string AppPath
        {
            get { return this.appPath; }
            set { this.appPath = value; }
        }
    
        public Keys[] ShortcutToPress
        {
            get { return this.shortcutToPress; }
            set { this.shortcutToPress = value; }
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
                systemWrapper.Release((byte)key);
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
                systemWrapper.Press((byte) systemWrapper.ScanKey(key));      
                Thread.Sleep(100);
                systemWrapper.Release((byte) systemWrapper.ScanKey(key));
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
                        systemWrapper.Press(VK_SHIFT);
                    }
                    systemWrapper.Press((byte) systemWrapper.ScanKey(c));

                    if (char.IsUpper(c)) // If c is uppercase, release shift key
                    {
                        systemWrapper.Release(VK_SHIFT);
                    }
                    systemWrapper.Release((byte)systemWrapper.ScanKey(c));
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
            switch (action)
            {
                case XAction.None:
                    {
                        // do nothing
                        break;
                    }
                case XAction.PressKey:
                    {
                        if (keyToPress != Keys.None) { PressKey(keyToPress); }
                        break;
                    }
                case XAction.PressKeysFromString:
                    {
                        if (stringToPress != null) { PressKeysFromString(stringToPress); }
                        break;
                    }
                case XAction.PressShortcut:
                    {
                        if (shortcutToPress != null) { PressShortcut(shortcutToPress); }
                        break;
                    }
                case XAction.OpenApp:
                    {
                        if (appPath != null) { OpenApplication(appPath); }
                        break;
                    }
            }
        }
    }

}
