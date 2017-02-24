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
        Mock<ISystemWrapper> mockWrapper;

        [TestInitialize]
        public void Setup()
        {
            mockWrapper = new Mock<ISystemWrapper>();
            xKeyboard = new XKeyBoard(mockWrapper.Object);
        }

        [TestCleanup]
        public void Cleanup()
        {
            mockWrapper.VerifyAll();
        }

        /*************************************/
        /* Test PressKey(Keys key) function */
        [TestMethod]
        public void TestPressKeyFormsKeys()
        {
            mockWrapper.Setup(x => x.Press((byte)Keys.A));
            mockWrapper.Setup(x => x.Release((byte)Keys.A));

            bool status = xKeyboard.PressKey(Keys.A);
            Assert.IsTrue(status);
        }
        [TestMethod]
        public void TestPressKeyFormsKeys_PressException()
        {
            mockWrapper.Setup(x => x.Press((byte) Keys.A)).Throws(new Exception());

            bool status = xKeyboard.PressKey(Keys.A);
            Assert.IsFalse(status);
        }
        [TestMethod]
        public void TestPressKeyFormsKeys_ReleaseException()
        {
            mockWrapper.Setup(x => x.Press((byte)Keys.A));
            mockWrapper.Setup(x => x.Release((byte) Keys.A)).Throws(new Exception());

            bool status = xKeyboard.PressKey(Keys.A);
            Assert.IsFalse(status);
        }

        /***********************************/
        /* Test PressKey(char c) function */
        [TestMethod]
        public void TestPressKeyChar()
        {
            mockWrapper.Setup(x => x.ScanKey('A')).Returns(1);
            mockWrapper.Setup(x => x.Press((byte) 1));
            mockWrapper.Setup(x => x.Release((byte) 1));

            bool status = xKeyboard.PressKey('A');
            Assert.IsTrue(status);
        }
        [TestMethod]
        public void TestPressKeyChar_PressException()
        {
            mockWrapper.Setup(x => x.ScanKey('B')).Returns(1);
            mockWrapper.Setup(x => x.Press((byte) 1)).Throws(new Exception());

            bool status = xKeyboard.PressKey('B');
            Assert.IsFalse(status);
        }
        [TestMethod]
        public void TestPressKeyChar_ReleaseException()
        {
            mockWrapper.Setup(x => x.ScanKey('B')).Returns(1);
            mockWrapper.Setup(x => x.Press((byte) 1));
            mockWrapper.Setup(x => x.Release((byte) 1)).Throws(new Exception());

            bool status = xKeyboard.PressKey('B');
            Assert.IsFalse(status);
        }

        /************************************************/
        /* Test PressKeysFromString(string s) function */
        [TestMethod]
        public void TestPressKeysFromString()
        {
            mockWrapper.Setup(x => x.ScanKey('a')).Returns(1);
            mockWrapper.Setup(x => x.ScanKey('b')).Returns(2);
            mockWrapper.Setup(x => x.Press((byte) 1));
            mockWrapper.Setup(x => x.Release((byte) 1));
            mockWrapper.Setup(x => x.Press((byte) 2));
            mockWrapper.Setup(x => x.Release((byte) 2));

            bool status = xKeyboard.PressKeysFromString("ab");
            Assert.IsTrue(status);
        }
        [TestMethod]
        public void TestPressKeysFromString_UpperCase()
        {
            mockWrapper.Setup(x => x.ScanKey('A')).Returns(1);
            mockWrapper.Setup(x => x.ScanKey('b')).Returns(2);
            mockWrapper.Setup(x => x.Press(0x10)); // press shift key
            mockWrapper.Setup(x => x.Press((byte)1));
            mockWrapper.Setup(x => x.Release((byte)1));
            mockWrapper.Setup(x => x.Press((byte)2));
            mockWrapper.Setup(x => x.Release((byte)2));

            bool status = xKeyboard.PressKeysFromString("Ab");
            Assert.IsTrue(status);
        }
        [TestMethod]
        public void TestPressKeysFromString_PressException()
        {
            mockWrapper.Setup(x => x.ScanKey('a')).Returns(1);
            mockWrapper.Setup(x => x.Press((byte) 1)).Throws(new Exception());

            bool status = xKeyboard.PressKeysFromString("ab");
            Assert.IsFalse(status);
        }
        [TestMethod]
        public void TestPressKeysFromString_ReleaseException()
        {
            mockWrapper.Setup(x => x.ScanKey('a')).Returns(1);
            mockWrapper.Setup(x => x.Press((byte) 1));
            mockWrapper.Setup(x => x.Release((byte) 1)).Throws(new Exception());

            bool status = xKeyboard.PressKeysFromString("ab");
            Assert.IsFalse(status);
        }

        /*************************************************/
        /* Test PressShortcut(Keys[] shortcut) function */
        [TestMethod]
        public void TestPressShortcut()
        {
            mockWrapper.Setup(x => x.Press((byte)Keys.LWin));
            mockWrapper.Setup(x => x.Release((byte)Keys.LWin));
            mockWrapper.Setup(x => x.Press((byte)Keys.R));
            mockWrapper.Setup(x => x.Release((byte)Keys.R));

            Keys[] shortcut = { Keys.LWin, Keys.R };
            bool status = xKeyboard.PressShortcut(shortcut);
            Assert.IsTrue(status);
        }
        [TestMethod]
        public void TestPressShortcut_PressException()
        {
            Keys[] shortcut = { Keys.LWin, Keys.R };
            mockWrapper.Setup(x => x.Press((byte)Keys.LWin));
            mockWrapper.Setup(x => x.Press((byte) Keys.R)).Throws(new Exception());
            bool status = xKeyboard.PressShortcut(shortcut);
            Assert.IsFalse(status);
        }
        [TestMethod]
        public void TestPressShortcut_ReleaseException()
        {
            Keys[] shortcut = { Keys.LWin, Keys.R };
            mockWrapper.Setup(x => x.Press((byte)Keys.LWin));
            mockWrapper.Setup(x => x.Press((byte)Keys.R));
            mockWrapper.Setup(x => x.Release((byte)Keys.LWin));
            mockWrapper.Setup(x => x.Release((byte) Keys.R)).Throws(new Exception());

            bool status = xKeyboard.PressShortcut(shortcut);
            Assert.IsFalse(status);
        }

        /***********************************************/
        /* Test OpenApplication(string path) function */
        [TestMethod]
        public void TestOpenApplication()
        {
            mockWrapper.Setup(x => x.IsFileExist("file")).Returns(true);
            mockWrapper.Setup(x => x.StartProcess("file"));

            bool status = xKeyboard.OpenApplication("file");
            Assert.IsTrue(status);
        }
        [TestMethod]
        public void TestOpenApplication_NonExistFile()
        {
            mockWrapper.Setup(x => x.IsFileExist("file")).Returns(false);

            bool status = xKeyboard.OpenApplication("file");
            Assert.IsFalse(status);
        }
        [TestMethod]
        public void TestOpenApplication_IsFileExistException()
        {
            mockWrapper.Setup(x => x.IsFileExist("file")).Throws(new Exception());

            bool status = xKeyboard.OpenApplication("file");
            Assert.IsFalse(status);
        }
        [TestMethod]
        public void TestOpenApplication_StartProcessException()
        {
            mockWrapper.Setup(x => x.IsFileExist("file")).Returns(true);
            mockWrapper.Setup(x => x.StartProcess("file")).Throws(new Exception());

            bool status = xKeyboard.OpenApplication("file");
            Assert.IsFalse(status);
        }
    }
}
