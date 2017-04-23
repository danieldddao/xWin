using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace xWin.Forms
{
    public partial class QuickTypeBar : Form
    {

        public QuickTypeBar()
        {
            InitializeComponent();
            this.MouseDown += new MouseEventHandler(QuickTypeBar_MouseDown);
            this.MouseUp += new MouseEventHandler(QuickTypeBar_MouseUp);
            this.MouseMove += new MouseEventHandler(QuickTypeBar_MouseMove);
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

        private void quickTypeButton1_Click(object sender, EventArgs e)
        {

        }

        private void quickTypeButton2_Click(object sender, EventArgs e)
        {

        }

        private void quickTypeButton3_Click(object sender, EventArgs e)
        {

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
