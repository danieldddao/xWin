using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Windows.Forms;
using TechTalk.SpecFlow;
using xWin.Library;
using xWin.Wrapper;

namespace Cucumber.Steps
{
    [Binding]
    public class KeyboardInputsSteps
    {
        Mock<ISystemWrapper> mockSystemWrapper;
        XKeyBoard xKeyboard;
        bool status;

        [Given(@"I have keyboard set up")]
        public void GivenIHaveKeyboardSetUp()
        {
            mockSystemWrapper = new Mock<ISystemWrapper>();
            xKeyboard = new XKeyBoard(mockSystemWrapper.Object);
        }

        [When(@"I press key Keys\.B")]
        public void WhenIPressKeyKeys_B()
        {
            mockSystemWrapper.Setup(x => x.Press((byte)Keys.B));
            mockSystemWrapper.Setup(x => x.Release((byte)Keys.B));
            status = xKeyboard.PressKey(Keys.B);
        }

        [When(@"I press key '(.*)'")]
        public void WhenIPressKey(string p0)
        {
            char c = p0.ToCharArray()[0];
            mockSystemWrapper.Setup(x => x.ScanKey(c)).Returns(1);
            mockSystemWrapper.Setup(x => x.Press((byte) 1));
            mockSystemWrapper.Setup(x => x.Release((byte) 1));
            status = xKeyboard.PressKey(c);
        }

        [Then(@"It should be pressed")]
        public void ThenItShouldBePressed()
        {
            Assert.IsTrue(status);
            mockSystemWrapper.VerifyAll();
        }

        [When(@"I press keys from string '(.*)'")]
        public void WhenIPressKeysFromString(string p0)
        {
            mockSystemWrapper.Setup(x => x.ScanKey(It.IsAny<char>())).Returns(1);
            mockSystemWrapper.Setup(x => x.Press((byte)1));
            mockSystemWrapper.Setup(x => x.Release((byte)1));
            status = xKeyboard.PressKeysFromString(p0);
        }

        [Then(@"It should be pressed with shift key")]
        public void ThenItShouldBePressedWithShiftKey()
        {
            Assert.IsTrue(status);
            mockSystemWrapper.Verify(x => x.Press(0x10), Times.AtLeastOnce());
            mockSystemWrapper.Verify(x => x.Release(0x10), Times.AtLeastOnce());

        }

        [Then(@"It should be pressed without shift key")]
        public void ThenItShouldBePressedWithoutShiftKey()
        {
            Assert.IsTrue(status);
            mockSystemWrapper.Verify(x => x.Press(0x10), Times.Never());
            mockSystemWrapper.Verify(x => x.Release(0x10), Times.Never());
        }

        [When(@"I press the shortcut Ctrl\+R")]
        public void WhenIPressTheShortcutCtrlR()
        {
            mockSystemWrapper.Setup(x => x.Press((byte) Keys.ControlKey));
            mockSystemWrapper.Setup(x => x.Press((byte)Keys.R));
            mockSystemWrapper.Setup(x => x.Release((byte)Keys.ControlKey));
            mockSystemWrapper.Setup(x => x.Release((byte) Keys.R));

            Keys[] shortcut = { Keys.ControlKey, Keys.R };
            status = xKeyboard.PressShortcut(shortcut);
        }

        [When(@"I open the application from invalid path ""(.*)""")]
        public void WhenIOpenTheApplicationFromInvalidPath(string p0)
        {
            mockSystemWrapper.Setup(x => x.IsFileExist(p0)).Returns(false);
            status = xKeyboard.OpenApplication(p0);
        }

        [Then(@"It should not open the application")]
        public void ThenItShouldNotOpenTheApplication()
        {
            Assert.IsFalse(status);
        }

        [When(@"I open the application from valid path ""(.*)""")]
        public void WhenIOpenTheApplicationFromValidPath(string p0)
        {
            mockSystemWrapper.Setup(x => x.IsFileExist(p0)).Returns(true);
            mockSystemWrapper.Setup(x => x.StartProcess(p0));

            status = xKeyboard.OpenApplication(p0);
            mockSystemWrapper.Verify(x => x.StartProcess(p0), Times.Once());
        }

        [Then(@"It should open the application")]
        public void ThenItShouldOpenTheApplication()
        {
            Assert.IsTrue(status);
        }

    }
}
