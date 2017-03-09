using System;
using System.Windows.Forms;
using xWin.Library;

namespace xWin.Forms
{
    public partial class ControllerOptions : Form
    {
        XController xController;
        ButtonOptions buttonOptions;

        public ControllerOptions(XController controller)
        {
            InitializeComponent();
            this.xController = controller;
            buttonOptions = new ButtonOptions();
        }

        private void HightlightButton(Button button)
        {
            button.BackgroundImage = (System.Drawing.Image)Properties.Resources.button_highlight;
            button.BackgroundImageLayout = ImageLayout.Zoom;
        }

        private void ClearHightlightButton(Button button)
        {
            button.BackgroundImage = null;
        }

        /* Button LT */
        private void buttonLT_Click(object sender, EventArgs e)
        {
            buttonOptions.Text = "Button LT Options";
            buttonOptions.ShowDialog();
        }
        private void buttonLT_MouseEnter(object sender, EventArgs e)
        {
            HightlightButton(buttonLT);
        }
        private void buttonLT_MouseLeave(object sender, EventArgs e)
        {
            ClearHightlightButton(buttonLT);
        }

        /* Button LB */
        private void buttonLB_Click(object sender, EventArgs e)
        {
            buttonOptions.Text = "Button LB Options";
            buttonOptions.ShowDialog();
        }
        private void buttonLB_MouseEnter(object sender, EventArgs e)
        {
            HightlightButton(buttonLB);
        }
        private void buttonLB_MouseLeave(object sender, EventArgs e)
        {
            ClearHightlightButton(buttonLB);
        }

        /* Button RT */
        private void buttonRT_Click(object sender, EventArgs e)
        {
            buttonOptions.Text = "Button RT Options";
            buttonOptions.ShowDialog();
        }
        private void buttonRT_MouseEnter(object sender, EventArgs e)
        {
            HightlightButton(buttonRT);
        }
        private void buttonRT_MouseLeave(object sender, EventArgs e)
        {
            ClearHightlightButton(buttonRT);
        }

        /* Button RB */
        private void buttonRB_Click(object sender, EventArgs e)
        {
            buttonOptions.Text = "Button RB Options";
            buttonOptions.ShowDialog();
        }
        private void buttonRB_MouseEnter(object sender, EventArgs e)
        {
            HightlightButton(buttonRB);
        }
        private void buttonRB_MouseLeave(object sender, EventArgs e)
        {
            ClearHightlightButton(buttonRB);
        }

        /* Button X */
        private void buttonX_Click(object sender, EventArgs e)
        {
            buttonOptions.Text = "Button X Options";
            buttonOptions.ShowDialog();
        }
        private void buttonX_MouseEnter(object sender, EventArgs e)
        {
            HightlightButton(buttonX);
        }
        private void buttonX_MouseLeave(object sender, EventArgs e)
        {
            ClearHightlightButton(buttonX);
        }

        /* Button Y */
        private void buttonY_Click(object sender, EventArgs e)
        {
            buttonOptions.Text = "Button Y Options";
            buttonOptions.ShowDialog();
        }
        private void buttonY_MouseEnter(object sender, EventArgs e)
        {
            HightlightButton(buttonY);
        }
        private void buttonY_MouseLeave(object sender, EventArgs e)
        {
            ClearHightlightButton(buttonY);
        }

        /* Button A */
        private void buttonA_Click(object sender, EventArgs e)
        {
            buttonOptions.Text = "Button A Options";
            buttonOptions.ShowDialog();
        }
        private void buttonA_MouseEnter(object sender, EventArgs e)
        {
            HightlightButton(buttonA);
        }
        private void buttonA_MouseLeave(object sender, EventArgs e)
        {
            ClearHightlightButton(buttonA);
        }

        /* Button B */
        private void buttonB_Click(object sender, EventArgs e)
        {
            buttonOptions.Text = "Button B Options";
            buttonOptions.ShowDialog();
        }
        private void buttonB_MouseEnter(object sender, EventArgs e)
        {
            HightlightButton(buttonB);
        }
        private void buttonB_MouseLeave(object sender, EventArgs e)
        {
            ClearHightlightButton(buttonB);
        }

        /* Button Back */
        private void buttonBack_Click(object sender, EventArgs e)
        {
            buttonOptions.Text = "Button Back Options";
            buttonOptions.ShowDialog();
        }
        private void buttonBack_MouseEnter(object sender, EventArgs e)
        {
            HightlightButton(buttonBack);
        }
        private void buttonBack_MouseLeave(object sender, EventArgs e)
        {
            ClearHightlightButton(buttonBack);
        }

        /* Button Start */
        private void buttonStart_Click(object sender, EventArgs e)
        {
            buttonOptions.Text = "Button Start Options";
            buttonOptions.ShowDialog();
        }
        private void buttonStart_MouseEnter(object sender, EventArgs e)
        {
            HightlightButton(buttonStart);
        }
        private void buttonStart_MouseLeave(object sender, EventArgs e)
        {
            ClearHightlightButton(buttonStart);
        }

        /* Button DPadUp */
        private void buttonDPadUp_Click(object sender, EventArgs e)
        {
            buttonOptions.Text = "Button DPadUp Options";
            buttonOptions.ShowDialog();
        }
        private void buttonDPadUp_MouseEnter(object sender, EventArgs e)
        {
            HightlightButton(buttonDPadUp);
        }
        private void buttonDPadUp_MouseLeave(object sender, EventArgs e)
        {
            ClearHightlightButton(buttonDPadUp);
        }

        /* Button DPadDown */
        private void buttonDPadDown_Click(object sender, EventArgs e)
        {
            buttonOptions.Text = "Button DPadDown Options";
            buttonOptions.ShowDialog();
        }
        private void buttonDPadDown_MouseEnter(object sender, EventArgs e)
        {
            HightlightButton(buttonDPadDown);
        }
        private void buttonDPadDown_MouseLeave(object sender, EventArgs e)
        {
            ClearHightlightButton(buttonDPadDown);
        }

        /* Button DPadRight */
        private void buttonDPadRight_Click(object sender, EventArgs e)
        {
            buttonOptions.Text = "Button DpadRight Options";
            buttonOptions.ShowDialog();
        }
        private void buttonDPadRight_MouseEnter(object sender, EventArgs e)
        {
            HightlightButton(buttonDPadRight);
        }
        private void buttonDPadRight_MouseLeave(object sender, EventArgs e)
        {
            ClearHightlightButton(buttonDPadRight);
        }

        /* Button DPadLeft */
        private void buttonDPadLeft_Click(object sender, EventArgs e)
        {
            buttonOptions.Text = "Button DPadLeft Options";
            buttonOptions.ShowDialog();
        }
        private void buttonDPadLeft_MouseEnter(object sender, EventArgs e)
        {
            HightlightButton(buttonDPadLeft);
        }
        private void buttonDPadLeft_MouseLeave(object sender, EventArgs e)
        {
            ClearHightlightButton(buttonDPadLeft);
        }
    }
}
