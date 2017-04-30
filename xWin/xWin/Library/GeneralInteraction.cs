using Microsoft.Win32;
using SharpDX.DirectInput;
using SharpDX.XInput;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using xWin.Wrapper;
using static BasicControl.Types;
using static TypingControl.Types;
using static xWin.Library.StringSendingImports;
namespace xWin.Library
{
    public enum Mode
    {
        Normal = 0, Typing, Stopped
    }

    public struct ControllerCalibration
    {
        public int lx, ly, rx, ry;
    }

    public class WI//Windows Interaction
    {
        public static int GetKeyboardSpeed()
        {
            int keyboardspeed = 31;
            using (var key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Keyboard"))
            {
                Debug.Assert(key != null);
                int.TryParse((String)key.GetValue("KeyboardSpeed", "31"), out keyboardspeed);
            }
            return keyboardspeed;
        }


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

        [DllImport("user32.dll")]
        private static extern uint SendInput(uint numberOfInputs, INPUT[] inputs, int sizeOfInputStructure);

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

        public static void Press(Keys key)
        {
            // Presses the key  
            keybd_event((byte)key, 0, 1, 0);
        }
        public static void Release(Keys key)
        {
            // Releases the key  
            keybd_event((byte)key, 0, 3, 0);
        }

        public static void SendString(string s)
        {
            INPUT[] input = new INPUT[s.Length];
            for(int i = 0; i < input.Length; ++i)
            {
                input[i] = new INPUT();
                input[i].type = 1;//keyboard
                input[i].data.ki.Vk = 0;
                input[i].data.ki.Scan = (ushort)s[i];
                input[i].data.ki.Time = 0;
                input[i].data.ki.Flags = 0x0004;//unicode
                input[i].data.ki.ExtraInfo = IntPtr.Zero;
            }
            SendInput((uint)input.Length, input, Marshal.SizeOf(typeof(INPUT)));
        }

        public static void ScrollUp()
        {
            mouse_event(0x0800, 0, 0, 120, 0);
        }
        public static void ScrollDown()
        {
            mouse_event(0x0800, 0, 0, -120, 0);
        }
        public static void ScrollLeft()
        {
            mouse_event(0x1000, 0, 0, -120, 0);
        }
        public static void ScrollRight()
        {
            mouse_event(0x1000, 0, 0, 120, 0);
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
            bool just_toggled = false;

            GamepadFlags toggle = new GamepadFlags(config.Togglestop);

            bool M_Up = false, M_Down = false, M_Right = false, M_Left = false;

            
            while (true)
            {
                st.Start();
                var datas = c.GetState();
                var bs = datas.Gamepad.Buttons;
                datas.Gamepad.LeftThumbX = shortbound(datas.Gamepad.LeftThumbX - cc.lx);
                datas.Gamepad.LeftThumbY = shortbound(datas.Gamepad.LeftThumbY - cc.ly);
                datas.Gamepad.RightThumbX = shortbound(datas.Gamepad.RightThumbX - cc.rx);
                datas.Gamepad.RightThumbY = shortbound(datas.Gamepad.RightThumbY - cc.ry);
                //var wrapper = new SystemWrapper();
                
                if (just_toggled && new GamepadFlags(datas.Gamepad.Buttons) & toggle)
                {
                    just_toggled = true;
                }
                else
                    just_toggled = false;
                switch (m)
                {
                    case Mode.Normal:
                        {
                            var kms = i.NextState(datas.Gamepad);
                            Console.Write("Released: ");
                            foreach (var l in kms.released)
                            {
                                Console.Write(l.ToString() + ",");

                                switch(l)
                                {
                                    case Keys.LButton:
                                        LUp();
                                        break;
                                    case Keys.RButton:
                                        RUp();
                                        break;
                                    case Keys.MButton:
                                        MUp();
                                        break;
                                    default:
                                        Release(l);
                                        break;
                                }
                            }
                            Console.WriteLine();
                            Console.Write("Pressed: ");
                            foreach (var l in kms.pressed)
                            {
                                Console.Write(l.ToString() + ",");
                                switch (l)
                                {
                                    case Keys.LButton:
                                        LDown();
                                        break;
                                    case Keys.RButton:
                                        RDown();
                                        break;
                                    case Keys.MButton:
                                        MDown();
                                        break;
                                    default:
                                        Press(l);
                                        break;
                                }
                            }
                            Console.WriteLine();
                            Console.Write("Released: ");
                            foreach (var l in kms.r_special)
                            {
                                Console.Write(l.ToString() + ",");

                                switch(l)
                                {
                                    case SpecialAction.MouseDown:
                                        M_Down = false;
                                        break;
                                    case SpecialAction.MouseUp:
                                        M_Up = false;
                                        break;
                                    case SpecialAction.MouseLeft:
                                        M_Left = false;
                                        break;
                                    case SpecialAction.MouseRight:
                                        M_Right = false;
                                        break;
                                    case SpecialAction.Precision:
                                    case SpecialAction.Turbo:
                                        dpi = config.Basic.Dpi;
                                        break;
                                }
                            }
                            Console.WriteLine();
                            Console.Write("Pressed: ");
                            foreach (var l in kms.special)
                            {
                                Console.Write(l.ToString() + ",");

                                switch(l)
                                {
                                    case SpecialAction.MouseDown:
                                        M_Down = true;
                                        break;
                                    case SpecialAction.MouseUp:
                                        M_Up = true;
                                        break;
                                    case SpecialAction.MouseLeft:
                                        M_Left = true;
                                        break;
                                    case SpecialAction.MouseRight:
                                        M_Right = true;
                                        break;
                                    case SpecialAction.EnterTypingMode:
                                        m = Mode.Typing;
                                        break;
                                    case SpecialAction.Precision:
                                        dpi = config.Basic.SlowDpi;
                                        break;
                                    case SpecialAction.Turbo:
                                        dpi = config.Basic.FastDpi;
                                        break;
                                    case SpecialAction.ScrollUp:
                                        ScrollUp();
                                        break;
                                    case SpecialAction.ScrollDown:
                                        ScrollDown();
                                        break;
                                    case SpecialAction.ScrollLeft:
                                        ScrollLeft();
                                        break;
                                    case SpecialAction.ScrollRight:
                                        ScrollRight();
                                        break;
                                    case SpecialAction.OpenMenu:
                                        #warning OPEN MENU CODE NOT DEFINED
                                        break;
                                    
                                }
                            }
                            Console.WriteLine();
                            MoveCursor((short)kms.mouse_movement.x, (short)kms.mouse_movement.y, (int)dpi);
                            if (!just_toggled && new GamepadFlags(datas.Gamepad.Buttons) & toggle)
                            {
                                m = Mode.Stopped;
                                just_toggled = true;
                            }
                            break;
                        }
                    case Mode.Typing:
                        {
                            var ts = ki.NextState(datas.Gamepad);
                            Console.Write("Actions: ");
                            foreach (var act in ts.Actions)
                            {
                                Console.Write(act.ToString());
                                switch(act)
                                {
                                    case KeyboardAction.Confirm:
                                        text += ts.Text;
                                        SendString(ts.Text);
                                        break;
                                    case KeyboardAction.LeaveTyping:
                                        m = Mode.Normal;
                                        break;
                                    case KeyboardAction.CursorDown:
                                        Press(Keys.Down);
                                        break;
                                    case KeyboardAction.CursorRight:
                                        Press(Keys.Right);
                                        break;
                                    case KeyboardAction.CursorLeft:
                                        Press(Keys.Left);
                                        break;
                                    case KeyboardAction.CursorUp:
                                        Press(Keys.Up);
                                        break;
                                    case KeyboardAction.OpenMenu:
                                    #warning OPEN MENU CODE NOT DEFINED
                                        break;
                                    case KeyboardAction.Uidown:
                                    #warning UI Movement Code Not Defined
                                        break;
                                    case KeyboardAction.Uiup:
                                        break;
                                    case KeyboardAction.Uileft:
                                        break;
                                    case KeyboardAction.Uiright:
                                        break;
                                    case KeyboardAction.Backspace:
                                        Press(Keys.Back);
                                        break;
                                    case KeyboardAction.Delete:
                                        Press(Keys.Delete);
                                        break;
                                    case KeyboardAction.Shift:
                                        Press(Keys.ShiftKey);
                                        break;
                                    case KeyboardAction.Copy:
                                        Press(Keys.ControlKey);
                                        Press(Keys.C);
                                        break;
                                    case KeyboardAction.Cut:
                                        Press(Keys.ControlKey);
                                        Press(Keys.X);
                                        break;
                                    case KeyboardAction.Paste:
                                        Press(Keys.ControlKey);
                                        Press(Keys.V);
                                        break;
                                    case KeyboardAction.SelectAll:
                                        Press(Keys.ControlKey);
                                        Press(Keys.A);
                                        break;
                                    case KeyboardAction.Save:
                                        Press(Keys.ControlKey);
                                        Press(Keys.S);
                                        break;
                                    case KeyboardAction.Home:
                                        Press(Keys.Home);
                                        break;
                                    case KeyboardAction.End:
                                        Press(Keys.End);
                                        break;
                                    case KeyboardAction.Insert:
                                        Press(Keys.Insert);
                                        break;
                                    case KeyboardAction.Enter:
                                        Press(Keys.Enter);
                                        break;
                                }
                                
                            }
                            Console.WriteLine();
                            Console.Write("Releases: ");
                            foreach (var act in ts.Release)
                            {
                                Console.Write(act.ToString());
                                switch (act)
                                {
                                    case KeyboardAction.CursorDown:
                                        Release(Keys.Down);
                                        break;
                                    case KeyboardAction.CursorRight:
                                        Release(Keys.Right);
                                        break;
                                    case KeyboardAction.CursorLeft:
                                        Release(Keys.Left);
                                        break;
                                    case KeyboardAction.CursorUp:
                                        Release(Keys.Up);
                                        break;
                                    case KeyboardAction.Backspace:
                                        Release(Keys.Back);
                                        break;
                                    case KeyboardAction.Delete:
                                        Release(Keys.Delete);
                                        break;
                                    case KeyboardAction.Shift:
                                        Release(Keys.ShiftKey);
                                        break;
                                    case KeyboardAction.Copy:
                                        Release(Keys.C);
                                        Release(Keys.ControlKey);
                                        break;
                                    case KeyboardAction.Cut:
                                        Release(Keys.X);
                                        Release(Keys.ControlKey);
                                        break;
                                    case KeyboardAction.Paste:
                                        Release(Keys.V);
                                        Release(Keys.ControlKey);
                                        break;
                                    case KeyboardAction.SelectAll:
                                        Release(Keys.A);
                                        Release(Keys.ControlKey);
                                        break;
                                    case KeyboardAction.Save:
                                        Release(Keys.S);
                                        Release(Keys.ControlKey);
                                        break;
                                    case KeyboardAction.Home:
                                        Release(Keys.Home);
                                        break;
                                    case KeyboardAction.End:
                                        Release(Keys.End);
                                        break;
                                    case KeyboardAction.Insert:
                                        Release(Keys.Insert);
                                        break;
                                    case KeyboardAction.Enter:
                                        Release(Keys.Enter);
                                        break;
                                }
                            }
                            Console.WriteLine();
                            Console.WriteLine(ts.t1.ToString() + "," + ts.t2.ToString());
                            Console.WriteLine(ts.Text);
                            Console.WriteLine("Current String:" + text);
                            break;
                        }
                    case Mode.Stopped:
                        {
                            Console.WriteLine("STOPPED");
                            if (!just_toggled && new GamepadFlags(datas.Gamepad.Buttons) & toggle)
                            {
                                m = Mode.Normal;
                                just_toggled = true;
                            }
                            break;
                        }
                }

                while (st.Elapsed < TickSpeed) {  }
                st.Stop();
                st.Reset();
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
