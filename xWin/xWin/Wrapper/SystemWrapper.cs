using System.Runtime.InteropServices;
using System.IO;
using System.Diagnostics;
using WindowsInput;
using xWin.Library;
using System;
using System.Windows.Forms;
using System.Threading;

namespace xWin.Wrapper
{
    /*
     * Wrapper of System class used for unit testing
     */
    public interface ISystemWrapper
    {
        void Press(byte key);
        void Release(byte key);
        void SimulateKeyDown(WindowsInput.Native.VirtualKeyCode key);
        void SimulateKeyUp(WindowsInput.Native.VirtualKeyCode key);
        void SimulateKeyPress(WindowsInput.Native.VirtualKeyCode key);
        void SimulateText(string text);
        short ScanKey(char c);
        bool IsFileExist(string path);
        void StartProcess(string path);
        void ThrowException();
    }

    public class SystemWrapper : ISystemWrapper
    {
        public const int KEYEVENTF_EXTENDEDKEY = 0x0001; //Key down flag
        public const int KEYEVENTF_KEYUP = 0x0002; //Key up flag

        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, uint dwExtraInfo);
        [DllImport("user32.dll")]
        public static extern short VkKeyScan(char s);
        InputSimulator inputSimulator = new InputSimulator();

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

        public void SimulateKeyDown(WindowsInput.Native.VirtualKeyCode key)
        {
            try
            {
                inputSimulator.Keyboard.KeyDown(key);
            }
            catch (Exception e)
            {
                Log.GetLogger().Error("SimulateKeyDown: " + e);
            }
        }

        public void SimulateKeyUp(WindowsInput.Native.VirtualKeyCode key)
        {
            try
            {
                inputSimulator.Keyboard.KeyUp(key);
            }
            catch (Exception e)
            {
                Log.GetLogger().Error("SimulateKeyUp: " + e);
            }
        }

        [System.Runtime.ExceptionServices.HandleProcessCorruptedStateExceptions]
        [System.Security.SecurityCritical]
        public void SimulateKeyPress(WindowsInput.Native.VirtualKeyCode key)
        {
            try
            {
                inputSimulator.Keyboard.KeyPress(key);
            }
            catch (Exception e)
            {
                Log.GetLogger().Error("SimulateKeyPress: " + e);
            }
        }

        public void SimulateText(string text)
        {
            try
            {
                inputSimulator.Keyboard.TextEntry(text);
            }
            catch (Exception e)
            {
                Log.GetLogger().Error("SimulateText: " + e);
            }
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
            try
            {
                Process.Start(path);
            }
            catch (Exception e)
            {
                Log.GetLogger().Error("StartProcess: " + e);
            }
        }

        public void ThrowException() { } // for testing exceptions
    }
}
