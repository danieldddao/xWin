using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xWin.Library;
using System.Windows.Forms;
using Moq;

namespace MSTest.Library
{
    [TestClass]
    public class XKeyboardTest
    {
        XKeyBoard xKeyboard;
        Mock<XKeyBoard> mockXKeyboard;

        [TestInitialize]
        public void Setup()
        {
            xKeyboard = new XKeyBoard();
            mockXKeyboard = new Mock<XKeyBoard>();
        }

        [TestMethod]
        public void TestPressKeyFormsKeys()
        {
            bool status = xKeyboard.PressKey(Keys.A);
            Assert.IsTrue(status);
        }
        [TestMethod()]
        [ExpectedException(typeof(System.Exception), AllowDerivedTypes = true)]
        public void TestPressKeyFormsKeys_PressException()
        {
            mockXKeyboard.Setup(x => x.Press((byte) Keys.A)).Throws(new Exception());
            xKeyboard.PressKey(Keys.A);
            mockXKeyboard.Verify(x => x.Press((byte)'a'), Times.Once);
        }
        [TestMethod()]
        [ExpectedException(typeof(System.Exception), AllowDerivedTypes = true)]
        public void TestPressKeyFormsKeys_ReleaseException()
        {
            mockXKeyboard.Setup(x => x.Release((byte) Keys.A)).Throws(new Exception());
            xKeyboard.PressKey(Keys.A);
            mockXKeyboard.Verify(x => x.Release((byte)'a'), Times.Once);
        }

        [TestMethod]
        public void TestPressKeyChar()
        {
            bool status = xKeyboard.PressKey('A');
            Assert.IsTrue(status);
        }
        [TestMethod()]
        [ExpectedException(typeof(System.Exception), AllowDerivedTypes = true)]
        public void TestPressKeyChar_PressException()
        {
            mockXKeyboard.Setup(x => x.Press((byte)'B')).Throws(new Exception());
            xKeyboard.PressKey('B');
            mockXKeyboard.Verify(x => x.Press((byte)'a'), Times.Once);
        }
        [TestMethod()]
        [ExpectedException(typeof(System.Exception), AllowDerivedTypes = true)]
        public void TestPressKeyChar_ReleaseException()
        {
            mockXKeyboard.Setup(x => x.Release((byte)'B')).Throws(new Exception());
            xKeyboard.PressKey('B');
            mockXKeyboard.Verify(x => x.Release((byte)'a'), Times.Once);
        }

        [TestMethod()]
        public void TestPressKeysFromString()
        {
            bool status = xKeyboard.PressKeysFromString("ab");
            Assert.IsTrue(status);
        }
        [TestMethod()]
        [ExpectedException(typeof(System.Exception), AllowDerivedTypes = true)]
        public void TestPressKeysFromString_PressException()
        {
            mockXKeyboard = new Mock<XKeyBoard>();
            mockXKeyboard.Setup(x => x.Press((byte)'a')).Throws(new Exception());
            xKeyboard.PressKeysFromString("ab");
            mockXKeyboard.Verify(x => x.Press((byte)'a'), Times.Once);
        }
        [TestMethod()]
        [ExpectedException(typeof(System.Exception), AllowDerivedTypes = true)]
        public void TestPressKeysFromString_ReleaseException()
        {
            mockXKeyboard = new Mock<XKeyBoard>();
            mockXKeyboard.Setup(x => x.Release((byte)'a')).Throws(new Exception());
            xKeyboard.PressKeysFromString("ab");
            mockXKeyboard.Verify(x => x.Release((byte)'a'), Times.Once);
        }
    }
}
