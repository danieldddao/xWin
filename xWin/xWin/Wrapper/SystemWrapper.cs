using System.Runtime.InteropServices;
using System.IO;
using System.Diagnostics;

namespace xWin.Wrapper
{
    /*
     * Wrapper of System class used for unit testing
     */
    public interface ISystemWrapper
    {
        void Press(byte key);
        void Release(byte key);
        short ScanKey(char c);
        bool IsFileExist(string path);
        void StartProcess(string path);
    }

    public class SystemWrapper : ISystemWrapper
    {
        public const int KEYEVENTF_EXTENDEDKEY = 0x0001; //Key down flag
        public const int KEYEVENTF_KEYUP = 0x0002; //Key up flag

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
            keybd_event(key, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
        }

        public short ScanKey(char c)
        {
            return VkKeyScan(c);
        }

        public bool IsFileExist(string path)
        {
            return File.Exists(path);
        }

        public void StartProcess(string path)
        {
            Process.Start(path);
        }

    }
}
