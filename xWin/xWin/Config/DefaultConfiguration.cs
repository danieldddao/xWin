using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BasicControl.Types;
using SharpDX.XInput;
using xWin.Library;
using static KeyboardSet.Types;
using static TypingControl.Types;

using static xWin.Config.BasicControlHelpers;
using static xWin.Config.TypingControlHelpers;



namespace xWin.Config
{
    public static class BasicControlHelpers
    {
        public static Behavior NormalButtonPress(Keys k)
        {
            var b = new Behavior
            {
                //OnPress = new Actions { Keybinds = { (int)k } },
                OnHold = new Actions { Keybinds = { (int)k } }
            };
            return b;
        }
        public static Behavior NormalButtonPress(SpecialAction sa)
        {
            return new Behavior
            {
                //OnPress = new Actions { SpecialActions = { sa } },
                OnHold = new Actions { SpecialActions = { sa } }
            };
        }

        public static Behavior NoHoldButtonPress(Keys k)
        {
            var b = new Behavior
            {
                OnPress = new Actions { Keybinds = { (int)k } }
            };
            return b;
        }
        public static Behavior NoHoldButtonPress(SpecialAction sa)
        {
            var b = new Behavior
            {
                OnPress = new Actions { SpecialActions = { sa } }
            };
            return b;
        }
        public static Behavior NormalButtonRelease(Keys k)
        {
            var b = new Behavior
            {
                //OnRelease = new Actions { Keybinds = { (int)k } },
                OnStay = new Actions { Keybinds = { (int)k } }
            };
            return b;
        }
        public static Behavior NormalButtonRelease(SpecialAction sa)
        {
            return new Behavior
            {
                //OnRelease = new Actions { SpecialActions = { sa } },
                OnStay = new Actions { SpecialActions = { sa } }
            };
        }

        public static Behavior NoHoldButtonRelease(Keys k)
        {
            var b = new Behavior
            {
                OnRelease = new Actions { Keybinds = { (int)k } }
            };
            return b;
        }
        public static Behavior NoHoldButtonRelease(SpecialAction sa)
        {
            var b = new Behavior
            {
                OnRelease = new Actions { SpecialActions = { sa } }
            };
            return b;
        }
    }

    public static class TypingControlHelpers
    {
        public static KeyboardActionContainer ActionOnPress(KeyboardAction ka)
        {
            return new KeyboardActionContainer
            {
                Binding = ka,
                WhenActive = ActiveWhen.Pressed
            };
        }
        public static KeyboardActionContainer ActionOnHold(KeyboardAction ka)
        {
            return new KeyboardActionContainer
            {
                Binding = ka,
                WhenActive = ActiveWhen.Held
            };
        }
        public static KeyboardActionContainer ActionOnRelease(KeyboardAction ka)
        {
            return new KeyboardActionContainer
            {
                Binding = ka,
                WhenActive = ActiveWhen.Released
            };
        }
        public static KeyboardActionContainer ActionOnStay(KeyboardAction ka)
        {
            return new KeyboardActionContainer
            {
                Binding = ka,
                WhenActive = ActiveWhen.Stayed
            };
        }
    }

    public static class Defaults
    {
        public static uint DEADZONE = 7000;
        public static byte TRIGGER_DEADZONE = 5;
        public static Configuration DefaultConfiguration()
        {
            return new Configuration
            {
                Basic = DefaultBasicControl(),
                Typing = DefaultTypingConfiguration(),
                Togglestop = (int)new GamepadFlags(GamepadButtonFlags.Start | GamepadButtonFlags.Back)
            };
        }
        public static Configuration DefaultConfiguration2()
        {
            return new Configuration
            {
                Basic = DefaultBasicControl2(),
                Typing = DefaultTypingConfiguration2(),
                Togglestop = (int)new GamepadFlags(GamepadButtonFlags.Start | GamepadButtonFlags.Back)
            };
        }

