using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using xWin.Library;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static xWin.Library.Interpreter;
using static Configuration.Types;
using System.Diagnostics;

namespace MSTest.Library
{
    [TestClass]
    public class BehaviorsTests
    {
        Behavior b1,b2,b3,b4,b5;
        Stick s1, s2, s3;

        private KeyboardMouseState KMState()
        {
            return new KeyboardMouseState { special = new Queue<SpecialAction>(), mouse_movement = new Queue<PolarStick>(), pressed = new Queue<Keys>() };
        }

        [TestInitialize]
        public void Setup()
        {
            b1 = new Behavior
            {
                OnPress = new Configuration.Types.Action { Keybind = (int)Keys.A },
                OnHold = new Configuration.Types.Action { Keybind = (int)Keys.B },
                OnRelease = new Configuration.Types.Action { Keybind = (int)Keys.C },
                OnStay = new Configuration.Types.Action { Keybind = (int)Keys.D },
                OnPressToggle = false,
                OnReleaseToggle = false
            };
            b2 = new Behavior
            {
                OnPress = new Configuration.Types.Action { SpecialAction = SpecialAction.Turbo },
                OnHold = new Configuration.Types.Action { Keybind = (int)Keys.B },
                OnRelease = new Configuration.Types.Action { SpecialAction = SpecialAction.TypingMode },
                OnStay = new Configuration.Types.Action { Keybind = (int)Keys.D },
                OnPressToggle = true,
                OnReleaseToggle = true
            };
            b3 = new Behavior
            {
                OnPress = new Configuration.Types.Action { SpecialAction = SpecialAction.MouseDown },
                OnHold = new Configuration.Types.Action { SpecialAction = SpecialAction.MouseLeft },
                OnRelease = new Configuration.Types.Action { SpecialAction = SpecialAction.MouseRight },
                OnStay = new Configuration.Types.Action { SpecialAction = SpecialAction.MouseUp },
                OnPressToggle = false,
                OnReleaseToggle = false
            };
            b4 = new Behavior
            {
                OnPress = new Configuration.Types.Action { SpecialAction = SpecialAction.Pass },
                OnHold = new Configuration.Types.Action { SpecialAction = SpecialAction.Pass },
                OnRelease = new Configuration.Types.Action { SpecialAction = SpecialAction.Pass },
                OnStay = new Configuration.Types.Action { SpecialAction = SpecialAction.Pass },
                OnPressToggle = false,
                OnReleaseToggle = false
            };

            b5 = new Behavior
            {
                OnPress = new Configuration.Types.Action { Keybind = (int)Keys.None },
                OnHold = new Configuration.Types.Action { Keybind = (int)Keys.None },
                OnRelease = new Configuration.Types.Action { Keybind = (int)Keys.None },
                OnStay = new Configuration.Types.Action { Keybind = (int)Keys.None },
                OnPressToggle = false,
                OnReleaseToggle = false
            };


            s1 = new Stick
            {
                Deadzone = 1000,
                RegionStart = 0,
                ControlMouse = false,
                StayBehavior = b1,
                Regions = { new Region { Range = 180, Behavior = b3 }, new Region { Range = 180, Behavior = b5 } }
            };
            s2 = new Stick
            {
                Deadzone = 1000,
                ControlMouse = true,
                InvertLr = false,
                InvertUd = false
            };

            s3 = new Stick
            {
                Deadzone = 1000,
                ControlMouse = true,
                InvertLr = true,
                InvertUd = true
            };


        }

        [TestCleanup]
        public void Cleanup()
        {

        }

        [TestMethod]
        public void TestASpecialActionFeed()
        {
            var sa = new ASpecialAction(SpecialAction.Turbo);
            var s = KMState();
            sa.feed(s);
            Assert.AreEqual(1, s.special.Count);
            Assert.AreEqual(0, s.mouse_movement.Count);
            Assert.AreEqual(0, s.pressed.Count);
            Assert.AreEqual(SpecialAction.Turbo, s.special.Dequeue());
        }

        [TestMethod]
        public void TestANormalActionFeed()
        {
            var na = new ANormalAction(Keys.NumPad5);
            var s = KMState();
            na.feed(s);
            Assert.AreEqual(0, s.special.Count);
            Assert.AreEqual(0, s.mouse_movement.Count);
            Assert.AreEqual(1, s.pressed.Count);
            Assert.AreEqual(Keys.NumPad5, s.pressed.Dequeue());
        }

