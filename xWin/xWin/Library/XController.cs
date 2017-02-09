using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX.XInput;

namespace xWin.Library
{
	class XController
	{
        Controller controller;

        internal XController(Controller c)
        {
            this.controller = c;
        }

        public bool isConnected()
        {
            return controller.IsConnected;
        }

        public bool isButtonAPressed()
        {
            State s = controller.GetState();
            return s.Gamepad.Buttons.HasFlag(GamepadButtonFlags.A);
        }

        public bool isButtonBPressed()
        {
            State s = controller.GetState();
            return s.Gamepad.Buttons.HasFlag(GamepadButtonFlags.B);
        }

        public bool isButtonXPressed()
        {
            State s = controller.GetState();
            return s.Gamepad.Buttons.HasFlag(GamepadButtonFlags.X);
        }

        public bool isButtonYPressed()
        {
            State s = controller.GetState();
            return s.Gamepad.Buttons.HasFlag(GamepadButtonFlags.Y);
        }

        public bool isButtonBackPressed()
        {
            State s = controller.GetState();
            return s.Gamepad.Buttons.HasFlag(GamepadButtonFlags.Back);
        }

        public bool isButtonDPadDownPressed()
        {
            State s = controller.GetState();
            return s.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadDown);
        }

        public bool isButtonDPadUpPressed()
        {
            State s = controller.GetState();
            return s.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadUp);
        }

        public bool isButtonDPadLeftPressed()
        {
            State s = controller.GetState();
            return s.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadLeft);
        }

        public bool isButtonDPadRightPressed()
        {
            State s = controller.GetState();
            return s.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadRight);
        }

        public bool isButtonLeftShoulderPressed()
        {
            State s = controller.GetState();
            return s.Gamepad.Buttons.HasFlag(GamepadButtonFlags.LeftShoulder);
        }

        public bool isButtonRightShoulderPressed()
        {
            State s = controller.GetState();
            return s.Gamepad.Buttons.HasFlag(GamepadButtonFlags.RightShoulder);
        }

        public bool isButtonLeftThumbPressed()
        {
            State s = controller.GetState();
            return s.Gamepad.Buttons.HasFlag(GamepadButtonFlags.LeftThumb);
        }

        public bool isButtonRightThumbPressed()
        {
            State s = controller.GetState();
            return s.Gamepad.Buttons.HasFlag(GamepadButtonFlags.RightThumb);
        }

        public bool isButtonStartPressed()
        {
            State s = controller.GetState();
            return s.Gamepad.Buttons.HasFlag(GamepadButtonFlags.Start);
        }
    }
}
