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
    public interface IXController
    {
        bool IsConnected();
        bool IsPreviouslyConnected { get; set; }
        IXKeyBoard GetKeyBoardForButton(GamepadButtonFlags button);
        List<GamepadButtonFlags> GetCurrentlyPressedButtons();
    }

    public class XController : IXController
    {
        private readonly IControllerWrapper controllerWrapper;

        private short deadZoneRad { get; set; }
        private const short MAX_INPUT = 32767;
        private System.Drawing.Rectangle screenBounds = System.Windows.Forms.Screen.PrimaryScreen.Bounds;
        private Dictionary<GamepadButtonFlags, XKeyBoard> singleButtonMaps;
        public bool IsPreviouslyConnected { get; set; } = false;

        [DllImport("user32.dll", EntryPoint = "SetCursorPos")]
        public static extern long SetCursorPos(int x, int y);
        [DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);
        
        public XController(IControllerWrapper iController)
        {
            this.controllerWrapper = iController;
            if (controllerWrapper.IsConnected())
            {
                controllerWrapper.UpdateState();
            }
            InitializeButtonMaps();
        }

        public XController(short deadZoneRad = 7000)
        {
            this.deadZoneRad = deadZoneRad;
            controllerWrapper = new ControllerWrapper(new SharpDX.XInput.Controller(UserIndex.One));
            if (controllerWrapper.IsConnected())
            {
                controllerWrapper.UpdateState();
            }
            InitializeButtonMaps();
        }

        public XController(SharpDX.XInput.Controller controller, short deadZoneRad = 7000)
        {
            controllerWrapper = new ControllerWrapper(controller);
            if (controllerWrapper.IsConnected())
            {
                controllerWrapper.UpdateState();
            }
            this.deadZoneRad = deadZoneRad;
            InitializeButtonMaps();
        }

        private void InitializeButtonMaps()
        {
            this.singleButtonMaps = new Dictionary<GamepadButtonFlags, XKeyBoard>();
            foreach (GamepadButtonFlags b in Enum.GetValues(typeof(GamepadButtonFlags)))
            {
                this.singleButtonMaps.Add(b, new XKeyBoard());
                Log.GetLogger().Debug("Initialized ButtonMaps's button: " + b);
            }
            Log.GetLogger().Debug("Initialized All ButtonMaps");
        }

        public void UpdateState()
        {
            controllerWrapper.UpdateState();
            Log.GetLogger().Debug("Updated Controller State");
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

            currentButtons.Add("A", controllerWrapper.IsButtonPressed(GamepadButtonFlags.A));
            currentButtons.Add("B", controllerWrapper.IsButtonPressed(GamepadButtonFlags.B));
            currentButtons.Add("X", controllerWrapper.IsButtonPressed(GamepadButtonFlags.X));
            currentButtons.Add("Y", controllerWrapper.IsButtonPressed(GamepadButtonFlags.Y));
            currentButtons.Add("START", controllerWrapper.IsButtonPressed(GamepadButtonFlags.Start));
            currentButtons.Add("BACK", controllerWrapper.IsButtonPressed(GamepadButtonFlags.Back));
            currentButtons.Add("LEFT_S", controllerWrapper.IsButtonPressed(GamepadButtonFlags.LeftShoulder));
            currentButtons.Add("RIGHT_S", controllerWrapper.IsButtonPressed(GamepadButtonFlags.RightShoulder));
            currentButtons.Add("LEFT_T", controllerWrapper.IsButtonPressed(GamepadButtonFlags.LeftThumb));
            currentButtons.Add("RIGHT_T", controllerWrapper.IsButtonPressed(GamepadButtonFlags.RightThumb));
            currentButtons.Add("DPAD_UP", controllerWrapper.IsButtonPressed(GamepadButtonFlags.DPadUp));
            currentButtons.Add("DPAD_RIGHT", controllerWrapper.IsButtonPressed(GamepadButtonFlags.DPadRight));
            currentButtons.Add("DPAD_LEFT", controllerWrapper.IsButtonPressed(GamepadButtonFlags.DPadLeft));
            currentButtons.Add("DPAD_DOWN", controllerWrapper.IsButtonPressed(GamepadButtonFlags.DPadDown));
            currentButtons.Add("NONE", controllerWrapper.IsButtonPressed(GamepadButtonFlags.None));

            return currentButtons;
        }

        public Dictionary<string, short> GetLeftCart()
        {
            Dictionary<string, short> thumbLoc = new Dictionary<string, short>();

            thumbLoc.Add("X", controllerWrapper.GetState().Gamepad.LeftThumbX);
            thumbLoc.Add("Y", controllerWrapper.GetState().Gamepad.LeftThumbY);

            return thumbLoc;
        }

        public Dictionary<string, double> GetLeftPolar()
        {
            Dictionary<string, double> thumbLoc = new Dictionary<string, double>();
            short x = controllerWrapper.GetState().Gamepad.LeftThumbX;
            short y = controllerWrapper.GetState().Gamepad.LeftThumbY;

            double r = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
            double theta = Math.Atan(y / x);
            thumbLoc.Add("R", r);
            thumbLoc.Add("THETA", theta);

            return thumbLoc;
        }

        public Dictionary<string, short> GetRightCart()
        {
            Dictionary<string, short> thumbLoc = new Dictionary<string, short>();

            thumbLoc.Add("X", controllerWrapper.GetState().Gamepad.RightThumbX);
            thumbLoc.Add("Y", controllerWrapper.GetState().Gamepad.RightThumbY);

            return thumbLoc;
        }

        public Dictionary<string, double> GetRightPolar()
        {
            Dictionary<string, double> thumbLoc = new Dictionary<string, double>();
            short x = controllerWrapper.GetState().Gamepad.RightThumbX;
            short y = controllerWrapper.GetState().Gamepad.RightThumbY;

            double r = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
            double theta = Math.Atan(y / x);
            thumbLoc.Add("R", r);
            thumbLoc.Add("THETA", theta);
            
            return thumbLoc;
        }

        public short GetLeftTrigger()
        {
            return controllerWrapper.GetState().Gamepad.LeftTrigger;
        }

        public short GetRightTrigger()
        {
            return controllerWrapper.GetState().Gamepad.RightTrigger;
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

        /* Get XKeyboard corresponding to button */
        public IXKeyBoard GetKeyBoardForButton(GamepadButtonFlags button)
        {
            try
            {
                if (singleButtonMaps.ContainsKey(button))
                {
                    XKeyBoard xKeyboard = singleButtonMaps[button];
                    Log.GetLogger().Debug("Sucessfully got XKeyboard for button" + button);
                    return xKeyboard;
                }
                else
                { return null; }
            } catch (Exception e)
            {
                Log.GetLogger().Error("Error when getting keyboard for button " + button, e);
                return null;
            }

        }

        /* Get all currently pressed buttons */
        public List<GamepadButtonFlags> GetCurrentlyPressedButtons()
        {
            List<GamepadButtonFlags> pressedButtons = new List<GamepadButtonFlags>();
            try
            {
                UpdateState(); // update state before checking

                // Check each button and add button to the list if it's currently pressed
                foreach (GamepadButtonFlags button in Enum.GetValues(typeof(GamepadButtonFlags)))
                {
                    if (button != GamepadButtonFlags.None && controllerWrapper.IsButtonPressed(button))
                    {
                        pressedButtons.Add(button);
                        Log.GetLogger().Debug("button " + button + " is pressed");
                    }
                }
                Log.GetLogger().Debug("pressedButtons " + pressedButtons);
                return pressedButtons;
            }
            catch (Exception e)
            {
                Log.GetLogger().Error(e);
                return pressedButtons;
            }
            
        }

    } // end class
}
