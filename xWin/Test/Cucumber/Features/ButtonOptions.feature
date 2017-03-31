@ButtonOptions
Feature: ButtonOptions Window
	Default: Open Application checkbox is checked. Open Application's path is ".../Test.exe"

Scenario: ButtonOptions loads successfully
	Given XWin program is set up to test ButtonOptions
	And I have the ControllerOptions window opened
	When I launch the "buttonLT" ButtonOptions window
	Then It should load "buttonLT" ButtonOptions window successfully

#
# Keyboard Mapping Screnarios
#
Scenario: Click Keyboard button will open the dialog
	Given XWin program is set up to test ButtonOptions
	And I have the ControllerOptions window opened
	And I launch the "buttonLT" ButtonOptions window
	When I click on Keyboard button
	Then It should display the keyboard mapping dialog for button "LeftThumb"

Scenario: Initially Keyboard option is None
	Given XWin program is set up to test ButtonOptions
	And I have the ControllerOptions window opened
	When I launch the "buttonLT" ButtonOptions window
	Then It should display None key for Keyboard
	And It should not check the checkbox for Keyboard

Scenario: Select a key from Keyboard button will display the key and check the checkbox
	Given XWin program is set up to test ButtonOptions
	And I have the ControllerOptions window opened
	And I launch the "buttonLT" ButtonOptions window
	When I click on Keyboard button
	And I choose key "btnRETURN"
	Then It should display the key "Enter" for Keyboard
	And It should display the current action for Keyboard
	And It should check the checkbox for Keyboard
	
Scenario: Switching to Keyboard will check only Keyboard checkbox
	Given XWin program is set up to test ButtonOptions
	And I have the ControllerOptions window opened
	And I launch the "buttonLT" ButtonOptions window
	When I click on "keyboardCheckBox" checkbox
	Then It should leave only "keyboardCheckBox" checked

#
#Open Application Screnarios
#
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

#
# Shortcut Mapping Screnarios
#
Scenario: Click Shortcut button will open the dialog
	Given XWin program is set up to test ButtonOptions
	And I have the ControllerOptions window opened
	And I launch the "buttonLT" ButtonOptions window
	When I click on Shortcut button
	Then It should display the Shortcut mapping dialog for button "LeftThumb"

Scenario: Initially Shortcut option is None
	Given XWin program is set up to test ButtonOptions
	And I have the ControllerOptions window opened
	When I launch the "buttonLT" ButtonOptions window
	Then It should display None for Shortcut
	And It should not check the checkbox for Shortcut

Scenario: Enter and save shortcut from Shortcut button will display the shortcut and check the checkbox
	Given XWin program is set up to test ButtonOptions
	And I have the ControllerOptions window opened
	And I launch the "buttonLT" ButtonOptions window
	When I click on Shortcut button
	And I enter shortcut F5
	Then It should display shortcut "F5" for shortcut
	And It should display the current action for Shortcut Mapping
	And It should check the checkbox for Shortcut Mapping

Scenario: Enter and not save shortcut from Shortcut button will not display the shortcut and not check the checkbox
	Given XWin program is set up to test ButtonOptions
	And I have the ControllerOptions window opened
	And I launch the "buttonLT" ButtonOptions window
	When I click on Shortcut button
	And I enter shortcut F5 without saving
	Then It should display None for Shortcut
	And It should not display the current action for Shortcut Mapping
	And It should not check the checkbox for Shortcut Mapping
	
Scenario: Switching to Shortcut will check only Shortcut checkbox
	Given XWin program is set up to test ButtonOptions
	And I have the ControllerOptions window opened
	And I launch the "buttonLT" ButtonOptions window
	When I click on "shortcutCheckBox" checkbox
	Then It should leave only "shortcutCheckBox" checked


#
#Text Mapping Screnarios
#
Scenario: Click Text button will open the dialog
	Given XWin program is set up to test ButtonOptions
	And I have the ControllerOptions window opened
	And I launch the "buttonLT" ButtonOptions window
	When I click on Text button
	Then It should display the text mapping dialog for button "LeftThumb"

Scenario: Initially Text option is None
	Given XWin program is set up to test ButtonOptions
	And I have the ControllerOptions window opened
	When I launch the "buttonLT" ButtonOptions window
	Then It should display None text for Text
	And It should not check the checkbox for Text

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
	
Scenario: Switching to Text will check only Text checkbox
	Given XWin program is set up to test ButtonOptions
	And I have the ControllerOptions window opened
	And I launch the "buttonLT" ButtonOptions window
	When I click on "textCheckBox" checkbox
	Then It should leave only "textCheckBox" checked