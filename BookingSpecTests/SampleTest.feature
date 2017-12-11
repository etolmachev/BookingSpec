Feature: SampleTest
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Scenario: Open Main Page and Click Sign In Button
	Given I open browser
	And I navigate to url "https://booking.com"
	Then I wait for 5 seconds
	When I click Sign In button
	Then I wait for 5 seconds