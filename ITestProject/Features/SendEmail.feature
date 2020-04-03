Feature: SendEmail
	This feature file contains scenarios for Sending email functionality

@email_creation
Scenario Outline: Send email 
		This scenario should check ability to send Emails
	
	Given I am on Email Page
	When I navigate to New Message Page by Make Message button
	When I type <To> and <Subject> to the form
	And I also type <Body>
	When I click Send
	Then I verify that message was sent

Examples: 
	| To                         | Subject      | Body |
	| andrii.hnatyshyn@gmail.com | Test Subject | Test |
	| andrii.hnatyshyn@i.ua		 | Test Subject2 | Test2 |