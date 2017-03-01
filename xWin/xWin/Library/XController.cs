using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using SharpDX.XInput;

namespace xWin.Library
{
    public class XController
    {
        private Controller controller { get; }
        private State currentControllerState { get; set; }
        private short deadZoneRad { get; set; }
        private const short MAX_INPUT = 32767;
        private System.Drawing.Rectangle screenBounds = System.Windows.Forms.Screen.PrimaryScreen.Bounds;

        [DllImport("User32.Dll", EntryPoint = "SetCursorPos")]
        public static extern long SetCursorPos(int x, int y);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        public XController(short deadZoneRad = 7000)
        {
            controller = new SharpDX.XInput.Controller(UserIndex.One);
            try
            {
                currentControllerState = controller.GetState();
            }
            catch
            {
                ;
            }
            this.deadZoneRad = deadZoneRad;
        }

        public XController(SharpDX.XInput.Controller contoller, short deadZoneRad = 4000)
        {
            this.controller = controller;
            currentControllerState = this.controller.GetState();
            this.deadZoneRad = deadZoneRad;
        }

        public void UpdateSate()
        {
            currentControllerState = controller.GetState();
        }

        public Dictionary<string,bool> ButtonsPressed()
        {
            Dictionary<string,bool> currentButtons = new Dictionary<string,bool>();
            /*
            if(currentControllerState.Gamepad.Buttons.HasFlag(GamepadButtonFlags.A))
            {
                currentButtons.Add(Buttons.A);
            }
            if (currentControllerState.Gamepad.Buttons.HasFlag(GamepadButtonFlags.B)) { currentButtons.Add(Buttons.B); }
            if (currentControllerState.Gamepad.Buttons.HasFlag(GamepadButtonFlags.X)) { currentButtons.Add(Buttons.X); }
            if (currentControllerState.Gamepad.Buttons.HasFlag(GamepadButtonFlags.Y)) { currentButtons.Add(Buttons.Y); }
            if (currentControllerState.Gamepad.Buttons.HasFlag(GamepadButtonFlags.Start)) { currentButtons.Add(Buttons.START); }
            if (currentControllerState.Gamepad.Buttons.HasFlag(GamepadButtonFlags.Back)) { currentButtons.Add(Buttons.START); }
            if (currentControllerState.Gamepad.Buttons.HasFlag(GamepadButtonFlags.LeftShoulder)) { currentButtons.Add(Buttons.LEFT_BUMPER); }
            if (currentControllerState.Gamepad.Buttons.HasFlag(GamepadButtonFlags.RightShoulder)) { currentButtons.Add(Buttons.RIGHT_BUMPER); }
            if (currentControllerState.Gamepad.Buttons.HasFlag(GamepadButtonFlags.LeftThumb)) { currentButtons.Add(Buttons.LEFT_STICK); }
            if (currentControllerState.Gamepad.Buttons.HasFlag(GamepadButtonFlags.RightThumb)) { currentButtons.Add(Buttons.RIGHT_STICK); }
            if (currentControllerState.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadUp)) { currentButtons.Add(Buttons.DPAD_UP); }
            if (currentControllerState.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadRight)) { currentButtons.Add(Buttons.DPAD_RIGHT); }
            if (currentControllerState.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadLeft)) { currentButtons.Add(Buttons.DPAD_LEFT); }
            if (currentControllerState.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadDown)) { currentButtons.Add(Buttons.DPAD_DOWN); }
            if (currentControllerState.Gamepad.Buttons.HasFlag(GamepadButtonFlags.None)) { currentButtons.Add(Buttons.NONE); }
            */

            currentButtons.Add("A", currentControllerState.Gamepad.Buttons.HasFlag(GamepadButtonFlags.A));
            currentButtons.Add("B", currentControllerState.Gamepad.Buttons.HasFlag(GamepadButtonFlags.B));
            currentButtons.Add("X", currentControllerState.Gamepad.Buttons.HasFlag(GamepadButtonFlags.X));
            currentButtons.Add("Y", currentControllerState.Gamepad.Buttons.HasFlag(GamepadButtonFlags.Y));
            currentButtons.Add("START", currentControllerState.Gamepad.Buttons.HasFlag(GamepadButtonFlags.Start));
            currentButtons.Add("BACK", currentControllerState.Gamepad.Buttons.HasFlag(GamepadButtonFlags.Back));
            currentButtons.Add("LEFT_S", currentControllerState.Gamepad.Buttons.HasFlag(GamepadButtonFlags.LeftShoulder));
            currentButtons.Add("RIGHT_S", currentControllerState.Gamepad.Buttons.HasFlag(GamepadButtonFlags.RightShoulder));
            currentButtons.Add("LEFT_T", currentControllerState.Gamepad.Buttons.HasFlag(GamepadButtonFlags.LeftThumb));
            currentButtons.Add("RIGHT_T", currentControllerState.Gamepad.Buttons.HasFlag(GamepadButtonFlags.RightThumb));
            currentButtons.Add("DPAD_UP", currentControllerState.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadUp));
            currentButtons.Add("DPAD_RIGHT", currentControllerState.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadRight));
            currentButtons.Add("DPAD_LEFT", currentControllerState.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadLeft));
            currentButtons.Add("DPAD_DOWN", currentControllerState.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadDown));
            currentButtons.Add("NONE", currentControllerState.Gamepad.Buttons.HasFlag(GamepadButtonFlags.None));

            return currentButtons;
        }

        public Dictionary<string, short> GetLeftCart()
        {
            Dictionary<string, short> thumbLoc = new Dictionary<string, short>();

            thumbLoc.Add("X", currentControllerState.Gamepad.LeftThumbX);
            thumbLoc.Add("Y", currentControllerState.Gamepad.LeftThumbY);

            return thumbLoc;
        }

        public Dictionary<string, double> GetLeftPolar()
        {
            Dictionary<string, double> thumbLoc = new Dictionary<string, double>();
            short x = currentControllerState.Gamepad.LeftThumbX;
            short y = currentControllerState.Gamepad.LeftThumbY;

            double r = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
            double theta = Math.Atan(y / x);
            thumbLoc.Add("R", r);
            thumbLoc.Add("THETA", theta);

            return thumbLoc;
        }

        public Dictionary<string, short> GetRightCart()
        {
            Dictionary<string, short> thumbLoc = new Dictionary<string, short>();

            thumbLoc.Add("X", currentControllerState.Gamepad.RightThumbX);
            thumbLoc.Add("Y", currentControllerState.Gamepad.RightThumbY);

            return thumbLoc;
        }

        public Dictionary<string, double> GetRightPolar()
        {
            Dictionary<string, double> thumbLoc = new Dictionary<string, double>();
            short x = currentControllerState.Gamepad.RightThumbX;
            short y = currentControllerState.Gamepad.RightThumbY;

            double r = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
            double theta = Math.Atan(y / x);
            thumbLoc.Add("R", r);
            thumbLoc.Add("THETA", theta);
            
            return thumbLoc;
        }

        public short GetLeftTrigger()
        {
            return currentControllerState.Gamepad.LeftTrigger;
        }

        public short GetRightTrigger()
        {
            return currentControllerState.Gamepad.RightTrigger;
        }

        public void MoveCurser()
        {
            int currX = currentControllerState.Gamepad.LeftThumbX;
            int currY = currentControllerState.Gamepad.LeftThumbY;
            float xDiff = 0;
            float yDiff = 0;
            int dpi = 10;
            
            if(Math.Abs(currX) > deadZoneRad)
            {
                xDiff = currX;
                xDiff /= MAX_INPUT;
                xDiff *= dpi;
                
                Cursor.Position = new Point(Cursor.Position.X + (short)Math.Floor(xDiff), Cursor.Position.Y);
            }
            if(Math.Abs(currY) > deadZoneRad)
            {
                yDiff = currY;
                yDiff /= MAX_INPUT;
                yDiff *= dpi;
                yDiff *= -1;
                
                Cursor.Position = new Point(Cursor.Position.X, Cursor.Position.Y + (short)Math.Floor(yDiff));
            }
        }

        public bool IsConnected()
        {
            return controller.IsConnected;
        }
        
        private const int MOUSEEVENTF_MOVE = 0x0001;
        private const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const int MOUSEEVENTF_LEFTUP = 0x0004;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
        private const int MOUSEEVENTF_RIGHTUP = 0x0010;
        private const int MOUSEEVENTF_MIDDLEDOWN = 0x0020;
        private const int MOUSEEVENTF_MIDDLEUP = 0x0040;
        private const int MOUSEEVENTF_ABSOLUTE = 0x8000;
        
        public static void LeftClick()
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN, System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y, 0, 0);
        }

        public static void LeftDown()
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN, System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y, 0, 0);
        }

        public static void LeftUp()
        {
            mouse_event(MOUSEEVENTF_LEFTUP, System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y, 0, 0);
        }

        public static void RightClick()
        {
            mouse_event(MOUSEEVENTF_RIGHTDOWN, System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y, 0, 0);
            mouse_event(MOUSEEVENTF_RIGHTUP, System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y, 0, 0);
        }

        public static void RightDown()
        {
            mouse_event(MOUSEEVENTF_RIGHTDOWN, System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y, 0, 0);
        }

        public static void RightUp()
        {
            mouse_event(MOUSEEVENTF_RIGHTUP, System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y, 0, 0);
        }
    }
}
