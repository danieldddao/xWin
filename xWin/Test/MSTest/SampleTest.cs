using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using xWin.Library;
using Moq;

namespace UnitTest
{
    [TestClass]
    public class SampleTest
    {
        Mock<XController> mockController;

        [TestInitialize]
        public void Setup()
        {
            mockController = new Mock<XController>();
        }
        [TestMethod]
        public void Test()
        {
            mockController.Setup(c => c.IsConnected()).Returns(true);
            Assert.IsTrue(true);
        }
    }
}
