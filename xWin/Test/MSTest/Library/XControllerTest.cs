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
        Mock<xWin.Wrapper.XController> mockController;
   

        [TestInitialize]
        public void Setup()
        {
            mockController = new Mock<xWin.Wrapper.XController>();
            
            //controller = new XController(mockController.)
        }

        [TestMethod]
        public void RightButtonTest()
        {           
            mockController.Setup(x => x.RightDown());
            mockController.Setup(x => x.RightUp()); 

        }
        [TestMethod]
        public void LeftButtonTest()
        {
            mockController.Setup(x => x.LeftUp());
            mockController.Setup(x => x.LeftDown());
            mockController.Setup(x => x.LeftClick());
        }
    }
}
