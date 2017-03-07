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
        Behavior KeyBehavior,SpecialBehavior,NoBehavior,TogglePressBehavior, ToggleReleaseBehavior;
        Stick KeyBehaviorStick, SpinnyBehaviorStick, MouseControlStick;

        private KeyboardMouseState KMState()
        {
            return new KeyboardMouseState { special = new Queue<SpecialAction>(),
                mouse_movement = new Queue<KeyboardMouseState.coord>(), pressed = new Queue<Keys>() };
        }

        [TestInitialize]
        public void Setup()
        {
            KeyBehavior = new Behavior
            {
                OnPress = new Configuration.Types.Action { Keybind = (int)Keys.A },
                OnHold = new Configuration.Types.Action { Keybind = (int)Keys.B },
                OnRelease = new Configuration.Types.Action { Keybind = (int)Keys.C },
                OnStay = new Configuration.Types.Action { Keybind = (int)Keys.D },
                OnPressToggle = false,
                OnReleaseToggle = false
            };
            SpecialBehavior = new Behavior
            {
                OnPress = new Configuration.Types.Action { SpecialAction = SpecialAction.MouseDown },
                OnHold = new Configuration.Types.Action { SpecialAction = SpecialAction.MouseLeft },
                OnRelease = new Configuration.Types.Action { SpecialAction = SpecialAction.MouseRight },
                OnStay = new Configuration.Types.Action { SpecialAction = SpecialAction.MouseUp },
                OnPressToggle = false,
                OnReleaseToggle = false
            };
            NoBehavior = new Behavior
            {
                OnPress = new Configuration.Types.Action { Keybind = (int)Keys.None },
                OnHold = new Configuration.Types.Action { Keybind = (int)Keys.None },
                OnRelease = new Configuration.Types.Action { Keybind = (int)Keys.None },
                OnStay = new Configuration.Types.Action { Keybind = (int)Keys.None },
                OnPressToggle = false,
                OnReleaseToggle = false
            };

            TogglePressBehavior = new Behavior
            {
                OnPress = new Configuration.Types.Action { Keybind = (int)Keys.A },
                OnHold = new Configuration.Types.Action { Keybind = (int)Keys.None },
                OnRelease = new Configuration.Types.Action { Keybind = (int)Keys.None },
                OnStay = new Configuration.Types.Action { Keybind = (int)Keys.None },
                OnPressToggle = true,
                OnReleaseToggle = false
            };

            ToggleReleaseBehavior = new Behavior
            {
                OnPress = new Configuration.Types.Action { Keybind = (int)Keys.None },
                OnHold = new Configuration.Types.Action { Keybind = (int)Keys.None },
                OnRelease = new Configuration.Types.Action { Keybind = (int)Keys.A },
                OnStay = new Configuration.Types.Action { Keybind = (int)Keys.None },
                OnPressToggle = false,
                OnReleaseToggle = true
            };

            var b1 = new Behavior
            {
                OnPress = new Configuration.Types.Action { SpecialAction = SpecialAction.MouseDown },
                OnHold = new Configuration.Types.Action { Keybind = (int)Keys.None },
                OnRelease = new Configuration.Types.Action { Keybind = (int)Keys.None },
                OnStay = new Configuration.Types.Action { Keybind = (int)Keys.None },
                OnPressToggle = false,
                OnReleaseToggle = false
            };

            var b2 = new Behavior
            {
                OnPress = new Configuration.Types.Action { SpecialAction = SpecialAction.MouseUp },
                OnHold = new Configuration.Types.Action { Keybind = (int)Keys.None },
                OnRelease = new Configuration.Types.Action { Keybind = (int)Keys.None },
                OnStay = new Configuration.Types.Action { Keybind = (int)Keys.None },
                OnPressToggle = false,
                OnReleaseToggle = false
            };


            KeyBehaviorStick = new Stick
            {
                Deadzone = 1000,
                RegionStart = 0,
                ControlMouse = false,
                StayBehavior = NoBehavior,
                Regions = { new Region { Range = 180, Behavior = KeyBehavior },
                            new Region { Range = 180, Behavior = NoBehavior } }
            };

            SpinnyBehaviorStick = new Stick
            {
                Deadzone = 1000,
                RegionStart = 0,
                ControlMouse = false,
                StayBehavior = NoBehavior,
                Regions = { new Region { Range = 180, Behavior =b1 },
                            new Region { Range = 180, Behavior =b2 } }
            };

            MouseControlStick = new Stick
            {
                Deadzone = 1000,
                ControlMouse = true
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
        public void TestButtonBehaviorWithKeybinds_Press()
        {
            var bb = new ButtonBehavior(KeyBehavior);
            bb.Act(false, KMState());

            KeyboardMouseState kmstate = KMState();
            bb.Act(true, kmstate);


            Assert.AreEqual(1, kmstate.pressed.Count);
            Assert.AreEqual((Keys)KeyBehavior.OnPress.Keybind, kmstate.pressed.Dequeue());
            
            Assert.AreEqual(0, kmstate.special.Count);
            Assert.AreEqual(0, kmstate.mouse_movement.Count);
        }

        [TestMethod]
        public void TestButtonBehaviorWithKeybinds_Hold()
        {
            var bb = new ButtonBehavior(KeyBehavior);
            bb.Act(true, KMState());

            KeyboardMouseState kmstate = KMState();
            bb.Act(true, kmstate);


            Assert.AreEqual(1, kmstate.pressed.Count);
            Assert.AreEqual((Keys)KeyBehavior.OnHold.Keybind, kmstate.pressed.Dequeue());

            Assert.AreEqual(0, kmstate.special.Count);
            Assert.AreEqual(0, kmstate.mouse_movement.Count);
        }

        [TestMethod]
        public void TestButtonBehaviorWithKeybinds_Release()
        {
            var bb = new ButtonBehavior(KeyBehavior);
            bb.Act(true, KMState());

            KeyboardMouseState kmstate = KMState();
            bb.Act(false, kmstate);


            Assert.AreEqual(1, kmstate.pressed.Count);
            Assert.AreEqual((Keys)KeyBehavior.OnRelease.Keybind, kmstate.pressed.Dequeue());

            Assert.AreEqual(0, kmstate.special.Count);
            Assert.AreEqual(0, kmstate.mouse_movement.Count);
        }

        [TestMethod]
        public void TestButtonBehaviorWithKeybinds_Stay()
        {
            var bb = new ButtonBehavior(KeyBehavior);
            bb.Act(false, KMState());

            KeyboardMouseState kmstate = KMState();
            bb.Act(false, kmstate);


            Assert.AreEqual(1, kmstate.pressed.Count);
            Assert.AreEqual((Keys)KeyBehavior.OnStay.Keybind, kmstate.pressed.Dequeue());

            Assert.AreEqual(0, kmstate.special.Count);
            Assert.AreEqual(0, kmstate.mouse_movement.Count);
        }


        [TestMethod]
        public void TestButtonBehaviorWithSpecialActions_Press()
        {
            var bb = new ButtonBehavior(SpecialBehavior);
            bb.Act(false, KMState());

            KeyboardMouseState kmstate = KMState();
            bb.Act(true, kmstate);
            
            Assert.AreEqual(0, kmstate.pressed.Count);
            Assert.AreEqual(1, kmstate.special.Count);

            Assert.AreEqual((SpecialAction)SpecialBehavior.OnPress.SpecialAction, kmstate.special.Dequeue());

            Assert.AreEqual(0, kmstate.mouse_movement.Count);
        }
        
        [TestMethod]
        public void TestButtonBehaviorWithSpecialActions_Hold()
        {
            var bb = new ButtonBehavior(SpecialBehavior);
            bb.Act(true, KMState());

            KeyboardMouseState kmstate = KMState();
            bb.Act(true, kmstate);

            Assert.AreEqual(0, kmstate.pressed.Count);
            Assert.AreEqual(1, kmstate.special.Count);

            Assert.AreEqual((SpecialAction)SpecialBehavior.OnHold.SpecialAction, kmstate.special.Dequeue());

            Assert.AreEqual(0, kmstate.mouse_movement.Count);
        }

        [TestMethod]
        public void TestButtonBehaviorWithSpecialActions_Release()
        {
            var bb = new ButtonBehavior(SpecialBehavior);
            bb.Act(true, KMState());

            KeyboardMouseState kmstate = KMState();
            bb.Act(false, kmstate);
            
            Assert.AreEqual(0, kmstate.pressed.Count);
            Assert.AreEqual(1, kmstate.special.Count);

            Assert.AreEqual((SpecialAction)SpecialBehavior.OnRelease.SpecialAction, kmstate.special.Dequeue());

            Assert.AreEqual(0, kmstate.mouse_movement.Count);
        }

        [TestMethod]
        public void TestButtonBehaviorWithSpecialActions_Stay()
        {
            var bb = new ButtonBehavior(SpecialBehavior);
            bb.Act(false, KMState());

            KeyboardMouseState kmstate = KMState();
            bb.Act(false, kmstate);

            Assert.AreEqual(0, kmstate.pressed.Count);
            Assert.AreEqual(1, kmstate.special.Count);

            Assert.AreEqual((SpecialAction)SpecialBehavior.OnStay.SpecialAction, kmstate.special.Dequeue());

            Assert.AreEqual(0, kmstate.mouse_movement.Count);
        }

        [TestMethod]
        public void TestButtonBehaviorWithNoAction()
        {
            KeyboardMouseState kmstate = KMState();
            var bb = new ButtonBehavior(NoBehavior);
            bb.Act(true, kmstate);

            Assert.AreEqual(0, kmstate.pressed.Count);
            Assert.AreEqual(0, kmstate.special.Count);
            Assert.AreEqual(0, kmstate.mouse_movement.Count);
        }
        
        [TestMethod]
        public void TestButtonBehaviorWithTogglePress()
        {
            var bb = new ButtonBehavior(TogglePressBehavior);
            bb.Act(false, KMState());

            KeyboardMouseState kmstate = KMState();
            bb.Act(true, kmstate);

            Assert.AreEqual(1, kmstate.pressed.Count);

            Assert.AreEqual((Keys)TogglePressBehavior.OnPress.Keybind, kmstate.pressed.Dequeue());

            Assert.AreEqual(0, kmstate.special.Count);
            Assert.AreEqual(0, kmstate.mouse_movement.Count);

            kmstate = KMState();
            bb.Act(false, KMState());
            bb.Act(false, KMState());
            bb.Act(true, kmstate);

            Assert.AreEqual(0, kmstate.pressed.Count);
            Assert.AreEqual(0, kmstate.special.Count);
            Assert.AreEqual(0, kmstate.mouse_movement.Count);
        }

        [TestMethod]
        public void TestButtonBehaviorWithToggleRelease()
        {
            var bb = new ButtonBehavior(ToggleReleaseBehavior);
            bb.Act(true, KMState());

            KeyboardMouseState kmstate = KMState();
            bb.Act(false, kmstate);

            Assert.AreEqual(1, kmstate.pressed.Count);

            Assert.AreEqual((Keys)ToggleReleaseBehavior.OnRelease.Keybind, kmstate.pressed.Dequeue());

            Assert.AreEqual(0, kmstate.special.Count);
            Assert.AreEqual(0, kmstate.mouse_movement.Count);

            kmstate = KMState();
            bb.Act(true, KMState());
            bb.Act(false, kmstate);

            Assert.AreEqual(0, kmstate.pressed.Count);
            Assert.AreEqual(0, kmstate.special.Count);
            Assert.AreEqual(0, kmstate.mouse_movement.Count);
        }
        
        [TestMethod]
        public void TestRegionStickBehavior()
        {
            var rsb = new RegionStickBehavior(SpinnyBehaviorStick);
            rsb.Act(0, 0, KMState());

            KeyboardMouseState kmstate = KMState();
            rsb.Act(0, -2000, kmstate);
            Assert.AreEqual(0, kmstate.pressed.Count);
            Assert.AreEqual(1, kmstate.special.Count);
            Assert.AreEqual(SpinnyBehaviorStick.Regions[0].Behavior.OnPress.SpecialAction, kmstate.special.Dequeue());
            Assert.AreEqual(0, kmstate.mouse_movement.Count);

            rsb.Act(0, 2000, kmstate);
            Assert.AreEqual(0, kmstate.pressed.Count);
            Assert.AreEqual(1, kmstate.special.Count);
            Assert.AreEqual(SpinnyBehaviorStick.Regions[1].Behavior.OnPress.SpecialAction, kmstate.special.Dequeue());
            Assert.AreEqual(0, kmstate.mouse_movement.Count);
        }

        [TestMethod]
        public void TestMouseControlBehavior_OutsideDeadzone()
        {
            var rsb = new MouseStickBehavior(MouseControlStick);
            var kmstate = KMState();
            rsb.Act(2000, 2000, kmstate);
            Assert.AreEqual(0, kmstate.pressed.Count);
            Assert.AreEqual(0, kmstate.special.Count);
            Assert.AreEqual(1, kmstate.mouse_movement.Count);

            var pl = new PolarStick(2000, 2000, 0);
            var i = kmstate.mouse_movement.Dequeue();
            var p2 = new PolarStick((short)i.x, (short)i.y, 0);
            Assert.AreEqual(pl.theta, p2.theta);

        }
    }

}
