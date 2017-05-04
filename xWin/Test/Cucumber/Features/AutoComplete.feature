@AutoComplete
Feature: AutoComplete
	
Scenario: AutoComplete configuration is in Settings tab
	Given XWin program is set up and launched
	When I click on Settings tab
	Then I should see Auto-Complete label

Scenario: View AutoComplete's Dictionary database by clicking on Manage Dictionary button
	Given XWin program is set up and launched
	When I click on Settings tab
	And I click on Manage Dictionary Button
	Then I should see Dictionary Database

Scenario: Clear Dictionary by clicking on clear button
	Given XWin program is set up and launched
	When I click on Settings tab
	And I click on Manage Dictionary Button
	And I click on Clear Dictionary button
	Then I should not see any word in the list

Scenario: Remove word in dictionary
	Given XWin program is set up and launched
	When I click on Settings tab
	And I click on Manage Dictionary Button
	And I remove word "this" from dictionary
	Then I should not see word "this"

Scenario: Add new word to dictionary
	Given XWin program is set up and launched
	When I click on Settings tab
	And I click on Manage Dictionary Button
	And I add word "newWord" to dictionary
	Then I should see word "newWord"

Scenario: View Word Prediction tips
	Given XWin program is set up and launched
	When I click on Settings tab
	And I click on word prediction tips
	Then I should see word prediction tips window

Scenario: View QuickType Suggestions tips
	Given XWin program is set up and launched
	When I click on Settings tab
	And I click on quicktype suggestions tips
	Then I should see quicktype suggestions tips window

Scenario: View Customize QuickType Bar
	Given XWin program is set up and launched
	When I click on Settings tab
	And I click on customize quicktype bar
	Then I should see customize quicktype bar window

Scenario: Customize QuickType Bar's Suggestion 1 Window
	Given XWin program is set up and launched
	When I click on Settings tab
	And I click on customize quicktype bar
	And I click on Suggestion 1
	Then I should see shortcut window for suggestion 1

Scenario: Customize QuickType Bar's Suggestion 2 Window
	Given XWin program is set up and launched
	When I click on Settings tab
	And I click on customize quicktype bar
	And I click on Suggestion 2
	Then I should see shortcut window for suggestion 2

Scenario: Customize QuickType Bar's Suggestion 3 Window
	Given XWin program is set up and launched
	When I click on Settings tab
	And I click on customize quicktype bar
	And I click on Suggestion 3
	Then I should see shortcut window for suggestion 3

Scenario: Customize QuickType Bar's Suggestion 1 with shortcut
	Given XWin program is set up and launched
	When I click on Settings tab
	And I click on customize quicktype bar
	And I click on Suggestion 1
	And I enter shortcut F5 for suggestion 1
	Then It should display shortcut F5 for suggestion 1

Scenario: Customize QuickType Bar's Suggestion 2 with shortcut
	Given XWin program is set up and launched
	When I click on Settings tab
	And I click on customize quicktype bar
	And I click on Suggestion 2
	And I enter shortcut F5 for suggestion 2
	Then It should display shortcut F5 for suggestion 2

Scenario: Customize QuickType Bar's Suggestion 3 with shortcut
	Given XWin program is set up and launched
	When I click on Settings tab
	And I click on customize quicktype bar
	And I click on Suggestion 3
	And I enter shortcut F5 for suggestion 3
	Then It should display shortcut F5 for suggestion 3

Scenario: Saving shortcut QuickType Bar's Suggestion 1
	Given XWin program is set up and launched
	When I click on Settings tab
	And I click on customize quicktype bar
	And I click on Suggestion 1
	And I enter shortcut F5 for suggestion 1
	And I save customization
	Then It should save the shortcut for suggestion 1

Scenario: Saving shortcut QuickType Bar's Suggestion 2
	Given XWin program is set up and launched
	When I click on Settings tab
	And I click on customize quicktype bar
	And I click on Suggestion 2
	And I enter shortcut F5 for suggestion 2
	And I save customization
	Then It should save the shortcut for suggestion 2

Scenario: Saving shortcut QuickType Bar's Suggestion 3
	Given XWin program is set up and launched
	When I click on Settings tab
	And I click on customize quicktype bar
	And I click on Suggestion 3
	And I enter shortcut F5 for suggestion 3
	And I save customization
	Then It should save the shortcut for suggestion 3

Scenario: Can't set the suggestion 1's shortcut for suggestion 2
	Given XWin program is set up and launched
	When I click on Settings tab
	And I click on customize quicktype bar
	And I click on Suggestion 1
	And I enter shortcut F5 for suggestion 1
	And I click on Suggestion 2
	And I enter shortcut F5 for suggestion 2
	Then I should receive a message box

Scenario: Can't set the suggestion 2's shortcut for suggestion 1
	Given XWin program is set up and launched
	When I click on Settings tab
	And I click on customize quicktype bar
	And I click on Suggestion 2
	And I enter shortcut F2 for suggestion 2
	And I click on Suggestion 1
	And I enter shortcut F2 for suggestion 1
	Then I should receive a message box

Scenario: Can't set the suggestion 2's shortcut for suggestion 3
	Given XWin program is set up and launched
	When I click on Settings tab
	And I click on customize quicktype bar
	And I click on Suggestion 2
	And I enter shortcut F2 for suggestion 2
	And I click on Suggestion 3
	And I enter shortcut F2 for suggestion 3
	Then I should receive a message box

Scenario: Can't set the suggestion 3's shortcut for suggestion 2
	Given XWin program is set up and launched
	When I click on Settings tab
	And I click on customize quicktype bar
	And I click on Suggestion 3
	And I enter shortcut F3 for suggestion 3
	And I click on Suggestion 2
	And I enter shortcut F3 for suggestion 2
	Then I should receive a message box

Scenario: Can't set the suggestion 1's shortcut for suggestion 3
	Given XWin program is set up and launched
	When I click on Settings tab
	And I click on customize quicktype bar
	And I click on Suggestion 1
	And I enter shortcut F1 for suggestion 1
	And I click on Suggestion 3
	And I enter shortcut F1 for suggestion 3
	Then I should receive a message box

Scenario: Can't set the suggestion 3's shortcut for suggestion 1
	Given XWin program is set up and launched
	When I click on Settings tab
	And I click on customize quicktype bar
	And I click on Suggestion 3
	And I enter shortcut F3 for suggestion 3
	And I click on Suggestion 1
	And I enter shortcut F3 for suggestion 1
	Then I should receive a message box

Scenario: Check Using shortcuts for QuickType Bar
	Given XWin program is set up and launched
	When I click on Settings tab
	And I click on customize quicktype bar
	And I check using shortcuts checkbox
	And I save customization
	Then It should check the checkbox

Scenario: Uncheck Using shortcuts for QuickType Bar
	Given XWin program is set up and launched
	When I click on Settings tab
	And I click on customize quicktype bar
	And I uncheck using shortcuts checkbox
	And I save customization
	Then It should uncheck the checkbox