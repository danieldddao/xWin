using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using SharpDX.XInput;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;

namespace xWin.Wrapper
{
    public interface IXControllerWrapper
    {
        bool IsConnected();
        void LeftClick();
        void LeftDown();
        void LeftUp();
        void RightClick();
        void RightDown();
        void RightUp();
        void MoveCursor(int dpi = 10, int deadZoneRad = 7000);
        State UpdateState();
        Dictionary<string, bool> ButtonsPressed();
        Dictionary<string, short> GetLeftCart();
        Dictionary<string, double> GetLeftPolar();
        Dictionary<string, short> GetRightCart();
        Dictionary<string, double> GetRightPolar();
        short GetLeftTrigger();
        short GetRightTrigger();
    }

    public class XControllerWrapper : IXControllerWrapper
    {
        private Controller controller;
        private State currentControllerState;
        [DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);
        private const int MOUSEEVENTF_MOVE = 0x0001;
        private const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const int MOUSEEVENTF_LEFTUP = 0x0004;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
        private const int MOUSEEVENTF_RIGHTUP = 0x0010;
        private const int MOUSEEVENTF_MIDDLEDOWN = 0x0020;
        private const int MOUSEEVENTF_MIDDLEUP = 0x0040;
        private const int MOUSEEVENTF_ABSOLUTE = 0x8000;

        public XControllerWrapper(Controller c)
        {
            this.controller = c;
        }

        public virtual bool IsConnected()
        {
            return controller.IsConnected;
        }

        public virtual void LeftClick()
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN, System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y, 0, 0);
        }

        public virtual void LeftDown()
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN, System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y, 0, 0);
        }

        public virtual void LeftUp()
        {
            mouse_event(MOUSEEVENTF_LEFTUP, System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y, 0, 0);
        }

        public virtual void RightClick()
        {
            mouse_event(MOUSEEVENTF_RIGHTDOWN, System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y, 0, 0);
            mouse_event(MOUSEEVENTF_RIGHTUP, System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y, 0, 0);
        }

        public virtual void RightDown()
        {
            mouse_event(MOUSEEVENTF_RIGHTDOWN, System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y, 0, 0);
        }

        public virtual void RightUp()
        {
            mouse_event(MOUSEEVENTF_RIGHTUP, System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y, 0, 0);
        }

        public virtual void MoveCursor(int dpi = 5, int deadZoneRad = 7000)
        {
            const short MAX_INPUT = 32767;
            int currX = currentControllerState.Gamepad.LeftThumbX;
            int currY = currentControllerState.Gamepad.LeftThumbY;
            float xDiff = 0;
            float yDiff = 0;
            if (Math.Abs(currX) > deadZoneRad)
            {
                xDiff = currX;
                xDiff /= MAX_INPUT;
                xDiff *= dpi;
                Cursor.Position = new Point(Cursor.Position.X + (short)Math.Floor(xDiff), Cursor.Position.Y);
            }
            if (Math.Abs(currY) > deadZoneRad)
            {
                yDiff = currY;
                yDiff /= MAX_INPUT;
                yDiff *= dpi;
                yDiff *= -1;

                Cursor.Position = new Point(Cursor.Position.X, Cursor.Position.Y + (short)Math.Floor(yDiff));
            }
            Thread.Sleep(1*dpi);
        }
        public virtual State UpdateState()
        {
            this.currentControllerState = controller.GetState();
            return controller.GetState();
        }

        public Dictionary<string, bool> ButtonsPressed()
        {
            Dictionary<string, bool> currentButtons = new Dictionary<string, bool>();
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
    }
}
