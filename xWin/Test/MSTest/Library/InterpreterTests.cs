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
    class InterpreterTests
    {
        private State APressed;
        [TestInitialize]
        public void Setup()
        {
            APressed = new State();
            APressed.Gamepad.Buttons = GamepadButtonFlags.A;
        }

        [TestCleanup]
        public void Cleanup()
        {

        }

        [TestMethod]
        public void ButtonToKeyChain()
        {
            var c = new Interpreter(Defaults.DefaultConfiguration());
            //var s = new State();
            var kms = c.NextState(APressed);
            Assert.AreEqual(0, kms.pressed.Count);
            Assert.AreEqual(kms.pressed.Dequeue(), Keys.LButton);
        }
    }
}
