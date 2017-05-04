using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Automation;
using TechTalk.SpecFlow;
using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.TabItems;
using TestStack.White.UIItems.WindowItems;

namespace Cucumber.Steps
{
    [Binding]
    class AutoCompleteSteps
    {
        string appPath;
        Application application;
        Window window;

        [AfterScenario("AutoComplete")]
        public void ClearProgram()
        {
            application.Kill();
        }

        [Given(@"XWin program is set up and launched")]
        public void GivenXWinProgramIsSetUpAndLaunched()
        {
            appPath = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "xWin.exe");
            application = Application.Launch(appPath);
            window = application.GetWindow("XWin Panel", InitializeOption.NoCache);
        }

        [When(@"I click on Settings tab")]
        public void WhenIClickOnSettingsTab()
        {
            Tab controllerPanel = window.Get<Tab>("ControllerPanel");
            controllerPanel.SelectTabPage("Settings");
        }

        [Then(@"I should see Auto-Complete label")]
        public void ThenIShouldSeeAuto_CompleteLabel()
        {
            Label label = window.Get<Label>("labelAutocomplete");
            Assert.AreEqual(label.Text, "Auto-Complete:");
        }

        [When(@"I click on Manage Dictionary Button")]
        public void WhenIClickOnManageDictionaryButton()
        {
            Button button = window.Get<Button>("buttonViewDictionary");
            button.Click();
        }

        [Then(@"I should see Dictionary Database")]
        public void ThenIShouldSeeDictionaryDatabase()
        {
            List<Window> listWindows = application.GetWindows();
            Assert.AreEqual(listWindows.Count, 2);
            Assert.IsTrue(listWindows[1].Title.Contains("Auto-Complete Dictionary"));
        }

        [When(@"I click on Clear Dictionary button")]
        public void WhenIClickOnClearDictionaryButton()
        {
            Button button = window.Get<Button>("clearButton");
            button.Click();
        }

        [Then(@"I should not see any word in the list")]
        public void ThenIShouldNotSeeAnyWordInTheList()
        {
            ListView ListView = window.Get<ListView>("DictionaryListView");
            Assert.AreEqual(ListView.Rows.Count, 0);
        }

        [When(@"I remove word ""(.*)"" from dictionary")]
        public void WhenIRemoveWordFromDictionary(string p0)
        {
            ListView ListView = window.Get<ListView>("DictionaryListView");
            foreach (ListViewRow row in ListView.Rows)
            {
                if (String.Compare(row.Name, p0, true) == 0)
                {
                    SelectionItemPattern pattern = (SelectionItemPattern)(BasePattern)row.AutomationElement.GetCurrentPattern(SelectionItemPattern.Pattern);
                    pattern.Select();
                    break;
                }
            }
            Button button = window.Get<Button>("removeWordsButton");
            button.Click();
        }

        [Then(@"I should not see word ""(.*)""")]
        public void ThenIShouldNotSeeWord(string p0)
        {
            ListView ListView = window.Get<ListView>("DictionaryListView");
            foreach (ListViewRow row in ListView.Rows)
            {
                Assert.AreNotEqual(row.Cells[0].Text, p0);
            }
        }

        [When(@"I add word ""(.*)"" to dictionary")]
        public void WhenIAddWordToDictionary(string p0)
        {
            Button button = window.Get<Button>("addWordButton");
            button.Click();
            List<Window> listWindows = application.GetWindows();
            Assert.AreEqual(listWindows.Count, 3);

            TextBox name = listWindows[2].Get<TextBox>("wordTextBox");
            name.Text = p0;
            Button saveButton = listWindows[1].Get<Button>("saveButton");
            saveButton.Click();
        }

        [Then(@"I should see word ""(.*)""")]
        public void ThenIShouldSeeWord(string p0)
        {
            bool b = false;
            List<Window> listWindows = application.GetWindows();
            Assert.AreEqual(listWindows.Count, 2);

            ListView ListView = listWindows[1].Get<ListView>("DictionaryListView");
            foreach (ListViewRow row in ListView.Rows)
            {
                if (row.Cells[1].Text == p0) { b = true; }
            }
            Assert.IsTrue(b);
        }

        [When(@"I click on word prediction tips")]
        public void WhenIClickOnWordPredictionTips()
        {
            Button button = window.Get<Button>("wordPredictionTipsButton");
            button.Click();
        }

        [Then(@"I should see word prediction tips window")]
        public void ThenIShouldSeeWordPredictionTipsWindow()
        {
            List<Window> listWindows = application.GetWindows();
            Assert.AreEqual(listWindows.Count, 2);
            Assert.AreEqual(listWindows[0].Title, "Tips on how to use Word Prediction");
        }

        [When(@"I click on quicktype suggestions tips")]
        public void WhenIClickOnQuicktypeSuggestionsTips()
        {
            Button button = window.Get<Button>("quickTypeTipsButton");
            button.Click();
        }

