using Gma.System.MouseKeyHook;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using xWin.Library;

namespace xWin.Forms
{
    public partial class AutoComplete : Form
    {
        private static IKeyboardMouseEvents keyboardGlobalHook; // events to read keyboard's keydown and keypress.
        AutoCompleteDB db = new AutoCompleteDB();

        public bool enableWordPrediction = true;
        public bool enableQuickType = true;
        public bool usingxWin = false;

        public Keys[] keys = { Keys.None, Keys.None }; // array of 2 keys, Keys[0] is the previously entered key, Keys[1] is the currently entered key.
        public string typedWord = ""; // word that user's typing
        public string predictiveSubWord = ""; // subword of the word that needs to be showed to the user
        public int quickTypeTimerInterval = 5000;

        public AutoComplete()
        {
            InitializeComponent();
            quickTypeButton1.Text = "";
            quickTypeButton2.Text = "";
            quickTypeButton3.Text = "";
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
                                else { c = "" + (char)39; }
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

        /*
         * Word Prediction: Predict the word based on what user's currently typing
         */
        private void PredictWord(string word)
        {
            try
            {
                predictiveSubWord = word.Substring(word.IndexOf(typedWord) + typedWord.ToCharArray().Length);
                Log.GetLogger().Debug("typedword length: " + typedWord.ToCharArray().Length);
                Log.GetLogger().Debug("predictive word (top word): " + word);
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
            catch (Exception e)
            {
                Log.GetLogger().Error(e);
            }
        }

        public void KeyboardInputsSubscribe()
        {
            try
            {
                keyboardGlobalHook = Hook.GlobalEvents();
                keyboardGlobalHook.KeyDown += GlobalHookKeyDown;
                keyboardGlobalHook.KeyUp += GlobalHookKeyUp;
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
                Log.GetLogger().Debug("Unsubscribed to stop reading keyboard inputs");
            }
            catch (Exception e)
            {
                Log.GetLogger().Error(e);
            }
        }

        // When a key is down
        private void GlobalHookKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                // If not interacting with xWin App
                if (usingxWin == false)
                {
                    KeyboardInputsUnsubscribe();
                    currentWindow = GetCurrentWindow();
                    Log.GetLogger().Info("Current Active Window " + currentWindow);

                    if (enableQuickType)
                    {
                        // Get the Id of xWin App
                        IntPtr xWinId = IntPtr.Zero;
                        foreach (Process p in Process.GetProcessesByName("xWin"))
                        {
                            xWinId = p.MainWindowHandle;
                        }
                        //Log.GetLogger().Info("xWin Window ID: " + xWinId);
                        // show quicktype bar if current active window is not xWin
                        if (currentWindow != xWinId)
                        {
                            this.TopMost = true;
                            this.Show();
                        }
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

                        typedWord += predictiveSubWord; // Apply the currently typed word
                        Log.GetLogger().Info("Applied currently typed word: " + typedWord);
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
                // If not interacting with xWin App
                if (usingxWin == false)
                {
                    KeyboardInputsUnsubscribe(); // Stop reading keyboard inputs

                    // reset quicktype bar
                    SetQuickTypeButton1("");
                    SetQuickTypeButton2("");
                    SetQuickTypeButton3("");
                    predictiveSubWord = ""; // reset predictive Subword

                    if (e.KeyCode != Keys.Enter && e.KeyCode != Keys.Space && e.KeyCode != Keys.Tab)
                    {
                        List<string> topThree = db.GetTopThreeWords(typedWord);
                        string logMsg = "top three words: ";
                        foreach (string word in topThree) { logMsg += word + " "; }
                        Log.GetLogger().Info(logMsg);

                        // If there exists at least a word that matches the currently typed word
                        if (topThree.Count > 0)
                        {
                            if (topThree[0] != typedWord) // Use Top 1 Word as word prediction if it is not the same as currently typed word
                            {
                                PredictWord(topThree[0]);
                            }
                            else if (topThree.Count >= 2 && topThree[1] != typedWord) // Use Top 2 Word as word prediction if it exists and is not the same as currently typed word
                            {
                                PredictWord(topThree[1]);
                            }
                            else if (topThree.Count >= 3 && topThree[2] != typedWord) // Use Top 3 Word as word prediction if it exists and is not the same as currently typed word
                            {
                                PredictWord(topThree[2]);
                            }

                            // Set word suggestions for quicktype bar
                            string[] topTmp = { "", "", "" };
                            for (int i = 0; i < topThree.Count; i++)
                            { if (typedWord != topThree[i]) { topTmp[i] = topThree[i]; } }
                            SetQuickTypeButton1(topTmp[0]);
                            SetQuickTypeButton2(topTmp[1]);
                            SetQuickTypeButton3(topTmp[2]);
                        }
                    }

                    keys[0] = e.KeyCode;
                    QuickTypeBarTimer.Stop(); // stop previous timer
                    QuickTypeBarTimer.Interval = quickTypeTimerInterval;
                    QuickTypeBarTimer.Start(); // start new timer
                    KeyboardInputsSubscribe(); // Start reading keyboard inputs
                }
            }
            catch (Exception ex)
            {
                Log.GetLogger().Error(ex);
                Log.GetLogger().Error("Error when key is up :");
            }
        }

        public void SetQuickTypeButton1(string text)
        {
            quickTypeButton1.Text = text;
        }
        public void SetQuickTypeButton2(string text)
        {
            quickTypeButton2.Text = text;
        }
        public void SetQuickTypeButton3(string text)
        {
            quickTypeButton3.Text = text;
        }

        private void ApplyWord(string word)
        {
            try
            {
                // If not interacting with xWin App
                if (usingxWin == false)
                {
                    Log.GetLogger().Info("[QuickTypeBar] Switch to last window used to type: " + currentWindow);
                    FocusToPreviousWindow();

                    if (word != "")
                    {
                        Log.GetLogger().Info("[QuickTypeBar] Applying Word: " + word);
                        KeyboardInputsUnsubscribe();

                        // Apply the predictive word
                        string subword = word.Substring(word.IndexOf(typedWord) + typedWord.ToCharArray().Length);
                        Log.GetLogger().Info("[QuickTypeBar] Subword: " + subword);

                        Wrapper.SystemWrapper systemWrapper = new Wrapper.SystemWrapper();
                        systemWrapper.SimulateText(subword);

                        typedWord = word; // Apply the currently typed word
                        quickTypeButton1.Text = "";
                        quickTypeButton2.Text = "";
                        quickTypeButton3.Text = "";
                        Log.GetLogger().Info("[QuickTypeBar] Applied currently typed word: " + typedWord);

                        QuickTypeBarTimer.Stop(); // stop previous timer
                        QuickTypeBarTimer.Interval = quickTypeTimerInterval;
                        QuickTypeBarTimer.Start(); // start new timer
                        KeyboardInputsSubscribe();
                    }
                }
            }
            catch (Exception e)
            {
                Log.GetLogger().Error(e);
            }
        }

        private void quickTypeButton1_Click(object sender, EventArgs e)
        {
            Log.GetLogger().Info("QuickTypeBtn1 pressed");
            ApplyWord(quickTypeButton1.Text);
        }

        private void quickTypeButton2_Click(object sender, EventArgs e)
        {
            Log.GetLogger().Info("QuickTypeBtn2 pressed");
            ApplyWord(quickTypeButton2.Text);
        }

        private void quickTypeButton3_Click(object sender, EventArgs e)
        {
            Log.GetLogger().Info("QuickTypeBtn3 pressed");
            ApplyWord(quickTypeButton3.Text);
        }

        // Hide QuickType Bar when timer ticks
        private void QuickTypeBarTimer_Tick(object sender, EventArgs e)
        {
            QuickTypeBarTimer.Stop();
            this.Hide();
        }

        /*
         * Code to switch to last active window
         */
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool IsWindowVisible(IntPtr hWnd);

        [DllImport("user32.dll")]
        static extern IntPtr GetLastActivePopup(IntPtr hWnd);

        [DllImport("user32.dll", ExactSpelling = true)]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        const uint GA_PARENT = 1;
        const uint GA_ROOT = 2;
        const uint GA_ROOTOWNER = 3;
        IntPtr currentWindow;

        public IntPtr GetCurrentWindow()
        {
            IntPtr activeAppWindow = GetForegroundWindow();
            if (activeAppWindow == IntPtr.Zero)
                return IntPtr.Zero;

            IntPtr prevAppWindow = GetLastActivePopup(activeAppWindow);
            return IsWindowVisible(prevAppWindow) ? prevAppWindow : IntPtr.Zero;
        }

        public void FocusToPreviousWindow()
        {
            if (currentWindow != IntPtr.Zero)
                SetForegroundWindow(currentWindow);
        }

        /*
         * Code for moving the form by dragging anywhere on the form
         */
        private bool drag = false;
        private Point start_point = new Point(0, 0);
        private bool draggable = true;

        protected override void OnControlAdded(ControlEventArgs e)
        {
            if (this.Draggable)
            {
                e.Control.MouseDown += new MouseEventHandler(QuickTypeBar_MouseDown);
                e.Control.MouseUp += new MouseEventHandler(QuickTypeBar_MouseUp);
                e.Control.MouseMove += new MouseEventHandler(QuickTypeBar_MouseMove);
            }
            base.OnControlAdded(e);
        }

        void QuickTypeBar_MouseDown(object sender, MouseEventArgs e)
        {
            this.drag = true;
            this.start_point = new Point(e.X, e.Y);
        }

        void QuickTypeBar_MouseUp(object sender, MouseEventArgs e)
        {
            this.drag = false;
        }

        void QuickTypeBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.drag)
            {
                Point p1 = new Point(e.X, e.Y);
                Point p2 = this.PointToScreen(p1);
                Point p3 = new Point(p2.X - this.start_point.X,
                                     p2.Y - this.start_point.Y);
                this.Location = p3;
            }
        }

        public bool Draggable
        {
            set
            {
                this.draggable = value;
            }
            get
            {
                return this.draggable;
            }
        }

    }
}
