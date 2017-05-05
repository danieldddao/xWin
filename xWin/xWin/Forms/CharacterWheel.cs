using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Protobuf.Collections;
using SharpDX.XInput;
using xWin.Library;

namespace xWin.Forms
{
    public partial class CharacterWheel : Form
    {
        private TypingInterpreter.TypingState ts;
        private TypingInterpreter ki;
        private State datas;
        private GenericController c;
        private Configuration config;
        bool[] highlightOuterLabels = new bool[] { false, false, false, false, false, false, false, false };
        bool[] highlightInnerLabels = new bool[] { false, false, false, false };
        Label[] outerLabels;
        Label[] innerLabels;
        public static bool visible = false;
        public static int t1=-1;
        public static int t2=-1;
        public static RepeatedField<KeyboardSet.Types.StringChoice> keySet;
        public static bool keysChanged;

        public CharacterWheel(Configuration config)
        {
            this.config = config;
            ki = new TypingInterpreter(this.config.Typing);
            keySet = config.Typing.Base.Set;
            InitializeComponent();
            innerLabels = new Label[] { setLabel1, setLabel2, setLabel3, setLabel4 };
            outerLabels = new Label[] { subsetLabel4, subsetLabel3, subsetLabel2, subsetLabel1, subsetLabel8, subsetLabel7, subsetLabel6, subsetLabel5 };
        }

        protected override void SetVisibleCore(bool value)
        {
            base.SetVisibleCore(visible);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!visible)
            {
                this.Visible = false;
                return;
            }
            this.Visible = true;

            try
            {
                setLabel1.Text = keySet[0].Display;
                setLabel2.Text = keySet[1].Display;
                setLabel3.Text = keySet[2].Display;
                setLabel4.Text = keySet[3].Display;

                subsetLabel1.Text = keySet[t1].Subset[0];
                subsetLabel2.Text = keySet[t1].Subset[1];
                subsetLabel3.Text = keySet[t1].Subset[2];
                subsetLabel4.Text = keySet[t1].Subset[3];
                subsetLabel5.Text = keySet[t1].Subset[4];
                subsetLabel6.Text = keySet[t1].Subset[5];
                subsetLabel7.Text = keySet[t1].Subset[6];
                subsetLabel8.Text = keySet[t1].Subset[7];
            }
            catch
            {
                ;
            }
            switch (t1)
            {
                case 0:
                    if (!highlightInnerLabels[0])
                    {
                        clearHighlightedInnerLabels();
                        HightlightChoice(setLabel1);
                        for (int i = 0; i < 4; i++) highlightInnerLabels[i] = false;
                        highlightInnerLabels[0] = true;
                    }
                    break;
                case 1:
                    if (!highlightInnerLabels[1])
                    {
                        clearHighlightedInnerLabels();
                        HightlightChoice(setLabel2);
                        for (int i = 0; i < 4; i++) highlightInnerLabels[i] = false;
                        highlightInnerLabels[1] = true;
                    }
                    break;
                case 2:
                    if (!highlightInnerLabels[2])
                    {
                        clearHighlightedInnerLabels();
                        HightlightChoice(setLabel3);
                        for (int i = 0; i < 4; i++) highlightInnerLabels[i] = false;
                        highlightInnerLabels[2] = true;
                    }
                    break;
                case 3:
                    if (!highlightInnerLabels[3])
                    {
                        clearHighlightedInnerLabels();
                        HightlightChoice(setLabel4);
                        for (int i = 0; i < 4; i++) highlightInnerLabels[i] = false;
                        highlightInnerLabels[3] = true;
                    }
                    break;
                default:
                    clearHighlightedInnerLabels();
                    for (int i = 0; i < 4; i++) highlightInnerLabels[i] = false;
                    break;
            }
            switch (t2)
            {
                case 0:
                    if (!highlightOuterLabels[0])
                    {
                        clearHighlightedOuterLabels();
                        HightlightChoice(subsetLabel1);
                        for (int i = 0; i < 8; i++) highlightOuterLabels[i] = false;
                        highlightOuterLabels[0] = true;
                    }
                    break;
                case 1:
                    if (!highlightOuterLabels[1])
                    {
                        clearHighlightedOuterLabels();
                        HightlightChoice(subsetLabel2);
                        for (int i = 0; i < 8; i++) highlightOuterLabels[i] = false;
                        highlightOuterLabels[1] = true;
                    }

                    break;
                case 2:
                    if (!highlightOuterLabels[2])
                    {
                        clearHighlightedOuterLabels();
                        HightlightChoice(subsetLabel3);
                        for (int i = 0; i < 8; i++) highlightOuterLabels[i] = false;
                        highlightOuterLabels[2] = true;
                    }
                    break;
                case 3:
                    if (!highlightOuterLabels[3])
                    {
                        clearHighlightedOuterLabels();
                        HightlightChoice(subsetLabel4);
                        for (int i = 0; i < 8; i++) highlightOuterLabels[i] = false;
                        highlightOuterLabels[3] = true;
                    }
                    break;
                case 4:
                    if (!highlightOuterLabels[4])
                    {
                        clearHighlightedOuterLabels();
                        HightlightChoice(subsetLabel5);
                        for (int i = 0; i < 8; i++) highlightOuterLabels[i] = false;
                        highlightOuterLabels[4] = true;
                    }
                    break;
                case 5:
                    if (!highlightOuterLabels[5])
                    {
                        clearHighlightedOuterLabels();
                        HightlightChoice(subsetLabel6);
                        for (int i = 0; i < 8; i++) highlightOuterLabels[i] = false;
                        highlightOuterLabels[5] = true;
                    }
                    break;
                case 6:
                    if (!highlightOuterLabels[6])
                    {
                        clearHighlightedOuterLabels();
                        HightlightChoice(subsetLabel7);
                        for (int i = 0; i < 8; i++) highlightOuterLabels[i] = false;
                        highlightOuterLabels[6] = true;
                    }
                    break;
                case 7:
                    if (!highlightOuterLabels[7])
                    {
                        clearHighlightedOuterLabels();
                        HightlightChoice(subsetLabel8);
                        for (int i = 0; i < 8; i++) highlightOuterLabels[i] = false;
                        highlightOuterLabels[7] = true;
                    }
                    break;
                default:
                    clearHighlightedOuterLabels();
                    for (int i = 0; i < 8; i++) highlightOuterLabels[i] = false;
                    break;
            }

            }

