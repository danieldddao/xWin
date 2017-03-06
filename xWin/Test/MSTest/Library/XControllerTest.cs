using System;
using System.Text;
using System.Collections.Generic;
using xWin.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using xWin.Wrapper;
using SharpDX;

namespace MSTest.Library
{
    /// <summary>
    /// Summary description for XControllerTest
    /// </summary>
    [TestClass]
    public class XControllerTest
    {
        xWin.Library.XController controller;
        Mock<xWin.Wrapper.XControllerWrapper> mockController;
   

        [TestInitialize]
        public void Setup()
        {
            mockController = new Mock<xWin.Wrapper.XControllerWrapper>();

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
    }
}
