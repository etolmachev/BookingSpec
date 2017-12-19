Feature: SampleTest
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Scenario Template: Attempt to Sign In using Invalid combinations of email and password
	Given I open browser
	And I navigate to url "https://booking.com"
	When I click Sign In button
	And I set following parameters on Sign In Pop Up dialog
		| Field    | Value      |
		| Email    | <Email>    |
		| Password | <Password> |
	And I click Sign In button on PopUp
	Then I wait while page popup is working
	And I see message error with "<Message>"

Scenarios: 
		| Email                      | Password  | Message                                                               |
		| testmirantistest@gmail.com | wrongpass | You entered an email address/password combination that doesn't match. |
		| invalidEmail@g.com         | 1234qweR  | You entered an email address/password combination that doesn't match. |
		| invalidEmail@g.com         | wrongpass | You entered an email address/password combination that doesn't match. |
		|                            | 1234qweR  | Please enter a valid email address.                                   |
		| testmirantistest@gmail.com |           | Please add a password                                                 |
		|                            |           | Please enter a valid email address.                                   |

Scenario: Input in email field more than 80 chars and assert that there only 80 chars
	Given I open browser
	And I navigate to url "https://booking.com"
	When I click Sign In button
	And I write email with length ninety chars "testmirantistesttestmirantistesttestmirantistesttestmirantistesttestmirantistest@gmail.ru"
	Then I check that length of email is 80 chars

Scenario: Attempt to recover password with invalid email
	Given I open browser
	And I navigate to url "https://booking.com"
	When I click Sign In button
	When I click Forgot Your Password button
	And I write email "estmirantistest@gmail.com"
	And I Click button Send
	Then I wait while page popup is loading
	Then I see an error on ForgotYourPasswordPopUp

Scenario: Cancel recover password and Sign in
	Given I open browser
	And I navigate to url "https://booking.com"
	When I click Sign In button
	When I click Forgot Your Password button
	And I write email "testmirantistest@gmail.com"
	Then I click button Cancel
	When I set following parameters on Sign In Pop Up dialog
		| Field | Value |
		| Email | testmirantistest@gmail.com |
		| Password  | 1234qweR |
	And I click Sign In button on PopUp
	Then I see that i am Signed In

Scenario: Click on recover password and Sign In with old password
	Given I open browser
	And I navigate to url "https://booking.com"
	When I click Sign In button
	When I click Forgot Your Password button
	And I write email "testmirantistest@gmail.com"
	And I Click button Send
	And I wait while page popup is loading
	Then I click button Back to sign in
	When I set following parameters on Sign In Pop Up dialog
		| Field | Value |
		| Email | testmirantistest@gmail.com |
		| Password  | 1234qweR |
	And I click Sign In button on PopUp
	Then I see that i am Signed In 

Scenario: Input Valid Email and Pass close PopUp after that open PopUp and Sign In
	Given I open browser
	And I navigate to url "https://booking.com"
	When I click Sign In button
	When I set following parameters on Sign In Pop Up dialog
		| Field | Value |
		| Email | testmirantistest@gmail.com |
		| Password  | 1234qweR |
	Then I click on X button
	And  I click Sign In button
	When I click Sign In button on PopUp
	Then I see that i am Signed In 

Scenario: Input Valid Email and Pass then Refresh and attempt to Sign In
	Given I open browser
	And I navigate to url "https://booking.com"
	When I click Sign In button
	When I set following parameters on Sign In Pop Up dialog
		| Field | Value |
		| Email | testmirantistest@gmail.com |
		| Password  | 1234qwER |
	Then I click on X button
	When I refresh page
	And  I click Sign In button
	When I click Sign In button on PopUp
	Then I see that i am not Signed In 

Scenario: Recover Password by use link from email
	Given I open browser
	And I navigate to url "https://booking.com"
	When I click Sign In button
	When I click Forgot Your Password button
	And I write email "testmirantistest@gmail.com"
	And I Click button Send
	Then I click on the link in email
	And I change my password "1234qwER"
	When I set following parameters on Sign In Pop Up dialog
		| Field | Value |
		| Email | testmirantistest@gmail.com |
		| Password  | 1234qwER |
	And I click Sign In button on PopUp
	Then I see that i am Signed In 
