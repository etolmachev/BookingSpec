Feature: AccommodationSearch

Scenario: Input valid data in order to Search accommodation on main page
	When I open browser
	And I navigate to url "https://booking.com"
	When I input data "New York, New York State, USA" in Destination Search field on main page
	And I click on first autocomplete option that contains "New York"
	And I set the calendar for the current date plus one year
	Then I click button Search on main page
	And I see that I am on Search Result page and see that offered accommodation is in "New York"

Scenario Template: Input invalid data in accommodation search calendar on main page
	When I open browser
	And I navigate to url "https://booking.com"
	When I set following parameters in calendar on main page
		| Field     | Month      | MonthDay      | Year      |
		| Check In  | <MonthIn>  | <MonthDayIn>  | <YearIn>  |
		| Check Out | <MonthOut> | <MonthDayOut> | <YearOut> |
	When I input data "Issaquah, WA, United States" in Destination Search field on main page
	And I click on first autocomplete option that contains "Issaquah"
	Then I click button Search on main page
	And I see date error message "<Message>" on main page
	
	Scenarios: 
		| MonthIn | MonthDayIn | YearIn | MonthOut | MonthDayOut | YearOut | Message                                              |
		| 03      | 15         | 2018   | 03       | 15          | 2020    | Reservations longer than 30 nights are not possible. |
		| 03      | 15         | 2005   | 03       | 15          | 2005    | Select a check-in date that's in the future.         |

	Scenario: Input invalid data in Destination Search accommodation field on main page
	When I open browser
	And I navigate to url "https://booking.com"
	When I input data "sfsadfasdf" in Destination Search field on main page
	And I set the calendar for the current date plus one year
	Then I click button Search on main page
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
	| 03      | 25         | 2018   | 03       | 15          | 2018    |
	| 03      | 15         | 2018   | 03       | 13          | 2018    |

Scenario: Check that Search accommodation Adults dropdown menu works properly
	When I open browser
	And I navigate to url "https://booking.com"
	When I input data "Issaquah, WA, United States" in Destination Search field on main page
	And I click on first autocomplete option that contains "Issaquah"
	And I set the calendar for the current date plus one year
	When I click "Adults" and choose "5" in dropdown menu on main page
	Then I click button Search on main page
	And I see that Search result is for "Groups" and "5 adults"

 Scenario: Check that Search accommodation Children dropdown menu works properly
	When I open browser
	And I navigate to url "https://booking.com"
	When I input data "Issaquah, WA, United States" in Destination Search field on main page
	And I click on first autocomplete option that contains "Issaquah"
	And I set the calendar for the current date plus one year
	When I click "Children" and choose "1" in dropdown menu on main page
	Then I click button Search on main page
	And I see that Search result is for "Families" and "1 child"

 Scenario: Check that Search accommodation Rooms dropdown menu works properly
	When I open browser
	And I navigate to url "https://booking.com"
	When I input data "Issaquah, WA, United States" in Destination Search field on main page
	And I click on first autocomplete option that contains "Issaquah"
	And I set the calendar for the current date plus one year
	When I click "Adults" and choose "5" in dropdown menu on main page
	And I click "Rooms" and choose "3" in dropdown menu on main page
	Then I click button Search on main page
	And I see that Search result contains offers with "3" rooms

Scenario: Check that Search accommodation option Buisness traveling works properly
	When I open browser
	And I navigate to url "https://booking.com"
	When I input data "Issaquah, WA, United States" in Destination Search field on main page
	And I click on first autocomplete option that contains "Issaquah"
	And I set the calendar for the current date plus one year
	When I click Yes for Buisness traveling on main page
	And I click "Adults" and choose "3" in dropdown menu on main page
	Then I click button Search on main page
	And I see that Search result is for "Business Travelers" and "3 adults"

Scenario:1Assurance that each checkbox filter of Accommodation search works properly
	When I open browser
	And I navigate to url "https://booking.com"
	And I set the calendar for the current date plus one year
	When I input data "New York, New York State, USA" in Destination Search field on main page
	And I click on first autocomplete option that contains "New York"
	Then I click button Search on main page
	And I wait browser page to load
	And I click all buttons Show More to see every available filter
	And I set following parameters in filter checkboxes on search result page
	| Field          | Scenario Key | Value |
	| Vacation Homes | amount       | On    |
	And I wait while search page loading
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field          | Value |
	| Vacation Homes | Off   |
	And I wait while search page loading
	And I set following parameters in filter checkboxes on search result page
	| Field         | Scenario Key | Value |
	| Wonderful: 9+ | amount       | On    |
	And I wait while search page loading
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field         | Value |
	| Wonderful: 9+ | Off   |
	And I wait while search page loading

