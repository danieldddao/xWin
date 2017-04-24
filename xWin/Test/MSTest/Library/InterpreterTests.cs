using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using xWin.Library;
using xWin.Config;
using SharpDX.XInput;
using System.Windows.Forms;

namespace MSTest.Library
{
    [TestClass]
    public class InterpreterTests
    {
        private Gamepad APressed;

        [TestInitialize]
        public void Setup()
        {
            APressed = new Gamepad();
            APressed.Buttons = GamepadButtonFlags.A;

        }

        [TestCleanup]
        public void Cleanup()
        {

        }

        [TestMethod]
        public void EmptyBasicControlTest()
        {
            var c = new Interpreter(new BasicControl());
        }

        [TestMethod]
        public void EmptyBasicControlNoActivityTest()
        {
            var c = new Interpreter(new BasicControl());
            var m = c.NextState(APressed);
            Assert.AreEqual(0, m.pressed.Count);
            Assert.AreEqual(0, m.special.Count);
            Assert.AreEqual(0, m.mouse_movement.x);
            Assert.AreEqual(0, m.mouse_movement.y);
        }


        [TestMethod]
        public void LooselyDefinedConfigTest()
        {
            var c = new Interpreter(Defaults.DefaultConfiguration());
        }

        [TestMethod]
        public void BlankStateNoReturnTest()//only when there are no "stay" binds defined
        {
            var c = new Interpreter(Defaults.DefaultConfiguration());
            c.Reset();
            var kms = c.NextState(new Gamepad());
            Assert.AreEqual(0, kms.mouse_movement.x);
            Assert.AreEqual(0, kms.mouse_movement.y);
            Assert.AreEqual(0, kms.pressed.Count);
            Assert.AreEqual(0, kms.special.Count);
        }

        [TestMethod]
        public void ButtonToKeyChain()
        {
            var d = Defaults.DefaultConfiguration();
            var c = new Interpreter(d);
            c.Reset();
            var kms = c.NextState(APressed);
            Assert.AreEqual(1, kms.pressed.Count);
            Assert.AreEqual(kms.pressed.Dequeue(),Keys.LButton);
        }

        [TestMethod]
        public void StickToKeyChain()
        {
            var d = Defaults.DefaultConfiguration();
            var c = new Interpreter(d);
            c.Reset();

            Gamepad g = new Gamepad();
            g.RightThumbX = 0;
            g.RightThumbY = 10000;
            g.Buttons = 0;
            var kms = c.NextState(g);
            Assert.AreEqual(1, kms.pressed.Count);
            var s = kms.pressed.Dequeue();
            Assert.AreEqual(Keys.PageUp,s ,string.Format("{0} {1}",(int)Keys.PageUp, (int)s) );

        }

        [TestMethod]
        public void TriggerToKeyChain()
        {
            var d = Defaults.DefaultConfiguration();
            d.ButtonMap.Add((int)new GamepadFlags(0, false, false, false, false, 0, 1, 0, 0), Defaults.NormalButtonPress(Keys.Control));
            var c = new Interpreter(d);
            c.Reset();

            Gamepad g = new Gamepad();
            g.RightTrigger = 255;
            g.Buttons = 0;
            var kms = c.NextState(g);
            Assert.AreEqual(1, kms.pressed.Count);
            var s = kms.pressed.Dequeue();
            Assert.AreEqual(Keys.Control, s, string.Format("{0} {1}", (int)Keys.Control, (int)s));

        }

    }
}
