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
using System.IO;
using xWin.GUI;

namespace xWin
{
    public class Program
    {
        
        public static void RunFormApplication()
        {
            initialize_datas();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var l = new List<string>();

            l.Add(Path.GetFullPath(@"..\..\..\config"));

            var io = new IO<Configuration>(l, IO<Configuration>.CONFIGURATION_EXT);
            //io.WriteToFile(Defaults.DefaultConfiguration(), "default");
            Program.config = io.ReadFromFile(l[0] + @"\Basic" + io.ext);

            //var cfw = new ConfigWindow(new Configuration(), l);
            //Application.Run(cfw);
            //return;
            //cfw.ShowDialog();
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
            //cc.lx = datas.Gamepad.LeftThumbX;
            //cc.ly = datas.Gamepad.LeftThumbY;
            //cc.rx = datas.Gamepad.RightThumbX;
            //cc.ry = datas.Gamepad.RightThumbY;
            
            cc.deadzone = 7000;


            Program.Controller = controller;
            Program.cc = cc;
            Program.tick = 2000;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            log4net.Config.XmlConfigurator.Configure();
            XWinPanel panel = new XWinPanel(l);
            ((log4net.Repository.Hierarchy.Hierarchy)log4net.LogManager.GetRepository()).Root.AddAppender(panel);
            Log.GetLogger().Info("Starting the Application...");
            Application.Run(panel);
        }

        public static GenericController Controller;
        public static bool update_controller;

        public static Configuration config;
        public static bool update_config;

        public static ControllerCalibration cc;
        public static bool update_cc;

        public static int tick;
        public static bool update_tick;

        private static void initialize_datas()
        {
            update_controller = false;
            update_config = false;
            update_cc = false;
            config = new Configuration();
            cc = new ControllerCalibration();
            cc.lx = 0;
            cc.ly = 0;
            cc.rx = 0;
            cc.ry = 0;
            cc.deadzone = 5000;
        }

        [STAThread]
        static void Main(string[] args)
        {
            //RunFormApplicationForTesting();
            RunFormApplication();
            /*
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var l = new List<string>();
            
            l.Add(Path.GetFullPath(@"..\..\..\config"));

            var io = new IO<Configuration>(l, IO<Configuration>.CONFIGURATION_EXT);
            //io.WriteToFile(Defaults.DefaultConfiguration(), "default");
            Program.config = io.ReadFromFile(l[0]+@"\Basic"+io.ext);

            //var cfw = new ConfigWindow(new Configuration(), l);
            //Application.Run(cfw);
            //return;
            //cfw.ShowDialog();
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

            
            Program.Controller = controller;
            Program.cc = cc;
            Program.tick = 2000;
           // var mw = new MainWindow(l);
           // Application.Run(mw);*/
        }
    }
}