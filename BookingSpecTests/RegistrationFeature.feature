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
	Then I see that I am Registered and Signed In

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

Scenario: Input email and pass that already registered and make sure that I am signed in
	When I open browser
	And I navigate to url "https://booking.com"
	And I click Register button on Ribbon menu
	And I set following parameters on Register Pop Up dialog
	| Field    | Value                      |
	| Email    | testmirantistest@gmail.com |
	| Password | 1234qweR                   |
	And I click Get Started button on PopUp
	Then I see that I am Signed In

Scenario: Input email that already registered and invalid pass to make sure that I am not registered and not signed in
	When I open browser
	And I navigate to url "https://booking.com"
	And I click Register button on Ribbon menu
	And I set following parameters on Register Pop Up dialog
	| Field    | Value                      |
	| Email    | testmirantistest@gmail.com |
	| Password | 12341234                   |
	And I click Get Started button on PopUp
	Then I see that I am not Signed In and not Registered

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
	Then I see that credential values are saved in Register PopUp fields
	When I click Get Started button on PopUp
	Then I see that I am Signed In and Registered 

Scenario: Check that previous values in Register PopUp fields are not saved
	When I open browser
	And I navigate to url "https://booking.com"
	And I click Register button on Ribbon menu
	And I set following parameters on Register Pop Up dialog
		| Field    | Value                      |
		| Email    | testmirantistest@gmail.com |
		| Password | 1234qwER                   |
	And I click on X button
	And I refresh page
	And  I click Register button on Ribbon menu
	Then I see that credential values are not saved in Register PopUp fields
	When I click Get Started button on PopUp
	Then I see error message "Please enter a valid email address." on Register PopUp
