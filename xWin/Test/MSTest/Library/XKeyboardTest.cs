using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using xWin.Library;
using System.Windows.Forms;
using Moq;
using xWin.Wrapper;
using System.Runtime.InteropServices;

namespace MSTest.Library
{
    [TestClass]
    public class XKeyboardTest
    {
        [DllImport("user32.dll")]
        public static extern short VkKeyScan(char s);

        XKeyBoard xKeyboard;
        Mock<ISystemWrapper> mockSystemWrapper;

        [TestInitialize]
        public void Setup()
        {
            mockSystemWrapper = new Mock<ISystemWrapper>();
            xKeyboard = new XKeyBoard(mockSystemWrapper.Object);
        }

        [TestCleanup]
        public void Cleanup()
        {
            mockSystemWrapper.VerifyAll();
        }

        /*************************************/
        /* Test PressKey(Keys key) function */
        [TestMethod]
        public void TestPressKeyFormsKeys()
        {
            mockSystemWrapper.Setup(x => x.Press((byte)Keys.A));
            mockSystemWrapper.Setup(x => x.Release((byte)Keys.A));

            bool status = xKeyboard.PressKey(Keys.A);
            Assert.IsTrue(status);
        }
        [TestMethod]
        public void TestPressKeyFormsKeys_PressException()
        {
            mockSystemWrapper.Setup(x => x.Press((byte) Keys.A)).Throws(new Exception());

            bool status = xKeyboard.PressKey(Keys.A);
            Assert.IsFalse(status);
        }
        [TestMethod]
        public void TestPressKeyFormsKeys_ReleaseException()
        {
            mockSystemWrapper.Setup(x => x.Press((byte)Keys.A));
            mockSystemWrapper.Setup(x => x.Release((byte) Keys.A)).Throws(new Exception());

            bool status = xKeyboard.PressKey(Keys.A);
            Assert.IsFalse(status);
        }

        /***********************************/
        /* Test PressKey(char c) function */
        [TestMethod]
        public void TestPressKeyChar()
        {
            mockSystemWrapper.Setup(x => x.ScanKey('a')).Returns(1);
            mockSystemWrapper.Setup(x => x.Press((byte) 1));
            mockSystemWrapper.Setup(x => x.Release((byte) 1));

            bool status = xKeyboard.PressKey('a');
            Assert.IsTrue(status);
        }
        [TestMethod]
        public void TestPressKeyChar_UpperCase()
        {
            mockSystemWrapper.Setup(x => x.ScanKey('A')).Returns(1);
            mockSystemWrapper.Setup(x => x.Press((byte)1));
            mockSystemWrapper.Setup(x => x.Release((byte)1));

            bool status = xKeyboard.PressKey('A');
            Assert.IsTrue(status);
            mockSystemWrapper.Verify(x => x.Press(0x10), Times.Once());
            mockSystemWrapper.Verify(x => x.Release(0x10), Times.Once());
        }
        [TestMethod]
        public void TestPressKeyChar_PressException()
        {
            mockSystemWrapper.Setup(x => x.ScanKey('B')).Returns(1);
            mockSystemWrapper.Setup(x => x.Press((byte) 1)).Throws(new Exception());

            bool status = xKeyboard.PressKey('B');
            Assert.IsFalse(status);
        }
        [TestMethod]
        public void TestPressKeyChar_ReleaseException()
        {
            mockSystemWrapper.Setup(x => x.ScanKey('B')).Returns(1);
            mockSystemWrapper.Setup(x => x.Press((byte) 1));
            mockSystemWrapper.Setup(x => x.Release((byte) 1)).Throws(new Exception());

            bool status = xKeyboard.PressKey('B');
            Assert.IsFalse(status);
        }

