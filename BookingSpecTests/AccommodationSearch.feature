Feature: AccommodationSearch

Scenario: Input valid data in order to Search accommodation on main page
	When I open browser
	And I navigate to url "https://booking.com"
	When I input data "New York, New York State, USA" in Destination Search field on main page
	And I click on first autocomplete option that contains "New York"
	And I set the calendar for the current date plus one year
	Then I click button Search on main page
	And I see that I am on Search Result page and see that offered accommodation is in "New York"

Scenario: Input invalid data in accommodation search calendar on main page
	When I open browser
	And I navigate to url "https://booking.com"
	When I set following parameters in calendar on main page
		| Field     | Month | MonthDay | Year |
		| Check In  | 04    | 15       | 2018 |
		| Check Out | 04    | 15       | 2020 |
	When I input data "Issaquah, WA, United States" in Destination Search field on main page
	And I click on first autocomplete option that contains "Issaquah"
	Then I click button Search on main page
	And I see date error message "Reservations longer than 30 nights are not possible." on main page

	Scenario: Input invalid data in Destination Search accommodation field on main page
	When I open browser
	And I navigate to url "https://booking.com"
	When I input data "sfsadfasdf" in Destination Search field on main page
	And I set the calendar for the current date plus one year
	Then I click button Search on main page
	And I wait browser page to load
	And I see destination error message "Sorry, we don't recognize that name." on main page

Scenario Template: Check that check-in date always earlier than check-out date
	When I open browser
	And I navigate to url "https://booking.com"
	And I set following parameters in calendar on main page
	| Field     | Month      | MonthDay      | Year      |
	| Check In  | <MonthIn>  | <MonthDayIn>  | <YearIn>  |
	| Check Out | <MonthOut> | <MonthDayOut> | <YearOut> |
	Then I make sure that check-out date is later for one day than check-in

	Scenarios: 
	| MonthIn | MonthDayIn | YearIn | MonthOut | MonthDayOut | YearOut |
	| 04      | 25         | 2018   | 04       | 15          | 2018    |
	| 04      | 15         | 2018   | 04       | 13          | 2018    |

Scenario: Check that Search accommodation Adults dropdown menu works properly
	When I open browser
	And I navigate to url "https://booking.com"
	When I input data "Issaquah, WA, United States" in Destination Search field on main page
	And I click on first autocomplete option that contains "Issaquah"
	And I set the calendar for the current date plus one year
	When I set following parameters in dropdown menus
	| Field  | Value |
	| Adults | 5     |
	Then I click button Search on main page
	And I see that Search result is for "Groups" and "5 adults"

 Scenario: Check that Search accommodation Children dropdown menu works properly
	When I open browser
	And I navigate to url "https://booking.com"
	When I input data "Issaquah, WA, United States" in Destination Search field on main page
	And I click on first autocomplete option that contains "Issaquah"
	And I set the calendar for the current date plus one year
	When I set following parameters in dropdown menus
	| Field    | Value |
	| Children | 1     |
	Then I click button Search on main page
	And I see that Search result is for "Families" and "1 child"

 Scenario: Check that Search accommodation Rooms dropdown menu works properly
	When I open browser
	And I navigate to url "https://booking.com"
	When I input data "Issaquah, WA, United States" in Destination Search field on main page
	And I click on first autocomplete option that contains "Issaquah"
	And I set the calendar for the current date plus one year
	When I set following parameters in dropdown menus
	| Field  | Value |
	| Adults | 5     |
	| Rooms  | 3     |
	Then I click button Search on main page
	And I see that Search result contains offers with "3" rooms

Scenario: Check that Search accommodation option Buisness traveling works properly
	When I open browser
	And I navigate to url "https://booking.com"
	When I input data "Issaquah, WA, United States" in Destination Search field on main page
	And I click on first autocomplete option that contains "Issaquah"
	And I set the calendar for the current date plus one year
	When I click Yes for Buisness traveling on main page
	When I set following parameters in dropdown menus
	| Field  | Value |
	| Adults | 3     |
	Then I click button Search on main page
	And I see that Search result is for "Business Travelers" and "3 adults"

