using SharpDX.DirectInput;
using SharpDX.XInput;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using xWin.Wrapper;
using static BasicControl.Types;
using static TypingControl.Types;

namespace xWin.Library
{
    public enum Mode
    {
        Normal = 0, Typing
    }

    public struct ControllerCalibration
    {
        public int lx, ly, rx, ry;
    }

    public class WI//Windows Interaction
    {
        public static void MoveCursor(short x, short y, int dpi = 10)
        {
            Console.WriteLine(x.ToString() + "," + y.ToString()+","+dpi.ToString());
            if (x != 0 && y != 0)
            {
                var t = Math.Atan2(x, y);

                Cursor.Position = new Point(Cursor.Position.X + (int)(Math.Sin(t) * dpi), Cursor.Position.Y + (int)(Math.Cos(t) * dpi));
            }
        }
        public static short shortbound(int i)
        {
            if (i < -32767)
                return -32767;
            if (i > 32767)
                return 32767;
            return (short)i;
        }

        [DllImport("user32.dll")]
        private static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);
        [DllImport("user32.dll")]
        private static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, uint dwExtraInfo);

        public static void LDown()
        {
            mouse_event(0x0002, Control.MousePosition.X, Control.MousePosition.Y, 0, 0);
        }

        public static void RDown()
        {
            mouse_event(0x0008, Control.MousePosition.X, Control.MousePosition.Y, 0, 0);
        }

        public static void MDown()
        {
            mouse_event(0x0020, Control.MousePosition.X, Control.MousePosition.Y, 0, 0);
        }

        public static void LUp()
        {
            mouse_event(0x0004, Control.MousePosition.X, Control.MousePosition.Y, 0, 0);
        }

        public static void RUp()
        {
            mouse_event(0x0010, Control.MousePosition.X, Control.MousePosition.Y, 0, 0);
        }

        public static void MUp()
        {
            mouse_event(0x0040, Control.MousePosition.X, Control.MousePosition.Y, 0, 0);
        }

        public static void Press(byte key)
        {
            // Presses the key  
            keybd_event(key, 0, 1, 0);
        }
        public static void Release(byte key)
        {
            // Releases the key  
            keybd_event(key, 0, 3, 0);
        }

        public static void InteractionLoop(GenericController c, Configuration config, ControllerCalibration cc, int tick, Mode m = Mode.Normal)
        {
            var i = new Interpreter(config.Basic);
            var ki = new TypingInterpreter(config.Typing);
            System.Diagnostics.Stopwatch st = new System.Diagnostics.Stopwatch();
            if (config.Basic.Dpi == 0)
                config.Basic.Dpi = 10;
            if (config.Basic.FastDpi == 0)
                config.Basic.FastDpi = 15;
            if (config.Basic.SlowDpi == 0)
                config.Basic.SlowDpi = 5;

            uint dpi = config.Basic.Dpi;
            TimeSpan TickSpeed = new TimeSpan(tick);
            var text = "";
            while (true)
            {
                st.Start();
                var datas = c.GetState();

                datas.Gamepad.LeftThumbX = shortbound(datas.Gamepad.LeftThumbX - cc.lx);
                datas.Gamepad.LeftThumbY = shortbound(datas.Gamepad.LeftThumbY - cc.ly);
                datas.Gamepad.RightThumbX = shortbound(datas.Gamepad.RightThumbX - cc.rx);
                datas.Gamepad.RightThumbY = shortbound(datas.Gamepad.RightThumbY - cc.ry);
                var wrapper = new SystemWrapper();
                switch (m)
                {
                    case Mode.Normal:
                        {
                            var kms = i.NextState(datas.Gamepad);
                            Console.Write("Released: ");
                            foreach (var l in kms.released)
                            {
                                Console.Write(l.ToString() + ",");
                                if (l == Keys.LButton)
                                    LUp();
                                else if (l == Keys.RButton)
                                    RUp();
                                else if (l == Keys.MButton)
                                    MUp();
                                else
                                    Release((byte)l);
                            }
                            Console.WriteLine();
                            Console.Write("Pressed: ");
                            foreach (var l in kms.pressed)
                            {
                                Console.Write(l.ToString() + ",");
                                if (l == Keys.LButton)
                                    LDown();
                                else if (l == Keys.RButton)
                                    RDown();
                                else if (l == Keys.MButton)
                                    MDown();
                                else
                                    Press((byte)l);
                            }
                            Console.WriteLine();
                            Console.Write("Released: ");
                            foreach (var l in kms.r_special)
                            {
                                Console.Write(l.ToString() + ",");
                                if (l == SpecialAction.Precision || l == SpecialAction.Turbo)
                                    dpi = config.Basic.Dpi;
                            }
                            Console.WriteLine();
                            Console.Write("Pressed: ");
                            foreach (var l in kms.special)
                            {
                                Console.Write(l.ToString() + ",");
                                if (l == BasicControl.Types.SpecialAction.EnterTypingMode)
                                {
                                    m = Mode.Typing;
                                    //ki.Reset();
                                }
                                else if (l == SpecialAction.Precision)
                                    dpi = config.Basic.SlowDpi;
                                else if (l == SpecialAction.Turbo)
                                    dpi = config.Basic.FastDpi;
                            }
                            Console.WriteLine();
                            MoveCursor((short)kms.mouse_movement.x, (short)kms.mouse_movement.y, (int)dpi);
                            break;
                        }
                    case Mode.Typing:
                        {
                            var ts = ki.NextState(datas.Gamepad);
                            Console.Write("Actions: ");
                            foreach (var act in ts.Actions)
                            {
                                Console.Write(act.ToString());
                                if (act == KeyboardAction.Confirm)
                                    text += ts.Text;
                                else if (act == KeyboardAction.LeaveTyping)
                                {
                                    m = Mode.Normal;
                                    //i.Reset();
                                }
                            }
                            Console.WriteLine();
                            Console.WriteLine(ts.t1.ToString() + "," + ts.t2.ToString());
                            Console.WriteLine(ts.Text);
                            Console.WriteLine("Current String:" + text);
                            break;
                        }
                }

                while (st.Elapsed < TickSpeed) { }
                st.Stop();
                Console.Clear();
            }
            }

    }

    public interface GenericController
    {
        State GetState();
    }

    class DIController : GenericController
    {
        Joystick J;
        public DIController(Joystick J)
        {
            this.J = J;
        }
        public State GetState()
        {
            return DI2XI.di2xi(J.GetCurrentState());
        }
    }

    class XBXController : GenericController
    {
        Controller C;
        public XBXController(Controller C)
        {
            this.C = C;
        }
        public State GetState()
        {
            return C.GetState();
        }
    }
}
