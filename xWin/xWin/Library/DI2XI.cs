using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX.DirectInput;
using SharpDX.XInput;


namespace xWin.Library
{
  class DI2XI
  {
    enum DPAD
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

    enum Buttons
    {
      B = 0,
      A, Y, X, LeftShoulder, RightShoulder, LeftTrigger, RightTrigger, Back, Start, LeftThumb, RightThumb, home, snap
    }
    
    static GamepadButtonFlags cv(Buttons b)
    {
      try {
        return (GamepadButtonFlags)Enum.Parse(typeof(GamepadButtonFlags), b.ToString());
      }
      catch {
        return GamepadButtonFlags.None;
      }
    }

    public static State di2xi(JoystickState di_state)
    {
      short g = 0;
      var xi_state = new State();

      for(var i = 0; i < 12; i++)
      {
        g += di_state.Buttons[i] ? (short)cv((Buttons)i) : (short)0;
      }
      //dpad
      switch(di_state.PointOfViewControllers[0])
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

      xi_state.Gamepad.LeftTrigger = di_state.Buttons[10] ? (byte)255 : (byte)0;
      xi_state.Gamepad.RightTrigger = di_state.Buttons[11] ? (byte)255 : (byte)0;

      xi_state.Gamepad.LeftThumbX = (short)di_state.X;
      xi_state.Gamepad.LeftThumbY = (short)di_state.Y;
      xi_state.Gamepad.RightThumbX = (short)di_state.RotationX;
      xi_state.Gamepad.RightThumbY = (short)di_state.RotationY;

      return xi_state;
    }
  }
}
