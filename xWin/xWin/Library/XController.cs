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

        public void ButtonsPressed()
        {
            //currentControllerState.Gamepad.Buttons.
            //GamepadButtonFlags.
        }
    }
}
