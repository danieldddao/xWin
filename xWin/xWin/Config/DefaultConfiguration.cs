using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Configuration.Types;
using SharpDX.XInput;


namespace xWin.Config
{
    using Action = Configuration.Types.Action;
    public static class Defaults
    {
        public static uint DEADZONE = 1000;
        public static byte TRIGGER_DEADZONE = 5;

        public static Behavior EmptyBehavior()
        {
            return new Behavior
            {
                OnPress = new Action { Keybind = (int)Keys.None },
                OnHold = new Action { Keybind = (int)Keys.None },
                OnRelease = new Action { Keybind = (int)Keys.None },
                OnStay = new Action { Keybind = (int)Keys.None },
                OnPressToggle = false,
                OnReleaseToggle = false
            };
        }

        public static Behavior NormalPressBehavior(Keys b)
        {
            return new Behavior
            {
                OnPress = new Action { Keybind = (int)b },
                OnHold = new Action { Keybind = (int)b },
                OnRelease = new Action { Keybind = (int)Keys.None },
                OnStay = new Action { Keybind = (int)Keys.None },
                OnPressToggle = false,
                OnReleaseToggle = false
            };
        }

        public static Behavior NormalPressBehavior(SpecialAction b)
        {
            return new Behavior
            {
                OnPress = new Action { SpecialAction = b },
                OnHold = new Action { SpecialAction = b },
                OnRelease = new Action { Keybind = (int)Keys.None },
                OnStay = new Action { Keybind = (int)Keys.None },
                OnPressToggle = false,
                OnReleaseToggle = false
            };
        }

        /*
        **Left Stick controls mouse, Right Stick does Page Up and Page Down, Dpad is Arrow Keys, Left Thumb is middle click
        **A is Left Click, B is Right Click, Y is Turbo
        */
        public static Configuration DefaultConfiguration()
        {
            return new Configuration
            {
                LeftStick = new Stick
                {
                    Deadzone = DEADZONE,
                    ControlMouse = true,
                    RegionStart = 0,
                    StayBehavior = new Behavior(),
                    InvertLr = false,
                    InvertUd = false,
                    Regions = { }
                },
                RightStick = new Stick
                {
                    Deadzone = DEADZONE,
                    ControlMouse = false,
                    RegionStart = 0,
                    StayBehavior = EmptyBehavior(),
                    InvertLr = false,
                    InvertUd = false,
                    Regions = {
                        new Region
                        {
                            Range = 180,
                            Behavior = new Behavior
                            {
                                OnPress = new Action { Keybind = (int)Keys.PageDown},
                                OnHold = new Action { Keybind = (int)Keys.PageDown },
                                OnRelease = new Action { Keybind = (int)Keys.None},
                                OnStay = new Action { Keybind = (int)Keys.None },
                                OnPressToggle = false,
                                OnReleaseToggle = false
                            }
                        },
                        new Region
                        {
                            Range = 180,
                            Behavior = new Behavior
                            {
                                OnPress = new Action { Keybind = (int)Keys.PageUp},
                                OnHold = new Action { Keybind = (int)Keys.PageUp },
                                OnRelease = new Action { Keybind = (int)Keys.None},
                                OnStay = new Action { Keybind = (int)Keys.None },
                                OnPressToggle = false,
                                OnReleaseToggle = false
                            }
                        }
                    }
                },
                LeftTrigger = new Trigger
                {
                    Deadzone = TRIGGER_DEADZONE,
                    Regions = { },
                    Unpressed = EmptyBehavior()
                },
                RightTrigger = new Trigger
                {
                    Deadzone = TRIGGER_DEADZONE,
                    Regions = { },
                    Unpressed = EmptyBehavior()
                },
                ButtonMap = 
                {
                    { (int)GamepadButtonFlags.A, NormalPressBehavior(Keys.LButton) },
                    { (int)GamepadButtonFlags.B, NormalPressBehavior(Keys.RButton) },
                    { (int)GamepadButtonFlags.LeftThumb, NormalPressBehavior(Keys.MButton) },
                    { (int)GamepadButtonFlags.Y, NormalPressBehavior(SpecialAction.Turbo) },
                    { (int)GamepadButtonFlags.DPadUp, NormalPressBehavior(Keys.Up) },
                    { (int)GamepadButtonFlags.DPadRight, NormalPressBehavior(Keys.Right) },
                    { (int)GamepadButtonFlags.DPadDown, NormalPressBehavior(Keys.Down) },
                    { (int)GamepadButtonFlags.DPadLeft, NormalPressBehavior(Keys.Left) }
                }
            };
        }
    }
}
