using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Forms;
using TechTalk.SpecFlow;
using xWin.Library;

namespace Cucumber.Steps
{
    [Binding]
    public class KeyboardInputsSteps
    {
        XKeyBoard xKeyboard;
        bool status;

        [Given(@"I have keyboard set up")]
        public void GivenIHaveKeyboardSetUp()
        {
            xKeyboard = new XKeyBoard();
        }

        [When(@"I press key Keys\.B")]
        public void WhenIPressKeyKeys_B()
        {
            status = xKeyboard.PressKey(Keys.B);
        }

        [When(@"I press key '(.*)'")]
        public void WhenIPressKey(string p0)
        {
            status = xKeyboard.PressKey(p0.ToCharArray()[0]);
        }

        [Then(@"It should be pressed")]
        public void ThenItShouldBePressed()
        {
            Assert.IsTrue(status);
        }
    }
}