        /************************************************/
        /* Test PressKeysFromString(string s) function */
        [TestMethod]
        public void TestPressKeysFromString()
        {
            mockSystemWrapper.Setup(x => x.ScanKey('a')).Returns(1);
            mockSystemWrapper.Setup(x => x.ScanKey('b')).Returns(2);
            mockSystemWrapper.Setup(x => x.Press((byte) 1));
            mockSystemWrapper.Setup(x => x.Release((byte) 1));
            mockSystemWrapper.Setup(x => x.Press((byte) 2));
            mockSystemWrapper.Setup(x => x.Release((byte) 2));

            bool status = xKeyboard.PressKeysFromString("ab");
            Assert.IsTrue(status);
        }
        [TestMethod]
        public void TestPressKeysFromString_UpperCase()
        {
            mockSystemWrapper.Setup(x => x.ScanKey('A')).Returns(1);
            mockSystemWrapper.Setup(x => x.ScanKey('b')).Returns(2);
            mockSystemWrapper.Setup(x => x.Press(0x10)); // press shift key
            mockSystemWrapper.Setup(x => x.Press((byte)1));
            mockSystemWrapper.Setup(x => x.Release((byte)1));
            mockSystemWrapper.Setup(x => x.Press((byte)2));
            mockSystemWrapper.Setup(x => x.Release((byte)2));

            bool status = xKeyboard.PressKeysFromString("Ab");
            Assert.IsTrue(status);
        }
        [TestMethod]
        public void TestPressKeysFromString_PressException()
        {
            mockSystemWrapper.Setup(x => x.ScanKey('a')).Returns(1);
            mockSystemWrapper.Setup(x => x.Press((byte) 1)).Throws(new Exception());

            bool status = xKeyboard.PressKeysFromString("ab");
            Assert.IsFalse(status);
        }
        [TestMethod]
        public void TestPressKeysFromString_ReleaseException()
        {
            mockSystemWrapper.Setup(x => x.ScanKey('a')).Returns(1);
            mockSystemWrapper.Setup(x => x.Press((byte) 1));
            mockSystemWrapper.Setup(x => x.Release((byte) 1)).Throws(new Exception());

            bool status = xKeyboard.PressKeysFromString("ab");
            Assert.IsFalse(status);
        }

        /*************************************************/
        /* Test PressShortcut(Keys[] shortcut) function */
        [TestMethod]
        public void TestPressShortcut()
        {
            mockSystemWrapper.Setup(x => x.Press((byte)Keys.LWin));
            mockSystemWrapper.Setup(x => x.Release((byte)Keys.LWin));
            mockSystemWrapper.Setup(x => x.Press((byte)Keys.R));
            mockSystemWrapper.Setup(x => x.Release((byte)Keys.R));

            Keys[] shortcut = { Keys.LWin, Keys.R };
            bool status = xKeyboard.PressShortcut(shortcut);
            Assert.IsTrue(status);
        }
        [TestMethod]
        public void TestPressShortcut_PressException()
        {
            Keys[] shortcut = { Keys.LWin, Keys.R };
            mockSystemWrapper.Setup(x => x.Press((byte)Keys.LWin));
            mockSystemWrapper.Setup(x => x.Press((byte) Keys.R)).Throws(new Exception());
            bool status = xKeyboard.PressShortcut(shortcut);
            Assert.IsFalse(status);
        }
        [TestMethod]
        public void TestPressShortcut_ReleaseException()
        {
            Keys[] shortcut = { Keys.LWin, Keys.R };
            mockSystemWrapper.Setup(x => x.Press((byte)Keys.LWin));
            mockSystemWrapper.Setup(x => x.Press((byte)Keys.R));
            mockSystemWrapper.Setup(x => x.Release((byte)Keys.LWin));
            mockSystemWrapper.Setup(x => x.Release((byte) Keys.R)).Throws(new Exception());

            bool status = xKeyboard.PressShortcut(shortcut);
            Assert.IsFalse(status);
        }

        /***********************************************/
        /* Test OpenApplication(string path) function */
        [TestMethod]
        public void TestOpenApplication()
        {
            mockSystemWrapper.Setup(x => x.IsFileExist("file")).Returns(true);
            mockSystemWrapper.Setup(x => x.StartProcess("file"));

            bool status = xKeyboard.OpenApplication("file");
            Assert.IsTrue(status);
        }
        [TestMethod]
        public void TestOpenApplication_NonExistFile()
        {
            mockSystemWrapper.Setup(x => x.IsFileExist("file")).Returns(false);

            bool status = xKeyboard.OpenApplication("file");
            Assert.IsFalse(status);
        }
        [TestMethod]
        public void TestOpenApplication_IsFileExistException()
        {
            mockSystemWrapper.Setup(x => x.IsFileExist("file")).Throws(new Exception());

            bool status = xKeyboard.OpenApplication("file");
            Assert.IsFalse(status);
        }
        [TestMethod]
        public void TestOpenApplication_StartProcessException()
        {
            mockSystemWrapper.Setup(x => x.IsFileExist("file")).Returns(true);
            mockSystemWrapper.Setup(x => x.StartProcess("file")).Throws(new Exception());

            bool status = xKeyboard.OpenApplication("file");
            Assert.IsFalse(status);
        }
    }
}