Scenario: Assurance that each checkbox filter of Accommodation search works properly
	When I open browser
	And I navigate to url "https://booking.com"
	And I set my currency as "U.S. Dollar"
	When I input data "New York, New York State, USA" in Destination Search field on main page
	And I click on first autocomplete option that contains "New York"
	And I set the calendar for the current date plus one year
	Then I click button Search on main page
	And I wait browser page to load
	And I click all buttons Show More to see every available filter
	And I set following parameters in filter checkboxes on search result page
	| Field                    | Scenario Key | Value |
	| US$61 - US$120 per night | amount       | On    |
	And I wait while search page loading
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field                    | Value |
	| US$61 - US$120 per night | Off   |
	And I wait while search page loading
	And I set following parameters in filter checkboxes on search result page
	| Field                     | Scenario Key | Value |
	| US$120 - US$180 per night | amount       | On    |
	And I wait while search page loading
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field                     | Value |
	| US$120 - US$180 per night | Off   |
	And I wait while search page loading
	And I set following parameters in filter checkboxes on search result page
	| Field                     | Scenario Key | Value |
	| US$180 - US$240 per night | amount       | On    |
	And I wait while search page loading
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field                     | Value |
	| US$180 - US$240 per night | Off   |
	And I wait while search page loading
	And I set following parameters in filter checkboxes on search result page
	| Field              | Scenario Key | Value |
	| US$240 + per night | amount       | On    |
	And I wait while search page loading
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field              | Value |
	| US$240 + per night | Off   |
	And I wait while search page loading
	And I set following parameters in filter checkboxes on search result page
	| Field         | Scenario Key | Value |
	| Wonderful: 9+ | amount       | On    |
	And I wait while search page loading
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field         | Value |
	| Wonderful: 9+ | Off   |
	And I wait while search page loading
	And I set following parameters in filter checkboxes on search result page
	| Field         | Scenario Key | Value |
	| Very Good: 8+ | amount       | On    |
	And I wait while search page loading
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field         | Value |
	| Very Good: 8+ | Off   |
	And I wait while search page loading
	And I set following parameters in filter checkboxes on search result page
	| Field    | Scenario Key | Value |
	| Good: 7+ | amount       | On    |
	And I wait while search page loading
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field    | Value |
	| Good: 7+ | Off   |
	And I wait while search page loading
	And I set following parameters in filter checkboxes on search result page
	| Field        | Scenario Key | Value |
	| Pleasant: 6+ | amount       | On    |
	And I wait while search page loading
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field        | Value |
	| Pleasant: 6+ | Off   |
	And I wait while search page loading
	And I set following parameters in filter checkboxes on search result page
	| Field  | Scenario Key | Value |
	| 1 star | amount       | On    |
	And I wait while search page loading
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field  | Value |
	| 1 star | Off   |
	And I wait while search page loading
	And I set following parameters in filter checkboxes on search result page
	| Field   | Scenario Key | Value |
	| 2 stars | amount       | On    |
	And I wait while search page loading
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field   | Value |
	| 2 stars | Off   |
	And I wait while search page loading
	And I set following parameters in filter checkboxes on search result page
	| Field   | Scenario Key | Value |
	| 3 stars | amount       | On    |
	And I wait while search page loading
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field   | Value |
	| 3 stars | Off   |
	And I wait while search page loading
	And I set following parameters in filter checkboxes on search result page
	| Field   | Scenario Key | Value |
	| 4 stars | amount       | On    |
	And I wait while search page loading
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field   | Value |
	| 4 stars | Off   |
	And I wait while search page loading
	And I set following parameters in filter checkboxes on search result page
	| Field   | Scenario Key | Value |
	| 5 stars | amount       | On    |
	And I wait while search page loading
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field   | Value |
	| 5 stars | Off   |
	And I wait while search page loading
	And I set following parameters in filter checkboxes on search result page
	| Field   | Scenario Key | Value |
	| Unrated | amount       | On    |
	And I wait while search page loading
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field   | Value |
	| Unrated | Off   |
	And I wait while search page loading
	And I set following parameters in filter checkboxes on search result page
	| Field                | Scenario Key | Value |
	| Front Desk Open 24/7 | amount       | On    |
	And I wait while search page loading
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field                | Value |
	| Front Desk Open 24/7 | Off   |
	And I wait while search page loading
	And I set following parameters in filter checkboxes on search result page
	| Field  | Scenario Key | Value |
	| Hotels | amount       | On    |
	And I wait while search page loading
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field  | Value |
	| Hotels | Off   |
	And I wait while search page loading
	And I set following parameters in filter checkboxes on search result page
	| Field      | Scenario Key | Value |
	| Apartments | amount       | On    |
	And I wait while search page loading
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field      | Value |
	| Apartments | Off   |
	And I wait while search page loading
	And I set following parameters in filter checkboxes on search result page
	| Field          | Scenario Key | Value |
	| Vacation Homes | amount       | On    |
	And I wait while search page loading
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field          | Value |
	| Vacation Homes | Off   |
	And I wait while search page loading
	And I set following parameters in filter checkboxes on search result page
	| Field   | Scenario Key | Value |
	| Hostels | amount       | On    |
	And I wait while search page loading
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field   | Value |
	| Hostels | Off   |
	And I wait while search page loading
	And I set following parameters in filter checkboxes on search result page
	| Field              | Scenario Key | Value |
	| Bed and Breakfasts | amount       | On    |
	And I wait while search page loading
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field              | Value |
	| Bed and Breakfasts | Off   |
	And I wait while search page loading
	And I set following parameters in filter checkboxes on search result page
	| Field       | Scenario Key | Value |
	| Guesthouses | amount       | On    |
	And I wait while search page loading
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field       | Value |
	| Guesthouses | Off   |
	And I wait while search page loading
	And I set following parameters in filter checkboxes on search result page
	| Field     | Scenario Key | Value |
	| Homestays | amount       | On    |
	And I wait while search page loading
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field     | Value |
	| Homestays | Off   |
	And I wait while search page loading
	And I set following parameters in filter checkboxes on search result page
	| Field                      | Scenario Key | Value |
	| Family-Friendly Properties | amount       | On    |
	And I wait while search page loading
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field                      | Value |
	| Family-Friendly Properties | Off   |
	And I wait while search page loading
	And I set following parameters in filter checkboxes on search result page
	| Field          | Scenario Key | Value |
	| Fitness Center | amount       | On    |
	And I wait while search page loading
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field          | Value |
	| Fitness Center | Off   |
	And I wait while search page loading
	And I set following parameters in filter checkboxes on search result page
	| Field   | Scenario Key | Value |
	| Massage | amount       | On    |
	And I wait while search page loading
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field   | Value |
	| Massage | Off   |
	And I wait while search page loading
	And I set following parameters in filter checkboxes on search result page
	| Field                              | Scenario Key | Value |
	| Bicycle Rental (additional charge) | amount       | On    |
	And I wait while search page loading
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field                              | Value |
	| Bicycle Rental (additional charge) | Off   |
	And I wait while search page loading
	And I set following parameters in filter checkboxes on search result page
	| Field   | Scenario Key | Value |
	| Library | amount       | On    |
	And I wait while search page loading
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field   | Value |
	| Library | Off   |
	And I wait while search page loading
	And I set following parameters in filter checkboxes on search result page
	| Field   | Scenario Key | Value |
	| Fitness | amount       | On    |
	And I wait while search page loading
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field   | Value |
	| Fitness | Off   |
	And I wait while search page loading
	And I set following parameters in filter checkboxes on search result page
	| Field             | Scenario Key | Value |
	| Great Value Today | amount       | On    |
	And I wait while search page loading
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field             | Value |
	| Great Value Today | Off   |
	And I wait while search page loading
	And I set following parameters in filter checkboxes on search result page
	| Field             | Scenario Key | Value |
	| Free cancellation | amount       | On    |
	And I wait while search page loading
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field             | Value |
	| Free cancellation | Off   |
	And I wait while search page loading
	And I set following parameters in filter checkboxes on search result page
	| Field                    | Scenario Key | Value |
	| Book without credit card | amount       | On    |
	And I wait while search page loading
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field                    | Value |
	| Book without credit card | Off   |
	And I wait while search page loading
	And I set following parameters in filter checkboxes on search result page
	| Field         | Scenario Key | Value |
	| No prepayment | amount       | On    |
	And I wait while search page loading
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field         | Value |
	| No prepayment | Off   |
	And I wait while search page loading
	And I set following parameters in filter checkboxes on search result page
	| Field              | Scenario Key | Value |
	| Breakfast included | amount       | On    |
	And I wait while search page loading
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field              | Value |
	| Breakfast included | Off   |
	And I wait while search page loading
	And I set following parameters in filter checkboxes on search result page
	| Field                     | Scenario Key | Value |
	| Great breakfast available | amount       | On    |
	And I wait while search page loading
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field                     | Value |
	| Great breakfast available | Off   |
	And I wait while search page loading
	And I set following parameters in filter checkboxes on search result page
	| Field              | Scenario Key | Value |
	| Kitchen facilities | amount       | On    |
	And I wait while search page loading
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field              | Value |
	| Kitchen facilities | Off   |
	And I wait while search page loading
	And I set following parameters in filter checkboxes on search result page
	| Field                 | Scenario Key | Value |
	| Empire State Building | amount       | On    |
	And I wait while search page loading
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field                 | Value |
	| Empire State Building | Off   |
	And I wait while search page loading
	And I set following parameters in filter checkboxes on search result page
	| Field        | Scenario Key | Value |
	| Times Square | amount       | On    |
	And I wait while search page loading
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field        | Value |
	| Times Square | Off   |
	And I wait while search page loading
	And I set following parameters in filter checkboxes on search result page
	| Field           | Scenario Key | Value |
	| Brooklyn Bridge | amount       | On    |
	And I wait while search page loading
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field           | Value |
	| Brooklyn Bridge | Off   |
	And I wait while search page loading
	And I set following parameters in filter checkboxes on search result page
	| Field        | Scenario Key | Value |
	| Central Park | amount       | On    |
	And I wait while search page loading
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field        | Value |
	| Central Park | Off   |
	And I wait while search page loading
	And I set following parameters in filter checkboxes on search result page
	| Field           | Scenario Key | Value |
	| Top of the Rock | amount       | On    |
	And I wait while search page loading
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field           | Value |
	| Top of the Rock | Off   |
	And I wait while search page loading
	And I set following parameters in filter checkboxes on search result page
	| Field     | Scenario Key | Value |
	| Twin beds | amount       | On    |
	And I wait while search page loading
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field     | Value |
	| Twin beds | Off   |
	And I wait while search page loading
	And I set following parameters in filter checkboxes on search result page
	| Field      | Scenario Key | Value |
	| Double bed | amount       | On    |
	And I wait while search page loading
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field      | Value |
	| Double bed | Off   |
	And I wait while search page loading
	And I set following parameters in filter checkboxes on search result page
	| Field           | Scenario Key | Value |
	| Smoking allowed | amount       | On    |
	And I wait while search page loading
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field           | Value |
	| Smoking allowed | Off   |
	And I wait while search page loading
	And I set following parameters in filter checkboxes on search result page
	| Field              | Scenario Key | Value |
	| No smoking allowed | amount       | On    |
	And I wait while search page loading
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field              | Value |
	| No smoking allowed | Off   |
	And I wait while search page loading
	And I set following parameters in filter checkboxes on search result page
	| Field        | Scenario Key | Value |
	| Family Rooms | amount       | On    |
	And I wait while search page loading
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field        | Value |
	| Family Rooms | Off   |
	And I wait while search page loading
	And I set following parameters in filter checkboxes on search result page
	| Field        | Scenario Key | Value |
	| Pet Friendly | amount       | On    |
	And I wait while search page loading
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field        | Value |
	| Pet Friendly | Off   |
	And I wait while search page loading
	And I set following parameters in filter checkboxes on search result page
	| Field                          | Scenario Key | Value |
	| Facilities for Disabled Guests | amount       | On    |
	And I wait while search page loading
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field                          | Value |
	| Facilities for Disabled Guests | Off   |
	And I wait while search page loading
	And I set following parameters in filter checkboxes on search result page
	| Field     | Scenario Key | Value |
	| Free WiFi | amount       | On    |
	And I wait while search page loading
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field     | Value |
	| Free WiFi | Off   |
	And I wait while search page loading
	And I set following parameters in filter checkboxes on search result page
	| Field      | Scenario Key | Value |
	| Restaurant | amount       | On    |
	And I wait while search page loading
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field      | Value |
	| Restaurant | Off   |
	And I wait while search page loading
	And I set following parameters in filter checkboxes on search result page
	| Field   | Scenario Key | Value |
	| Parking | amount       | On    |
	And I wait while search page loading
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field   | Value |
	| Parking | Off   |
	And I wait while search page loading
	And I set following parameters in filter checkboxes on search result page
	| Field        | Scenario Key | Value |
	| Free Parking | amount       | On    |
	And I wait while search page loading
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field        | Value |
	| Free Parking | Off   |
	And I wait while search page loading
	And I set following parameters in filter checkboxes on search result page
	| Field        | Scenario Key | Value |
	| Room Service | amount       | On    |
	And I wait while search page loading
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field        | Value |
	| Room Service | Off   |
	And I wait while search page loading
	And I set following parameters in filter checkboxes on search result page
	| Field | Scenario Key | Value |
	| Spa   | amount       | On    |
	And I wait while search page loading
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field | Value |
	| Spa   | Off   |
	And I wait while search page loading
	And I set following parameters in filter checkboxes on search result page
	| Field           | Scenario Key | Value |
	| Airport Shuttle | amount       | On    |
	And I wait while search page loading
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field           | Value |
	| Airport Shuttle | Off   |
	And I wait while search page loading
	And I set following parameters in filter checkboxes on search result page
	| Field         | Scenario Key | Value |
	| Swimming Pool | amount       | On    |
	And I wait while search page loading
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field         | Value |
	| Swimming Pool | Off   |
	And I wait while search page loading
	And I set following parameters in filter checkboxes on search result page
	| Field            | Scenario Key | Value |
	| Air conditioning | amount       | On    |
	And I wait while search page loading
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field            | Value |
	| Air conditioning | Off   |
	And I wait while search page loading
	And I set following parameters in filter checkboxes on search result page
	| Field   | Scenario Key | Value |
	| Bathtub | amount       | On    |
	And I wait while search page loading
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field   | Value |
	| Bathtub | Off   |
	And I wait while search page loading
	And I set following parameters in filter checkboxes on search result page
	| Field          | Scenario Key | Value |
	| Coffee machine | amount       | On    |
	And I wait while search page loading
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field          | Value |
	| Coffee machine | Off   |
	And I wait while search page loading
	And I set following parameters in filter checkboxes on search result page
	| Field           | Scenario Key | Value |
	| Electric kettle | amount       | On    |
	And I wait while search page loading
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field           | Value |
	| Electric kettle | Off   |
	And I wait while search page loading
	And I set following parameters in filter checkboxes on search result page
	| Field          | Scenario Key | Value |
	| Flat-screen TV | amount       | On    |
	And I wait while search page loading
	And I see that displayed "amount" of options equal to amount displayed on filter
	And I set following parameters in filter checkboxes on search result page
	| Field          | Value |
	| Flat-screen TV | Off   |
	And I wait while search page loading

