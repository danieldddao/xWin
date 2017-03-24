@XWinPanel
Feature: XWinPanel

Scenario: XWinPanel loads successfully
	Given XWin program is set up
	When I launch the program
	Then It should load XWinPanel successfully

Scenario: Controller 1 is connected
	Given XWin program is set up
	When I launch the program
	Then It should show that controller 1 is connected

Scenario: Controller 1 connected can launch ControllerOptions window
	Given XWin program is set up
	When I launch the program
	And I click on Controller 1 button
	Then It should show ControllerOptions window

Scenario: Controller 2 is disconnected
	Given XWin program is set up
	When I launch the program
	Then It should show that controller 2 is disconnected

Scenario: Controller 2 disconnected cannot launch ControllerOptions window
	Given XWin program is set up
	When I launch the program
	And I click on Controller 2 button
	Then It should not show ControllerOptions window

Scenario: Controller 3 is disconnected
	Given XWin program is set up
	When I launch the program
	Then It should show that controller 3 is disconnected

Scenario: Controller 3 disconnected cannot launch ControllerOptions window
	Given XWin program is set up
	When I launch the program
	And I click on Controller 3 button
	Then It should not show ControllerOptions window

Scenario: Controller 4 is connected
	Given XWin program is set up
	When I launch the program
	Then It should show that controller 4 is connected

Scenario: Controller 4 connected can launch ControllerOptions window
	Given XWin program is set up
	When I launch the program
	And I click on Controller 4 button
	Then It should show ControllerOptions window
