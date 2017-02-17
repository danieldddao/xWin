using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace xWin.Library
{
    public class XKeyBoard
    {
        const uint KEYEVENTF_EXTENDEDKEY = 0x0001;

        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, uint dwExtraInfo);
        [DllImport("user32.dll")]
        public static extern short VkKeyScan(char s);

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
                throw e;
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
                throw e;
            }
        }

        public bool PressKeysFromString(string s)
        {
            try
            {
                char[] array = s.ToCharArray(); // Convert String to array of characters
                for (int i = 0; i < array.Length; i++)
                {
                    char c = array[i];
                    Press((byte)VkKeyScan(c));
                    Release((byte)VkKeyScan(c));
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error When Mapping String to Keys: {0}", s);
                throw e;
            }
        }
    }
}
