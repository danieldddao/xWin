using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX.DirectInput;
using SharpDX.XInput;


namespace xWin.Library
{
    public class DI2XI
    {
        public enum DPAD
        {
            none = -1,
            Up = 0,
            UpRight = 1,
            Right = 2,
            DownRight = 3,
            Down = 4,
            DownLeft = 5,
            Left = 6,
            UpLeft = 7
        }

        public enum Buttons
        {
            B = 0,
            A, Y, X, LeftShoulder, RightShoulder, LeftTrigger, RightTrigger, Back, Start, LeftThumb, RightThumb
        }

        public static GamepadButtonFlags ConvertFlags(Buttons b)
        {
            try
            {
                return (GamepadButtonFlags)Enum.Parse(typeof(GamepadButtonFlags), b.ToString());
            }
            catch
            {
                return GamepadButtonFlags.None;
            }
        }

        public static State di2xi(JoystickState di_state)
        {
            short g = 0;
            var xi_state = new State();

            for (var i = 0; i < 6; i++)
            {
                g += di_state.Buttons[i] ? (short)ConvertFlags((Buttons)i) : (short)0;
            }
            for (var i = 8; i < 12; i++)
            {
                g += di_state.Buttons[i] ? (short)ConvertFlags((Buttons)i) : (short)0;
            }
            //dpad
            switch (di_state.PointOfViewControllers[0])
            {
                case 0:
                    g += (short)GamepadButtonFlags.DPadUp;
                    break;
                case 4500:
                    g += (short)GamepadButtonFlags.DPadUp + (short)GamepadButtonFlags.DPadRight;
                    break;
                case 9000:
                    g += (short)GamepadButtonFlags.DPadRight;
                    break;
                case 13500:
                    g += (short)GamepadButtonFlags.DPadDown + (short)GamepadButtonFlags.DPadRight;
                    break;
                case 18000:
                    g += (short)GamepadButtonFlags.DPadDown;
                    break;
                case 22500:
                    g += (short)GamepadButtonFlags.DPadDown + (short)GamepadButtonFlags.DPadLeft;
                    break;
                case 27000:
                    g += (short)GamepadButtonFlags.DPadLeft;
                    break;
                case 31500:
                    g += (short)GamepadButtonFlags.DPadUp + (short)GamepadButtonFlags.DPadLeft;
                    break;
                default:
                    break;
            }
            xi_state.Gamepad.Buttons = (GamepadButtonFlags)g;

            xi_state.Gamepad.LeftTrigger = di_state.Buttons[6] ? (byte)254 : (byte)0;
            xi_state.Gamepad.RightTrigger = di_state.Buttons[7] ? (byte)254 : (byte)0;

            xi_state.Gamepad.LeftThumbX = (short)di_state.X;
            xi_state.Gamepad.LeftThumbY = (short)-di_state.Y;
            xi_state.Gamepad.RightThumbX = (short)di_state.RotationX;
            xi_state.Gamepad.RightThumbY = (short)-di_state.RotationY;

            return xi_state;
        }

        public static Joystick setup_stick()
        {
            // Initialize DirectInput
            var directInput = new DirectInput();

            // Find a Joystick Guid
            var joystickGuid = Guid.Empty;

            foreach (var deviceInstance in directInput.GetDevices(SharpDX.DirectInput.DeviceType.Gamepad, DeviceEnumerationFlags.AllDevices))
                joystickGuid = deviceInstance.InstanceGuid;

            // If Gamepad not found, look for a Joystick
            if (joystickGuid == Guid.Empty)
                foreach (var deviceInstance in directInput.GetDevices(SharpDX.DirectInput.DeviceType.Joystick, DeviceEnumerationFlags.AllDevices))
                    joystickGuid = deviceInstance.InstanceGuid;

            // If Joystick not found, throws an error
            if (joystickGuid == Guid.Empty)
            {
                Log.GetLogger().Info("No joystick/Gamepad found.");
                //Console.ReadKey();
                Environment.Exit(1);
            }

            // Instantiate the joystick
            var joystick = new Joystick(directInput, joystickGuid);

            Log.GetLogger().Info("Found Joystick/Gamepad with GUID: " + joystickGuid);

            // Set BufferSize in order to use buffered data.
            joystick.Properties.BufferSize = 128;

            foreach (DeviceObjectInstance doi in joystick.GetObjects(DeviceObjectTypeFlags.Axis))
            {
                joystick.GetObjectPropertiesById(doi.ObjectId).Range = new InputRange(-32767, 32767);
            }

            // Acquire the joystick
            joystick.Acquire();
            return joystick;
        }
        
    }
}
