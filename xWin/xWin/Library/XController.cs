using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using SharpDX.XInput;
using xWin.Wrapper;


namespace xWin.Library
{
    public class XController
    {
        private readonly IXControllerWrapper controllerWrapper;
        private Controller controller;
        private State currentControllerState { get; set; }
        private short deadZoneRad { get; set; }
        private const short MAX_INPUT = 32767;
        private System.Drawing.Rectangle screenBounds = System.Windows.Forms.Screen.PrimaryScreen.Bounds;

        [DllImport("User32.Dll", EntryPoint = "SetCursorPos")]
        public static extern long SetCursorPos(int x, int y);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);
        
        public XController(IXControllerWrapper iXController)
        {
            this.controllerWrapper = iXController;
        }

        public XController(short deadZoneRad = 7000)
        {
            this.controller = new SharpDX.XInput.Controller(UserIndex.One);
            try
            {
                currentControllerState = controller.GetState();
            }
            catch
            {
                ;
            }
            this.deadZoneRad = deadZoneRad;
            controllerWrapper = new XControllerWrapper(this.controller);
        }

        public XController(SharpDX.XInput.Controller contoller, short deadZoneRad = 7000)
        {
            this.controller = controller;
            currentControllerState = this.controller.GetState();
            this.deadZoneRad = deadZoneRad;
        }

        public void UpdateState()
        {
            
            try
            {
                currentControllerState = controller.GetState();
                currentControllerState = controllerWrapper.UpdateState();
            }
            catch
            {
                ;
            }
        }

        public Dictionary<string,bool> ButtonsPressed()
        {
            return controllerWrapper.ButtonsPressed();
        }

        public Dictionary<string, short> GetLeftCart()
        {
            return controllerWrapper.GetLeftCart();
        }

        public Dictionary<string, double> GetLeftPolar()
        {
            return controllerWrapper.GetLeftPolar();
        }

        public Dictionary<string, short> GetRightCart()
        {
            return controllerWrapper.GetRightCart();
        }

        public Dictionary<string, double> GetRightPolar()
        {
            return controllerWrapper.GetRightPolar();
        }

        public short GetLeftTrigger()
        {
            return controllerWrapper.GetLeftTrigger();
        }

        public short GetRightTrigger()
        {
            return controllerWrapper.GetRightTrigger();
        }

        public bool MoveCursor()
        {
            try
            {
                controllerWrapper.MoveCursor();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool IsConnected()
        {
            try
            {
                controllerWrapper.IsConnected();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool LeftUp()
        {
            try
            {
                controllerWrapper.LeftUp();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool LeftDown()
        {
            try
            {
                controllerWrapper.LeftDown();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool LeftClick()
        {
            try
            {
                controllerWrapper.LeftClick();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool RightUp()
        {
            try
            {
                controllerWrapper.RightUp();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool RightDown()
        {
            try
            {
                controllerWrapper.RightDown();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool RightClick()
        {
            try
            {
                controllerWrapper.RightClick();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