        /*
        **Left Stick controls mouse, Right Stick does Page Up and Page Down, Dpad is Arrow Keys, Left Thumb is middle click
        **A is Left Click, B is Right Click, Y is Turbo
        */
        public static BasicControl DefaultBasicControl()
        {
            return new BasicControl
            {
                Repeaterate = 400000,
                Repeatdelay = 4000000,
                LeftStick = new Stick
                {
                    Deadzone = DEADZONE,
                    ControlMouse = true
                },
                RightStick = new Stick
                {
                    Deadzone = DEADZONE,
                    Regions = { 180, 180 }
                },
                LeftTrigger = new Trigger
                {
                    Deadzone = TRIGGER_DEADZONE
                    //one region
                },
                RightTrigger = new Trigger
                {
                    Deadzone = TRIGGER_DEADZONE,
                    //Regions = {250}
                },
                ButtonMap =
                {
                    { (int)new GamepadFlags(GamepadButtonFlags.A),         NormalButtonPress(Keys.LButton) },
                    { (int)new GamepadFlags(GamepadButtonFlags.B),         NormalButtonPress(Keys.RButton) },
                    { (int)new GamepadFlags(GamepadButtonFlags.LeftThumb), NormalButtonPress(Keys.MButton) },
                    { (int)new GamepadFlags(GamepadButtonFlags.Y),         NormalButtonPress(Keys.A) },
                    { (int)new GamepadFlags(GamepadButtonFlags.X),         NormalButtonPress(SpecialAction.Precision) },
                    { (int)new GamepadFlags(GamepadButtonFlags.DPadUp),    NoHoldButtonPress(SpecialAction.ScrollUp) },
                    { (int)new GamepadFlags(GamepadButtonFlags.DPadRight), NoHoldButtonPress(SpecialAction.ScrollRight) },
                    { (int)new GamepadFlags(GamepadButtonFlags.DPadDown),  NoHoldButtonPress(SpecialAction.ScrollDown) },
                    { (int)new GamepadFlags(GamepadButtonFlags.DPadLeft),  NoHoldButtonPress(SpecialAction.ScrollLeft) },
                    //{ (int)new GamepadFlags(0,false,false,false,false,0,0,0,1), NormalButtonPress(Keys.PageUp) },
                    //{ (int)new GamepadFlags(0,false,false,false,false,0,0,0,2), NormalButtonPress(Keys.PageDown) },
                    { (int)new GamepadFlags(0,false,false,false,true), NormalButtonRelease(SpecialAction.EnterTypingMode) }


                }
            };
        }
        public static TypingControl DefaultTypingConfiguration()
        {
            return new TypingControl
            {
                Description = "the default typing control",
                Tier1 = {   (int)new GamepadFlags(0, false, false, false, false, 0, 0, 0, 1),
                            (int)new GamepadFlags(0, false, false, false, false, 0, 0, 0, 2),
                            (int)new GamepadFlags(0, false, false, false, false, 0, 0, 0, 3),
                            (int)new GamepadFlags(0, false, false, false, false, 0, 0, 0, 4)
                },
                Tier2 = {   (int)new GamepadFlags(0, false, false, false, false, 0, 0, 1),
                            (int)new GamepadFlags(0, false, false, false, false, 0, 0, 2),
                            (int)new GamepadFlags(0, false, false, false, false, 0, 0, 3),
                            (int)new GamepadFlags(0, false, false, false, false, 0, 0, 4),
                            (int)new GamepadFlags(0, false, false, false, false, 0, 0, 5),
                            (int)new GamepadFlags(0, false, false, false, false, 0, 0, 6),
                            (int)new GamepadFlags(0, false, false, false, false, 0, 0, 7),
                            (int)new GamepadFlags(0, false, false, false, false, 0, 0, 8)
                },
                LeftStick = new Stick
                {
                    Deadzone = DEADZONE,
                    Regions = { 45, 45, 45, 45, 45, 45, 45, 45 }
                },
                RightStick = new Stick
                {
                    Deadzone = DEADZONE,
                    Regions = { 90, 90, 90, 90 }
                },
                Base = new KeyboardSet
                {
                    Count = 4,
                    Subcount = 8,
                    Set =
                    {
                        new StringChoice { Subset = { "a","b","c","d","e","f","g","h"} },
                        new StringChoice { Subset = { "i","j","k","l","m","n","o","p"} },
                        new StringChoice { Subset = { "q","r","s","t","u","v","w","x"} },
                        new StringChoice { Subset = { "y","z","0","1","2","3","4","5"} },
                    }
                },

                KeyboardSelect =
                {
                    { (int)new GamepadFlags(GamepadButtonFlags.RightShoulder),
                        new KeyboardSet
                        {
                            Count = 4,
                            Subcount = 8,
                            Set =
                            {
                                new StringChoice { Subset = { "A","B","C","D","E","F","G","H"} },
                                new StringChoice { Subset = { "I","J","K","L","M","N","O","P"} },
                                new StringChoice { Subset = { "Q","R","S","T","U","V","W","X"} },
                                new StringChoice { Subset = { "Y","Z","6","7","8","9",".","?"} },
                            }
                        }
                    }
                },

                Bindings =
                {
                    {
                        (int)new GamepadFlags(GamepadButtonFlags.None,false,false,true),
                        new KeyboardActionContainer {Binding = KeyboardAction.Confirm, WhenActive=ActiveWhen.Pressed }
                    },
                    {
                        (int)new GamepadFlags(GamepadButtonFlags.None,false,false,false,true),
                        new KeyboardActionContainer {Binding = KeyboardAction.LeaveTyping, WhenActive=ActiveWhen.Pressed }
                    },
                    {  (int)new GamepadFlags(GamepadButtonFlags.DPadUp),ActionOnHold(KeyboardAction.CursorUp) },
                    {  (int)new GamepadFlags(GamepadButtonFlags.DPadDown),ActionOnHold(KeyboardAction.CursorDown) },
                    {  (int)new GamepadFlags(GamepadButtonFlags.DPadLeft),ActionOnHold(KeyboardAction.CursorLeft) },
                    {  (int)new GamepadFlags(GamepadButtonFlags.DPadRight),ActionOnHold(KeyboardAction.CursorRight) }
                }
            };
        }

