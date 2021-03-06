﻿Feature: Login

Scenario Template: Attempt to Sign In using Invalid combinations of email and password
	When I open browser
	And I navigate to url "https://booking.com"
	And I click Sign In button on Ribbon menu
	And I set following parameters on Sign In Pop Up dialog
		| Field    | Value      |
		| Email    | <Email>    |
		| Password | <Password> |
	And I click Sign In button on PopUp
	Then I wait while "Sign In" popup is working
	And I see message error with "<Message>"

Scenarios: 
		| Email              | Password             | Message                                                                        |
		| {{config::email}}  | wrongpass            | You entered an email address/password combination that doesn't match. I forgot |
		| invalidEmail@g.com | {{config::password}} | You entered an email address/password combination that doesn't match. I forgot |
		| invalidEmail@g.com | wrongpass            | You entered an email address/password combination that doesn't match. I forgot |
		|                    | {{config::password}} | Please enter a valid email address.                                            |
		| {{config::email}}  |                      | Please add a password                                                          |
		|                    |                      | Please enter a valid email address.                                            |

Scenario: Check maximum length for email field on Sign In
	When I open browser
	And I navigate to url "https://booking.com"
	And I click Sign In button on Ribbon menu
	And I set following parameters on Sign In Pop Up dialog
		| Field | Value                                                                                     |
		| Email | testmirantistesttestmirantistesttestmirantistesttestmirantistesttestmirantistest@gmail.ru |
	Then I see that value of email field consists of 80 chars on Sign In Pop Up dialog

Scenario: Attempt to recover password with invalid email
	When I open browser
	And I navigate to url "https://booking.com"
	And I click Sign In button on Ribbon menu
	And I click Forgot Your Password button
	And I set following parameters on Forgot Your Password Pop Up dialog
		| Field    | Value                     |
		| Email    | estmirantistest@gmail.com |
	And I click button Send on Forgot Your Password PopUp
	Then I wait while "Forgot Your Password" popup is working
	And I see error message "Oops! We can't find a profile registered with that name." on Forgot Your Password PopUp

Scenario: Cancel recover password and Sign in
	When I open browser
	And I navigate to url "https://booking.com"
	And I click Sign In button on Ribbon menu
	And I click Forgot Your Password button
	And I set following parameters on Forgot Your Password Pop Up dialog
		| Field | Value             |
		| Email | {{config::email}} |
	And I click button Cancel on Forgot Your Password PopUp
	Then I see Sign In PopUp dialog
	When I set following parameters on Sign In Pop Up dialog
		| Field    | Value                |
		| Email    | {{config::email}}    |
		| Password | {{config::password}} |
	And I click Sign In button on PopUp
	Then I see that I am Signed In

Scenario: Click on recover password and Sign In with old password
	When I open browser
	And I navigate to url "https://booking.com"
	And I click Sign In button on Ribbon menu
	And I click Forgot Your Password button
	And I set following parameters on Forgot Your Password Pop Up dialog
		| Field | Value             |
		| Email | {{config::email}} |
	And I click button Send on Forgot Your Password PopUp
	Then I wait while "Forgot Your Password" popup is working
	When I click button Back To Sign In on Forgot Your Password PopUp
	And I set following parameters on Sign In Pop Up dialog
		| Field    | Value                |
		| Email    | {{config::email}     |
		| Password | {{config::password}} |
	And I click Sign In button on PopUp
	Then I see that I am Signed In 

Scenario: Check that previous values in PopUp fields are saved
	When I open browser
	And I navigate to url "https://booking.com"
	And I click Sign In button on Ribbon menu
	And I set following parameters on Sign In Pop Up dialog
		| Field    | Value                |
		| Email    | {{config::email}}    |
		| Password | {{config::password}} |
	And I click on X button
	And  I click Sign In button on Ribbon menu
	Then I see that credential values: "{{config::email}}" "{{config::password}}" are "saved" in Sign In PopUp fields
	When I click Sign In button on PopUp
	Then I see that I am Signed In 

Scenario: Check that previous values in PopUp fields are not saved
	When I open browser
	And I navigate to url "https://booking.com"
	And I click Sign In button on Ribbon menu
	And I set following parameters on Sign In Pop Up dialog
		| Field    | Value                |
		| Email    | {{config::email}}    |
		| Password | {{config::password}} |
	And I click on X button
	And I refresh page
	And  I click Sign In button on Ribbon menu
	Then I see that credential values: "{{config::email}}" "{{config::password}}" are "not saved" in Sign In PopUp fields
	When I click Sign In button on PopUp
	Then I see error message "Please enter a valid email address." on Sign In PopUp

@Ignore
#("This scenario implementation is coming soon")
Scenario: Recover Password by use link from email
	When I open browser
	And I navigate to url "https://booking.com"
	And I click Sign In button on Ribbon menu
	And I click Forgot Your Password button
	And I set following parameters on Forgot Your Password Pop Up dialog
		| Field | Value             |
		| Email | {{config::email}} |
	And I click button Send on Forgot Your Password PopUp
	And I click on the link in email
	And I change my password "1234qwER"
	And I set following parameters on Sign In Pop Up dialog
		| Field    | Value             |
		| Email    | {{config::email}} |
		| Password | 1234qwER          |
	And I click Sign In button on PopUp
	Then I see that I am Signed In 
	