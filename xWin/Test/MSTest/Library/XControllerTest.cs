using System;
using System.Text;
using System.Collections.Generic;
using xWin.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using xWin.Wrapper;

namespace MSTest.Library
{
    /// <summary>
    /// Summary description for XControllerTest
    /// </summary>
    [TestClass]
    public class XControllerTest
    {
        XController controller;
        Mock<ISystemWrapper> mockSystemWrapper;

        [TestInitialize]
        public void Setup()
        {
            mockSystemWrapper = new Mock<ISystemWrapper>();
            //XController = 
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
