using Gma.System.MouseKeyHook;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using xWin.Library;

namespace xWin.Forms.AutoCompleteForms
{
    public partial class AutoComplete : Form
    {
        private static IKeyboardMouseEvents keyboardGlobalHook; // events to read keyboard's keydown and keypress.
        AutoCompleteDB db = new AutoCompleteDB();

        public bool enableWordPrediction = true;
        public bool enableQuickType = true;

        private Keys[] keys = { Keys.None, Keys.None }; // array of 2 keys, Keys[0] is the previously entered key, Keys[1] is the currently entered key.
        private string typedWord = ""; // word that user's typing
        private string predictiveSubWord = ""; // subword of the word that needs to be showed to the user
        private List<Keys> currentlyPressedShortcut = new List<Keys>();

        public int quickTypeTimerInterval = 5000;
        public List<Keys> suggestion1Shortcut = new List<Keys>(); // shortcut for suggestion 1
        public List<Keys> suggestion2Shortcut = new List<Keys>(); // shortcut for suggestion 2
        public List<Keys> suggestion3Shortcut = new List<Keys>(); // shortcut for suggestion 3

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
            string c = ""; // default empty string
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
                if (!currentlyPressedShortcut.Contains(e.KeyCode)) { currentlyPressedShortcut.Add(e.KeyCode); }

                currentWindow = GetCurrentWindow();
                Log.GetLogger().Debug("[Key Down] Current Active Window: " + currentWindow);
                // Get the Id of xWin App
                IntPtr xWinId = IntPtr.Zero;
                foreach (Process p in Process.GetProcessesByName("xWin"))
                {
                    xWinId = p.MainWindowHandle;
                }
                Log.GetLogger().Debug("[Key Down] xWin Window ID: " + xWinId);

