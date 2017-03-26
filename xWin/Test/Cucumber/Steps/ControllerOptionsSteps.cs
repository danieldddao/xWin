using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.TabItems;
using TestStack.White;
using TechTalk.SpecFlow;
using xWin.Forms;
using xWin.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.White.Factory;
using System.IO;
using System.Collections.Generic;

namespace Cucumber.Steps
{
    [Binding]
    class ControllerOptionsSteps
    {
        string appPath;
        Application application;
        Window window;

        [AfterScenario("ControllerOptions")]
        public void Setup()
        {
            application.Kill();
        }

        [Given(@"XWin program is set up to test ControllerOptions")]
        public void GivenXWinProgramIsSetUpToTestControllerOptions()
        {
            appPath = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "xWin.exe");
        }

        [Given(@"I lauch the program")]
        public void GivenILauchTheProgram()
        {
            application = Application.Launch(appPath);
            window = application.GetWindow("XWin Panel", InitializeOption.NoCache);
        }

        [When(@"I lauch the ControllerOptions window")]
        public void WhenILauchTheControllerOptionsWindow()
        {
            Button buttonController4 = window.Get<Button>("Controller4");
            buttonController4.Click();
        }

        [Then(@"It should load ControllerOptions window successfully")]
        public void ThenItShouldLoadControllerOptionsWindowSuccessfully()
        {
            List<Window> listWindows = application.GetWindows();
            Assert.AreEqual(listWindows[1].Title, "XBox360 Controller");

            Label controllerLabel = window.Get<Label>("ControllerLabel");
            Assert.AreEqual(controllerLabel.Text, "Choose a button to customize");
        }


        [Given(@"I lauch the ControllerOptions window")]
        public void GivenILauchTheControllerOptionsWindow()
        {
            Button buttonController4 = window.Get<Button>("Controller4");
            buttonController4.Click();
        }

        [When(@"I click on ""(.*)"" button")]
        public void WhenIClickOnButton(string button)
        {
            Button controllerButton = window.Get<Button>(button);
            controllerButton.Click();
        }

        [Then(@"It should load ButtonOptions ""(.*)"" window successfully")]
        public void ThenItShouldLoadButtonOptionsWindowSuccessfully(string button)
        {
            string buttonName = button.Substring(6);
            List<Window> listWindows = application.GetWindows();
            Assert.AreEqual(listWindows.Count, 3);
            Assert.AreEqual(listWindows[2].Title, "Button " + buttonName + " Options");
        }

    }
}
