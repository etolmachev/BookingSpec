Feature: Registration

Scenario: Input valid credentials in order to Register
	When I open browser
	And I navigate to url "https://booking.com"
	And I click Register button on Ribbon menu
	And I set following parameters on Register Pop Up dialog
	| Field    | Value                      |
	| Email    | testmirantistest@gmail.com |
	| Password | 1234qweR                   |
	And I click Get Started button on PopUp
	Then I see that I am Signed In

Scenario Template: Attempt to Register using Invalid combinations of email and password
	When I open browser
	And I navigate to url "https://booking.com"
	And I click Register button on Ribbon menu
	And I set following parameters on Register Pop Up dialog
		| Field    | Value      |
		| Email    | <Email>    |
		| Password | <Password> |
	And I click Get Started button on PopUp
	Then I wait while page popup is working
	And I see message error with "<Message>"

	Scenarios: 
		| Email        | Password  | Message                                         |
		| 2131312@.com | 1         | Password needs to be at least 8 characters long |
		| 2131312@.com |           | Please add a password                           |
		| 2131312@.com | wrongpass | Please enter a valid email address.             |
		| 2131312.com  | 12341234  | Please enter a valid email address.             |
		| 2131312@com  | 12341234  | Please enter a valid email address.             |
		|              |           | Please enter a valid email address.             |

Scenario: Try to register as already registered user
	When I open browser
	And I navigate to url "https://booking.com"
	And I click Register button on Ribbon menu
	And I set following parameters on Register Pop Up dialog
	| Field    | Value                      |
	| Email    | testmirantistest@gmail.com |
	| Password | 1234qweR                   |
	And I click Get Started button on PopUp
	Then I see that I am Signed In

Scenario: Attempt to register with already used email
	When I open browser
	And I navigate to url "https://booking.com"
	And I click Register button on Ribbon menu
	And I set following parameters on Register Pop Up dialog
	| Field    | Value                      |
	| Email    | testmirantistest@gmail.com |
	| Password | 12341234                   |
	And I click Get Started button on PopUp
	Then I wait while page popup is working
	Then I see error message "You entered an email address/password combination that doesn't match. I forgot" on Register PopUp
	When I click on X button
	Then I see that I am not Signed In
	When I click Sign In button on Ribbon menu
	Then I check that I am not Registered
	| Field    | Value                      |
	| Email    | testmirantistest@gmail.com |
	| Password | 12341234                   |
	Then I wait while page popup is working
	And I see error message "You entered an email address/password combination that doesn't match. I forgot" on Sign In PopUp

Scenario: Check maximum length for email field on Register PopUp
	When I open browser
	And I navigate to url "https://booking.com"
	And I click Register button on Ribbon menu
	And I set following parameters on Register Pop Up dialog
		| Field | Value                                                                                     |
		| Email | testmirantistesttestmirantistesttestmirantistesttestmirantistesttestmirantistest@gmail.ru |
	Then I see that value of email field consists of 80 chars on Register Pop Up dialog

Scenario: Check that previous values in Register PopUp fields are saved
	When I open browser
	And I navigate to url "https://booking.com"
	And I click Register button on Ribbon menu
	And I set following parameters on Register Pop Up dialog
		| Field    | Value                      |
		| Email    | testmirantistest@gmail.com |
		| Password | 1234qweR                   |
	And I click on X button
	And I click Register button on Ribbon menu
	Then I see that credential values: "testmirantistest@mail.com" "1234qweR" are "saved" in Register PopUp fields
	When I click Get Started button on PopUp
	Then I see that I am Signed In

Scenario: Check that previous values in Register PopUp fields are not saved
	When I open browser
	And I navigate to url "https://booking.com"
	And I click Register button on Ribbon menu
	And I set following parameters on Register Pop Up dialog
		| Field    | Value                      |
		| Email    | testmirantistest@gmail.com |
		| Password | 1234qweR                   |
	And I click on X button
	And I refresh page
	And  I click Register button on Ribbon menu
	Then I see that credential values: "testmirantistest@mail.com" "1234qweR" are "not saved" in Register PopUp fields
	When I click Get Started button on PopUp
	Then I see error message "Please enter a valid email address." on Register PopUp
