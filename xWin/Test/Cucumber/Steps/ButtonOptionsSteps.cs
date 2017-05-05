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
using TestStack.White.WindowsAPI;

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

        /*
         * Keyboard Option
         */ 
        [When(@"I click on Keyboard button")]
        public void WhenIClickOnKeyboardButton()
        {
            Button buttonKeyboard = window.Get<Button>("mapKeyboard");
            buttonKeyboard.Click();
        }

        [Then(@"It should display the keyboard mapping dialog for button ""(.*)""")]
        public void ThenItShouldDisplayTheKeyboardMappingDialogForButton(string p0)
        {
            listWindows = application.GetWindows();
            Assert.AreEqual(listWindows.Count, 4);
            Assert.AreEqual(listWindows[3].Title, "Keyboard Mapping");
        }

        [Then(@"It should display None key for Keyboard")]
        public void ThenItShouldDisplayNoneKeyForKeyboard()
        {
            listWindows = application.GetWindows();
            TextBox currentActionTextbox = listWindows[2].Get<TextBox>("keyboardTextBox");
            Assert.IsTrue(currentActionTextbox.Text.Contains("Key Mapping: NONE"));
        }

        [Then(@"It should not check the checkbox for Keyboard")]
        public void ThenItShouldNotCheckTheCheckboxForKeyboard()
        {
            listWindows = application.GetWindows();
            keyboardCheckBox = listWindows[2].Get<CheckBox>("keyboardCheckBox");
            Assert.IsFalse(keyboardCheckBox.Checked);
        }

        [When(@"I choose key ""(.*)""")]
        public void WhenIChooseKey(string key)
        {
            listWindows = application.GetWindows();
            Button buttonKey = listWindows[3].Get<Button>(key);
            buttonKey.Click();
        }

        [Then(@"It should display the key ""(.*)"" for Keyboard")]
        public void ThenItShouldDisplayTheKeyForKeyboard(string key)
        {
            listWindows = application.GetWindows();
            TextBox openAppTextBox = listWindows[2].Get<TextBox>("keyboardTextBox");
            Assert.AreEqual(openAppTextBox.Text, "Key Mapping: " + key);
        }

        [Then(@"It should display the current action for Keyboard")]
        public void ThenItShouldDisplayTheCurrentActionForKeyboard()
        {
            listWindows = application.GetWindows();
            TextBox currentActionTextbox = listWindows[2].Get<TextBox>("currentActionTextbox");
            Assert.IsTrue(currentActionTextbox.Text.Contains("currently maps to:"));
            Assert.IsTrue(currentActionTextbox.Text.Contains("Keyboard"));
        }

        [Then(@"It should check the checkbox for Keyboard")]
        public void ThenItShouldCheckTheCheckboxForKeyboard()
        {
            listWindows = application.GetWindows();
            openAppCheckBox = listWindows[2].Get<CheckBox>("openAppCheckBox");
            keyboardCheckBox = listWindows[2].Get<CheckBox>("keyboardCheckBox");
            shortcutCheckBox = listWindows[2].Get<CheckBox>("shortcutCheckBox");
            textCheckBox = listWindows[2].Get<CheckBox>("textCheckBox");

            Assert.IsTrue(keyboardCheckBox.Checked);
            Assert.IsFalse(openAppCheckBox.Checked);
            Assert.IsFalse(shortcutCheckBox.Checked);
            Assert.IsFalse(textCheckBox.Checked);
        }

        [When(@"I enter Return key and use it")]
        public void WhenIEnterReturnKeyAndUseIt()
        {
            listWindows = application.GetWindows();
            listWindows[3].Keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
            TextBox enteredTextBox = listWindows[3].Get<TextBox>("KeyTextBox");
            Assert.AreEqual(enteredTextBox.Text, "Return");
            Button saveButton = listWindows[3].Get<Button>("buttonSaveKey");
            saveButton.Click();
        }

        /*
         * Open Application Option
         */
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

        /*
         * Shortcut Option
         */
        [When(@"I click on Shortcut button")]
        public void WhenIClickOnShortcutButton()
        {
            Button buttonOpenApp = window.Get<Button>("mapShortcut");
            buttonOpenApp.Click();
        }

        [Then(@"It should display the Shortcut mapping dialog for button ""(.*)""")]
        public void ThenItShouldDisplayTheShortcutMappingDialogForButton(string p0)
        {
            listWindows = application.GetWindows();
            Assert.AreEqual(listWindows.Count, 4);
            Assert.AreEqual(listWindows[3].Title, "Shortcut Mapping");
        }

        [Then(@"It should display None for Shortcut")]
        public void ThenItShouldDisplayNoneForShortcut()
        {
            listWindows = application.GetWindows();
            TextBox currentActionTextbox = listWindows[2].Get<TextBox>("shortcutTextBox");
            Assert.IsTrue(currentActionTextbox.Text.Contains("Shortcut: NONE"));
            
        }

        [Then(@"It should not check the checkbox for Shortcut")]
        public void ThenItShouldNotCheckTheCheckboxForShortcut()
        {
            listWindows = application.GetWindows();
            shortcutCheckBox = listWindows[2].Get<CheckBox>("shortcutCheckBox");
            Assert.IsFalse(shortcutCheckBox.Checked);
        }

        [When(@"I enter shortcut F5")]
        public void WhenIEnterShortcutF5()
        {
            listWindows = application.GetWindows();
            listWindows[3].Keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.F5);
            Button saveButton = listWindows[3].Get<Button>("buttonDone");
            saveButton.Click();
        }

        [Then(@"It should display shortcut ""(.*)"" for shortcut")]
        public void ThenItShouldDisplayShortcutForShortcut(string shortcut)
        {
            listWindows = application.GetWindows();
            TextBox openAppTextBox = listWindows[2].Get<TextBox>("shortcutTextBox");
            Assert.AreEqual(openAppTextBox.Text, "Shortcut: " + shortcut);
        }

        [Then(@"It should display the current action for Shortcut Mapping")]
        public void ThenItShouldDisplayTheCurrentActionForShortcutMapping()
        {
            listWindows = application.GetWindows();
            TextBox currentActionTextbox = listWindows[2].Get<TextBox>("currentActionTextbox");
            Assert.IsTrue(currentActionTextbox.Text.Contains("currently maps to:"));
            Assert.IsTrue(currentActionTextbox.Text.Contains("Shortcut"));
        }

        [Then(@"It should check the checkbox for Shortcut Mapping")]
        public void ThenItShouldCheckTheCheckboxForShortcutMapping()
        {
            listWindows = application.GetWindows();
            openAppCheckBox = listWindows[2].Get<CheckBox>("openAppCheckBox");
            keyboardCheckBox = listWindows[2].Get<CheckBox>("keyboardCheckBox");
            shortcutCheckBox = listWindows[2].Get<CheckBox>("shortcutCheckBox");
            textCheckBox = listWindows[2].Get<CheckBox>("textCheckBox");

            Assert.IsTrue(shortcutCheckBox.Checked);
            Assert.IsFalse(keyboardCheckBox.Checked);
            Assert.IsFalse(textCheckBox.Checked);
            Assert.IsFalse(openAppCheckBox.Checked);
        }

        [When(@"I enter shortcut F5 without saving")]
        public void WhenIEnterShortcutF5WithoutSaving()
        {
            listWindows = application.GetWindows();
            listWindows[3].Keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.F5);
            Button cancelButton = listWindows[3].Get<Button>("buttonClear");
            cancelButton.Click();
        }

        [Then(@"It should not display the current action for Shortcut Mapping")]
        public void ThenItShouldNotDisplayTheCurrentActionForShortcutMapping()
        {
            listWindows = application.GetWindows();
            TextBox currentActionTextbox = listWindows[2].Get<TextBox>("currentActionTextbox");
            Assert.IsTrue(currentActionTextbox.Text.Contains("currently maps to:"));
            Assert.IsFalse(currentActionTextbox.Text.Contains("Shortcut"));
        }

        [Then(@"It should not check the checkbox for Shortcut Mapping")]
        public void ThenItShouldNotCheckTheCheckboxForShortcutMapping()
        {
            listWindows = application.GetWindows();
            shortcutCheckBox = listWindows[2].Get<CheckBox>("shortcutCheckBox");

            Assert.IsFalse(shortcutCheckBox.Checked);
        }

        /*
         * Text Option
         */
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

        [Then(@"It should display None text for Text")]
        public void ThenItShouldDisplayNoneTextForText()
        {
            listWindows = application.GetWindows();
            TextBox currentActionTextbox = listWindows[2].Get<TextBox>("textTextBox");
            Assert.IsTrue(currentActionTextbox.Text.Contains("Text: NONE"));
        }

        [Then(@"It should not check the checkbox for Text")]
        public void ThenItShouldNotCheckTheCheckboxForText()
        {
            listWindows = application.GetWindows();
            textCheckBox = listWindows[2].Get<CheckBox>("textCheckBox");
            Assert.IsFalse(textCheckBox.Checked);
        }

    }
}
