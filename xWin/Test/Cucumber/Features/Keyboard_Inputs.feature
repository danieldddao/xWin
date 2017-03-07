Feature: Keyboard Inputs
	
@mytag
Scenario: Press a key on keyboard using Windows.Forms.Keys
	Given I have keyboard set up
	When I press key Keys.B
	Then It should be pressed

@mytag
Scenario: Press a key on keyboard using lowercase character
	Given I have keyboard set up
	When I press key 'a'
	Then It should be pressed without shift key
	@mytag
Scenario: Press a key on keyboard using uppercase character
	Given I have keyboard set up
	When I press key 'A'
	Then It should be pressed with shift key
Scenario: Press a key on keyboard using shiftedkey character
	Given I have keyboard set up
	When I press key '!'
	Then It should be pressed with shift key

@mytag
Scenario: Press keys from given lowercase string
	Given I have keyboard set up
	When I press keys from string 'abc'
	Then It should be pressed without shift key
@mytag
Scenario: Press keys from given uppercase-lowercase string
	Given I have keyboard set up
	When I press keys from string 'Abc'
	Then It should be pressed with shift key
@mytag
Scenario: Press keys from given shiftedkeys-lowercase string
	Given I have keyboard set up
	When I press keys from string '!@bc'
	Then It should be pressed with shift key
@mytag
Scenario: Press keys from given uppercase string
	Given I have keyboard set up
	When I press keys from string 'ABC'
	Then It should be pressed with shift key
@mytag
Scenario: Press keys from given shiftedkeys string
	Given I have keyboard set up
	When I press keys from string '#$#'
	Then It should be pressed with shift key

@mytag
Scenario: Press shortcut from given valid shortcut
	Given I have keyboard set up
	When I press the shortcut Ctrl+R
	Then It should be pressed

@mytag
Scenario: Open application from invalid path
	Given I have keyboard set up
	When I open the application from invalid path "file"
	Then It should not open the application

@mytag
Scenario: Open application from valid path
	Given I have keyboard set up
	When I open the application from valid path "file"
	Then It should open the application