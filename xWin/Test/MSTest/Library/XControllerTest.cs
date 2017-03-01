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
        XControllerImplementation controller;
        Mock<ISystemWrapper> mockSystemWrapper;
        Mock<SharpDX.XInput.Controller> mockController;

        [TestInitialize]
        public void Setup()
        {
            mockSystemWrapper = new Mock<ISystemWrapper>();
            mockController = new Mock<SharpDX.XInput.Controller>();
            //controller = new XController(mockController.)
        }

        [TestMethod]
        public void TestMethod1()
        {
            //
            // TODO: Add test logic here
            //
        }
    }
}
