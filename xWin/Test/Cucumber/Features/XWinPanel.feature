@XWinPanel
Feature: XWinPanel Window

#Scenario: XWinPanel loads successfully
#	Given XWin program is set up
#	When I launch the program
#	Then It should load XWinPanel successfully
#
#Scenario: Controller 1 is connected
#	Given XWin program is set up
#	When I launch the program
#	Then It should show that controller 1 is connected
#
#Scenario: Controller 1 connected can launch ControllerOptions window
#	Given XWin program is set up
#	When I launch the program
#	And I click on Controller 1 button
#	Then It should show ControllerOptions window
#
#Scenario: Controller 2 is disconnected
#	Given XWin program is set up
#	When I launch the program
#	Then It should show that controller 2 is disconnected
#
#Scenario: Controller 2 disconnected cannot launch ControllerOptions window
#	Given XWin program is set up
#	When I launch the program
#	And I click on Controller 2 button
#	Then It should not show ControllerOptions window
#
#Scenario: Controller 3 is disconnected
#	Given XWin program is set up
#	When I launch the program
#	Then It should show that controller 3 is disconnected
#
#Scenario: Controller 3 disconnected cannot launch ControllerOptions window
#	Given XWin program is set up
#	When I launch the program
#	And I click on Controller 3 button
#	Then It should not show ControllerOptions window
#
#Scenario: Controller 4 is connected
#	Given XWin program is set up
#	When I launch the program
#	Then It should show that controller 4 is connected
#
#Scenario: Controller 4 connected can launch ControllerOptions window
#	Given XWin program is set up
#	When I launch the program
#	And I click on Controller 4 button
#	Then It should show ControllerOptions window
#	
#Scenario: XWinPanel Shows Log
#	Given XWin program is set up
#	When I launch the program
#	And I click on Log tab
#	Then It should have Log tab
#	
#Scenario: Log shows information
#	Given XWin program is set up
#	When I launch the program
#	And I click on Log tab
#	Then Log should show "Application started"
#
#Scenario: Enable debug mode in Log successfully
#	Given XWin program is set up
#	When I launch the program
#	And I click on Log tab
#	And I enable debug mode for logging
#	Then Log should show "Enabled Debug Mode"
#
#Scenario: Disable debug mode in Log successfully
#	Given XWin program is set up
#	When I launch the program
#	And I click on Log tab
#	And I disabled debug mode for logging
#	Then Log should show "Disabled Debug Mode"
#
#Scenario: Clear all logs successfully
#	Given XWin program is set up
#	When I launch the program
#	And I click on Log tab
#	And I clear all logs
#	Then Log should show "Cleared all logs!"
#
#Scenario: Open log file successfully
#	Given XWin program is set up
#	When I launch the program
#	And I click on Log tab
#	And I open log file
#	Then Log should show "Log file opened!"

Scenario: Click on Report Button will open Report Form
	Given XWin program is set up
	When I launch the program
	And I click on Log tab
	And I click on report button
	Then Report Window should be opened

Scenario: Empty Name will show message
	Given XWin program is set up
	When I launch the program
	And I click on Log tab
	And I click on report button
	And I click on send button to report
	Then It should show the message box

Scenario: Empty Email will show message
	Given XWin program is set up
	When I launch the program
	And I click on Log tab
	And I click on report button
	And I fill "Name" in Name text box
	And I click on send button to report
	Then It should show the message box

Scenario: Wrong email format will show message
	Given XWin program is set up
	When I launch the program
	And I click on Log tab
	And I click on report button
	And I fill "Name" in Name text box
	And I fill "email" in email text box
	And I click on send button to report
	Then It should show the message box

Scenario: Empty email message will show message
	Given XWin program is set up
	When I launch the program
	And I click on Log tab
	And I click on report button
	And I fill "Name" in Name text box
	And I fill "email@gmail.com" in email text box
	And I click on send button to report
	Then It should show the message box

Scenario: correct information will show message
	Given XWin program is set up
	When I launch the program
	And I click on Log tab
	And I click on report button
	And I fill "Name" in Name text box
	And I fill "email@gmail.com" in email text box
	And I fill "message" in email message text box
	And I click on send button to report
	Then It should show the message box