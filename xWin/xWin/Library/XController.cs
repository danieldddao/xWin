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
        private short deadZoneRad { get; set; }
        private Controller controller { get; }
        private State currentControllerState { get; set; }

        [DllImport("User32.Dll", EntryPoint = "SetCursorPos")]
        public static extern long SetCursorPos(int x, int y);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        public XController(short deadZoneRad = 500)
        {
            controller = new SharpDX.XInput.Controller();
            this.deadZoneRad = deadZoneRad;
            currentControllerState = controller.GetState();
        }

        public XController(SharpDX.XInput.Controller contoller, short deadZoneRad = 500)
        {
            this.controller = controller;
            this.deadZoneRad = deadZoneRad;
            currentControllerState = this.controller.GetState();
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

        public bool IsConnected()
        {
            return controller.IsConnected;
        }
    }
}