        [Then(@"I should see quicktype suggestions tips window")]
        public void ThenIShouldSeeQuicktypeSuggestionsTipsWindow()
        {
            List<Window> listWindows = application.GetWindows();
            Assert.AreEqual(listWindows.Count, 2);
            Assert.AreEqual(listWindows[0].Title, "Tips on how to use QuickType Suggestions");
        }

        [When(@"I click on customize quicktype bar")]
        public void WhenIClickOnCustomizeQuicktypeBar()
        {
            Button button = window.Get<Button>("customizeQuickTypeBar");
            button.Click();
        }

        [Then(@"I should see customize quicktype bar window")]
        public void ThenIShouldSeeCustomizeQuicktypeBarWindow()
        {
            List<Window> listWindows = application.GetWindows();
            Assert.AreEqual(listWindows.Count, 2);
            Assert.AreEqual(listWindows[1].Title, "Customize QuickType Bar");
        }

        [When(@"I click on Suggestion (.*)")]
        public void WhenIClickOnSuggestion(int p0)
        {
            List<Window> listWindows = application.GetWindows();
            Button button = listWindows[1].Get<Button>("quickTypeButton" + p0);
            button.Click();
        }

        [Then(@"I should see shortcut window for suggestion (.*)")]
        public void ThenIShouldSeeShortcutWindowForSuggestion(int p0)
        {
            List<Window> listWindows = application.GetWindows();
            Assert.AreEqual(listWindows.Count, 3);
            Assert.AreEqual(listWindows[2].Title, "Set shortcut for suggestion " + p0);
        }

        [When(@"I enter shortcut F(.*) for suggestion (.*)")]
        public void WhenIEnterShortcutFForSuggestion(int p0, int p1)
        {
            List<Window> listWindows = application.GetWindows();
            listWindows[2].Keyboard.PressSpecialKey(TestStack.White.WindowsAPI.KeyboardInput.SpecialKeys.F5);
            Button saveButton = listWindows[2].Get<Button>("buttonDone");
            saveButton.Click();
        }

        [Then(@"It should display shortcut F(.*) for suggestion (.*)")]
        public void ThenItShouldDisplayShortcutFForSuggestion(int p0, int p1)
        {
            List<Window> listWindows = application.GetWindows();
            TextBox textbox = listWindows[1].Get<TextBox>("quickTypeButton" + p1 + "TextBox");
            Assert.AreEqual(textbox.Text, "F5");
        }

        [When(@"I save customization")]
        public void WhenISaveCustomization()
        {
            List<Window> listWindows = application.GetWindows();
            Button saveButton = listWindows[1].Get<Button>("saveButton");
            saveButton.Click();
        }

        [Then(@"It should save the shortcut for suggestion (.*)")]
        public void ThenItShouldSaveTheShortcutForSuggestion(int p0)
        {
            List<Window> listWindows = application.GetWindows();
            Button button = listWindows[0].Get<Button>("customizeQuickTypeBar");
            button.Click();
            listWindows = application.GetWindows();
            TextBox textbox = listWindows[1].Get<TextBox>("quickTypeButton" + p0 + "TextBox");
            Assert.AreEqual(textbox.Text, "F5");
        }

        [Then(@"I should receive a message box")]
        public void ThenIShouldReceiveAMessageBox()
        {
            List<Window> listWindows = application.GetWindows();
            Assert.AreEqual(listWindows.Count, 3);
            Button buttonMessageBoxClose = listWindows[2].Get<Button>(TestStack.White.UIItems.Finders.SearchCriteria.ByText("Close"));
            Assert.IsNotNull(buttonMessageBoxClose);
            buttonMessageBoxClose.Click();
        }

        [When(@"I check using shortcuts checkbox")]
        public void WhenICheckUsingShortcutsCheckbox()
        {
            List<Window> listWindows = application.GetWindows();
            CheckBox checkbox = listWindows[1].Get<CheckBox>("usingShortcutsCheckBox");
            checkbox.Checked = true;
        }

        [Then(@"It should check the checkbox")]
        public void ThenItShouldCheckTheCheckbox()
        {
            List<Window> listWindows = application.GetWindows();
            Button button = listWindows[0].Get<Button>("customizeQuickTypeBar");
            button.Click();
            listWindows = application.GetWindows();
            CheckBox checkbox = listWindows[1].Get<CheckBox>("usingShortcutsCheckBox");
            Assert.IsTrue(checkbox.Checked);
        }

        [When(@"I uncheck using shortcuts checkbox")]
        public void WhenIUncheckUsingShortcutsCheckbox()
        {
            List<Window> listWindows = application.GetWindows();
            CheckBox checkbox = listWindows[1].Get<CheckBox>("usingShortcutsCheckBox");
            checkbox.Checked = false;
        }

        [Then(@"It should uncheck the checkbox")]
        public void ThenItUncheckTheCheckbox()
        {
            List<Window> listWindows = application.GetWindows();
            Button button = listWindows[0].Get<Button>("customizeQuickTypeBar");
            button.Click();
            listWindows = application.GetWindows();
            CheckBox checkbox = listWindows[1].Get<CheckBox>("usingShortcutsCheckBox");
            Assert.IsFalse(checkbox.Checked);
        }

    }
}
