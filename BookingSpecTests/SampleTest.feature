Feature: SampleTest
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Scenario: Open Main Page and Click Sign In Button
	Given I open browser
	And I navigate to url "https://booking.com"
	When I click Sign In button
	When I write my email "testmirantistest@gmail.com"
	And I write my password "1234qweR"
	When I click on PopUp Sign In button
	Then I wait for 5 seconds
	
