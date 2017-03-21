using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Extensions.Forms;
using xWin.Forms;
using xWin.Library;
using Moq;
using NUnit.Framework;

namespace NUnitForms
{
    [TestFixture]
    public class XWinPanelTest : NUnitFormTest
    {
        XWinPanel xWinPanel;
        Mock<IXController> mockXController1;
        Mock<IXController> mockXController2;
        Mock<IXController> mockXController3;
        Mock<IXController> mockXController4;

        [OneTimeSetUp]
        public override void Setup()
        {
            mockXController1 = new Mock<IXController>();
            mockXController2 = new Mock<IXController>();
            mockXController3 = new Mock<IXController>();
            mockXController4 = new Mock<IXController>();

            xWinPanel = new XWinPanel(mockXController1.Object, mockXController2.Object, mockXController3.Object, mockXController4.Object);
            xWinPanel.Show();
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            mockXController1.VerifyAll();
            mockXController2.VerifyAll();
            mockXController3.VerifyAll();
            mockXController4.VerifyAll();
        }

        [Test]
        public void TestXWinPanelCreate()
        {
            Assert.AreEqual("XWin Panel", xWinPanel.Text);
        }

        [Test]
        public void TestButtons_DisconnectedControllers()
        {
            ButtonTester buttonController1 = new ButtonTester("Controller1");
            Assert.AreEqual("XWin Panel", buttonController1.Text);
        }
    }
}