        [TestMethod]
        public void TestButtonBehaviorWithKeybinds()
        {
            KeyboardMouseState kmstate = KMState();
            var bb = new ButtonBehavior(b1);
            bb.Act(true, kmstate);
            bb.Act(true, kmstate);
            bb.Act(false, kmstate);
            bb.Act(false, kmstate);

            Assert.AreEqual(4, kmstate.pressed.Count);

            Assert.AreEqual(Keys.A, kmstate.pressed.Dequeue());
            Assert.AreEqual(Keys.B, kmstate.pressed.Dequeue());
            Assert.AreEqual(Keys.C, kmstate.pressed.Dequeue());
            Assert.AreEqual(Keys.D, kmstate.pressed.Dequeue());
            
            Assert.AreEqual(0, kmstate.special.Count);
            Assert.AreEqual(0, kmstate.mouse_movement.Count);
        }

        [TestMethod]
        public void TestButtonBehaviorWithSpecialActions()
        {
            var kmstate = KMState();
            var bb = new ButtonBehavior(b3);
            bb.Act(true, kmstate);
            bb.Act(true, kmstate);
            bb.Act(false, kmstate);
            bb.Act(false, kmstate);

            Assert.AreEqual(4, kmstate.special.Count);

            Assert.AreEqual(SpecialAction.MouseDown, kmstate.special.Dequeue());
            Assert.AreEqual(SpecialAction.MouseLeft, kmstate.special.Dequeue());
            Assert.AreEqual(SpecialAction.MouseRight, kmstate.special.Dequeue());
            Assert.AreEqual(SpecialAction.MouseUp, kmstate.special.Dequeue());
            
            Assert.AreEqual(0, kmstate.pressed.Count);
            Assert.AreEqual(0, kmstate.mouse_movement.Count);

        }

        [TestMethod]
        public void TestButtonBehaviorWithToggle()
        {
            KeyboardMouseState kmstate = KMState();
            var bb = new ButtonBehavior(b2);
            bb.Act(true, kmstate);
            bb.Act(true, kmstate);
            bb.Act(false, kmstate);
            bb.Act(false, kmstate);
            bb.Act(true, kmstate);
            bb.Act(true, kmstate);
            bb.Act(false, kmstate);
            bb.Act(false, kmstate);

            Assert.AreEqual(4, kmstate.pressed.Count);
            Assert.AreEqual(Keys.B, kmstate.pressed.Dequeue());
            Assert.AreEqual(Keys.D, kmstate.pressed.Dequeue());
            Assert.AreEqual(Keys.B, kmstate.pressed.Dequeue());
            Assert.AreEqual(Keys.D, kmstate.pressed.Dequeue());

            Assert.AreEqual(8, kmstate.special.Count);
            Assert.AreEqual(SpecialAction.Turbo, kmstate.special.Dequeue());
            Assert.AreEqual(SpecialAction.Turbo, kmstate.special.Dequeue());
            Assert.AreEqual(SpecialAction.Turbo, kmstate.special.Dequeue());
            Assert.AreEqual(SpecialAction.TypingMode, kmstate.special.Dequeue());
            Assert.AreEqual(SpecialAction.Turbo, kmstate.special.Dequeue());
            Assert.AreEqual(SpecialAction.TypingMode, kmstate.special.Dequeue());
            Assert.AreEqual(SpecialAction.TypingMode, kmstate.special.Dequeue());
            Assert.AreEqual(SpecialAction.TypingMode, kmstate.special.Dequeue());

            Assert.AreEqual(0, kmstate.mouse_movement.Count);
        }

        [TestMethod]
        public void TestButtonBehaviorEmpty()
        {
            KeyboardMouseState kmstate = KMState();
            var bb = new ButtonBehavior(b5);
            bb.Act(true, kmstate);
            bb.Act(true, kmstate);
            bb.Act(false, kmstate);
            bb.Act(false, kmstate);

            Assert.AreEqual(0, kmstate.pressed.Count);
            Assert.AreEqual(0, kmstate.special.Count);
            Assert.AreEqual(0, kmstate.mouse_movement.Count);
        }


        [TestMethod]
        public void TestRegionStickBehavior ()
        {
            var rsb = new RegionStickBehavior(s1);
            var kmstate = KMState();
            rsb.Act(0, -2000, kmstate);
            Assert.AreEqual(s1.Regions[0].Behavior.OnPress.SpecialAction, kmstate.special.Dequeue());
            Assert.AreEqual((Keys)s1.StayBehavior.OnRelease.Keybind, kmstate.pressed.Dequeue());
            Assert.AreEqual(0, kmstate.special.Count);
            Assert.AreEqual(0, kmstate.mouse_movement.Count);
            Assert.AreEqual(0, kmstate.pressed.Count);
            rsb.Act(0, -2000, kmstate);
            rsb.Act(0, 0, kmstate);
            
        }
    }

}
