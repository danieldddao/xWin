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
            //
            // TODO: Add test logic here
            //
            
            mockController.Setup(x => x.RightDown());
            mockController.Setup(x => x.RightUp());
            mockController.Setup(x => x.RightClick());
        }
    }
}