        private void HightlightChoice(Label label)
        {
            label.BackgroundImage = (System.Drawing.Image)Properties.Resources.button_highlight_invert;
            label.BackgroundImageLayout = ImageLayout.Zoom;
        }

        private void clearHighlightedOuterLabels()
        {
            foreach (Label l in outerLabels)
            {
                l.BackgroundImage = null;
            }
        }
        private void clearHighlightedInnerLabels()
        {
            foreach (Label l in innerLabels)
            {
                l.BackgroundImage = null;
            }
        }

        private void CharacterWheel_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            if (System.Windows.Forms.Cursor.Position.X - this.Width - 20 <= SystemInformation.VirtualScreen.Left && System.Windows.Forms.Cursor.Position.Y - this.Height - 20 <= SystemInformation.VirtualScreen.Top)
                Location = new Point(SystemInformation.VirtualScreen.Left, SystemInformation.VirtualScreen.Top);
            else if (System.Windows.Forms.Cursor.Position.X - this.Width - 20 <= SystemInformation.VirtualScreen.Left)
                Location = new Point(SystemInformation.VirtualScreen.Left, System.Windows.Forms.Cursor.Position.Y - this.Height - 20);
            else if (System.Windows.Forms.Cursor.Position.Y - this.Height - 20 <= SystemInformation.VirtualScreen.Top)
                Location = new Point(System.Windows.Forms.Cursor.Position.X - this.Width - 20, SystemInformation.VirtualScreen.Top);
            else Location = new Point(System.Windows.Forms.Cursor.Position.X - this.Width - 20, System.Windows.Forms.Cursor.Position.Y - this.Height - 20);
            this.Opacity = .75;
        }
    }
}
