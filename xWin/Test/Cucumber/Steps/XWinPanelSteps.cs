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
using System.Drawing;
using System.Collections.Generic;

namespace Cucumber.Steps
{
    [Binding]
    class XWinPanelSteps
    {
        string appPath;
        Application application;
        Window window;

        [AfterScenario("XWinPanel")]
        public void Setup()
        {
            application.Kill();
        }

        [Given(@"XWin program is set up")]
        public void GivenXWinPanelIsSetUp()
        {
            appPath = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "xWin.exe");
        }

        [When(@"I launch the program")]
        public void WhenILaunchTheProgram()
        {
            application = Application.Launch(appPath);
            window = application.GetWindow("XWin Panel", InitializeOption.NoCache);
        }

        [Then(@"It should load XWinPanel successfully")]
        public void ThenItShouldLoadXWinPanelSuccessfully()
        {
            Assert.IsNotNull(window);
            Assert.IsTrue(window.DisplayState == DisplayState.Restored);
            Assert.AreEqual(window.Title, "XWin Panel");
        }

        [Then(@"It should show that controller (.*) is connected")]
        public void ThenItShouldShowThatControllerIsConnected(int p0)
        {
            Button buttonController = window.Get<Button>("Controller" + p0);
            Assert.AreEqual(buttonController.Text, "Controller " + p0 + " \nConnected");
        }

        [Then(@"It should show that controller (.*) is disconnected")]
        public void ThenItShouldShowThatControllerIsDisconnected(int p0)
        {
            Button buttonController = window.Get<Button>("Controller" + p0);
            Assert.AreEqual(buttonController.Text, "Controller " + p0 + " \nDisconnected");
        }

        [When(@"I click on Controller (.*) button")]
        public void WhenIClickOnControllerButton(int p0)
        {
            Button buttonController = window.Get<Button>("Controller" + p0);
            buttonController.Click();
        }

        [Then(@"It should show ControllerOptions window")]
        public void ThenItShouldShowControllerOptionsWindow()
        {
            List<Window> listWindows = application.GetWindows();
            Assert.AreEqual(listWindows.Count, 2); // there are 2 windows opened
            Assert.AreEqual(listWindows[1].Title, "XBox360 Controller");
        }

        [Then(@"It should not show ControllerOptions window")]
        public void ThenItShouldNotShowControllerOptionsWindow()
        {
            List<Window> listWindows = application.GetWindows();
            Assert.AreEqual(listWindows.Count, 1); // there is only XWinPanel window opened
            Assert.AreNotEqual(listWindows[0].Title, "XBox360 Controller");
        }

        /*
         * Tests for Logging
         */
        [When(@"I click on Log tab")]
        public void WhenIClickOnLogTab()
        {
            Tab controllerPanel = window.Get<Tab>("ControllerPanel");
            controllerPanel.SelectTabPage("Log");
        }

        [Then(@"It should have Log tab")]
        public void ThenItShouldHaveLogTab()
        {
            ListView logListView = window.Get<ListView>("logListView");
            Assert.IsNotNull(logListView);
            CheckBox debugModeCheckBox = window.Get<CheckBox>("debugModeCheckbox");
            Assert.IsNotNull(debugModeCheckBox);
            Button clearLogsButton = window.Get<Button>("clearLogsButton");
            Assert.IsNotNull(clearLogsButton);
            Button openLogFileButton = window.Get<Button>("openLogFileButton");
            Assert.IsNotNull(openLogFileButton);
        }

        [Then(@"Log should show ""(.*)""")]
        public void ThenLogShouldShow(string p0)
        {
            ListView logListView = window.Get<ListView>("logListView");
            bool logShowed = false;
            foreach (ListViewRow row in logListView.Rows)
            {
                if (row.Cells[3].Text.Contains(p0))
                {
                    logShowed = true;
                }
            }
            Assert.IsTrue(logShowed);
            foreach (var process in System.Diagnostics.Process.GetProcessesByName("notepad"))
            { process.Kill(); }
        }

        [When(@"I enable debug mode for logging")]
        public void WhenIEnableDebugModeForLogging()
        {
            CheckBox debugModeCheckBox = window.Get<CheckBox>("debugModeCheckbox");
            debugModeCheckBox.Checked = true;
        }

        [When(@"I disabled debug mode for logging")]
        public void WhenIDisabledDebugModeForLogging()
        {
            CheckBox debugModeCheckBox = window.Get<CheckBox>("debugModeCheckbox");
            debugModeCheckBox.Checked = true;
            debugModeCheckBox.Checked = false;
        }

        [When(@"I clear all logs")]
        public void WhenIClearAllLogs()
        {
            Button clearAllLogs = window.Get<Button>("clearLogsButton");
            clearAllLogs.Click();
        }

        [When(@"I open log file")]
        public void WhenIOpenLogFile()
        {
            Button openLog = window.Get<Button>("openLogFileButton");
            openLog.Click();
        }

    }
}
