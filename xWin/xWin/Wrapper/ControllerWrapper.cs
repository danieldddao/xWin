using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX.XInput;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;

namespace xWin.Wrapper
{
    public interface IControllerWrapper
    {
        bool IsConnected();
        State GetState();
        void UpdateState();
        void LeftClick();
        void LeftDown();
        void LeftUp();
        void RightClick();
        void RightDown();
        void RightUp();
        void MoveCursor(int dpi, int deadZoneRad);
        void MoveCursor(int flag,int deadZoneRad,int dpi);
        bool IsButtonPressed(GamepadButtonFlags button);
        void MouseWheel(int WHEEL_DATA);
    }

    public class ControllerWrapper : IControllerWrapper
    {
        Controller controller;
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
        private const int MOUSEEVENTF_WHEEL = 0x0800;

        public ControllerWrapper(Controller controller)
        {
            this.controller = controller;
            if (controller.IsConnected)
            {
                currentControllerState = controller.GetState();
            }
        }

        public virtual bool IsConnected()
        {
            return controller.IsConnected;
        }

        public State GetState()
        {
            return currentControllerState;
        }

        public void UpdateState()
        {
            try
            {
                if (controller.IsConnected)
                {
                    currentControllerState = controller.GetState();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("{0}", e);
            }
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

        public virtual void MouseWheel(int WHEEL_DATA)
        {
            mouse_event(MOUSEEVENTF_WHEEL, System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y, WHEEL_DATA, 0);
        }

        public virtual void MoveCursor(int dpi = 10, int deadZoneRad = 7000)
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
        }

        public virtual void MoveCursor(int flag, int dpi = 10, int deadZoneRad = 7000)
        {
            const short MAX_INPUT = 32767;
            currentControllerState.Gamepad.LeftThumbX = MAX_INPUT;
            currentControllerState.Gamepad.LeftThumbX = MAX_INPUT;
            int currX = currentControllerState.Gamepad.LeftThumbX;
            int currY = currentControllerState.Gamepad.LeftThumbY;
            float xDiff = 0;
            float yDiff = 0;
            currentControllerState.Gamepad.LeftThumbX = 1;
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
        }

        public bool IsButtonPressed(GamepadButtonFlags button)
        {
            return currentControllerState.Gamepad.Buttons.HasFlag(button);
        }
    }
}
