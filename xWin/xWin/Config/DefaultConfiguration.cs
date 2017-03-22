using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BasicControl.Types;
using SharpDX.XInput;
using xWin.Library;

namespace xWin.Config
{
    public static class Defaults
    {
        public static uint DEADZONE = 7000;
        public static byte TRIGGER_DEADZONE = 5;

        public static Behavior NormalButtonPress(Keys k)
        {
            var b = new Behavior
            {
                OnPress = new Actions{ Keybinds = { (int)k } },
                OnHold = new Actions{ Keybinds = { (int)k } }
            };
            return b;
        }

        public static Behavior NormalButtonPress(SpecialAction sa)
        {
            return new Behavior
            {
                OnPress = new Actions{ SpecialActions = { sa } },
                OnHold = new Actions{ SpecialActions = { sa } }
            };
        }

        /*
        **Left Stick controls mouse, Right Stick does Page Up and Page Down, Dpad is Arrow Keys, Left Thumb is middle click
        **A is Left Click, B is Right Click, Y is Turbo
        */
        public static BasicControl DefaultConfiguration()
        {
            return new BasicControl
            {
                LeftStick = new Stick
                {
                    Deadzone = DEADZONE,
                    ControlMouse = true
                },
                RightStick = new Stick
                {
                    Deadzone = DEADZONE,
                    Regions = {180, 180}
                },
                LeftTrigger = new Trigger
                {
                    Deadzone = TRIGGER_DEADZONE
                    //one region
                },
                RightTrigger = new Trigger
                {
                    Deadzone = TRIGGER_DEADZONE,
                    Regions = {250}
                },
                ButtonMap = 
                {
                    { (int)new GamepadFlags(GamepadButtonFlags.A),         NormalButtonPress(Keys.LButton) },
                    { (int)new GamepadFlags(GamepadButtonFlags.B),         NormalButtonPress(Keys.RButton) },
                    { (int)new GamepadFlags(GamepadButtonFlags.LeftThumb), NormalButtonPress(Keys.MButton) },
                    { (int)new GamepadFlags(GamepadButtonFlags.Y),         NormalButtonPress(SpecialAction.Turbo) },
                    { (int)new GamepadFlags(GamepadButtonFlags.DPadUp),    NormalButtonPress(Keys.Up) },
                    { (int)new GamepadFlags(GamepadButtonFlags.DPadRight), NormalButtonPress(Keys.Right) },
                    { (int)new GamepadFlags(GamepadButtonFlags.DPadDown),  NormalButtonPress(Keys.Down) },
                    { (int)new GamepadFlags(GamepadButtonFlags.DPadLeft),  NormalButtonPress(Keys.Left) },
                    { (int)new GamepadFlags(0,false,false,false,false,0,0,0,1), NormalButtonPress(Keys.PageDown) },
                    { (int)new GamepadFlags(0,false,false,false,false,0,0,0,2), NormalButtonPress(Keys.PageUp) }
                }
            };
        }
    }
}
