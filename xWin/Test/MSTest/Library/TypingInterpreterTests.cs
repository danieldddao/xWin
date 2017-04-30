using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using xWin.Library;
using SharpDX.XInput;
using System.Windows.Forms;

namespace MSTest.Library
{
    [TestClass]
    class TypingInterpreterTests
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
        public void EmptyTypingdControlTest()
        {
            var c = new TypingInterpreter(new TypingControl());
        }

        [TestMethod]
        public void EmptyTypingControlNoActivityTest()
        {
            var c = new TypingInterpreter(new TypingControl());
            var m = c.NextState(APressed);
            Assert.AreEqual(0, m.t1);
            Assert.AreEqual(0, m.t2);
            Assert.AreEqual(0,m.Text.Length);
        }

        [TestMethod]
        public void teST()
        {

        }
    }
}
