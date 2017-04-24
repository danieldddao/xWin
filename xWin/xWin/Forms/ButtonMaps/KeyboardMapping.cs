using Gma.System.MouseKeyHook;
using System;
using System.Windows.Forms;
using xWin.Library;
using xWin.Wrapper;

namespace xWin.Forms.ButtonMaps
{
    public partial class KeyboardMapping : Form
    {
        byte VK_SHIFT = 0x10;
        byte VK_CONTROL = 0x11;
        byte VK_ALT = 0x12;
        SystemWrapper systemWrapper;
        public byte CurrentKey { get; set; }

        public KeyboardMapping()
        {
            InitializeComponent();
            CurrentKey = (byte) Keys.None;
            systemWrapper = new SystemWrapper();
        }

        private void KeyboardMapping_Load(object sender, EventArgs e)
        {
            Subscribe();
        }

        private void btnESC_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.Escape;
            Unsubscribe();
            this.Close();
        }

        private void btnF1_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.F1;
            Unsubscribe();
            this.Close();
        }

        private void btnF2_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.F2;
            Unsubscribe();
            this.Close();
        }

        private void btnF3_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.F3;
            Unsubscribe();
            this.Close();
        }

        private void btnF4_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.F4;
            Unsubscribe();
            this.Close();
        }

        private void btnF5_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.F5;
            Unsubscribe();
            this.Close();
        }

        private void btnF6_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.F6;
            Unsubscribe();
            this.Close();
        }

        private void btnF7_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.F7;
            Unsubscribe();
            this.Close();
        }

        private void btnF8_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.F8;
            Unsubscribe();
            this.Close();
        }

        private void btnF9_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.F9;
            Unsubscribe();
            this.Close();
        }

        private void btnF10_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.F10;
            Unsubscribe();
            this.Close();
        }

        private void btnF11_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.F11;
            Unsubscribe();
            this.Close();
        }

        private void btnF12_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.F12;
            Unsubscribe();
            this.Close();
        }

        private void btnTILDE_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) systemWrapper.ScanKey('~');
            Unsubscribe();
            this.Close();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.D1;
            Unsubscribe();
            this.Close();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.D2;
            Unsubscribe();
            this.Close();
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.D3;
            Unsubscribe();
            this.Close();
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.D4;
            Unsubscribe();
            this.Close();
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.D5;
            Unsubscribe();
            this.Close();
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.D6;
            Unsubscribe();
            this.Close();
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.D7;
            Unsubscribe();
            this.Close();
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.D8;
            Unsubscribe();
            this.Close();
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.D9;
            Unsubscribe();
            this.Close();
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte)Keys.D0;
            Unsubscribe();
            this.Close();
        }

        private void btnMINUS_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.OemMinus;
            Unsubscribe();
            this.Close();
        }

        private void btnEQUALS_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.Oemplus;
            Unsubscribe();
            this.Close();
        }

        private void btnBACKSPACE_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.Back;
            Unsubscribe();
            this.Close();
        }

        private void btnTAB_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.Tab;
            Unsubscribe();
            this.Close();
        }

        private void btnQ_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.Q;
            Unsubscribe();
            this.Close();
        }

        private void btnW_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.W;
            Unsubscribe();
            this.Close();
        }

        private void btnE_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.E;
            Unsubscribe();
            this.Close();
        }

        private void btnR_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.R;
            Unsubscribe();
            this.Close();
        }

        private void btnT_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.T;
            Unsubscribe();
            this.Close();
        }

        private void btnY_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.Y;
            Unsubscribe();
            this.Close();
        }

        private void btnU_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.U;
            Unsubscribe();
            this.Close();
        }

        private void btnI_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.I;
            Unsubscribe();
            this.Close();
        }

        private void btnO_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.O;
            Unsubscribe();
            this.Close();
        }

        private void btnP_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.P;
            Unsubscribe();
            this.Close();
        }

        private void btnOPENBRACKET_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.OemOpenBrackets;
            Unsubscribe();
            this.Close();
        }

        private void btnCLOSEBRACKET_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.OemCloseBrackets;
            Unsubscribe();
            this.Close();
        }

        private void btnBACKSLASH_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.OemBackslash;
            Unsubscribe();
            this.Close();
        }

        private void btnCAPS_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.CapsLock;
            Unsubscribe();
            this.Close();
        }

        private void btnA_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.A;
            Unsubscribe();
            this.Close();
        }

        private void btnS_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.S;
            Unsubscribe();
            this.Close();
        }

        private void btnD_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.D;
            Unsubscribe();
            this.Close();
        }

        private void btnF_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.F;
            Unsubscribe();
            this.Close();
        }

        private void btnG_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.G;
            Unsubscribe();
            this.Close();
        }

        private void btnH_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.H;
            Unsubscribe();
            this.Close();
        }

        private void btnJ_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.J;
            Unsubscribe();
            this.Close();
        }

        private void btnK_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.K;
            Unsubscribe();
            this.Close();
        }

        private void btnL_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.L;
            Unsubscribe();
            this.Close();
        }

        private void btnSEMICOLON_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.OemSemicolon;
            Unsubscribe();
            this.Close();
        }

        private void btnAPOSTROPHE_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.OemQuotes;
            Unsubscribe();
            this.Close();
        }

        private void btnRETURN_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.Enter;
            Unsubscribe();
            this.Close();
        }

        private void btnLSHIFT_Click(object sender, EventArgs e)
        {
            CurrentKey = VK_SHIFT;
            Unsubscribe();
            this.Close();
        }

        private void btnZ_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.Z;
            Unsubscribe();
            this.Close();
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.X;
            Unsubscribe();
            this.Close();
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.C;
            Unsubscribe();
            this.Close();
        }

        private void btnV_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.V;
            Unsubscribe();
            this.Close();
        }

        private void btnB_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.B;
            Unsubscribe();
            this.Close();
        }

        private void btnN_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.N;
            Unsubscribe();
            this.Close();
        }

        private void btnM_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.M;
            Unsubscribe();
            this.Close();
        }

        private void btnCOMMA_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.Oemcomma;
            Unsubscribe();
            this.Close();
        }

        private void btnPERIOD_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.OemPeriod;
            Unsubscribe();
            this.Close();
        }

        private void btnSLASH_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.OemQuestion;
            Unsubscribe();
            this.Close();
        }

        private void btnRSHIFT_Click(object sender, EventArgs e)
        {
            CurrentKey = VK_SHIFT;
            Unsubscribe();
            this.Close();
        }

        private void btnLCTRL_Click(object sender, EventArgs e)
        {
            CurrentKey = VK_CONTROL;
            Unsubscribe();
            this.Close();
        }

        private void btnLWin_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.LWin;
            Unsubscribe();
            this.Close();
        }

        private void btnLAlt_Click(object sender, EventArgs e)
        {
            CurrentKey = VK_ALT;
            Unsubscribe();
            this.Close();
        }

        private void btnSPACE_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.Space;
            Unsubscribe();
            this.Close();
        }

        private void buttonRWin_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.RWin;
            Unsubscribe();
            this.Close();
        }

        private void btnRALT_Click(object sender, EventArgs e)
        {
            CurrentKey = VK_ALT;
            Unsubscribe();
            this.Close();
        }

        private void btnRCTRL_Click(object sender, EventArgs e)
        {
            CurrentKey = VK_CONTROL;
            Unsubscribe();
            this.Close();
        }

        private void buttonLeft_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.Left;
            Unsubscribe();
            this.Close();
        }

        private void Right_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.Right;
            Unsubscribe();
            this.Close();
        }

        private void buttonUp_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.Up;
            Unsubscribe();
            this.Close();
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.Down;
            Unsubscribe();
            this.Close();
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.PrintScreen;
            Unsubscribe();
            this.Close();
        }

        private void btnScroll_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.Scroll;
            Unsubscribe();
            this.Close();
        }

        private void btnBreak_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.Pause;
            Unsubscribe();
            this.Close();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.Insert;
            Unsubscribe();
            this.Close();
        }

        private void btnHOME_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.Home;
            Unsubscribe();
            this.Close();
        }

        private void btnPGUP_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.PageUp;
            Unsubscribe();
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.Delete;
            Unsubscribe();
            this.Close();
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.End;
            Unsubscribe();
            this.Close();
        }

        private void btnPageDown_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.PageDown;
            Unsubscribe();
            this.Close();
        }

        private void btnNumLock_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.NumLock;
            Unsubscribe();
            this.Close();
        }

        private void btnNumSlash_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.Divide;
            Unsubscribe();
            this.Close();
        }

        private void btnNumStar_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.Multiply;
            Unsubscribe();
            this.Close();
        }

        private void btnNumDash_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.Subtract;
            Unsubscribe();
            this.Close();
        }

        private void btnNUM7_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.NumPad7;
            Unsubscribe();
            this.Close();
        }

        private void btnNUM8_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte)Keys.NumPad8;
            Unsubscribe();
            this.Close();
        }

        private void btnNUM9_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte)Keys.NumPad9;
            Unsubscribe();
            this.Close();
        }

        private void btnNUM4_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte)Keys.NumPad4;
            Unsubscribe();
            this.Close();
        }

        private void btnNUM5_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte)Keys.NumPad5;
            Unsubscribe();
            this.Close();
        }

        private void btnNUM6_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte)Keys.NumPad6;
            Unsubscribe();
            this.Close();
        }

        private void btnNUM1_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte)Keys.NumPad1;
            Unsubscribe();
            this.Close();
        }

        private void btnNUM2_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte)Keys.NumPad2;
            Unsubscribe();
            this.Close();
        }

        private void btnNUM3_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte)Keys.NumPad3;
            Unsubscribe();
            this.Close();
        }

        private void btnNUM0_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte)Keys.NumPad0;
            Unsubscribe();
            this.Close();
        }

        private void btnNUMPLUS_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.Add;
            Unsubscribe();
            this.Close();
        }

        private void btnNUMDOT_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.Decimal;
            Unsubscribe();
            this.Close();
        }

        private void btnNUMENTER_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.Enter;
            Unsubscribe();
            this.Close();
        }

        private void btnAcute_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.Oemtilde;
            Unsubscribe();
            this.Close();
        }

        private void btnExclamationMark_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte)systemWrapper.ScanKey('!');
            Unsubscribe();
            this.Close();
        }

        private void btnAmpersat_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte)systemWrapper.ScanKey('@');
            Unsubscribe();
            this.Close();
        }

        private void btnHash_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte)systemWrapper.ScanKey('#');
            Unsubscribe();
            this.Close();
        }

        private void btnDollar_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte)systemWrapper.ScanKey('$');
            Unsubscribe();
            this.Close();
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte)systemWrapper.ScanKey('%');
            Unsubscribe();
            this.Close();
        }

        private void btnCaret_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte)systemWrapper.ScanKey('^');
            Unsubscribe();
            this.Close();
        }

        private void btnAmpersand_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte)systemWrapper.ScanKey('&');
            Unsubscribe();
            this.Close();
        }

        private void btnAsterisk_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte)systemWrapper.ScanKey('*');
            Unsubscribe();
            this.Close();
        }

        private void btnOpenParen_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte)systemWrapper.ScanKey('(');
            Unsubscribe();
            this.Close();
        }

        private void btnCloseParen_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte)systemWrapper.ScanKey(')');
            Unsubscribe();
            this.Close();
        }

        private void btnUnderscore_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte)systemWrapper.ScanKey('_');
            Unsubscribe();
            this.Close();
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte)systemWrapper.ScanKey('+');
            Unsubscribe();
            this.Close();
        }

        private void btnOpenBrace_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte)systemWrapper.ScanKey('{');
            Unsubscribe();
            this.Close();
        }

        private void btnCloseBrace_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte)systemWrapper.ScanKey('}');
            Unsubscribe();
            this.Close();
        }

        private void btnPipe_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte)systemWrapper.ScanKey('|');
            Unsubscribe();
            this.Close();
        }

        private void btnColon_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte)systemWrapper.ScanKey(':');
            Unsubscribe();
            this.Close();
        }

        private void btnQuote_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte)systemWrapper.ScanKey('"');
            Unsubscribe();
            this.Close();
        }

        private void btnLessThan_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte)systemWrapper.ScanKey('<');
            Unsubscribe();
            this.Close();
        }

        private void btnGreaterThan_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte)systemWrapper.ScanKey('>');
            Unsubscribe();
            this.Close();
        }

        private void btnQuestionMark_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte)systemWrapper.ScanKey('?');
            Unsubscribe();
            this.Close();
        }

        private IKeyboardMouseEvents m_GlobalHook;
        Keys enteredKey = Keys.None;
        public void Subscribe()
        {
            m_GlobalHook = Hook.GlobalEvents();
            m_GlobalHook.KeyDown += GlobalHookKeyDown;
        }

        public void Unsubscribe()
        {
            m_GlobalHook.KeyDown -= GlobalHookKeyDown;
            m_GlobalHook.Dispose();
        }

        private void GlobalHookKeyDown(object sender, KeyEventArgs e)
        {
            KeyTextBox.Text = "";
            enteredKey = e.KeyCode;
            KeyTextBox.Text = e.KeyCode.ToString();
            e.Handled = true;
            e.SuppressKeyPress = true;
        }

        private void buttonSaveKey_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) enteredKey;
            Unsubscribe();
            this.Close();
            Log.GetLogger().Info("button " + (Keys)CurrentKey + " was saved");
        }
    }
}
