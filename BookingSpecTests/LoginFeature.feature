Feature: Login

Scenario Template: Attempt to Sign In using Invalid combinations of email and password
	When I open browser
	And I navigate to url "https://booking.com"
	When I click Sign In button on Ribbon menu
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

Scenario: Check maximum length for email field on Sign In
	When I open browser
	And I navigate to url "https://booking.com"
	When I click Sign In button on Ribbon menu
	And I set following parameters on Sign In Pop Up dialog
		| Field | Value                                                                                     |
		| Email | testmirantistesttestmirantistesttestmirantistesttestmirantistesttestmirantistest@gmail.ru |
	Then I see that value of email field consists of 80 chars on Sign In Pop Up dialog

Scenario: Attempt to recover password with invalid email
	When I open browser
	And I navigate to url "https://booking.com"
	When I click Sign In button on Ribbon menu
	And I click Forgot Your Password button
	When I set following parameters on Forgot Your Password Pop Up dialog
		| Field    | Value                      |
		| Email    | estmirantistest@gmail.com |
	Then I click button Send on Forgot Your Password PopUp
	And I wait while page popup is loading
	And I see error message "Oops! We can't find a profile registered with that name." on Forgot Your Password PopUp

Scenario: Cancel recover password and Sign in
	When I open browser
	And I navigate to url "https://booking.com"
	When I click Sign In button on Ribbon menu
	When I click Forgot Your Password button
	When I set following parameters on Forgot Your Password Pop Up dialog
		| Field    | Value                      |
		| Email    | testmirantistest@gmail.com |
	Then I click button Cancel on Forgot Your Password PopUp
	When I set following parameters on Sign In Pop Up dialog
		| Field    | Value                      |
		| Email    | testmirantistest@gmail.com |
		| Password | 1234qweR                   |
	And I click Sign In button on PopUp
	Then I see that I am Signed In

Scenario: Click on recover password and Sign In with old password
	When I open browser
	And I navigate to url "https://booking.com"
	When I click Sign In button on Ribbon menu
	When I click Forgot Your Password button
	When I set following parameters on Forgot Your Password Pop Up dialog
		| Field    | Value                      |
		| Email    | testmirantistest@gmail.com |
	Then I click button Send on Forgot Your Password PopUp
	And I wait while page popup is loading
	Then I click button Back To Sign In on Forgot Your Password PopUp
	When I set following parameters on Sign In Pop Up dialog
		| Field    | Value                      |
		| Email    | testmirantistest@gmail.com |
		| Password | 1234qweR                   |
	And I click Sign In button on PopUp
	Then I see that I am Signed In 

Scenario: Check that previous values in PopUp fields are saved
	When I open browser
	And I navigate to url "https://booking.com"
	When I click Sign In button on Ribbon menu
	When I set following parameters on Sign In Pop Up dialog
		| Field    | Value                      |
		| Email    | testmirantistest@gmail.com |
		| Password | 1234qweR                   |
	Then I click on X button
	And  I click Sign In button on Ribbon menu
	When I click Sign In button on PopUp
	Then I see that I am Signed In 

Scenario: Check that previous values in PopUp fields are not saved
	When I open browser
	And I navigate to url "https://booking.com"
	When I click Sign In button on Ribbon menu
	When I set following parameters on Sign In Pop Up dialog
		| Field    | Value                      |
		| Email    | testmirantistest@gmail.com |
		| Password | 1234qwER                   |
	Then I click on X button
	And I refresh page
	And  I click Sign In button on Ribbon menu
	When I click Sign In button on PopUp
	Then I see error message "Please enter a valid email address." on Sign In PopUp

@Ignore
#("This scenario implementation is coming soon")
Scenario: Recover Password by use link from email
	When I open browser
	And I navigate to url "https://booking.com"
	When I click Sign In button on Ribbon menu
	When I click Forgot Your Password button
	When I set following parameters on Forgot Your Password Pop Up dialog
		| Field    | Value                      |
		| Email    | testmirantistest@gmail.com |
	Then I click button Send on Forgot Your Password PopUp
	Then I click on the link in email
	And I change my password "1234qwER"
	When I set following parameters on Sign In Pop Up dialog
		| Field    | Value                      |
		| Email    | testmirantistest@gmail.com |
		| Password | 1234qwER                   |
	And I click Sign In button on PopUp
	Then I see that I am Signed In 
	