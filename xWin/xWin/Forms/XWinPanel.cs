using Gma.System.MouseKeyHook;
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

        /* Update Controllers status when loading main panel */
        private void XWinPanel_Load(object sender, EventArgs e)
        {
            UpdateControllers();
            if (enableWordPrediction || enableQuickType) { KeyboardInputsSubscribe(); } // Subscribe to read keyboard inputs
            if (enableWordPrediction) { wordPredictionCheckBox.Checked = true; }
            if (enableQuickType) { quickTypeCheckBox.Checked = true; }
            Log.GetLogger().Info("Application started");
        }

        private void XWinPanel_FormClosed(object sender, FormClosedEventArgs e)
        {
            KeyboardInputsUnsubscribe(); // Unsubscribe to unread keyboard inputs
        }

        private void UpdateControllers()
        {
            // Check status of each controller and update the button accordingly
            if (XCon1.IsConnected())
            {
                Controller1.Text = "Controller 1 \nConnected";
                Controller1.BackColor = Color.FromArgb(46, 204, 113);

                //Log.GetLogger().Debug("Previously Connected " + XCon1.IsPreviouslyConnected);
                if (!XCon1.IsPreviouslyConnected) { Log.GetLogger().Info("Controller 1 Connected"); }
                XCon1.IsPreviouslyConnected = true;
            }
            else
            {
                Controller1.Text = "Controller 1 \nDisconnected";
                Controller1.BackColor = Color.FromArgb(255, 0, 51);
                if (XCon1Thread.IsAlive) { XCon1Thread.Abort(); }

                //Log.GetLogger().Debug("Previously Connected " + XCon1.IsPreviouslyConnected);
                if (XCon1.IsPreviouslyConnected) { Log.GetLogger().Info("Controller 1 Disconnected"); }
                XCon1.IsPreviouslyConnected = false;
            }

            if (XCon2.IsConnected())
            {
                Controller2.Text = "Controller 2 \nConnected";
                Controller2.BackColor = Color.FromArgb(46, 204, 113);

                //Log.GetLogger().Debug("Previously Connected " + XCon2.IsPreviouslyConnected);
                if (!XCon2.IsPreviouslyConnected) { Log.GetLogger().Info("Controller 2 Connected"); }
                XCon2.IsPreviouslyConnected = true;
            }
            else
            {
                Controller2.Text = "Controller 2 \nDisconnected";
                Controller2.BackColor = Color.FromArgb(255, 0, 51);
                if (XCon2Thread.IsAlive) { XCon2Thread.Abort(); }
                //Log.GetLogger().Debug("Previously Connected " + XCon2.IsPreviouslyConnected);
                if (XCon2.IsPreviouslyConnected) { Log.GetLogger().Info("Controller 2 Disconnected"); }
                XCon2.IsPreviouslyConnected = false;
            }

            if (XCon3.IsConnected())
            {
                Controller3.Text = "Controller 3 \nConnected";
                Controller3.BackColor = Color.FromArgb(46, 204, 113);

                //Log.GetLogger().Debug("Previously Connected " + XCon3.IsPreviouslyConnected);
                if (!XCon3.IsPreviouslyConnected) { Log.GetLogger().Info("Controller 3 Connected"); }
                XCon3.IsPreviouslyConnected = true;
            }
            else
            {
                Controller3.Text = "Controller 3 \nDisconnected";
                Controller3.BackColor = Color.FromArgb(255, 0, 51);
                if (XCon3Thread.IsAlive) { XCon3Thread.Abort(); }
                //Log.GetLogger().Debug("Previously Connected " + XCon3.IsPreviouslyConnected);
                if (XCon3.IsPreviouslyConnected) { Log.GetLogger().Info("Controller 3 Disconnected"); }
                XCon3.IsPreviouslyConnected = false;
            }

            if (XCon4.IsConnected())
            {
                Controller4.Text = "Controller 4 \nConnected";
                Controller4.BackColor = Color.FromArgb(46, 204, 113);

                //Log.GetLogger().Debug("Previously Connected " + XCon4.IsPreviouslyConnected);
                if (!XCon4.IsPreviouslyConnected) { Log.GetLogger().Info("Controller 4 Connected"); }
                XCon4.IsPreviouslyConnected = true;
            }
            else
            {
                Controller4.Text = "Controller 4 \nDisconnected";
                Controller4.BackColor = Color.FromArgb(255, 0, 51);
                if (XCon4Thread.IsAlive) { XCon4Thread.Abort(); }
                //Log.GetLogger().Debug("Previously Connected " + XCon4.IsPreviouslyConnected);
                if (XCon4.IsPreviouslyConnected) { Log.GetLogger().Info("Controller 4 Disconnected"); }
                XCon4.IsPreviouslyConnected = false;
            }
        }

        private void Controller1_Click(object sender, EventArgs e)
        {
            if (XCon1.IsConnected())
            {
                OpXCon1.ShowDialog();
                Log.GetLogger().Info("Opened Controller 1's Dialog");
            }
        }

        private void Controller2_Click(object sender, EventArgs e)
        {
            if (XCon2.IsConnected())
            {
                OpXCon2.ShowDialog();
                Log.GetLogger().Info("Opened Controller 2's Dialog");
            }
        }

        private void Controller3_Click(object sender, EventArgs e)
        {
            if (XCon3.IsConnected())
            {
                OpXCon3.ShowDialog();
                Log.GetLogger().Info("Opened Controller 3's Dialog");
            }
        }

        private void Controller4_Click(object sender, EventArgs e)
        {
            if (XCon4.IsConnected())
            {
                OpXCon4.ShowDialog();
                Log.GetLogger().Info("Opened Controller 4's Dialog");
            }
        }

        public void ExecuteButtonsForController(IXController controller)
        {
            Thread keyboardThread = new Thread(delegate () {; });
            bool buttonPressA = false;
            bool buttonPressB = false;
            List<GamepadButtonFlags> list = new List<GamepadButtonFlags>();

            try
            {
                while (true)
                {
                    list = controller.GetCurrentlyPressedButtons();
                    Log.GetLogger().Debug("list of currently pressed buttons : " + list);
                    // If the list has only 1 button pressed
                    if (list.Count == 1)
                    {
                        GamepadButtonFlags b = list.First<GamepadButtonFlags>(); // get the currently pressed button
                        controller.GetKeyBoardForButton(b).Execute(); // Execute action for the button 
                        Log.GetLogger().Info("Executed button " + b + " for controller " + controller);
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
                        if (controller.GetRightCart()["Y"] > 9000 || controller.GetRightCart()["Y"] < -9000)
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
                Log.GetLogger().Error("Error when executing buttons for controller " + controller, e);
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

        /*
         * For Logging
         */
        delegate void UniversalVoidDelegate();
        /// Call form control action from different thread
        public static void ControlInvike(Control control, Action function)
        {
            if (control.IsDisposed || control.Disposing)
                return;

            if (control.InvokeRequired)
            {
                control.Invoke(new UniversalVoidDelegate(() => ControlInvike(control, function)));
                return;
            }
            function();
        }

        public void DoAppend(log4net.Core.LoggingEvent loggingEvent)
        {
            try
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
                }
                else if (loggingEvent.Level == log4net.Core.Level.Warn)
                {
                    list.BackColor = Color.Yellow;
                    list.ForeColor = Color.Black;
                }
                else
                {
                    list.BackColor = Color.White;
                    list.ForeColor = Color.Black;
                }
                list.SubItems.Add(loggingEvent.Level.Name);
                list.SubItems.Add(loggingEvent.LoggerName.Substring(loggingEvent.LoggerName.LastIndexOf("xWin")));
                list.SubItems.Add(loggingEvent.MessageObject.ToString());
                logListView.Sorting = System.Windows.Forms.SortOrder.Descending;
                ControlInvike(logListView, () => logListView.Items.Add(list));
            }
            catch (Exception e)
            {
                Log.GetLogger().Error(e);
            }
        }

        private void debugModeCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                Log.GetLogger().Error(ex);
            }
        }

        private void clearLogsButton_Click(object sender, EventArgs e)
        {
            try
            {
                logListView.Items.Clear();
                Log.ClearLogs();
            }
            catch (Exception ex)
            {
                Log.GetLogger().Error(ex);
            }
        }

        private void openLogFileButton_Click(object sender, EventArgs e)
        {
            try
            {
                Log.GetLogger().Info("Opening log file...");
                Log.OpenLogFile();
            }
            catch (Exception ex)
            {
                Log.GetLogger().Error(ex);
            }
        }

        private void reportError_Click(object sender, EventArgs e)
        {
            try
            {
                EmailError emailError = new EmailError();
                emailError.ShowDialog();
            }
            catch (Exception ex)
            {
                Log.GetLogger().Error(ex);
            }
        }

        /*
         * Code for AutoComplete feature
         */
        AutoCompleteDB db = new AutoCompleteDB();
        QuickTypeBar quickTypeBar = new QuickTypeBar();

        private IKeyboardMouseEvents keyboardGlobalHook; // events to read keyboard's keydown and keypress.
        private bool enableWordPrediction = true;
        private bool enableQuickType = true;
        private bool subscribed = false; // indicate whether we've already subscribed to read the keyboard inputs

        private Keys[] keys = { Keys.None, Keys.None }; // array of 2 keys, Keys[0] is the previously entered key, Keys[1] is the currently entered key.
        private string typedWord = ""; // word that user's typing
        private string predictiveSubWord = ""; // subword of the word that needs to be showed to the user

        private void buttonViewDictionary_Click(object sender, EventArgs e)
        {
            AutoCompleteDictionary dictionary = new AutoCompleteDictionary();
            dictionary.ShowDialog();
        }

        private void wordPredictionCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (wordPredictionCheckBox.Checked)
            { enableWordPrediction = true; }
            else
            { enableWordPrediction = false; }
        }

        private void quickTypeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (quickTypeCheckBox.Checked)
            { enableQuickType = true; }
            else
            { enableQuickType = false; }
        }

        public void KeyboardInputsSubscribe()
        {
            try
            {
                keyboardGlobalHook = Hook.GlobalEvents();
                keyboardGlobalHook.KeyDown += GlobalHookKeyDown;
                keyboardGlobalHook.KeyUp += GlobalHookKeyUp;
                subscribed = true;
                Log.GetLogger().Debug("Subscribed to read keyboard inputs");
            }
            catch (Exception e)
            {
                Log.GetLogger().Error(e);
            }
        }

        public void KeyboardInputsUnsubscribe()
        {
            try
            {
                keyboardGlobalHook.KeyDown -= GlobalHookKeyDown;
                keyboardGlobalHook.KeyUp -= GlobalHookKeyUp;
                keyboardGlobalHook.Dispose();
                subscribed = false;
                Log.GetLogger().Debug("Unsubscribed to stop reading keyboard inputs");
            }
            catch (Exception e)
            {
                Log.GetLogger().Error(e);
            }
        }

        // Convert a key to a coressponding character, which is returned as a string
        public string KeyToChar(Keys[] keys)
        {
            string c = "\0"; // default null char
            try
            {
                Keys key = keys[1];
                if ((key >= Keys.A) && (key <= Keys.Z))
                {
                    c = "" + (char)((int)'a' + (int)(key - Keys.A));
                }
                else if ((key >= Keys.D0) && (key <= Keys.D9))
                {
                    if (keys[0] == Keys.Shift)
                    {
                        switch (key)
                        {
                            case Keys.D0:
                                c = "" + ')';
                                break;
                            case Keys.D1:
                                c = "" + '!';
                                break;
                            case Keys.D2:
                                c = "" + '@';
                                break;
                            case Keys.D3:
                                c = "" + '#';
                                break;
                            case Keys.D4:
                                c = "" + '$';
                                break;
                            case Keys.D5:
                                c = "" + '%';
                                break;
                            case Keys.D6:
                                c = "" + '^';
                                break;
                            case Keys.D7:
                                c = "" + '&';
                                break;
                            case Keys.D8:
                                c = "" + '*';
                                break;
                            case Keys.D9:
                                c = "" + '(';
                                break;
                        }
                    }
                    else { c = "" + (char)((int)'0' + (int)(key - Keys.D0)); }
                }
                else
                {
                    switch (key)
                    { 
                        case Keys.ShiftKey: // ignore shift key
                        case Keys.LShiftKey:
                        case Keys.RShiftKey:
                            c = "";
                            break;
                        case Keys.Oem1:
                            {
                                if (keys[0] == Keys.Shift) { c = "" + ':'; }
                                else { c = "" + ';'; }
                                break;
                            }
                        case Keys.Oem7:
                            {
                                if (keys[0] == Keys.Shift) { c = "" + '"'; }
                                else { c = "" + (char) 39; }
                                break;
                            }
                        case Keys.Oemtilde:
                            {
                                if (keys[0] != Keys.Shift) { c = "" + '~'; }
                                c = "" + '`';
                                break;
                            }
                        case Keys.Oemcomma:
                            {
                                if (keys[0] != Keys.Shift) { c = "" + ','; }
                                break;
                            }
                        case Keys.OemPeriod:
                            {
                                if (keys[0] != Keys.Shift) { c = "" + '.'; }
                                break;
                            }
                        case Keys.OemQuestion:
                            {
                                if (keys[0] == Keys.Shift) { c = "" + '?'; }
                                else { c = "" + '/'; }
                                break;
                            }
                    }
                }
                return c;
            }
            catch (Exception e)
            {
                Log.GetLogger().Error(e);
                return c;
            }
        }

        // When a key is down
        private void GlobalHookKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                KeyboardInputsUnsubscribe();
                if (enableQuickType)
                {
                    quickTypeBar.TopMost = true;
                    quickTypeBar.Show();
                }

                // If keydown is Tab key
                // and currently typed word is not empty and it doesn't contain null character
                // Suppress actual tab key and complete the predictive word
                if (e.KeyCode == Keys.Tab && typedWord != "" && !typedWord.Contains('\0'))
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true;

                    // Complete the predictive word
                    char[] array = predictiveSubWord.ToArray<char>();
                    Wrapper.SystemWrapper systemWrapper = new Wrapper.SystemWrapper();
                    foreach (char c in array)
                    { systemWrapper.SimulateKeyPress((WindowsInput.Native.VirtualKeyCode)Keys.Right); }

                    typedWord = ""; // reset currently typed word
                    Log.GetLogger().Info("Reset currently typed word");
                }
                // New word
                else if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Space)
                {
                    if (typedWord != "") { db.UpdateOrInsertWord(typedWord); } // Update non-empty word into database
                    typedWord = ""; // reset the word
                }
                else if (e.KeyCode == Keys.Back) // Delete character
                {
                    if (predictiveSubWord != "") // If there's a predictive subword, remove it.
                    {
                        Wrapper.SystemWrapper systemWrapper = new Wrapper.SystemWrapper();
                        systemWrapper.SimulateKeyPress((WindowsInput.Native.VirtualKeyCode)Keys.Back);
                    }
                    if (typedWord.Length > 0) { typedWord = typedWord.Remove(typedWord.Length - 1); }
                    Log.GetLogger().Info("Backspace: removed last character, currently typed word is " + typedWord);
                }
                else
                {
                    keys[1] = e.KeyCode;
                    string c = KeyToChar(keys);
                    Log.GetLogger().Info("KeyToChar: " + c);
                    typedWord += c;
                    Log.GetLogger().Info("word typed: " + typedWord + " (length: " + typedWord.Length + ")");
                    Log.GetLogger().Info("Contain null char: " + typedWord.Contains('\0'));
                }
                KeyboardInputsSubscribe();
            }
            catch (Exception ex)
            {
                Log.GetLogger().Error(ex);
            }
        }

        // When a key is up
        private void GlobalHookKeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                // reset quicktype bar
                quickTypeBar.SetQuickTypeButton1("");
                quickTypeBar.SetQuickTypeButton2("");
                quickTypeBar.SetQuickTypeButton3("");

                KeyboardInputsUnsubscribe();
                predictiveSubWord = ""; // reset predictive Subword
                if (e.KeyCode != Keys.Enter && e.KeyCode != Keys.Space && e.KeyCode != Keys.Tab)
                {
                    List<string> topThree = db.GetTopThreeWords(typedWord);
                    if (topThree.Count > 0)
                    {
                        if (topThree[0] != typedWord) // if Top Word is not the same as currently typed word
                        {
                            predictiveSubWord = topThree[0].Substring(topThree[0].IndexOf(typedWord) + typedWord.ToCharArray().Length);
                            Log.GetLogger().Debug("typedword length: " + typedWord.ToCharArray().Length);
                            Log.GetLogger().Info("predictive word (top word): " + topThree[0]);
                            Log.GetLogger().Info("subWord: " + predictiveSubWord + ", length: " + predictiveSubWord.Length);

                            Wrapper.SystemWrapper systemWrapper = new Wrapper.SystemWrapper();
                            systemWrapper.SimulateText(predictiveSubWord); // show predictive subword
                            // highlight predictive subword
                            char[] array = predictiveSubWord.ToArray<char>();
                            systemWrapper.SimulateKeyDown((WindowsInput.Native.VirtualKeyCode)Keys.ShiftKey);
                            foreach (char c in array)
                            { systemWrapper.SimulateKeyPress((WindowsInput.Native.VirtualKeyCode)Keys.Left); }
                            systemWrapper.SimulateKeyUp((WindowsInput.Native.VirtualKeyCode)Keys.ShiftKey);
                        }

                        string[] topTmp = { "", "", "" };
                        for (int i = 0; i < topThree.Count; i++)
                        { if (typedWord != topThree[i]) { topTmp[i] = topThree[i]; } }
                        quickTypeBar.SetQuickTypeButton1(topTmp[0]);
                        quickTypeBar.SetQuickTypeButton2(topTmp[1]);
                        quickTypeBar.SetQuickTypeButton3(topTmp[2]);
                    }
                }
                keys[0] = e.KeyCode;
                KeyboardInputsSubscribe();

                QuickTypeBarTimer.Stop(); // stop previous timer
                QuickTypeBarTimer.Start(); // start new timer
            }
            catch (Exception ex)
            {
                Log.GetLogger().Error(ex);
                Log.GetLogger().Error("Error when key is up :");
            }
        }

        private void AutoCompleteTimer_Tick(object sender, EventArgs e)
        {
            //if (enableWordPrediction && !subscribed)
            //{ KeyboardInputsSubscribe(); } // Subscribe to read keyboard inputs

            //if (!enableWordPrediction && subscribed)
            //{ KeyboardInputsUnsubscribe(); } // Unsubscribe to stop reading keyboard inputs
        }

        private void QuickTypeBarTimer_Tick(object sender, EventArgs e)
        {
            QuickTypeBarTimer.Stop();
            quickTypeBar.Hide();

        }
    }
}
