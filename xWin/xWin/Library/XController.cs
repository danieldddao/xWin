using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SharpDX.XInput;

namespace xWin.Library
{
    public class XController
    {
        private SharpDX.XInput.Controller controller;
        private short DEADZONE_RADIUS;

        public XController()
        {
            this.controller = new SharpDX.XInput.Controller(UserIndex.One);
            this.DEADZONE_RADIUS = 500;
        }

        public XController(short deadZoneRad)
        {
            this.DEADZONE_RADIUS = deadZoneRad;
            this.controller = new SharpDX.XInput.Controller(UserIndex.One);
        }

        public XController(SharpDX.XInput.Controller c)
        {
            this.controller = c;
            this.DEADZONE_RADIUS = 500;
        }

        public XController(SharpDX.XInput.Controller c, short deadZoneRad)
        {
            this.controller = c;
            this.DEADZONE_RADIUS = deadZoneRad;
        }

        public void MoveCurser()
        {
            State s = controller.GetState();
            short currXVal = s.Gamepad.LeftThumbX;
            short currYVal = s.Gamepad.LeftThumbY;
            double currRad = Math.Sqrt(Math.Pow(currXVal, 2) + Math.Pow(currYVal, 2));

            if(currRad > this.DEADZONE_RADIUS)
            {
                int xDiff = Math.Abs(currXVal) - DEADZONE_RADIUS;
                int yDiff = Math.Abs(currYVal) - DEADZONE_RADIUS;

                Cursor.Position = new System.Drawing.Point(Cursor.Position.X+xDiff, Cursor.Position.Y+yDiff);
            }
        }

        public virtual bool IsConnected()
        {
            return controller.IsConnected;
        }

        public virtual bool IsDisconnected()
        {
            return !controller.IsConnected;
        }

        public virtual int GetLeftX()
        {
            State s = controller.GetState();
            return s.Gamepad.LeftThumbX;
        }

        public virtual int GetLeftY()
        {
            State s = controller.GetState();
            return s.Gamepad.LeftThumbY;
        }

        public virtual double GetLeftR()
        {
            State s = controller.GetState();
            return Math.Sqrt(Math.Pow(s.Gamepad.LeftThumbX, 2) + Math.Pow(s.Gamepad.LeftThumbY, 2));
        }

        public virtual double GetLeftTheta()
        {
            State s = controller.GetState();
            return Math.Atan(s.Gamepad.LeftThumbY / s.Gamepad.LeftThumbX);
        }

        public virtual short GetRightX()
        {
            State s = controller.GetState();
            return s.Gamepad.RightThumbX;
        }

        public virtual short GetRightY()
        {
            State s = controller.GetState();
            return s.Gamepad.RightThumbY;
        }

        public virtual double GetRightR()
        {
            State s = controller.GetState();
            return Math.Sqrt(Math.Pow(s.Gamepad.RightThumbX, 2) + Math.Pow(s.Gamepad.RightThumbY, 2));
        }

        public virtual double GetRightTheta()
        {
            State s = controller.GetState();
            return Math.Atan(s.Gamepad.RightThumbY / s.Gamepad.RightThumbX);
        }

        public virtual bool IsButtonAPressed()
        {
            State s = controller.GetState();
            return s.Gamepad.Buttons.HasFlag(GamepadButtonFlags.A);
        }

        public virtual bool IsButtonBPressed()
        {
            State s = controller.GetState();
            return s.Gamepad.Buttons.HasFlag(GamepadButtonFlags.B);
        }

        public virtual bool IsButtonXPressed()
        {
            State s = controller.GetState();
            return s.Gamepad.Buttons.HasFlag(GamepadButtonFlags.X);
        }

        public virtual bool IsButtonYPressed()
        {
            State s = controller.GetState();
            return s.Gamepad.Buttons.HasFlag(GamepadButtonFlags.Y);
        }

        public virtual bool IsButtonBackPressed()
        {
            State s = controller.GetState();
            return s.Gamepad.Buttons.HasFlag(GamepadButtonFlags.Back);
        }

        public virtual bool IsButtonDPadDownPressed()
        {
            State s = controller.GetState();
            return s.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadDown);
        }

        public virtual bool IsButtonDPadUpPressed()
        {
            State s = controller.GetState();
            return s.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadUp);
        }

        public virtual bool IsButtonDPadLeftPressed()
        {
            State s = controller.GetState();
            return s.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadLeft);
        }

        public virtual bool IsButtonDPadRightPressed()
        {
            State s = controller.GetState();
            return s.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadRight);
        }

        public virtual bool IsButtonLeftShoulderPressed()
        {
            State s = controller.GetState();
            return s.Gamepad.Buttons.HasFlag(GamepadButtonFlags.LeftShoulder);
        }

        public virtual bool IsButtonRightShoulderPressed()
        {
            State s = controller.GetState();
            return s.Gamepad.Buttons.HasFlag(GamepadButtonFlags.RightShoulder);
        }

        public virtual bool IsButtonLeftThumbPressed()
        {
            State s = controller.GetState();
            return s.Gamepad.Buttons.HasFlag(GamepadButtonFlags.LeftThumb);
        }

        public virtual bool IsButtonRightThumbPressed()
        {
            State s = controller.GetState();
            return s.Gamepad.Buttons.HasFlag(GamepadButtonFlags.RightThumb);
        }

        public virtual bool IsButtonStartPressed()
        {
            State s = controller.GetState();
            return s.Gamepad.Buttons.HasFlag(GamepadButtonFlags.Start);
        }
    }
}
