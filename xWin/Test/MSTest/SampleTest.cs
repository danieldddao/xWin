using Microsoft.VisualStudio.TestTools.UnitTesting;
using xWin;
using xWin.Library;
using Moq;
namespace UnitTest
{
  [TestClass]
    public class SampleTest
    {
        Mock<XController> mockController;
        //Mock<StickInterpreter> mockSticks;
        [TestInitialize]
        public void Setup()
        {
            mockController = new Mock<XController>();
            //mockSticks = new Mock<StickInterpreter>(8,0);
        }
        [TestMethod]
        public void Test()
        {
            mockController.Setup(c => c.IsConnected()).Returns(true);
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void TestSticks()
        {
            StickInterpreter sticks = new StickInterpreter(8);
            
            
        }
    }
}