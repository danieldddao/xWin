using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using xWin.Library;
using SharpDX.XInput;
using xWin.Forms;
using xWin.Wrapper;
//using static Configuration.Types;
using SharpDX.DirectInput;
using xWin.Config;
using System.Drawing;
using Moq;
using xWin.Wrapper;
using xWin.Forms.ButtonMaps;
using System.Diagnostics;

namespace xWin
{



    class Program
    {
        public static short shortbound(int i)
        {
            if (i < -32767)
                return -32767;
            if (i > 32767)
                return 32767;
            return (short)i;
        }
        /* Run this method in Main instead of RunFormApplication() for cucumber tests */
        public static void RunFormApplicationForTesting()
        {
            Mock<IXController> mockController1 = new Mock<IXController>();
            Mock<IXController> mockController2 = new Mock<IXController>();
            Mock<IXController> mockController3 = new Mock<IXController>();
            Mock<IXController> mockController4 = new Mock<IXController>();
            mockController1.Setup(x => x.IsConnected()).Returns(true);
            mockController2.Setup(x => x.IsConnected()).Returns(false);
            mockController3.Setup(x => x.IsConnected()).Returns(false);
            mockController4.Setup(x => x.IsConnected()).Returns(true);

            // List of currently pressed buttons
            List<GamepadButtonFlags> list1 = new List<GamepadButtonFlags>();
            List<GamepadButtonFlags> list2 = new List<GamepadButtonFlags>();
            List<GamepadButtonFlags> list3 = new List<GamepadButtonFlags>();
            List<GamepadButtonFlags> list4 = new List<GamepadButtonFlags>();
            mockController1.Setup(x => x.GetCurrentlyPressedButtons()).Returns(list1);
            mockController2.Setup(x => x.GetCurrentlyPressedButtons()).Returns(list2);
            mockController3.Setup(x => x.GetCurrentlyPressedButtons()).Returns(list3);
            mockController4.Setup(x => x.GetCurrentlyPressedButtons()).Returns(list4);

            /* Controller 4 */
            // XKeyboard for Left Thumb button
            XKeyBoard keyboardLT4 = new XKeyBoard();
            keyboardLT4.AppPath = ".../Test.exe";
            keyboardLT4.Action = XAction.OpenApp;
            foreach (GamepadButtonFlags button in Enum.GetValues(typeof(GamepadButtonFlags)))
            {
                if (button != GamepadButtonFlags.None)
                {
                    if (button == GamepadButtonFlags.LeftThumb)
                    { mockController4.Setup(x => x.GetKeyBoardForButton(button)).Returns(keyboardLT4); }
                    else
                    { mockController4.Setup(x => x.GetKeyBoardForButton(button)).Returns(new XKeyBoard()); }
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            log4net.Config.XmlConfigurator.Configure();
            XWinPanel panel = new XWinPanel(mockController1.Object, mockController2.Object, mockController3.Object, mockController4.Object);
            ((log4net.Repository.Hierarchy.Hierarchy)log4net.LogManager.GetRepository()).Root.AddAppender(panel);
            Log.GetLogger().Info("Starting the Application...");
            Application.Run(panel);
        }
        
        public static void RunFormApplication()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            log4net.Config.XmlConfigurator.Configure();
            XWinPanel panel = new XWinPanel();
            ((log4net.Repository.Hierarchy.Hierarchy)log4net.LogManager.GetRepository()).Root.AddAppender(panel);
            Log.GetLogger().Info("Starting the Application...");
            Application.Run(panel);
        }


        public static void MoveCursor( float x, float y, int dpi = 10)
        {
            const short MAX_INPUT = 32767;
            x /= MAX_INPUT;
            x *= dpi;
            
            y /= MAX_INPUT;
            y *= dpi;

            Cursor.Position = new Point(Cursor.Position.X + (short)Math.Floor(x), Cursor.Position.Y + (short)Math.Floor(y));
        }



        [STAThread]
        static void Main(string[] args)
        {
            //RunFormApplicationForTesting();
            //RunFormApplication();

            bool XCONTROLLER = false;



            Controller XCon1 = new Controller();
            var a = new byte[16];
            a[0] = 1;
            Joystick joystick = null;
            if (XCONTROLLER)
                XCon1 = new Controller(UserIndex.One);
            else {
                // Initialize DirectInput
                DirectInput directInput = new DirectInput();
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
                joystick = new Joystick(directInput, joystickGuid);
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
            }
            var i = new Interpreter(Defaults.DefaultConfiguration());

            System.Diagnostics.Stopwatch st = new System.Diagnostics.Stopwatch();

            int lx, ly, rx, ry;


            //var datas = joystick.GetCurrentState();
            State datas;
            if (XCONTROLLER)
                datas = XCon1.GetState();
            else
                datas = DI2XI.di2xi(joystick.GetCurrentState());
            lx = datas.Gamepad.LeftThumbX;
            ly = datas.Gamepad.LeftThumbY;
            rx = datas.Gamepad.RightThumbX;
            ry = datas.Gamepad.RightThumbY; ;
            var index = 0;


            var wrapper = new SystemWrapper();

            TimeSpan TickSpeed = new TimeSpan(20);
            while (true)
            {
                //*
                st.Start();
                joystick.Poll();
                if (XCONTROLLER)
                    datas = XCon1.GetState();
                else
                    datas = DI2XI.di2xi(joystick.GetCurrentState());

                datas.Gamepad.LeftThumbX = shortbound((int)datas.Gamepad.LeftThumbX - lx);
                datas.Gamepad.LeftThumbY = shortbound((int)datas.Gamepad.LeftThumbY - ly);
                datas.Gamepad.RightThumbX = shortbound((int)datas.Gamepad.RightThumbX - rx);
                datas.Gamepad.RightThumbY = shortbound((int)datas.Gamepad.RightThumbY - ry);
                var kms = i.NextState(datas.Gamepad);
                MoveCursor(kms.mouse_movement.x, kms.mouse_movement.y);
                Console.Write("Pressed: ");
                foreach (var l in kms.pressed)
                {
                    Console.Write(l.ToString() + ",");
                    if(l == Keys.LButton)
                        ControllerWrapper.mouse_event(0x0002, Control.MousePosition.X, Control.MousePosition.Y, 0, 0);
                    else if(l == Keys.RButton)
                        ControllerWrapper.mouse_event(0x0008, Control.MousePosition.X, Control.MousePosition.Y, 0, 0);
                    else if(l == Keys.MButton)
                        ControllerWrapper.mouse_event(0x0020, Control.MousePosition.X, Control.MousePosition.Y, 0, 0);
                    else
                        wrapper.Press((byte)l);
                }
                Console.WriteLine();
                Console.Write("Released: ");
                foreach (var l in kms.released)
                {
                    Console.Write(l.ToString() + ",");
                    if (l == Keys.LButton)
                        ControllerWrapper.mouse_event(0x0004, Control.MousePosition.X, Control.MousePosition.Y, 0, 0);
                    else if (l == Keys.RButton)
                        ControllerWrapper.mouse_event(0x0010, Control.MousePosition.X, Control.MousePosition.Y, 0, 0);
                    else if (l == Keys.MButton)
                        ControllerWrapper.mouse_event(0x0040, Control.MousePosition.X, Control.MousePosition.Y, 0, 0);
                    else
                        wrapper.Release((byte)l);
                }
                Console.WriteLine();
                Console.Write("Pressed: ");
                foreach (var l in kms.special)
                {
                    Console.Write(l.ToString() + ",");
                }
                Console.WriteLine();
                Console.Write("Released: ");
                foreach (var l in kms.r_special)
                {
                    Console.Write(l.ToString() + ",");
                }
                Console.WriteLine();
                while (st.Elapsed < TickSpeed) { }
                st.Stop();
                //Console.WriteLine(st.Elapsed.ToString());
                //Thread.Sleep(300);
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