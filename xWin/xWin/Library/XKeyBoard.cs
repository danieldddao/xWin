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
    public static class XKeyBoard
    {
        const uint KEYEVENTF_EXTENDEDKEY = 0x0001;

        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, uint dwExtraInfo);
        [DllImport("user32.dll")]
        public static extern short VkKeyScan(char s);

        /*
         * Press and Release the key where key = System.Windows.Forms.Keys.somekey
         */
        public static void PressKey (Keys key)
        {
            // Presses the key  
            keybd_event((byte) key, 0, KEYEVENTF_EXTENDEDKEY | 0, 0);
            Thread.Sleep(100);
            // Releases the key  
            keybd_event((byte) key, 0, 2, 0);
        }

        /*
         * Press and Release the key where key is a char
         */
        public static void PressKey(char key)
        {
            // Presses the key  
            keybd_event((byte) VkKeyScan(key), 0, KEYEVENTF_EXTENDEDKEY | 0, 0);
            Thread.Sleep(100);
            // Releases the key  
            keybd_event((byte) VkKeyScan(key), 0, 2, 0);
        }

        public static void Press()
        {
            // Presses the key  
            keybd_event((byte)VkKeyScan('H'), 0, KEYEVENTF_EXTENDEDKEY | 0, 0);
            // Releases the key  
            keybd_event((byte)VkKeyScan('H'), 0, 2, 0);

            // Presses the key  
            keybd_event((byte)VkKeyScan('E'), 0, KEYEVENTF_EXTENDEDKEY | 0, 0);
            // Releases the key  
            keybd_event((byte)VkKeyScan('E'), 0, 2, 0);

            // Presses the key  
            keybd_event((byte)VkKeyScan('O'), 0, KEYEVENTF_EXTENDEDKEY | 0, 0);
            // Releases the key  
            keybd_event((byte)VkKeyScan('O'), 0, 2, 0);
        }
    }
}
