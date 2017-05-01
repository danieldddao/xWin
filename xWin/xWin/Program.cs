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
using static TypingControl.Types;
using static xWin.Library.WI;
namespace xWin
{
    class Program
    {

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

        [STAThread]
        static void Main(string[] args)
        {
            //RunFormApplicationForTesting();
            //RunFormApplication();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
<<<<<<< c25c5d1ae5026d701abe2b4ff78f9d4b88dac866
            var l = new List<string>();
            l.Add(@"C:\Users\Tim\Documents\Classes\software project\Project\xWin\config");
            l.Add(@"..\..\..\config");
            var cfw = new GUI.ConfigWindow(new Configuration(), l);
            //Application.Run(cfw);
            //return;
            cfw.ShowDialog();
=======
            var cfw = new GUI.ConfigWindow();
            Application.Run(cfw);
            return;
>>>>>>> started integrating the saving into a gui
            GenericController controller = null;
            var a = new byte[16];
            a[0] = 1;
            //Joystick joystick = null;

            var XCon1 = new Controller(UserIndex.One);

            if (XCon1.IsConnected)
                controller = new XBXController(XCon1);
            else
                controller = new DIController(DI2XI.setup_stick());

            var cc = new ControllerCalibration();
            State datas = controller.GetState();
            cc.lx = datas.Gamepad.LeftThumbX;
            cc.ly = datas.Gamepad.LeftThumbY;
            cc.rx = datas.Gamepad.RightThumbX;
            cc.ry = datas.Gamepad.RightThumbY;
            cc.deadzone = 7000;

            //var io = new IO<Configuration>(l,".dat");
            //io.WriteToFile(Defaults.DefaultConfiguration(), "default");
            //var c = io.ReadFromFile("default");
            //Defaults.DefaultConfiguration();

<<<<<<< c25c5d1ae5026d701abe2b4ff78f9d4b88dac866



            InteractionLoop(controller, cfw.c, cc, 20000);
=======
            


            InteractionLoop(controller, c, cc, 20000);
>>>>>>> started integrating the saving into a gui
        }
    }
}