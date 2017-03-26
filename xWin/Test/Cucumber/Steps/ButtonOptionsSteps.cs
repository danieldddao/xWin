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
    class ButtonOptionsSteps
    {
        string appPath;
        Application application;
        Window window;
        List<Window> listWindows;
        CheckBox keyboardCheckBox;
        CheckBox openAppCheckBox;
        CheckBox shortcutCheckBox;
        CheckBox textCheckBox;

        [AfterScenario("ButtonOptions")]
        public void Setup()
        {
            application.Kill();
        }

        [Given(@"XWin program is set up to test ButtonOptions")]
        public void GivenXWinProgramIsSetUpToTestButtonOptions()
        {
            appPath = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "xWin.exe");
            application = Application.Launch(appPath);
            window = application.GetWindow("XWin Panel", InitializeOption.NoCache);
        }

        [Given(@"I have the ControllerOptions window opened")]
        public void GivenIHaveTheControllerOptionsWindowOpened()
        {
            Button buttonController4 = window.Get<Button>("Controller4");
            buttonController4.Click();
        }

        [When(@"I launch the ""(.*)"" ButtonOptions window")]
        public void WhenILaunchTheButtonOptionsWindow(string button)
        {
            Button buttonLT = window.Get<Button>(button);
            buttonLT.Click();
        }

        [Then(@"It should load ""(.*)"" ButtonOptions window successfully")]
        public void ThenItShouldLoadButtonOptionsWindowSuccessfully(string button)
        {
            listWindows = application.GetWindows();
            string buttonName = button.Substring(6);
            Assert.AreEqual(listWindows.Count, 3);
            Assert.AreEqual(listWindows[2].Title, "Button " + buttonName + " Options");
            TextBox currentActionTextbox = listWindows[2].Get<TextBox>("currentActionTextbox");
            Assert.IsTrue(currentActionTextbox.Text.Contains("currently maps to:"));
        }

        [Given(@"I launch the ""(.*)"" ButtonOptions window")]
        public void GivenILaunchTheButtonOptionsWindow(string button)
        {
            Button buttonLT = window.Get<Button>(button);
            buttonLT.Click();
        }

        [When(@"I click on Open Application button")]
        public void WhenIClickOnOpenApplicationButton()
        {
            Button buttonOpenApp = window.Get<Button>("openApplication");
            buttonOpenApp.Click();
        }

        [Then(@"It should display the open application dialog")]
        public void ThenItShouldDisplayTheOpenApplicationDialog()
        {
            listWindows = application.GetWindows();
            Assert.AreEqual(listWindows.Count, 4);
            Assert.AreEqual(listWindows[3].Title, "Open");   
        }

        [When(@"I select to open application")]
        public void WhenISelectToOpenApplication()
        {
            listWindows = application.GetWindows();
            openAppCheckBox = listWindows[2].Get<CheckBox>("openAppCheckBox");
            openAppCheckBox.Checked = true;
        }

        [Then(@"It should display the application path for Open Application")]
        public void ThenItShouldDisplayTheApplicationPathForOpenApplication()
        {
            listWindows = application.GetWindows();
            TextBox openAppTextBox = listWindows[2].Get<TextBox>("openAppTextBox");
            Assert.AreEqual(openAppTextBox.Text, "Application to open: .../Test.exe");
        }

        [Then(@"It should display the current action for Open Application")]
        public void ThenItShouldDisplayTheCurrentActionForOpenApplication()
        {
            listWindows = application.GetWindows();
            TextBox currentActionTextbox = listWindows[2].Get<TextBox>("currentActionTextbox");
            Assert.IsTrue(currentActionTextbox.Text.Contains("currently maps to:"));
            Assert.IsTrue(currentActionTextbox.Text.Contains("Open Application"));
        }

        [Then(@"It should check the checkbox for Open Application")]
        public void ThenItShouldCheckTheCheckboxForOpenApplication()
        {
            listWindows = application.GetWindows();
            openAppCheckBox = listWindows[2].Get<CheckBox>("openAppCheckBox");
            keyboardCheckBox = listWindows[2].Get<CheckBox>("keyboardCheckBox");
            shortcutCheckBox = listWindows[2].Get<CheckBox>("shortcutCheckBox");
            textCheckBox = listWindows[2].Get<CheckBox>("textCheckBox");

            Assert.IsTrue(openAppCheckBox.Checked);
            Assert.IsFalse(keyboardCheckBox.Checked);
            Assert.IsFalse(shortcutCheckBox.Checked);
            Assert.IsFalse(textCheckBox.Checked);
        }

        [When(@"I click on ""(.*)"" checkbox")]
        public void WhenIClickOnCheckbox(string p0)
        {
            listWindows = application.GetWindows();
            openAppCheckBox = listWindows[2].Get<CheckBox>("openAppCheckBox");
            openAppCheckBox.Checked = false;
        }

        [Then(@"It should leave all checkboxes unchecked")]
        public void ThenItShouldLeaveAllCheckboxesUnchecked()
        {
            listWindows = application.GetWindows();
            openAppCheckBox = listWindows[2].Get<CheckBox>("openAppCheckBox");
            keyboardCheckBox = listWindows[2].Get<CheckBox>("keyboardCheckBox");
            shortcutCheckBox = listWindows[2].Get<CheckBox>("shortcutCheckBox");
            textCheckBox = listWindows[2].Get<CheckBox>("textCheckBox");

            Assert.IsFalse(textCheckBox.Checked);
            Assert.IsFalse(keyboardCheckBox.Checked);
            Assert.IsFalse(shortcutCheckBox.Checked);
            Assert.IsFalse(openAppCheckBox.Checked);
        }

        [When(@"I click on Text button")]
        public void WhenIClickOnTextButton()
        {
            Button buttonOpenApp = window.Get<Button>("mapText");
            buttonOpenApp.Click();
        }

        [Then(@"It should display the text mapping dialog for button ""(.*)""")]
        public void ThenItShouldDisplayTheTextMappingDialogForButton(string button)
        {
            listWindows = application.GetWindows();
            Assert.AreEqual(listWindows.Count, 4);
            Assert.AreEqual(listWindows[3].Title, "Map button '" + button + "' to text");
        }

        [When(@"I select to enter a text ""(.*)""")]
        public void WhenISelectToEnterAText(string text)
        {
            Button buttonOpenApp = window.Get<Button>("mapText");
            buttonOpenApp.Click();
            listWindows = application.GetWindows();
            TextBox textBoxText = listWindows[3].Get<TextBox>("textTextBox");
            textBoxText.Text = text;
            Button doneButton = listWindows[3].Get<Button>("doneButton");
            doneButton.Click();
        }

        [Then(@"It should display the text ""(.*)"" for Text Mapping")]
        public void ThenItShouldDisplayTheTextForTextMapping(string text)
        {
            listWindows = application.GetWindows();
            TextBox openAppTextBox = listWindows[2].Get<TextBox>("textTextBox");
            Assert.AreEqual(openAppTextBox.Text, "Text: " + text);
        }

        [Then(@"It should display the current action for Text Mapping")]
        public void ThenItShouldDisplayTheCurrentActionForTextMapping()
        {
            listWindows = application.GetWindows();
            TextBox currentActionTextbox = listWindows[2].Get<TextBox>("currentActionTextbox");
            Assert.IsTrue(currentActionTextbox.Text.Contains("currently maps to:"));
            Assert.IsTrue(currentActionTextbox.Text.Contains("Text"));
        }

        [Then(@"It should check the checkbox for Text Mapping")]
        public void ThenItShouldCheckTheCheckboxForTextMapping()
        {
            listWindows = application.GetWindows();
            openAppCheckBox = listWindows[2].Get<CheckBox>("openAppCheckBox");
            keyboardCheckBox = listWindows[2].Get<CheckBox>("keyboardCheckBox");
            shortcutCheckBox = listWindows[2].Get<CheckBox>("shortcutCheckBox");
            textCheckBox = listWindows[2].Get<CheckBox>("textCheckBox");

            Assert.IsTrue(textCheckBox.Checked);
            Assert.IsFalse(keyboardCheckBox.Checked);
            Assert.IsFalse(shortcutCheckBox.Checked);
            Assert.IsFalse(openAppCheckBox.Checked);
        }

        [Then(@"It should leave only ""(.*)"" checked")]
        public void ThenItShouldLeaveOnlyChecked(string checkbox)
        {
            listWindows = application.GetWindows();
            openAppCheckBox = listWindows[2].Get<CheckBox>("openAppCheckBox");
            keyboardCheckBox = listWindows[2].Get<CheckBox>("keyboardCheckBox");
            shortcutCheckBox = listWindows[2].Get<CheckBox>("shortcutCheckBox");
            textCheckBox = listWindows[2].Get<CheckBox>("textCheckBox");

            if (openAppCheckBox.Name == checkbox)
            {
                Assert.IsTrue(openAppCheckBox.Checked);
            } else
            {
                Assert.IsFalse(openAppCheckBox.Checked);
            }

            if (keyboardCheckBox.Name == checkbox)
            {
                Assert.IsTrue(keyboardCheckBox.Checked);
            }
            else
            {
                Assert.IsFalse(keyboardCheckBox.Checked);
            }

            if (shortcutCheckBox.Name == checkbox)
            {
                Assert.IsTrue(shortcutCheckBox.Checked);
            }
            else
            {
                Assert.IsFalse(shortcutCheckBox.Checked);
            }

            if (textCheckBox.Name == checkbox)
            {
                Assert.IsTrue(textCheckBox.Checked);
            }
            else
            {
                Assert.IsFalse(textCheckBox.Checked);
            }
        }

        [Then(@"It should display the error for empty text")]
        public void ThenItShouldDisplayTheErrorForEmptyText()
        {
            listWindows = application.GetWindows();
            Assert.AreEqual(listWindows.Count, 4);
            Button buttonMessageBoxClose = listWindows[3].Get<Button>(SearchCriteria.ByText("Close"));
            Assert.IsNotNull(buttonMessageBoxClose);
            buttonMessageBoxClose.Click();
        }

    }
}