        public static BasicControl DefaultBasicControl2()
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
                    Regions = { 180, 180 }
                },
                LeftTrigger = new Trigger
                {
                    Deadzone = TRIGGER_DEADZONE
                    //one region
                },
                RightTrigger = new Trigger
                {
                    Deadzone = TRIGGER_DEADZONE,
                    //Regions = {250}
                },
                ButtonMap =
                {
                    { (int)new GamepadFlags(GamepadButtonFlags.A),         NormalButtonPress(Keys.LButton) },
                    { (int)new GamepadFlags(GamepadButtonFlags.B),         NormalButtonPress(Keys.RButton) },
                    { (int)new GamepadFlags(GamepadButtonFlags.LeftThumb), NormalButtonPress(Keys.MButton) },
                    { (int)new GamepadFlags(GamepadButtonFlags.Y),         NormalButtonPress(SpecialAction.Turbo) },
                    { (int)new GamepadFlags(GamepadButtonFlags.X),         NormalButtonPress(SpecialAction.Precision) },
                    { (int)new GamepadFlags(GamepadButtonFlags.DPadUp),    NormalButtonPress(Keys.Up) },
                    { (int)new GamepadFlags(GamepadButtonFlags.DPadRight), NormalButtonPress(Keys.Right) },
                    { (int)new GamepadFlags(GamepadButtonFlags.DPadDown),  NormalButtonPress(Keys.Down) },
                    { (int)new GamepadFlags(GamepadButtonFlags.DPadLeft),  NormalButtonPress(Keys.Left) },
                    //{ (int)new GamepadFlags(0,false,false,false,false,0,0,0,1), NormalButtonPress(Keys.PageUp) },
                    //{ (int)new GamepadFlags(0,false,false,false,false,0,0,0,2), NormalButtonPress(Keys.PageDown) },
                    { (int)new GamepadFlags(0,false,true), NormalButtonRelease(SpecialAction.EnterTypingMode) }

                }
            };
        }
        public static TypingControl DefaultTypingConfiguration2()
        {
            return new TypingControl
            {
                Description = "the default typing control",
                Tier1 = {   (int)new GamepadFlags(GamepadButtonFlags.A),
                            (int)new GamepadFlags(GamepadButtonFlags.B),
                            (int)new GamepadFlags(GamepadButtonFlags.X),
                            (int)new GamepadFlags(GamepadButtonFlags.Y)
                },
                Tier2 = {   (int)new GamepadFlags(0, false, false, false, false, 0, 0, 1),
                            (int)new GamepadFlags(0, false, false, false, false, 0, 0, 2),
                            (int)new GamepadFlags(0, false, false, false, false, 0, 0, 3),
                            (int)new GamepadFlags(0, false, false, false, false, 0, 0, 4),
                            (int)new GamepadFlags(0, false, false, false, false, 0, 0, 5),
                            (int)new GamepadFlags(0, false, false, false, false, 0, 0, 6),
                            (int)new GamepadFlags(0, false, false, false, false, 0, 0, 7),
                            (int)new GamepadFlags(0, false, false, false, false, 0, 0, 8)
                },
                LeftStick = new Stick
                {
                    Deadzone = DEADZONE,
                    Regions = { 45, 45, 45, 45, 45, 45, 45, 45 }
                },
                RightStick = new Stick
                {
                    Deadzone = DEADZONE,
                    Regions = { 90, 90, 90, 90 }
                },
                RightTrigger = new Trigger
                {
                    Deadzone = TRIGGER_DEADZONE,
                    //Regions = {250}
                },
                Base = new KeyboardSet
                {
                    Count = 4,
                    Subcount = 8,
                    Set =
                    {
                        new StringChoice { Subset = { "τ","µ","σ","Σ","π","Γ","ß","α"} },
                        new StringChoice { Subset = { "i","j","k","l","m","n","o","p"} },
                        new StringChoice { Subset = { "q","r","s","t","u","v","w","x"} },
                        new StringChoice { Subset = { "y","z","0","1","2","3","4","5"} },
                    }
                },

                KeyboardSelect =
                {
                    { (int)new GamepadFlags(GamepadButtonFlags.RightShoulder),
                        new KeyboardSet
                        {
                            Count = 4,
                            Subcount = 8,
                            Set =
                            {
                                new StringChoice { Subset = { "A","B","C","D","E","F","G","H"} },
                                new StringChoice { Subset = { "I","J","K","L","M","N","O","P"} },
                                new StringChoice { Subset = { "Q","R","S","T","U","V","W","X"} },
                                new StringChoice { Subset = { "Y","Z","6","7","8","9",".","?"} },
                            }
                        }
                    }
                },

                Bindings =
                {
                    { (int)new GamepadFlags(0,false,false,true),ActionOnPress(KeyboardAction.Confirm) },
                    { (int)new GamepadFlags(0,false,true),ActionOnPress(KeyboardAction.LeaveTyping) }
                }
            };
        }
        
    }
}
