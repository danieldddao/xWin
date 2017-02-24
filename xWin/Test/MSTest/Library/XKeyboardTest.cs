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
        Mock<ISystemWrapper> mockWrapper;

        [TestInitialize]
        public void Setup()
        {
            xKeyboard = new XKeyBoard();
            mockWrapper = new Mock<ISystemWrapper>();
        }

        /* Test PressKey(Keys key) function */
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
            bool status = xKeyboard.PressKey(Keys.A);
            Assert.IsFalse(status);
            mockXKeyboard.Verify(x => x.Press((byte)'a'), Times.Once);
        }
        [TestMethod()]
        [ExpectedException(typeof(System.Exception), AllowDerivedTypes = true)]
        public void TestPressKeyFormsKeys_ReleaseException()
        {
            mockXKeyboard.Setup(x => x.Release((byte) Keys.A)).Throws(new Exception());
            bool status = xKeyboard.PressKey(Keys.A);
            Assert.IsFalse(status);
            mockXKeyboard.Verify(x => x.Release((byte)'a'), Times.Once);
        }

        /* Test PressKey(char c) function */
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
            bool status = xKeyboard.PressKey('B');
            Assert.IsFalse(status);
            mockXKeyboard.Verify(x => x.Press((byte)'a'), Times.Once);
        }
        [TestMethod()]
        [ExpectedException(typeof(System.Exception), AllowDerivedTypes = true)]
        public void TestPressKeyChar_ReleaseException()
        {
            mockXKeyboard.Setup(x => x.Release((byte)'B')).Throws(new Exception());
            bool status = xKeyboard.PressKey('B');
            Assert.IsFalse(status);
            mockXKeyboard.Verify(x => x.Release((byte)'a'), Times.Once);
        }

        /* Test PressKeysFromString(string s) function */
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
            mockXKeyboard.Setup(x => x.Press((byte)'a')).Throws(new Exception());
            bool status = xKeyboard.PressKeysFromString("ab");
            Assert.IsFalse(status);
            mockXKeyboard.Verify(x => x.Press((byte)'a'), Times.Once);
        }
        [TestMethod()]
        [ExpectedException(typeof(System.Exception), AllowDerivedTypes = true)]
        public void TestPressKeysFromString_ReleaseException()
        {
            mockXKeyboard.Setup(x => x.Release((byte)'a')).Throws(new Exception());
            bool status = xKeyboard.PressKeysFromString("ab");
            Assert.IsFalse(status);
            mockXKeyboard.Verify(x => x.Release((byte)'a'), Times.Once);
        }

        /* Test PressShortcut(Keys[] shortcut) function */
        [TestMethod()]
        public void TestPressShortcut()
        {
            Keys[] shortcut = { Keys.None, Keys.R };
            bool status = xKeyboard.PressShortcut(shortcut);
            Assert.IsTrue(status);
        }
        [TestMethod()]
        [ExpectedException(typeof(System.Exception), AllowDerivedTypes = true)]
        public void TestPressShortcut_PressException()
        {
            Keys[] shortcut = { Keys.LWin, Keys.R };
            mockXKeyboard.Setup(x => x.Press((byte) Keys.LWin)).Throws(new Exception());
            bool status = xKeyboard.PressShortcut(shortcut);
            Assert.IsFalse(status);
            mockXKeyboard.Verify(x => x.Press((byte) Keys.LWin), Times.Once);
        }
        [TestMethod()]
        [ExpectedException(typeof(System.Exception), AllowDerivedTypes = true)]
        public void TestPressShortcut_ReleaseException()
        {
            Keys[] shortcut = { Keys.LWin, Keys.R };
            mockXKeyboard.Setup(x => x.Release((byte) Keys.LWin)).Throws(new Exception());
            bool status = xKeyboard.PressShortcut(shortcut);
            Assert.IsFalse(status);
            mockXKeyboard.Verify(x => x.Release((byte) Keys.LWin), Times.Once);
        }

        /* Test OpenApplication(string path) function */
        [TestMethod()]
        public void TestOpenApplication()
        {
            mockWrapper.Setup(x => x.IsFileExist(It.IsAny<string>())).Returns(true);
            xKeyboard = new XKeyBoard(mockWrapper.Object);
            bool status = xKeyboard.OpenApplication("true");
            Assert.IsTrue(status);
            mockWrapper.Verify(x => x.IsFileExist("fail"), Times.Once);
        }
        [TestMethod()]
        public void TestOpenApplication_NonExistFile()
        {
            bool status = xKeyboard.OpenApplication("false");
            Assert.IsFalse(status);
        }
        [TestMethod()]
        [ExpectedException(typeof(System.Exception))]
        public void TestOpenApplication_Exception()
        {
            //mockXKeyboard.Setup(x => x.StartProcess("fail")).Throws(new Exception());
            //bool status = xKeyboard.OpenApplication("fail");
            //Assert.IsFalse(status);
            //mockXKeyboard.Verify(x => x.StartProcess("fail"), Times.Once);
        }
    }
}
