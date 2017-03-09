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
        private readonly IControllerWrapper controllerWrapper;

        private State currentControllerState { get; set; }
        private short deadZoneRad { get; set; }
        private const short MAX_INPUT = 32767;
        private System.Drawing.Rectangle screenBounds = System.Windows.Forms.Screen.PrimaryScreen.Bounds;

        [DllImport("user32.dll", EntryPoint = "SetCursorPos")]
        public static extern long SetCursorPos(int x, int y);

        [DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);
        
        public XController(IControllerWrapper iController)
        {
            this.controllerWrapper = iController;
        }

        public XController(short deadZoneRad = 7000)
        {
            this.deadZoneRad = deadZoneRad;
            controllerWrapper = new ControllerWrapper(new SharpDX.XInput.Controller(UserIndex.One));
            if (controllerWrapper.IsConnected())
            {
                currentControllerState = controllerWrapper.GetState();
            }
        }

        public XController(SharpDX.XInput.Controller controller, short deadZoneRad = 7000)
        {
            controllerWrapper = new ControllerWrapper(controller);
            if (controllerWrapper.IsConnected())
            {
                currentControllerState = controllerWrapper.GetState();
            }
            this.deadZoneRad = deadZoneRad;
        }

        public void UpdateState()
        {
            try
            {
                currentControllerState = controllerWrapper.GetState();
            }
            catch (Exception e)
            {
                Console.WriteLine("{0}", e);
            }
        }

        public Dictionary<string,bool> ButtonsPressed()
        {
            Dictionary<string,bool> currentButtons = new Dictionary<string,bool>();
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

        public bool MoveCursor()
        {
            try
            {
                controllerWrapper.MoveCursor(10,7000);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void MoveCursorTest()
        {
            controllerWrapper.MoveCursor(1,10, 7000);
        }

        public bool IsConnected()
        {
            return controllerWrapper.IsConnected();
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
