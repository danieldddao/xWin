Feature: Keyboard Inputs
	
@mytag
Scenario: Press a key on keyboard using Windows.Forms.Keys
	Given I have keyboard set up
	When I press key Keys.B
	Then It should be pressed

@mytag
Scenario: Press a key on keyboard using character
	Given I have keyboard set up
	When I press key 'A'
	Then It should be pressed
