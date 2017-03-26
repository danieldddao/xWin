@ButtonOptions
Feature: ButtonOptions Window
	Default: Open Application checkbox is checked. Open Application's path is ".../Test.exe"

Scenario: ButtonOptions loads successfully
	Given XWin program is set up to test ButtonOptions
	And I have the ControllerOptions window opened
	When I launch the "buttonLT" ButtonOptions window
	Then It should load "buttonLT" ButtonOptions window successfully


Scenario: Click Open Application button will open the dialog
	Given XWin program is set up to test ButtonOptions
	And I have the ControllerOptions window opened
	And I launch the "buttonLT" ButtonOptions window
	When I click on Open Application button
	Then It should display the open application dialog

Scenario: Select an application from Open Application button will display the application path and check the checkbox
	Given XWin program is set up to test ButtonOptions
	And I have the ControllerOptions window opened
	And I launch the "buttonLT" ButtonOptions window
	When I select to open application
	Then It should display the application path for Open Application
	And It should display the current action for Open Application
	And It should check the checkbox for Open Application

Scenario: Deselect Open Application checkbox will leave all checkboxes unchecked
	Given XWin program is set up to test ButtonOptions
	And I have the ControllerOptions window opened
	And I launch the "buttonLT" ButtonOptions window
	When I click on "openAppCheckBox" checkbox
	Then It should leave all checkboxes unchecked


Scenario: Click Text button will open the dialog
	Given XWin program is set up to test ButtonOptions
	And I have the ControllerOptions window opened
	And I launch the "buttonLT" ButtonOptions window
	When I click on Text button
	Then It should display the text mapping dialog for button "LeftThumb"

Scenario: Enter a text from Open Application button will display the application path and check the checkbox
	Given XWin program is set up to test ButtonOptions
	And I have the ControllerOptions window opened
	And I launch the "buttonLT" ButtonOptions window
	When I select to enter a text "Testing"
	Then It should display the text "Testing" for Text Mapping
	And It should display the current action for Text Mapping
	And It should check the checkbox for Text Mapping

Scenario: Enter an empty text from Open Application button will display an error window
	Given XWin program is set up to test ButtonOptions
	And I have the ControllerOptions window opened
	And I launch the "buttonLT" ButtonOptions window
	When I select to enter a text ""
	Then It should display the error for empty text
	
Scenario: Switching from Open Application to Text will check only Text checkbox
	Given XWin program is set up to test ButtonOptions
	And I have the ControllerOptions window opened
	And I launch the "buttonLT" ButtonOptions window
	When I click on "textCheckBox" checkbox
	Then It should leave only "textCheckBox" checked