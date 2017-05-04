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
        private IKeyboardMouseEvents keyboardGlobalHook; // events to read keyboard's keydown and keypress.
        AutoCompleteDB db;

        public bool enableWordPrediction = false;
        public bool enableQuickType = false;

        private Keys[] keys = { Keys.None, Keys.None }; // array of 2 keys, Keys[0] is the previously entered key, Keys[1] is the currently entered key.
        public string typedWord = ""; // word that user's typing
        public string predictiveSubWord = ""; // subword of the word that needs to be showed to the user
        private List<Keys> currentlyPressedShortcut = new List<Keys>();

        public int quickTypeTimerInterval = 5000;
        public List<Keys> suggestion1Shortcut = new List<Keys>(); // shortcut for suggestion 1
        public List<Keys> suggestion2Shortcut = new List<Keys>(); // shortcut for suggestion 2
        public List<Keys> suggestion3Shortcut = new List<Keys>(); // shortcut for suggestion 3
        public bool usingShortcuts = false;
        private bool timerStopped = false;

        public AutoComplete()
        {
            InitializeComponent();
            quickTypeButton1.Text = "";
            quickTypeButton2.Text = "";
            quickTypeButton3.Text = "";
            db = new AutoCompleteDB();
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

        // Convert a key to a coressponding character, which is returned as a string
        public string KeysToChar(Keys[] keys)
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
                    if (keys[0] == Keys.LShiftKey)
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
                // if key is not alphanumeric keys
                else
                {
                    switch (key)
                    {
                        case Keys.Oem1:
                            {
                                if (keys[0] == Keys.LShiftKey) { c = "" + ':'; }
                                else { c = "" + ';'; }
                                break;
                            }
                        case Keys.Oem7:
                            {
                                if (keys[0] == Keys.LShiftKey) { c = "" + '"'; }
                                else { c = "" + (char)39; }
                                break;
                            }
                        case Keys.Oemtilde:
                            {
                                if (keys[0] == Keys.LShiftKey) { c = "" + '~'; }
                                else { c = "" + '`'; }
                                break;
                            }
                        case Keys.Oemcomma:
                            {
                                if (keys[0] == Keys.LShiftKey) { c = "" + '<'; }
                                else { c = "" + ','; }
                                break;
                            }
                        case Keys.OemPeriod:
                            {
                                if (keys[0] == Keys.LShiftKey) { c = "" + '>'; }
                                else { c = "" + '.'; }
                                break;
                            }
                        case Keys.OemQuestion:
                            {
                                if (keys[0] == Keys.LShiftKey) { c = "" + '?'; }
                                else { c = "" + '/'; }
                                break;
                            }
                        case Keys.OemMinus:
                            {
                                if (keys[0] == Keys.LShiftKey) { c = "" + '_'; }
                                else { c = "" + '-'; }
                                break;
                            }
                        case Keys.Oemplus:
                            {
                                if (keys[0] == Keys.LShiftKey) { c = "" + '+'; }
                                else { c = "" + '='; }
                                break;
                            }
                        case Keys.OemOpenBrackets:
                            {
                                if (keys[0] == Keys.LShiftKey) { c = "" + '{'; }
                                else { c = "" + '['; }
                                break;
                            }
                        case Keys.Oem6:
                            {
                                if (keys[0] == Keys.LShiftKey) { c = "" + '}'; }
                                else { c = "" + ']'; }
                                break;
                            }
                        case Keys.Oem5:
                            {
                                if (keys[0] == Keys.LShiftKey) { c = "" + '|'; }
                                else { c = "" + '\\'; }
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
                //Log.GetLogger().Debug("[PredictWord] currently typed word: " + typedWord + " length: " + typedWord.ToCharArray().Length + ")");
                //Log.GetLogger().Debug("[PredictWord] predictive word (top word): " + word);
                //Log.GetLogger().Debug("[PredictWord] subWord: " + predictiveSubWord + " length: " + predictiveSubWord.Length);

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

        // When a key is down
        private void GlobalHookKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                currentWindow = GetCurrentWindow();
                ////Log.GetLogger().Debug("[Key Down] Current Active Window: " + currentWindow);
                
                // Get the Id of xWin App
                IntPtr xWinId = IntPtr.Zero;
                foreach (Process p in Process.GetProcessesByName("xWin"))
                { if (p.MainWindowHandle != IntPtr.Zero) xWinId = p.MainWindowHandle; }
                ////Log.GetLogger().Debug("[Key Down] xWin Window ID: " + xWinId);

                // If not interacting with xWin App
                if (currentWindow != xWinId)
                {
                    Keys currentKey = e.KeyCode;

                    // don't add key to list if it's already being pressed
                    if (!currentlyPressedShortcut.Contains(currentKey)) { currentlyPressedShortcut.Add(currentKey); }

                    //Log.GetLogger().Debug("[Key Down]");
                    KeyboardInputsUnsubscribe(); // Stop reading keyboard inputs

                    // show quicktype bar
                    if (enableQuickType)
                    {
                        this.TopMost = true;
                        this.Show();
                    }

                    // Suppress to bind key down
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    
                    // If only 1 key is being pressed down
                    if (currentlyPressedShortcut.Count == 1)
                    {
                        Wrapper.SystemWrapper systemWrapper = new Wrapper.SystemWrapper();

                        /*
                         * [Word Prediction]
                         */
                        // If key is Tab key and currently typed word is not empty
                        // Complete the predictive word
                        if (currentKey == Keys.Tab && typedWord != "" && predictiveSubWord != "")
                        {
                            // Apply the predictive word
                            char[] array = predictiveSubWord.ToArray<char>();
                            foreach (char c in array)
                            {
                                systemWrapper.SimulateKeyPress((WindowsInput.Native.VirtualKeyCode)Keys.Right); // move cursor to the right
                            }

                            typedWord += predictiveSubWord; // set currently typed word to the predictive word
                            predictiveSubWord = ""; // reset predictive Subword
                            //Log.GetLogger().Debug("[Key Down] [Word Prediction] [1] Applied currently typed word: " + typedWord);
                        }
                        // If key is Enter Key, Space Key, Period key, Comma key, or Tab key without predictive subword
                        // this indicates the beginning of a new word
                        // So save the currently typed word to the database
                        else if (currentKey == Keys.Enter || currentKey == Keys.Space || currentKey == Keys.OemPeriod || currentKey == Keys.Oemcomma || (currentKey == Keys.Tab && predictiveSubWord == ""))
                        {
                            // Press the key
                            //Log.GetLogger().Debug("[Key Down] [1] Press key : " + currentKey);
                            systemWrapper.SimulateKeyPress((WindowsInput.Native.VirtualKeyCode) currentKey);

                            if (typedWord != "")
                            {
                                db.UpdateOrInsertWord(typedWord); // Update non-empty word into database
                                //Log.GetLogger().Debug("[Key Down] [1] Updated new word");
                                typedWord = ""; // reset the word
                            }
                        }
                        // If key is Back key
                        // this indicates that currently typed word is deleted by 1 character
                        else if (currentKey == Keys.Back) // Delete character
                        {
                            // Press the key
                            //Log.GetLogger().Debug("[Key Down] [1] Press key : " + currentKey);
                            systemWrapper.SimulateKeyPress((WindowsInput.Native.VirtualKeyCode) currentKey);

                            // If there's a predictive subword, remove it.
                            if (predictiveSubWord != "")
                            { systemWrapper.SimulateKeyPress((WindowsInput.Native.VirtualKeyCode)Keys.Back); }

                            // Remove the last character from currently typed word
                            if (typedWord.Length > 0) { typedWord = typedWord.Remove(typedWord.Length - 1); }
                            //Log.GetLogger().Debug("[Key Down] [1] Backspace: removed last character, currently typed word is " + typedWord);
                        }
                        else
                        {
                            // Press the key
                            //Log.GetLogger().Debug("[Key Down] [1] Press key : " + currentKey);
                            systemWrapper.SimulateKeyPress((WindowsInput.Native.VirtualKeyCode) currentKey);

                            keys[0] = Keys.None;
                            keys[1] = currentKey;
                            string c = KeysToChar(keys);
                            //Log.GetLogger().Debug("[Key Down][1] KeyToChar: " + c);
                            typedWord += c;
                            //Log.GetLogger().Debug("[Key Down][1] word typed: " + typedWord + " (length: " + typedWord.Length + ")");
                            ////Log.GetLogger().Debug("[Key Down] Contain null char: " + typedWord.Contains('\0'));
                        }

                        System.Threading.Thread.Sleep(100);
                    } // end 1-key if statement

                    //System.Threading.Thread.Sleep(50);

                    // stop previous timer
                    StopTimer();

                    KeyboardInputsSubscribe(); // Start reading keyboard input
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
                ////Log.GetLogger().Debug("[Key Up] Current Active Window: " + currentWindow);
                
                // Get the Id of xWin App
                IntPtr xWinId = IntPtr.Zero;
                foreach (Process p in Process.GetProcessesByName("xWin"))
                { if (p.MainWindowHandle != IntPtr.Zero) xWinId = p.MainWindowHandle; }
                ////Log.GetLogger().Debug("[Key Up] xWin Window ID: " + xWinId);

                // If not interacting with xWin App
                if (currentWindow != xWinId)
                {
                    Log.GetLogger().Debug("[Key Up] " + e.KeyCode);
                    KeyboardInputsUnsubscribe(); // Stop reading keyboard inputs

                    Wrapper.SystemWrapper systemWrapper = new Wrapper.SystemWrapper();
                    // If there're 2 keys pressed and they are shift + another key
                    if (currentlyPressedShortcut.Count == 2 && (currentlyPressedShortcut.ToArray()[0] == Keys.LShiftKey || currentlyPressedShortcut.ToArray()[0] == Keys.RShiftKey))
                    {
                        Keys key = currentlyPressedShortcut.ToArray()[1];

                        // Press shift + another key
                        systemWrapper.SimulateKeyDown((WindowsInput.Native.VirtualKeyCode)Keys.LShiftKey);
                        systemWrapper.SimulateKeyPress((WindowsInput.Native.VirtualKeyCode)key);
                        systemWrapper.SimulateKeyUp((WindowsInput.Native.VirtualKeyCode)Keys.LShiftKey);

                        // Convert shift + another key to a char if possible
                        keys[0] = Keys.LShiftKey;
                        keys[1] = key;
                        string c = KeysToChar(keys);
                        //Log.GetLogger().Debug("[Key Up][2] KeyToChar: " + c);
                        typedWord += c;
                        //Log.GetLogger().Debug("[Key Up][2] word typed: " + typedWord + " (length: " + typedWord.Length + ")");
                        ////Log.GetLogger().Debug("[Key Up][2] Contain null char: " + typedWord.Contains('\0'));
                    }
                    // If there's a shortcut being pressed of size at least 2
                    else if (currentlyPressedShortcut.Count > 1)
                    {
                        Log.GetLogger().Debug("[Key Up] Currently pressed shortcut: " + string.Join("+ ", currentlyPressedShortcut.ToArray()));
                        if (usingShortcuts)
                        {
                            // If suggestion 1's shortcut is pressed and usingShortcuts is enabled
                            if (usingShortcuts && (suggestion1Shortcut.Count != 0) && (currentlyPressedShortcut.Count == suggestion1Shortcut.Count) && !currentlyPressedShortcut.Except(suggestion1Shortcut).Any())
                            {
                                Log.GetLogger().Debug("[Key Up] Applying suggestion 1 using shortcut!");
                                ApplyWord(quickTypeButton1.Text);
                                Log.GetLogger().Debug("[Key Up] Applied suggestion 1 using shortcut!");
                            }
                            // If suggestion 2's shortcut is pressed and usingShortcuts is enabled
                            else if (usingShortcuts && (suggestion2Shortcut.Count != 0) && (currentlyPressedShortcut.Count == suggestion2Shortcut.Count) && !currentlyPressedShortcut.Except(suggestion2Shortcut).Any())
                            {
                                //Log.GetLogger().Debug("[Key Up] Applying suggestion 2 using shortcut!");
                                ApplyWord(quickTypeButton2.Text);
                            }
                            // If suggestion 3's shortcut is pressed and usingShortcuts is enabled
                            else if (usingShortcuts && (suggestion3Shortcut.Count != 0) && (currentlyPressedShortcut.Count == suggestion3Shortcut.Count) && !currentlyPressedShortcut.Except(suggestion3Shortcut).Any())
                            {
                                //Log.GetLogger().Debug("[Key Up] Applying suggestion 3 using shortcut!");
                                ApplyWord(quickTypeButton3.Text);
                            }
                        }
                        else
                        {
                            this.Hide(); // hide quicktype bar
                            XKeyBoard keyboard = new XKeyBoard();
                            keyboard.PressShortcut(currentlyPressedShortcut.ToArray());
                            //Log.GetLogger().Debug("[Key Up] Applied shortcut!");
                        }
                    }
                    // If there's only 1 key pressed
                    else if (currentlyPressedShortcut.Count == 1)
                    {
                        Keys currentKey = currentlyPressedShortcut[0];
                        // reset quicktype bar
                        SetQuickTypeButton1("");
                        SetQuickTypeButton2("");
                        SetQuickTypeButton3("");

                        // If key is not Enter key, Space key, Tab key, Comma key, or Period key
                        // find top 3 words from database
                        if (currentKey != Keys.Enter && currentKey != Keys.Space && currentKey != Keys.Tab && currentKey != Keys.OemPeriod && currentKey != Keys.Oemcomma)
                        {
                            // get top three words
                            List<string> topThree = db.GetTopThreeWords(typedWord);
                            string logMsg = "top three words: ";
                            foreach (string word in topThree) { logMsg += word + " "; }
                            //Log.GetLogger().Debug("[Key Up] [1] " + logMsg);

                            // If there exists at least a word that matches the currently typed word
                            if (topThree.Count > 0)
                            {
                                /*
                                 * [Word Prediction]
                                 * Show top word from available top 3 words if word prediction option is enabled
                                 */ 
                                if (enableWordPrediction)
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
                                }

                                /*
                                 * [Quicktype suggestions]
                                 * Set word suggestions for quicktype bar
                                 */
                                if (enableQuickType)
                                {
                                    string[] topTmp = { "", "", "" };
                                    for (int i = 0; i < topThree.Count; i++)
                                    { if (typedWord != topThree[i]) { topTmp[i] = topThree[i]; } }
                                    SetQuickTypeButton1(topTmp[0]);
                                    SetQuickTypeButton2(topTmp[1]);
                                    SetQuickTypeButton3(topTmp[2]);
                                }
                            }
                        }
                    }
                 
                    //System.Threading.Thread.Sleep(50);

                    // start new timer
                    StartTimer();

                    KeyboardInputsSubscribe(); // Start reading keyboard inputs
                }

                // reset currently pressed shortcut
                currentlyPressedShortcut.Clear();
                Log.GetLogger().Debug("[Key Up] Currently pressed shortcut: " + string.Join("+ ", currentlyPressedShortcut.ToArray()));
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
                StopTimer();

                if (word != "")
                {
                    //Log.GetLogger().Debug("[QuickTypeBar] Applying Word: " + word);
                    KeyboardInputsUnsubscribe(); // Stop reading keyboard inputs

                    // Apply the predictive word
                    //Log.GetLogger().Debug("[QuickTypeBar] Currently Typed Word: " + typedWord + " (length: " + typedWord.ToArray().Length + ")");
                    string subword = word.Substring(word.IndexOf(typedWord) + typedWord.ToArray().Length);
                    //Log.GetLogger().Debug("[QuickTypeBar] Subword: " + subword);

                    // Apply subword
                    Wrapper.SystemWrapper systemWrapper = new Wrapper.SystemWrapper();
                    systemWrapper.SimulateText(subword);

                    typedWord = word; // set the currently typed word
                    predictiveSubWord = ""; // reset predictive Subword

                    // Reset all suggestions
                    quickTypeButton1.Text = "";
                    quickTypeButton2.Text = "";
                    quickTypeButton3.Text = "";
                    //Log.GetLogger().Debug("[QuickTypeBar] Successfully applied currently typed word: " + typedWord);

                    KeyboardInputsSubscribe(); // Start reading keyboard input
                }
            }
            catch (Exception e)
            {
                Log.GetLogger().Error(e);
            }
        }

        private void quickTypeButton1_Click(object sender, EventArgs e)
        {
            // If not dragging the quicktype bar
            if (mouseMoved == false)
            {
                //Log.GetLogger().Debug("QuickTypeBtn1 pressed");
                //Log.GetLogger().Debug("Switch to last window used to type: " + currentWindow);

                FocusToPreviousWindow();
                ApplyWord(quickTypeButton1.Text);

                // start new timer
                StartTimer();
            }
        }

        private void quickTypeButton2_Click(object sender, EventArgs e)
        {
            // If not dragging the quicktype bar
            if (mouseMoved == false)
            {
                //Log.GetLogger().Debug("QuickTypeBtn2 pressed");
                //Log.GetLogger().Debug("Switch to last window used to type: " + currentWindow);

                FocusToPreviousWindow();
                ApplyWord(quickTypeButton2.Text);

                // start new timer
                StartTimer();
            }
        }

        private void quickTypeButton3_Click(object sender, EventArgs e)
        {
            // If not dragging the quicktype bar
            if (mouseMoved == false)
            {
                //Log.GetLogger().Debug("QuickTypeBtn3 pressed");
                //Log.GetLogger().Debug("Switch to last window used to type: " + currentWindow);

                FocusToPreviousWindow();
                ApplyWord(quickTypeButton3.Text);

                // start new timer
                StartTimer();
            }
        }

        private void StopTimer()
        {
            try
            {
                if (timerStopped == false)
                {
                    QuickTypeBarTimer.Stop(); // stop current timer
                    timerStopped = true;
                    //Log.GetLogger().Debug("Timer stopped");
                }
            }
            catch (Exception e)
            {
                Log.GetLogger().Error(e);
            }
        }

        private void StartTimer()
        {
            try
            {
                if (timerStopped == true)
                {
                    QuickTypeBarTimer.Interval = quickTypeTimerInterval;
                    QuickTypeBarTimer.Start(); // start new timer
                    timerStopped = false;
                    //Log.GetLogger().Debug("Timer started");
                }
            }
            catch (Exception e)
            {
                Log.GetLogger().Error(e);
            }
        }

        // Hide QuickType Bar when timer ticks
        private void QuickTypeBarTimer_Tick(object sender, EventArgs e)
        {
            StopTimer();
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

        //const uint GA_PARENT = 1;
        //const uint GA_ROOT = 2;
        //const uint GA_ROOTOWNER = 3;
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
        private bool mouseMoved = false;
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
            StopTimer();
        }

        void QuickTypeBar_MouseUp(object sender, MouseEventArgs e)
        {
            this.drag = false;
            mouseMoved = false;
            StartTimer();
        }

        void QuickTypeBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.drag)
            {
                mouseMoved = true;
                //Log.GetLogger().Debug("Dragging quicktype bar");

                Point p1 = new Point(e.X, e.Y);
                Point p2 = this.PointToScreen(p1);
                Point p3 = new Point(p2.X - this.start_point.X,
                                     p2.Y - this.start_point.Y);
                this.Location = p3;
                
                //Log.GetLogger().Debug("Stopped dragging quicktype bar");
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
