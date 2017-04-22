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