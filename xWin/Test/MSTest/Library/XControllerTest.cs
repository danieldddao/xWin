using System;
using System.Text;
using System.Collections.Generic;
using xWin.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using xWin.Wrapper;
using SharpDX;
using System.Drawing;
using System.Windows.Forms;

namespace MSTest.Library
{
    /// <summary>
    /// Summary description for XControllerTest
    /// </summary>
    [TestClass]
    public class XControllerTest
    {
        xWin.Library.XController controller;
        Mock<xWin.Wrapper.ControllerWrapper> mockController;
   

        [TestInitialize]
        public void Setup()
        {
            mockController = new Mock<xWin.Wrapper.ControllerWrapper>();

            controller = new XController(mockController.Object);
        }

        [TestMethod]
        public void LeftUpTest()
        {
            mockController.Setup(x => x.LeftUp());
            bool status = controller.LeftUp();
            Assert.IsTrue(status);
        }
        [TestMethod]
        public void LeftUpTest_ThrowsException()
        {
            mockController.Setup(x => x.LeftUp()).Throws(new Exception());
            bool status = controller.LeftUp();
            Assert.IsFalse(status);
        }
        [TestMethod]
        public void LeftDownTest()
        {
            mockController.Setup(x => x.LeftDown());
            bool status = controller.LeftDown();
            Assert.IsTrue(status);
        }
        [TestMethod]
        public void LeftDownTest_ThrowsException()
        {
            mockController.Setup(x => x.LeftDown()).Throws(new Exception());
            bool status = controller.LeftDown();
            Assert.IsFalse(status);
        }
        [TestMethod]
        public void LeftClickTest()
        {
            mockController.Setup(x => x.LeftClick());
            bool status = controller.LeftClick();
            Assert.IsTrue(status);
        }
        [TestMethod]
        public void LeftClickTest_ThrowsException()
        {
            mockController.Setup(x => x.LeftClick()).Throws(new Exception());
            bool status = controller.LeftClick();
            Assert.IsFalse(status);
        }
        [TestMethod]
        public void RightUpTest()
        {
            mockController.Setup(x => x.RightUp());
            bool status = controller.RightUp();
            Assert.IsTrue(status);
        }
        [TestMethod]
        public void RightUpTest_ThrowsException()
        {
            mockController.Setup(x => x.RightUp()).Throws(new Exception()); ;
            bool status = controller.RightUp();
            Assert.IsFalse(status);
        }
        [TestMethod]
        public void RightDownTest()
        {
            mockController.Setup(x => x.RightDown());
            bool status = controller.RightDown();
            Assert.IsTrue(status);
        }
        [TestMethod]
        public void RightDownTest_ThrowsException()
        {
            mockController.Setup(x => x.RightDown()).Throws(new Exception()); ;
            bool status = controller.RightDown();
            Assert.IsFalse(status);
        }
        [TestMethod]
        public void RightClickTest()
        {
            mockController.Setup(x => x.RightClick());
            bool status = controller.RightClick();
            Assert.IsTrue(status);
        }
        [TestMethod]
        public void RightClickTest_ThrowsException()
        {
            mockController.Setup(x => x.RightClick()).Throws(new Exception()); ;
            bool status = controller.RightClick();
            Assert.IsFalse(status);
        }

        [TestMethod]
        public void TestConnected()
        {
            mockController.Setup(x => x.IsConnected());
            bool status = controller.IsConnected();
            Assert.IsTrue(status);
        }
        [TestMethod]
        public void TestConnected_ThrowsException()
        {
            mockController.Setup(x => x.IsConnected()).Throws(new Exception());
            bool status = controller.IsConnected();
            Assert.IsFalse(status);
        }

        [TestMethod]
        public void testMouseMove()
        {
            mockController.Setup(x => x.MoveCursor(10,7000));
            bool status = controller.MoveCursor();
            Assert.IsTrue(status);
        }
        [TestMethod]
        public void testCursorPos()
        {
            Cursor.Position = new Point(200, 200);
            mockController.Setup(x => x.MoveCursor(1,10, 32647));
            int mockPosX = Cursor.Position.X;
            int mockPosY = Cursor.Position.Y;
            Cursor.Position = new Point(200,200);
            controller.MoveCursorTest();
            int actPosX = Cursor.Position.X;
            int actPosY = Cursor.Position.Y;

            bool status = false;
            if(actPosX == mockPosX && actPosY == mockPosY)
            {
                status = true;
            }
            else
            {
                status = false;
            }
            System.Diagnostics.Trace.Write(actPosX);
            System.Diagnostics.Trace.Write(actPosY);
            Assert.IsTrue(status);
        }
    }
}
