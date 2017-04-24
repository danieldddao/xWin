using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using xWin.Library;
using SharpDX.XInput;
using xWin.Forms;
//using static Configuration.Types;
using SharpDX.DirectInput;
using xWin.Config;


namespace xWin
{



    class Program
    {
        public static int shortbound(int i)
        {
            if (i < -32767)
                return -32767;
            if (i > 32767)
                return 32767;
            return i;
        }
        public static void RunFormApplication()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new xWinPanel());
        }

        [STAThread]
        static void Main(string[] args)
        {
            XController c = new XController();
            //RunFormApplication();
            bool msg = false;
            /*
            while (true)
            {
                
                if (c.IsConnected())
                {
                    c.UpdateState();
                    foreach(var button in c.ButtonsPressed())
                    {
                        Console.WriteLine(button.Key + " is pressed: " + button.Value);
                    }
                    foreach(var thumb in c.GetLeftCart())
                    {
                        Console.WriteLine("Left stick " + thumb.Key + ": " + thumb.Value);
                    }
                    foreach(var thumb in c.GetRightCart())
                    {
                        Console.WriteLine("Right " + thumb.Key + ": " + thumb.Value);
                    }
                    Console.WriteLine("Left trigger: " + c.GetLeftTrigger());
                    Console.WriteLine("Right trigger:" + c.GetRightTrigger());
                    c.MoveCursor();
                    //if (c.ButtonsPressed()["A"]) c.LeftDown();
                    //else c.LeftUp();
                    //if (c.ButtonsPressed()["B"]) c.RightClick();
                    //Thread.Sleep(200);
                    Console.Clear();  
            }*/

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

            var i = new Interpreter(Defaults.DefaultConfiguration());

            System.Diagnostics.Stopwatch st = new System.Diagnostics.Stopwatch();

            int lx, ly, rx, ry;


            var datas = joystick.GetCurrentState();
            lx = datas.X;
            ly = datas.Y;
            rx = datas.RotationX;
            ry = datas.RotationY;
            var index = 0;
            while (true)
            {
                //*
                st.Start();
                joystick.Poll();
                datas = joystick.GetCurrentState();

                datas.X = shortbound(datas.X - lx);
                datas.Y = shortbound(datas.Y - ly);
                datas.RotationX = shortbound(datas.RotationX - rx);
                datas.RotationY = shortbound(datas.RotationY - ry);
                var state = DI2XI.di2xi(datas);
                var kms = i.NextState(state.Gamepad);
                Console.WriteLine(kms.mouse_movement.x.ToString()+","+kms.mouse_movement.y.ToString());
                foreach (var l in kms.pressed)
                {
                    Console.WriteLine(l.ToString());
                }
                foreach (var l in kms.special)
                {
                    Console.WriteLine(l.ToString());
                }
                st.Stop();
                Console.WriteLine(st.Elapsed.Milliseconds.ToString());
                Console.Clear();
                st.Reset();
                //*/
                /*
                joystick.Poll();
                datas = joystick.GetCurrentState();
                var state =  DI2XI.di2xi(datas);
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
                Console.WriteLine(index.ToString());
                index++;
                Thread.Sleep(300);
                Console.Clear();
               // */
            }

        }
    }
}