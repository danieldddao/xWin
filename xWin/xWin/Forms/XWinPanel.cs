using SharpDX.XInput;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using xWin.Library;

namespace xWin.Forms
{
    public partial class XWinPanel : Form
    {
        IXController XCon1;
        ControllerOptions OpXCon1;

        IXController XCon2;
        ControllerOptions OpXCon2;

        IXController XCon3;
        ControllerOptions OpXCon3;

        IXController XCon4;
        ControllerOptions OpXCon4;

        Thread XCon1Thread = new Thread(delegate () {; });
        Thread XCon2Thread = new Thread(delegate () {; });
        Thread XCon3Thread = new Thread(delegate () {; });
        Thread XCon4Thread = new Thread(delegate () {; });

        public XWinPanel()
        {
            InitializeComponent();

            // Initialize 4 controllers
            XCon1 = new XController(new SharpDX.XInput.Controller(UserIndex.One));
            OpXCon1 = new ControllerOptions(XCon1);

            XCon2 = new XController(new SharpDX.XInput.Controller(UserIndex.Two));
            OpXCon2 = new ControllerOptions(XCon2);

            XCon3 = new XController(new SharpDX.XInput.Controller(UserIndex.Three));
            OpXCon3 = new ControllerOptions(XCon3);

            XCon4 = new XController(new SharpDX.XInput.Controller(UserIndex.Four));
            OpXCon4 = new ControllerOptions(XCon4);
        }

        /* For Testing */
        public XWinPanel(IXController con1, IXController con2, IXController con3, IXController con4)
        {
            InitializeComponent();

            // Initialize 4 controllers
            XCon1 = con1;
            OpXCon1 = new ControllerOptions(XCon1);

            XCon2 = con2;
            OpXCon2 = new ControllerOptions(XCon2);

            XCon3 = con3;
            OpXCon3 = new ControllerOptions(XCon3);

            XCon4 = con4;
            OpXCon4 = new ControllerOptions(XCon4);

            timer1.Interval = 5000;
        }

        public Button GetController1()
        { return Controller1; }
        public Button GetController2()
        { return Controller2; }
        public Button GetController3()
        { return Controller3; }
        public Button GetController4()
        { return Controller4; }

        private void UpdateControllers()
        {
            // Check status of each controller and update the button accordingly
            if (XCon1.IsConnected())
            {
                Controller1.Text = "Controller 1 \nConnected";
                Controller1.BackColor = Color.FromArgb(46, 204, 113);
            }
            else
            {
                Controller1.Text = "Controller 1 \nDisconnected";
                Controller1.BackColor = Color.FromArgb(255, 0, 51);
                if (XCon1Thread.IsAlive) { XCon1Thread.Abort(); }
            }

            if (XCon2.IsConnected())
            {
                Controller2.Text = "Controller 2 \nConnected";
                Controller2.BackColor = Color.FromArgb(46, 204, 113);
            }
            else
            {
                Controller2.Text = "Controller 2 \nDisconnected";
                Controller2.BackColor = Color.FromArgb(255, 0, 51);
                if (XCon2Thread.IsAlive) { XCon2Thread.Abort(); }
            }

            if (XCon3.IsConnected())
            {
                Controller3.Text = "Controller 3 \nConnected";
                Controller3.BackColor = Color.FromArgb(46, 204, 113);
            }
            else
            {
                Controller3.Text = "Controller 3 \nDisconnected";
                Controller3.BackColor = Color.FromArgb(255, 0, 51);
                if (XCon3Thread.IsAlive) { XCon3Thread.Abort(); }
            }

            if (XCon4.IsConnected())
            {
                Controller4.Text = "Controller 4 \nConnected";
                Controller4.BackColor = Color.FromArgb(46, 204, 113);
            }
            else
            {
                Controller4.Text = "Controller 4 \nDisconnected";
                Controller4.BackColor = Color.FromArgb(255, 0, 51);
                if (XCon4Thread.IsAlive) { XCon4Thread.Abort(); }
            }
        }

        /* Update Controllers status when loading main panel */
        private void XWinPanel_Load(object sender, EventArgs e)
        {
            UpdateControllers();
        }

        private void Controller1_Click(object sender, EventArgs e)
        {
            if (XCon1.IsConnected())
            {
                OpXCon1.ShowDialog();
            }
        }

        private void Controller2_Click(object sender, EventArgs e)
        {
            if (XCon2.IsConnected())
            {
                OpXCon2.ShowDialog();
            }
        }