@ignore
# Search result check implementation is not ready yet
Scenario: Assurance that Accommodation search filters are working properly together
	When I open browser
	And I navigate to url "https://booking.com"
	And I set my currency as "U.S. Dollar"
	When I input data "Issaquah, WA, United States" in Destination Search field on main page
	And I click on first autocomplete option that contains "Issaquah"
	And I set the calendar for the current date plus one year
	Then I click button Search on main page
	And I wait browser page to load
	And I see that I am on Search Result page and see that offered accommodation is in "Issaquah"
	And I click all buttons Show More to see every available filter
	And I set following parameters in filter checkboxes on search result page
	| Field                    | Value |
	| US$61 - US$120 per night | On    |
	And I wait while search page loading
	And I set following parameters in filter checkboxes on search result page
	| Field   | Value |
	| 3 stars | On    |
	And I wait while search page loading
	And I set following parameters in filter checkboxes on search result page
	| Field    | Value |
	| Good: 7+ | On    |
	And I wait while search page loading
	And I set following parameters in filter checkboxes on search result page
	| Field                | Value |
	| Front Desk Open 24/7 | On    |
	And I wait while search page loading
	And I set following parameters in filter checkboxes on search result page
	| Field  | Value |
	| Hotels | On    |
	And I wait while search page loading
	And I set following parameters in filter checkboxes on search result page
	| Field                          | Value |
	| Only show available properties | On    |
	And I wait while search page loading
	Then I see that search result contains only offers with selected filters "RUB 6,800 - RUB 10,000 per night" "3 stars" "Good: 7+" "Front Desk Open 24/7" "Hotels" "Only show available properties"
