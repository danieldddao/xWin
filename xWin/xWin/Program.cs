using System;
using System.Threading;
using System.Windows.Forms;
using SharpDX.XInput;
using xWin.Library;
using static Configuration.Types;
using SharpDX.DirectInput;
namespace xWin
{
	class Program
	{
        static void Main(string[] args)
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
                Console.WriteLine("No joystick/Gamepad found.");
                Console.ReadKey();
                Environment.Exit(1);
            }

            // Instantiate the joystick
            var joystick = new Joystick(directInput, joystickGuid);

            Console.WriteLine("Found Joystick/Gamepad with GUID: {0}", joystickGuid);

            // Set BufferSize in order to use buffered data.
            joystick.Properties.BufferSize = 128;

            foreach (DeviceObjectInstance doi in joystick.GetObjects(DeviceObjectTypeFlags.Axis))
            {
                joystick.GetObjectPropertiesById(doi.ObjectId).Range = new InputRange(-32767, 32767);
            }

            // Acquire the joystick
            joystick.Acquire();
            // Poll events from joystick
            while (true)
            {
                joystick.Poll();
                var datas = joystick.GetCurrentState();
                var state = DI2XI.di2xi(datas);
                foreach (GamepadButtonFlags b in Enum.GetValues(typeof(GamepadButtonFlags)))
                {
                    if (state.Gamepad.Buttons.HasFlag(b))
                    {
                        Console.Write(b);
                        Console.Write(",");
                    }
                }

                if (state.Gamepad.LeftTrigger > 0)
                    Console.Write("LeftTrigger,");
                if (state.Gamepad.RightTrigger > 0)
                    Console.Write("RightTrigger,");

                
                var ps = new PolarStick(state.Gamepad.LeftThumbX, state.Gamepad.LeftThumbY, 1000);
                Console.WriteLine("");
                Console.WriteLine("Left Stick:");
                Console.Write("Direction: ");
                Console.WriteLine(ps.theta);
                Console.Write("Distance: ");
                Console.WriteLine(ps.R);


                ps = new PolarStick(state.Gamepad.RightThumbX, state.Gamepad.RightThumbY, 1000);
                Console.WriteLine("");
                Console.WriteLine("Right Stick:");
                Console.Write("Direction: ");
                Console.WriteLine(ps.theta);
                Console.Write("Distance: ");
                Console.WriteLine(ps.R);
                //*/
                /*
                for (int i = 0; i < datas.Buttons.GetLength(0); ++i)
                {
                  if (datas.Buttons[i])
                  {
                    Console.Write((Buttons)i);
                    Console.Write(",");
                  }
                }
                Console.WriteLine("");
                Console.Write(datas.X);
                Console.Write(",");
                Console.Write(datas.Y);
                Console.Write(",");
                Console.Write(datas.Z);
                Console.WriteLine("");
                Console.WriteLine(datas.RotationX);
                Console.Write(",");
                Console.Write(datas.RotationY);
                Console.WriteLine("");
                */
                /* D-Pad read
                * 
                */
                /*
               var j = datas.PointOfViewControllers[0] >= 0 ? (DPAD)(datas.PointOfViewControllers[0]/4500): DPAD.none;
               Console.WriteLine(j);
               */
                Thread.Sleep(300);
                Console.Clear();
            }
            /*
                  bool msg = false;
                  XController c = new XController(new Controller(UserIndex.One));
                  while (true)
                  {
                      Thread.Sleep(200);
                      if (c.IsConnected())
                      {
                          if (!msg) {
                              Console.WriteLine("Controller Connected!");
                              msg = true;
                          }
                          if (c.IsButtonAPressed())
                          {
                              Console.WriteLine("Button A pressed!");
                              XKeyBoard x = new XKeyBoard();
                              x.PressKeysFromString("Hello World@$%^&*()<>?");
                          }
                          if (c.IsButtonBPressed())
                          {
                              Console.WriteLine("Button B pressed!");
                              XKeyBoard x = new XKeyBoard();
                              Keys[] k = { Keys.LControlKey, Keys.LMenu, Keys.Tab };
                              x.PressShortcut(k);
                          }
                          if (c.IsButtonXPressed())
                          {
                              Console.WriteLine("Button X pressed!");
                              XKeyBoard x = new XKeyBoard();
                              x.OpenApplication("C:\\KMPlayer\\KMPlayer.exe");
                          }
                          if (c.IsButtonYPressed())
                          {
                              Console.WriteLine("Button Y pressed!");
                              XKeyBoard x = new XKeyBoard();
                              x.PressKey('|');
                          }
                          if (c.IsButtonBackPressed())
                          {
                              Console.WriteLine("Button Back pressed!");
                          }
                          if (c.IsButtonDPadDownPressed())
                          {
                              Console.WriteLine("Button DPadDown pressed!");
                          }
                          if (c.IsButtonDPadUpPressed())
                          {
                              Console.WriteLine("Button DPadUp pressed!");
                          }
                          if (c.IsButtonDPadLeftPressed())
                          {
                              Console.WriteLine("Button DPadLeft pressed!");
                          }
                          if (c.IsButtonDPadRightPressed())
                          {
                              Console.WriteLine("Button DPadRight pressed!");
                          }
                          if (c.IsButtonLeftShoulderPressed())
                          {
                              Console.WriteLine("Button LeftShoulder pressed!");
                          }
                          if (c.IsButtonRightShoulderPressed())
                          {
                              Console.WriteLine("Button RightShoulder pressed!");
                          }
                          if (c.IsButtonLeftThumbPressed())
                          {
                              Console.WriteLine("Button LeftThumb pressed!");
                          }
                          if (c.IsButtonRightThumbPressed())
                          {
                              Console.WriteLine("Button RightThumb pressed!");
                          }
                          if (c.IsButtonStartPressed())
                          {
                              Console.WriteLine("Button Start pressed!");
                          }
                      } else
                      {
                          Console.WriteLine("Controller Disconnected!");
                          msg = false;
                      }     
                  }
                  */
        }
	}
}