Scenario: Assurance that each checkbox filter of Accommodation search works properly
	When I open browser
	And I navigate to url "https://booking.com"
	And I set my currency as "U.S. Dollar"
	When I input data "New York, New York State, USA" in Destination Search field on main page
	And I click on first autocomplete option that contains "New York"
	And I set the calendar for the current date plus one year
	Then I click button Search on main page
	And I wait browser page to load
	And I set following parameters in filter checkboxes on search result page
	| Field                     | Scenario Key | Value |
	| US$120 - US$180 per night | amount       | On    |
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field                     | Value |
	| US$120 - US$180 per night | Off   |
	And I set following parameters in filter checkboxes on search result page
	| Field                     | Scenario Key | Value |
	| US$180 - US$240 per night | amount       | On    |
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field                     | Value |
	| US$180 - US$240 per night | Off   |
	And I set following parameters in filter checkboxes on search result page
	| Field              | Scenario Key | Value |
	| US$240 + per night | amount       | On    |
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field              | Value |
	| US$240 + per night | Off   |
	And I set following parameters in filter checkboxes on search result page
	| Field         | Scenario Key | Value |
	| Wonderful: 9+ | amount       | On    |
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field         | Value |
	| Wonderful: 9+ | Off   |
	And I set following parameters in filter checkboxes on search result page
	| Field         | Scenario Key | Value |
	| Very Good: 8+ | amount       | On    |
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field         | Value |
	| Very Good: 8+ | Off   |
	And I set following parameters in filter checkboxes on search result page
	| Field    | Scenario Key | Value |
	| Good: 7+ | amount       | On    |
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field    | Value |
	| Good: 7+ | Off   |
	And I set following parameters in filter checkboxes on search result page
	| Field        | Scenario Key | Value |
	| Pleasant: 6+ | amount       | On    |
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field        | Value |
	| Pleasant: 6+ | Off   |
	And I set following parameters in filter checkboxes on search result page
	| Field  | Scenario Key | Value |
	| 1 star | amount       | On    |
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field  | Value |
	| 1 star | Off   |
	And I set following parameters in filter checkboxes on search result page
	| Field   | Scenario Key | Value |
	| 2 stars | amount       | On    |
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field   | Value |
	| 2 stars | Off   |
	And I set following parameters in filter checkboxes on search result page
	| Field   | Scenario Key | Value |
	| 3 stars | amount       | On    |
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field   | Value |
	| 3 stars | Off   |
	And I set following parameters in filter checkboxes on search result page
	| Field   | Scenario Key | Value |
	| 4 stars | amount       | On    |
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field   | Value |
	| 4 stars | Off   |
	And I set following parameters in filter checkboxes on search result page
	| Field   | Scenario Key | Value |
	| 5 stars | amount       | On    |
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field   | Value |
	| 5 stars | Off   |
	And I set following parameters in filter checkboxes on search result page
	| Field   | Scenario Key | Value |
	| Unrated | amount       | On    |
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field   | Value |
	| Unrated | Off   |
	And I set following parameters in filter checkboxes on search result page
	| Field                | Scenario Key | Value |
	| Front Desk Open 24/7 | amount       | On    |
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field                | Value |
	| Front Desk Open 24/7 | Off   |
	And I set following parameters in filter checkboxes on search result page
	| Field  | Scenario Key | Value |
	| Hotels | amount       | On    |
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field  | Value |
	| Hotels | Off   |
	And I set following parameters in filter checkboxes on search result page
	| Field          | Scenario Key | Value |
	| Vacation Homes | amount       | On    |
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field          | Value |
	| Vacation Homes | Off   |
	And I set following parameters in filter checkboxes on search result page
	| Field   | Scenario Key | Value |
	| Hostels | amount       | On    |
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field   | Value |
	| Hostels | Off   |
	And I set following parameters in filter checkboxes on search result page
	| Field          | Scenario Key | Value |
	| Fitness Center | amount       | On    |
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field          | Value |
	| Fitness Center | Off   |
	And I set following parameters in filter checkboxes on search result page
	| Field   | Scenario Key | Value |
	| Massage | amount       | On    |
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field   | Value |
	| Massage | Off   |
	And I set following parameters in filter checkboxes on search result page
	| Field   | Scenario Key | Value |
	| Fitness | amount       | On    |
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field   | Value |
	| Fitness | Off   |
	And I set following parameters in filter checkboxes on search result page
	| Field             | Scenario Key | Value |
	| Great Value Today | amount       | On    |
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field             | Value |
	| Great Value Today | Off   |
	And I set following parameters in filter checkboxes on search result page
	| Field              | Scenario Key | Value |
	| Kitchen facilities | amount       | On    |
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field              | Value |
	| Kitchen facilities | Off   |
	And I set following parameters in filter checkboxes on search result page
	| Field                 | Scenario Key | Value |
	| Empire State Building | amount       | On    |
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field                 | Value |
	| Empire State Building | Off   |
	And I set following parameters in filter checkboxes on search result page
	| Field        | Scenario Key | Value |
	| Times Square | amount       | On    |
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field        | Value |
	| Times Square | Off   |
	And I set following parameters in filter checkboxes on search result page
	| Field           | Scenario Key | Value |
	| Brooklyn Bridge | amount       | On    |
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field           | Value |
	| Brooklyn Bridge | Off   |
	And I set following parameters in filter checkboxes on search result page
	| Field        | Scenario Key | Value |
	| Central Park | amount       | On    |
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field        | Value |
	| Central Park | Off   |
	And I set following parameters in filter checkboxes on search result page
	| Field           | Scenario Key | Value |
	| Top of the Rock | amount       | On    |
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field           | Value |
	| Top of the Rock | Off   |
	And I set following parameters in filter checkboxes on search result page
	| Field        | Scenario Key | Value |
	| Family Rooms | amount       | On    |
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field        | Value |
	| Family Rooms | Off   |
	And I set following parameters in filter checkboxes on search result page
	| Field        | Scenario Key | Value |
	| Pet Friendly | amount       | On    |
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field        | Value |
	| Pet Friendly | Off   |
	And I set following parameters in filter checkboxes on search result page
	| Field                          | Scenario Key | Value |
	| Facilities for Disabled Guests | amount       | On    |
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field                          | Value |
	| Facilities for Disabled Guests | Off   |
	And I set following parameters in filter checkboxes on search result page
	| Field     | Scenario Key | Value |
	| Free WiFi | amount       | On    |
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field     | Value |
	| Free WiFi | Off   |
	And I set following parameters in filter checkboxes on search result page
	| Field   | Scenario Key | Value |
	| Parking | amount       | On    |
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field   | Value |
	| Parking | Off   |
	And I set following parameters in filter checkboxes on search result page
	| Field | Scenario Key | Value |
	| Spa   | amount       | On    |
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field | Value |
	| Spa   | Off   |
	And I set following parameters in filter checkboxes on search result page
	| Field           | Scenario Key | Value |
	| Airport Shuttle | amount       | On    |
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field           | Value |
	| Airport Shuttle | Off   |
	And I set following parameters in filter checkboxes on search result page
	| Field         | Scenario Key | Value |
	| Swimming Pool | amount       | On    |
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field         | Value |
	| Swimming Pool | Off   |
	And I set following parameters in filter checkboxes on search result page
	| Field            | Scenario Key | Value |
	| Air conditioning | amount       | On    |
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field            | Value |
	| Air conditioning | Off   |
	And I set following parameters in filter checkboxes on search result page
	| Field   | Scenario Key | Value |
	| Bathtub | amount       | On    |
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field   | Value |
	| Bathtub | Off   |
	And I set following parameters in filter checkboxes on search result page
	| Field          | Scenario Key | Value |
	| Coffee machine | amount       | On    |
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field          | Value |
	| Coffee machine | Off   |
	And I set following parameters in filter checkboxes on search result page
	| Field          | Scenario Key | Value |
	| Flat-screen TV | amount       | On    |
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field          | Value |
	| Flat-screen TV | Off   |

Scenario: Assurance that Accommodation search filters are working properly together
	When I open browser
	And I navigate to url "https://booking.com"
	And I set my currency as "U.S. Dollar"
	When I input data "New York, New York State, USA" in Destination Search field on main page
	And I click on first autocomplete option that contains "New York"
	And I set the calendar for the current date plus one year
	Then I click button Search on main page
	And I wait browser page to load
	And I see that I am on Search Result page and see that offered accommodation is in "New York"
	And I set following parameters in filter checkboxes on search result page
	| Field                          | Value |
	| US$120 - US$180 per night      | On    |
	| 3 stars                        | On    |
	| Good: 7+                       | On    |
	| Hotels                         | On    |
	| Only show available properties | On    |
	| Free WiFi                      | On    |
	Then I see that search result contains offers with selected options only
	| Field     | Value   |
	| Price     | 120 180 |
	| Stars     | 3       |
	| Rating    | 7       |
	| Free Wifi | WiFi    |