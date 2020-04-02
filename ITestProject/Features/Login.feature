Feature: Login
	This feature file contains scenarios for Login functionality

@smoketest
Scenario Outline: Login with Different credentials
	This scenario should check to verify ability to login
	
	Given I am on Login page
	And I type <Login> and <Password> to the form
	And I also choose <Domain>
	When I press login
	Then the result should be successfull login to the I.UA

Examples: 
	| Domain   | Login            | Password   |
	| email.ua | andrii.hnatyshyn | Adrenalin1 |
	| i.ua     | andrii.hnatyshyn_test1 | Some_Password1 |
	| i.ua     | andrii.hnatyshyn | Adrenalin1 |
	| i.ua     | andrii.hnatyshyn_test2 | Some_Password2 |