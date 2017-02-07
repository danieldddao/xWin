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

        public bool buttonAPressed()
        {
            State s = controller.GetState();
            return s.Gamepad.Buttons.HasFlag(GamepadButtonFlags.A);
        }

        public bool buttonBPressed()
        {
            State s = controller.GetState();
            return s.Gamepad.Buttons.HasFlag(GamepadButtonFlags.B);
        }

        public bool buttonXPressed()
        {
            State s = controller.GetState();
            return s.Gamepad.Buttons.HasFlag(GamepadButtonFlags.X);
        }

        public bool buttonYPressed()
        {
            State s = controller.GetState();
            return s.Gamepad.Buttons.HasFlag(GamepadButtonFlags.Y);
        }
    }
}
