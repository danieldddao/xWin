﻿using System;
using System.Windows.Forms;
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

        }

        private void btnESC_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.Escape;
            this.Close();
        }

        private void btnF1_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.F1;
            this.Close();
        }

        private void btnF2_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.F2;
            this.Close();
        }

        private void btnF3_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.F3;
            this.Close();
        }

        private void btnF4_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.F4;
            this.Close();
        }

        private void btnF5_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.F5;
            this.Close();
        }

        private void btnF6_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.F6;
            this.Close();
        }

        private void btnF7_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.F7;
            this.Close();
        }

        private void btnF8_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.F8;
            this.Close();
        }

        private void btnF9_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.F9;
            this.Close();
        }

        private void btnF10_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.F10;
            this.Close();
        }

        private void btnF11_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.F11;
            this.Close();
        }

        private void btnF12_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.F12;
            this.Close();
        }

        private void btnTILDE_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.Oemtilde;
            this.Close();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.Oem1;
            this.Close();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.Oem2;
            this.Close();
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.Oem3;
            this.Close();
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.Oem4;
            this.Close();
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.Oem5;
            this.Close();
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.Oem6;
            this.Close();
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.Oem7;
            this.Close();
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.Oem8;
            this.Close();
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.OemOpenBrackets; // need to test
            this.Close();
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.OemCloseBrackets; // need to test
            this.Close();
        }

        private void btnMINUS_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.OemMinus;
            this.Close();
        }

        private void btnEQUALS_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.Oemplus; // need to test
            this.Close();
        }

        private void btnBACKSPACE_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.Back;
            this.Close();
        }

        private void btnTAB_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.Tab;
            this.Close();
        }

        private void btnQ_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.Q;
            this.Close();
        }

        private void btnW_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.W;
            this.Close();
        }

        private void btnE_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.E;
            this.Close();
        }

        private void btnR_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.R;
            this.Close();
        }

        private void btnT_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.T;
            this.Close();
        }

        private void btnY_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.Y;
            this.Close();
        }

        private void btnU_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.U;
            this.Close();
        }

        private void btnI_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.I;
            this.Close();
        }

        private void btnO_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.O;
            this.Close();
        }

        private void btnP_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.P;
            this.Close();
        }

        private void btnOPENBRACKET_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.OemOpenBrackets;
            this.Close();
        }

        private void btnCLOSEBRACKET_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.OemCloseBrackets;
            this.Close();
        }

        private void btnBACKSLASH_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.OemBackslash;
            this.Close();
        }

        private void btnCAPS_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.CapsLock;
            this.Close();
        }

        private void btnA_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.A;
            this.Close();
        }

        private void btnS_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.S;
            this.Close();
        }

        private void btnD_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.D;
            this.Close();
        }

        private void btnF_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.F;
            this.Close();
        }

        private void btnG_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.G;
            this.Close();
        }

        private void btnH_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.H;
            this.Close();
        }

        private void btnJ_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.J;
            this.Close();
        }

        private void btnK_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.K;
            this.Close();
        }

        private void btnL_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.L;
            this.Close();
        }

        private void btnSEMICOLON_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.OemSemicolon;
            this.Close();
        }

        private void btnAPOSTROPHE_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.OemQuotes; // need to test
            this.Close();
        }

        private void btnRETURN_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.Enter;
            this.Close();
        }

        private void btnLSHIFT_Click(object sender, EventArgs e)
        {
            CurrentKey = VK_SHIFT;
            this.Close();
        }

        private void btnZ_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.Z;
            this.Close();
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.X;
            this.Close();
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.C;
            this.Close();
        }

        private void btnV_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.V;
            this.Close();
        }

        private void btnB_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.B;
            this.Close();
        }

        private void btnN_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.N;
            this.Close();
        }

        private void btnM_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.M;
            this.Close();
        }

        private void btnCOMMA_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.Oemcomma;
            this.Close();
        }

        private void btnPERIOD_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.OemPeriod;
            this.Close();
        }

        private void btnSLASH_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.OemQuestion;
            this.Close();
        }

        private void btnRSHIFT_Click(object sender, EventArgs e)
        {
            CurrentKey = VK_SHIFT;
            this.Close();
        }

        private void btnLCTRL_Click(object sender, EventArgs e)
        {
            CurrentKey = VK_CONTROL;
            this.Close();
        }

        private void btnLWin_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.LWin;
            this.Close();
        }

        private void btnLAlt_Click(object sender, EventArgs e)
        {
            CurrentKey = VK_ALT;
            this.Close();
        }

        private void btnSPACE_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.Space;
            this.Close();
        }

        private void buttonRWin_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.RWin;
            this.Close();
        }

        private void btnRALT_Click(object sender, EventArgs e)
        {
            CurrentKey = VK_ALT;
            this.Close();
        }

        private void btnRCTRL_Click(object sender, EventArgs e)
        {
            CurrentKey = VK_CONTROL;
            this.Close();
        }

        private void buttonLeft_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.Left;
            this.Close();
        }

        private void Right_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.Right;
            this.Close();
        }

        private void buttonUp_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.Up;
            this.Close();
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.Down;
            this.Close();
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.PrintScreen;
            this.Close();
        }

        private void btnScroll_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.Scroll;
            this.Close();
        }

        private void btnBreak_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.Pause;
            this.Close();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.Insert;
            this.Close();
        }

        private void btnHOME_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.Home;
            this.Close();
        }

        private void btnPGUP_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.PageUp;
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.Delete;
            this.Close();
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.End;
            this.Close();
        }

        private void btnPageDown_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.PageDown;
            this.Close();
        }

        private void btnNumLock_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.NumLock;
            this.Close();
        }

        private void btnNumSlash_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) systemWrapper.ScanKey('/');
            this.Close();
        }

        private void btnNumStar_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) systemWrapper.ScanKey('*');
            this.Close();
        }

        private void btnNumDash_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) systemWrapper.ScanKey('-');
            this.Close();
        }

        private void btnNUM7_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.NumPad7;
            this.Close();
        }

        private void btnNUM8_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte)Keys.NumPad8;
            this.Close();
        }

        private void btnNUM9_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte)Keys.NumPad9;
            this.Close();
        }

        private void btnNUM4_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte)Keys.NumPad4;
            this.Close();
        }

        private void btnNUM5_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte)Keys.NumPad5;
            this.Close();
        }

        private void btnNUM6_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte)Keys.NumPad6;
            this.Close();
        }

        private void btnNUM1_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte)Keys.NumPad1;
            this.Close();
        }

        private void btnNUM2_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte)Keys.NumPad2;
            this.Close();
        }

        private void btnNUM3_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte)Keys.NumPad3;
            this.Close();
        }

        private void btnNUM0_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte)Keys.NumPad0;
            this.Close();
        }

        private void btnNUMPLUS_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) systemWrapper.ScanKey('+');
            this.Close();
        }

        private void btnNUMDOT_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) systemWrapper.ScanKey('.');
            this.Close();
        }

        private void btnNUMENTER_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte) Keys.Enter;
            this.Close();
        }

        private void btnAcute_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte)systemWrapper.ScanKey('`');
            this.Close();
        }

        private void btnExclamationMark_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte)systemWrapper.ScanKey('!');
            this.Close();
        }

        private void btnAmpersat_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte)systemWrapper.ScanKey('@');
            this.Close();
        }

        private void btnHash_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte)systemWrapper.ScanKey('#');
            this.Close();
        }

        private void btnDollar_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte)systemWrapper.ScanKey('$');
            this.Close();
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte)systemWrapper.ScanKey('%');
            this.Close();
        }

        private void btnCaret_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte)systemWrapper.ScanKey('^');
            this.Close();
        }

        private void btnAmpersand_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte)systemWrapper.ScanKey('&');
            this.Close();
        }

        private void btnAsterisk_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte)systemWrapper.ScanKey('*');
            this.Close();
        }

        private void btnOpenParen_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte)systemWrapper.ScanKey('(');
            this.Close();
        }

        private void btnCloseParen_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte)systemWrapper.ScanKey(')');
            this.Close();
        }

        private void btnUnderscore_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte)systemWrapper.ScanKey('_');
            this.Close();
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte)systemWrapper.ScanKey('+');
            this.Close();
        }

        private void btnOpenBrace_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte)systemWrapper.ScanKey('{');
            this.Close();
        }

        private void btnCloseBrace_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte)systemWrapper.ScanKey('}');
            this.Close();
        }

        private void btnPipe_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte)systemWrapper.ScanKey('|');
            this.Close();
        }

        private void btnColon_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte)systemWrapper.ScanKey(':');
            this.Close();
        }

        private void btnQuote_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte)systemWrapper.ScanKey('"');
            this.Close();
        }

        private void btnLessThan_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte)systemWrapper.ScanKey('<');
            this.Close();
        }

        private void btnGreaterThan_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte)systemWrapper.ScanKey('>');
            this.Close();
        }

        private void btnQuestionMark_Click(object sender, EventArgs e)
        {
            CurrentKey = (byte)systemWrapper.ScanKey('?');
            this.Close();
        }

    }
}