                // If not interacting with xWin App
                if (currentWindow != xWinId)
                {
                    KeyboardInputsUnsubscribe();
                    if (enableQuickType)
                    {
                        this.TopMost = true;
                        this.Show();
                    }

                    // Suppress to bind key down
                    e.Handled = true;
                    e.SuppressKeyPress = true;

                    // If there's no shortcut currently being pressed
                    if (currentlyPressedShortcut.Count == 1)
                    {
                        // If keydown is Tab key
                        // and currently typed word is not empty and it doesn't contain null character
                        // Suppress actual tab key and complete the predictive word
                        if (e.KeyCode == Keys.Tab && typedWord != "" && predictiveSubWord != "")
                        {
                            // Complete the predictive word
                            char[] array = predictiveSubWord.ToArray<char>();
                            Wrapper.SystemWrapper systemWrapper = new Wrapper.SystemWrapper();
                            foreach (char c in array)
                            { systemWrapper.SimulateKeyPress((WindowsInput.Native.VirtualKeyCode)Keys.Right); }

                            typedWord += predictiveSubWord; // Apply the currently typed word
                            predictiveSubWord = ""; // reset predictive Subword
                            Log.GetLogger().Info("[Key Down] Applied currently typed word: " + typedWord);
                        }
                        // New word
                        else if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Space || (e.KeyCode == Keys.Tab && predictiveSubWord == ""))
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
                            Log.GetLogger().Info("[Key Down] Backspace: removed last character, currently typed word is " + typedWord);
                        }
                        else
                        {
                            keys[1] = e.KeyCode;
                            string c = KeyToChar(keys);
                            Log.GetLogger().Info("[Key Down] KeyToChar: " + c);
                            typedWord += c;
                            Log.GetLogger().Info("[Key Down] word typed: " + typedWord + " (length: " + typedWord.Length + ")");
                            Log.GetLogger().Debug("[Key Down] Contain null char: " + typedWord.Contains('\0'));
                        }
                    }
                    //System.Threading.Thread.Sleep(100);
                    KeyboardInputsSubscribe();
                }
            }
            catch (Exception ex)
            {
                Log.GetLogger().Error(ex);
                Log.GetLogger().Error("[Key Down]:");
            }
        }

        // When a key is up
        private void GlobalHookKeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                currentWindow = GetCurrentWindow();
                Log.GetLogger().Debug("[Key Up] Current Active Window: " + currentWindow);
                // Get the Id of xWin App
                IntPtr xWinId = IntPtr.Zero;
                foreach (Process p in Process.GetProcessesByName("xWin"))
                {
                    xWinId = p.MainWindowHandle;
                }
                Log.GetLogger().Debug("[Key Up] xWin Window ID: " + xWinId);

                // If not interacting with xWin App
                if (currentWindow != xWinId)
                {
                    KeyboardInputsUnsubscribe(); // Stop reading keyboard inputs

                    Log.GetLogger().Info("[Key Up] Currently pressed shortcut: " + string.Join("+ ", currentlyPressedShortcut.ToArray()));
                    // If suggestion 1's shortcut is pressed
                    if ((suggestion1Shortcut.Count != 0) && (currentlyPressedShortcut.Count == suggestion1Shortcut.Count) && !currentlyPressedShortcut.Except(suggestion1Shortcut).Any())
                    {
                        Log.GetLogger().Info("[Key Up] Applying suggestion 1 using shortcut!");
                        ApplyWord(quickTypeButton1.Text);
                    }
                    // If suggestion 2's shortcut is pressed
                    else if ((suggestion2Shortcut.Count != 0) && (currentlyPressedShortcut.Count == suggestion2Shortcut.Count) && !currentlyPressedShortcut.Except(suggestion2Shortcut).Any())
                    {
                        Log.GetLogger().Info("[Key Up] Applying suggestion 2 using shortcut!");
                        ApplyWord(quickTypeButton2.Text);
                    }
                    // If suggestion 3's shortcut is pressed
                    else if ((suggestion3Shortcut.Count != 0) && (currentlyPressedShortcut.Count == suggestion3Shortcut.Count) && !currentlyPressedShortcut.Except(suggestion3Shortcut).Any())
                    {
                        Log.GetLogger().Info("[Key Up] Applying suggestion 3 using shortcut!");
                        ApplyWord(quickTypeButton3.Text);
                    }
                    else if (currentlyPressedShortcut.Count > 1)
                    {
                        Log.GetLogger().Info("[Key Up] Applying shortcut!");
                        XKeyBoard keyboard = new XKeyBoard();
                        keyboard.PressShortcut(currentlyPressedShortcut.ToArray());
                    }
                    else
                    {
                        
                        // reset quicktype bar
                        SetQuickTypeButton1("");
                        SetQuickTypeButton2("");
                        SetQuickTypeButton3("");

                        Wrapper.SystemWrapper systemWrapper = new Wrapper.SystemWrapper();
                        if ((e.KeyCode == Keys.Tab && predictiveSubWord == "") || (e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Space))
                        {
                            // press tab key when there's no word prediction
                            systemWrapper.SimulateKeyPress((WindowsInput.Native.VirtualKeyCode)e.KeyCode);
                            Log.GetLogger().Info("[Key Up] Pressed Key " + e.KeyCode);

                        }
                        else if (e.KeyCode != Keys.Enter && e.KeyCode != Keys.Space && e.KeyCode != Keys.Tab)
                        {
                            // press the key
                            systemWrapper.SimulateKeyPress((WindowsInput.Native.VirtualKeyCode)e.KeyCode);

                            List<string> topThree = db.GetTopThreeWords(typedWord);
                            string logMsg = "top three words: ";
                            foreach (string word in topThree) { logMsg += word + " "; }
                            Log.GetLogger().Info("[Key Up] " + logMsg);

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
                    }

                    keys[0] = e.KeyCode;
                    KeyboardInputsSubscribe(); // Start reading keyboard inputs
                    currentlyPressedShortcut.Clear(); // reset currently pressed shortcut
                    QuickTypeBarTimer.Stop(); // stop previous timer
                    QuickTypeBarTimer.Interval = quickTypeTimerInterval;
                    QuickTypeBarTimer.Start(); // start new timer
                    System.Threading.Thread.Sleep(50);
                }
            }
            catch (Exception ex)
            {
                Log.GetLogger().Error(ex);
                Log.GetLogger().Error("[Key Up] Error when key is up :");
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
                if (word != "")
                {
                    Log.GetLogger().Info("[QuickTypeBar] Applying Word: " + word);
                    KeyboardInputsUnsubscribe();

                    // Apply the predictive word
                    Log.GetLogger().Info("[QuickTypeBar] TypedWord: " + typedWord);
                    Log.GetLogger().Info("[QuickTypeBar] typedWord.ToArray().Length: " + typedWord.ToArray().Length);
                    string subword = word.Substring(word.IndexOf(typedWord) + typedWord.ToArray().Length);
                    Log.GetLogger().Info("[QuickTypeBar] Subword: " + subword);

                    Wrapper.SystemWrapper systemWrapper = new Wrapper.SystemWrapper();
                    systemWrapper.SimulateText(subword);

                    typedWord = word; // Apply the currently typed word
                    // reset all suggestions
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
            catch (Exception e)
            {
                Log.GetLogger().Error(e);
            }
        }

        private void quickTypeButton1_Click(object sender, EventArgs e)
        {
            Log.GetLogger().Info("QuickTypeBtn1 pressed");
            Log.GetLogger().Info("Switch to last window used to type: " + currentWindow);
            FocusToPreviousWindow();
            ApplyWord(quickTypeButton1.Text);
        }

        private void quickTypeButton2_Click(object sender, EventArgs e)
        {
            Log.GetLogger().Info("QuickTypeBtn2 pressed");
            Log.GetLogger().Info("Switch to last window used to type: " + currentWindow);
            FocusToPreviousWindow();
            ApplyWord(quickTypeButton2.Text);
        }

        private void quickTypeButton3_Click(object sender, EventArgs e)
        {
            Log.GetLogger().Info("QuickTypeBtn3 pressed");
            Log.GetLogger().Info("Switch to last window used to type: " + currentWindow);
            FocusToPreviousWindow();
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