        private void Controller3_Click(object sender, EventArgs e)
        {
            if (XCon3.IsConnected())
            {
                OpXCon3.ShowDialog();
            }
        }

        private void Controller4_Click(object sender, EventArgs e)
        {
            if (XCon4.IsConnected())
            {
                OpXCon4.ShowDialog();
            }
        }

        public void ExecuteButtonsForController(IXController controller)
        {
            Thread keyboardThread = new Thread(delegate () {; });
            bool buttonPressA = false;
            bool buttonPressB = false;
            List<GamepadButtonFlags> list = controller.GetCurrentlyPressedButtons();
            try
            {
                while (true)
                {
                    list = controller.GetCurrentlyPressedButtons();
                    // If the list has only 1 button pressed
                    if (list.Count == 1)
                    {
                        GamepadButtonFlags b = list.First<GamepadButtonFlags>(); // get the currently pressed button
                        controller.GetKeyBoardForButton(b).Execute(); // Execute action for the button 
                    }
                    Thread.Sleep(15);
                    if (controller.IsConnected())
                    {
                        controller.UpdateState();
                        controller.MoveCursor();
                        if (controller.ButtonsPressed()["A"])
                        {
                            if (!buttonPressA)
                            {
                                buttonPressA = true;
                                controller.LeftDown();
                            }
                        }
                        else
                        {
                            if (buttonPressA) controller.LeftUp();
                            buttonPressA = false;
                        }
                        if (controller.ButtonsPressed()["B"])
                        {
                            if (!buttonPressB)
                            {
                                buttonPressB = true;
                                controller.RightDown();
                            }
                        }
                        else
                        {
                            if (buttonPressB) controller.RightUp();
                            buttonPressB = false;
                        }
                        if (controller.ButtonsPressed()["Y"] && !keyboardThread.IsAlive)
                        {
                            keyboardThread = new Thread(delegate ()
                            {
                                Application.EnableVisualStyles();
                                Application.SetCompatibleTextRenderingDefault(false);
                                Application.Run(new KeyboardWindow(controller));
                            });
                            keyboardThread.Name = "keyboard";
                            keyboardThread.IsBackground = true;
                            keyboardThread.SetApartmentState(ApartmentState.STA);
                            keyboardThread.Start();
                        }
                        if(controller.GetRightCart()["Y"] > 9000 || controller.GetRightCart()["Y"] < -9000)
                        {
                            float percentage = (float)controller.GetRightCart()["Y"] / 32767;
                            Console.WriteLine(percentage);
                            int WHEEL_DATA = (int)(percentage * 120);
                            controller.MouseWheel(WHEEL_DATA);
                        }
                    }
                }
            }
             catch (Exception e)
            {
                Console.WriteLine("{0}", e);
            }
        }

        /* Update Controllers status every 0.1 sec */
        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateControllers();
            if (!XCon1Thread.IsAlive && XCon1.IsConnected())
            {
                XCon1Thread = new Thread(delegate ()
                {
                    ExecuteButtonsForController(XCon1);
                });
                XCon1Thread.Name = "XCon1";
                XCon1Thread.IsBackground = true;
                XCon1Thread.SetApartmentState(ApartmentState.STA);
                XCon1Thread.Start();
            }
            if (!XCon2Thread.IsAlive && XCon2.IsConnected())
            {
                XCon2Thread = new Thread(delegate ()
                {
                    ExecuteButtonsForController(XCon2);
                });
                XCon2Thread.Name = "XCon2";
                XCon2Thread.IsBackground = true;
                XCon2Thread.SetApartmentState(ApartmentState.STA);
                XCon2Thread.Start();
            }
            if (!XCon3Thread.IsAlive && XCon3.IsConnected())
            {
                XCon3Thread = new Thread(delegate ()
                {
                    ExecuteButtonsForController(XCon3);
                });
                XCon3Thread.Name = "XCon3";
                XCon3Thread.IsBackground = true;
                XCon3Thread.SetApartmentState(ApartmentState.STA);
                XCon3Thread.Start();
            }
            if (!XCon4Thread.IsAlive && XCon4.IsConnected())
            {
                XCon4Thread = new Thread(delegate ()
                {
                    ExecuteButtonsForController(XCon4);
                });
                XCon4Thread.Name = "XCon4";
                XCon4Thread.IsBackground = true;
                XCon4Thread.SetApartmentState(ApartmentState.STA);
                XCon4Thread.Start();
            }
        }
    }
}
