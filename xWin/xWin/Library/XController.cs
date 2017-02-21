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
        private System.Drawing.Rectangle screenBounds = System.Windows.Forms.Screen.PrimaryScreen.Bounds;
        private Controller controller { get; }
        private State currentControllerState { get; set; }
        private short oldLeftX;
        private short oldLeftY;
        private bool leftStickMove;

        [DllImport("User32.Dll", EntryPoint = "SetCursorPos")]
        public static extern long SetCursorPos(int x, int y);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        public XController()
        {
            controller = new SharpDX.XInput.Controller(UserIndex.One);
            currentControllerState = controller.GetState();
            leftStickMove = false;
        }

        public XController(SharpDX.XInput.Controller contoller, short deadZoneRad = 500)
        {
            this.controller = controller;
            currentControllerState = this.controller.GetState();
            leftStickMove = false;
        }

        public void UpdateSate()
        {
            currentControllerState = controller.GetState();
        }

        public Dictionary<string, bool> ButtonsPressed()
        {
            Dictionary<string, bool> currentButtons = new Dictionary<string, bool>();

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

        public void MoveCurser()
        {
            short currX = currentControllerState.Gamepad.LeftThumbX;
            short currY = currentControllerState.Gamepad.LeftThumbY;
            int xDiff = 0;
            int yDiff = 0;

            if(currX != oldLeftX || currY != oldLeftY)
            {
                if(currX > oldLeftX)
                {
                    xDiff = Math.Abs(currX - oldLeftX);
                }
                else
                {
                    xDiff = Math.Abs(oldLeftX - currX);
                    xDiff *= -1;
                }
                if(currY >= oldLeftY)
                {
                    yDiff = Math.Abs(currY - oldLeftY);
                }
                else
                {
                    yDiff = Math.Abs(oldLeftY - currY);
                    yDiff *= -1;
                }
                Win32.SetCursorPos(Cursor.Position.X + xDiff, Cursor.Position.Y + yDiff);
                //Cursor.Position = new Point(Cursor.Position.X + xDiff, Cursor.Position.Y + yDiff);
            }
        }

        public bool IsConnected()
        {
            return controller.IsConnected;
        }
    }
}
