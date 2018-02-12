Feature: SampleTest
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Scenario: Input valid credentials to Sign In
	When I open browser
	And I navigate to url "https://booking.com"
	When I click Sign In button on Ribbon menu
	And I write email on Sign in PopUp "{{config::email}}"
	And I write password "{{config::password}}"
	And I click Sign In button on PopUp
	Then I see that I am Signed In