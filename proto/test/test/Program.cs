using System.IO;
using Google.Protobuf;
using static Configuration.Types;
using System.Windows.Forms;
using SharpDX.XInput;
namespace test
{
  class Program
  {
    static void Main(string[] args)
    {
      string file = "../../../mouse_config.dat";
      Configuration config1 = new Configuration {
          LeftStick = new Stick { Threshold = 0, ControlMouse = true },
          RightStick = new Stick { Threshold = 0, ControlMouse = false },
          LeftTrigger = new Trigger { Threshold = 0 },
          RightTrigger = new Trigger { Threshold = 0 },
          ButtonMap = { }
      };

      /*Bind Left Click to A button*/
      Behavior b = new Behavior();
      b.OnHold = new Action { Keybind = (int) Keys.LButton };
      config1.ButtonMap.Add( (int) GamepadButtonFlags.A, b);

      /*Bind Right Click to B button*/
      b = new Behavior();
      b.OnHold = new Action { Keybind = (int)Keys.RButton };
      config1.ButtonMap.Add( (int)GamepadButtonFlags.B, b);

      /*Bind Middle Click to Left Thumb*/
      b = new Behavior();
      b.OnHold = new Action { Keybind = (int)Keys.MButton };
      config1.ButtonMap.Add((int)GamepadButtonFlags.LeftThumb, b);

      /*Bind Turbo to Y*/
      b = new Behavior();
      b.OnHold = new Action { SpecialAction = SpecialAction.Turbo };
      config1.ButtonMap.Add((int)GamepadButtonFlags.Y, b);

      /*Bind Arrow Keys to D Pad*/
      b = new Behavior();
      b.OnHold = new Action { Keybind = (int)Keys.Up };
      config1.ButtonMap.Add((int)GamepadButtonFlags.DPadUp, b);
      b = new Behavior();
      b.OnHold = new Action { Keybind = (int)Keys.Down };
      config1.ButtonMap.Add((int)GamepadButtonFlags.DPadDown, b);
      b = new Behavior();
      b.OnHold = new Action { Keybind = (int)Keys.Left };
      config1.ButtonMap.Add((int)GamepadButtonFlags.DPadLeft, b);
      b = new Behavior();
      b.OnHold = new Action { Keybind = (int)Keys.Right };
      config1.ButtonMap.Add((int)GamepadButtonFlags.DPadRight, b);

      /*Bind Page Up and Page Down to Right Stick because why not?*/
      b = new Behavior();
      b.OnHold = new Action { Keybind = (int)Keys.PageUp };
      config1.RightStick.Regions.Add(new Region {Behavior = b, Range = 180});
      b = new Behavior();
      b.OnHold = new Action { Keybind = (int)Keys.PageDown };
      config1.RightStick.Regions.Add(new Region { Behavior = b, Range = 180 });
      config1.RightStick.RegionStart = 0;
      
      using (var output = File.Create( file ))
      {
          config1.WriteTo(output);
      }
      Configuration config_in;
      using (Stream input = File.OpenRead(file))
      {
          config_in = Configuration.Parser.ParseFrom(input);
      }
      /*
      Console.WriteLine(config_in.InvertLRMouse);
      Console.WriteLine(config_in.InvertUDMouse);
      Console.WriteLine(config_in.LeftClick);
      Console.WriteLine(config_in.RightClick);
      Console.WriteLine(config_in.Sensitivity);
      */
    }
  }
}
