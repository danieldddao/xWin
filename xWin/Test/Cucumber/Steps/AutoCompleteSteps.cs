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
                //Assert.AreEqual(row.Cells[1].Text, p0);

            }
            Assert.IsTrue(b);
        }

    }
}
