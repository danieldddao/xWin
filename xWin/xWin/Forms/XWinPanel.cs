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
    public partial class XWinPanel : Form, log4net.Appender.IAppender
    {
        private static readonly log4net.ILog logger = Log.GetLogger();

        IXController XCon1;
        ControllerOptions OpXCon1;

        IXController XCon2;
        ControllerOptions OpXCon2;

        IXController XCon3;
        ControllerOptions OpXCon3;

        IXController XCon4;
        ControllerOptions OpXCon4;

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
            }
        }

        /* Update Controllers status when loading main panel */
        private void XWinPanel_Load(object sender, EventArgs e)
        {
            LoadLogFileToListView();
            UpdateControllers();
            logger.Info("Application started");
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
            List<GamepadButtonFlags> list = controller.GetCurrentlyPressedButtons();
            try
            {
                // If the list has only 1 button pressed
                if (list.Count == 1)
                {
                    GamepadButtonFlags b = list.First<GamepadButtonFlags>(); // get the currently pressed button
                    controller.GetKeyBoardForButton(b).Execute(); // Execute action for the button 
                }
                Thread.Sleep(50);
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
            ExecuteButtonsForController(XCon1);
            ExecuteButtonsForController(XCon2);
            ExecuteButtonsForController(XCon3);
            ExecuteButtonsForController(XCon4);
        }

        /*
         * For Logging
         */
        public void DoAppend(log4net.Core.LoggingEvent loggingEvent)
        {
            ListViewItem list = new ListViewItem(loggingEvent.TimeStamp.ToString());
            if (loggingEvent.Level == log4net.Core.Level.Error)
            {
                list.BackColor = Color.DarkRed;
                list.ForeColor = Color.White;
            }
            else if (loggingEvent.Level == log4net.Core.Level.Debug)
            {
                list.BackColor = Color.LightSkyBlue;
                list.ForeColor = Color.Black;
            } else if (loggingEvent.Level == log4net.Core.Level.Warn)
            {
                list.BackColor = Color.Yellow;
                list.ForeColor = Color.Black;
            } else
            {
                list.BackColor = Color.White;
                list.ForeColor = Color.Black;
            }
            list.SubItems.Add(loggingEvent.Level.Name);
            list.SubItems.Add(loggingEvent.LoggerName.Substring(loggingEvent.LoggerName.LastIndexOf("xWin")));
            list.SubItems.Add(loggingEvent.MessageObject.ToString());
            logListView.Sorting = System.Windows.Forms.SortOrder.Descending;
            logListView.Items.Add(list);
        }

        private void debugModeCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (debugModeCheckbox.Checked)
            {
                Log.EnableDebugMode();
            }
            else
            {
                Log.DisableDebugMode();
            }
        }

        private void clearLogsButton_Click(object sender, EventArgs e)
        {
            logListView.Items.Clear();
            Log.ClearLogs();
        }

        private void LoadLogFileToListView()
        {

        }

        private void openLogFileButton_Click(object sender, EventArgs e)
        {
            logger.Info("Opening log file...");
            try
            {
                var rollingFileAppender = ((log4net.Repository.Hierarchy.Hierarchy)log4net.LogManager.GetRepository()).Root.Appenders.OfType<log4net.Appender.RollingFileAppender>().FirstOrDefault();
                string file = rollingFileAppender != null ? rollingFileAppender.File : string.Empty;
                logger.Info("Log file is " + file);
                rollingFileAppender.ImmediateFlush = true;
                rollingFileAppender.LockingModel = new log4net.Appender.FileAppender.MinimalLock();
                rollingFileAppender.ActivateOptions();
                logger.Info("Locked the log file");
                System.Diagnostics.Process.Start(file);
                logger.Info("Log file opened!");
            } catch (Exception ex)
            {
                logger.Error("Error when opening log file: ", ex);

            }
        }
    }
}
