﻿using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using SharpDX.XInput;

namespace xWin.Library
{
    public class XController
    {
        private SharpDX.XInput.Controller controller;

        public XController()
        {
            this.controller = new SharpDX.XInput.Controller(UserIndex.Any);
        }

        public XController(SharpDX.XInput.Controller c)
        {
            this.controller = c;
        }

        public virtual bool IsConnected()
        {
            return controller.IsConnected;
        }

        public virtual bool IsDisconnected()
        {
            return !controller.IsConnected;
        }

        public virtual short GetLeftStickXValue()
        {
            State s = controller.GetState();
            return s.Gamepad.LeftThumbX;
        }

        public virtual short GetLeftStckYValue()
        {
            State s = controller.GetState();
            return s.Gamepad.LeftThumbY;
        }

        public virtual double GetLeftRValue()
        {
            State s = controller.GetState();
            return Math.Sqrt(Math.Pow(s.Gamepad.LeftThumbX, 2) + Math.Pow(s.Gamepad.LeftThumbY, 2));
        }

        public virtual double GetLeftThetaValue()
        {
            State s = controller.GetState();
            return Math.Atan(s.Gamepad.LeftThumbY / s.Gamepad.LeftThumbX);
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
