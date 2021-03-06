﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using BookingSpecBindings.TestBase;
using BookingSpecBindings.TestBase.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace BookingSpecBindings.Bindings
{
	[Binding]
	class AccomodationSearchResultBindings
	{
		AccommodationSearchResult searchPage = new AccommodationSearchResult();
		[Then(@"I see that I am on Search Result page and see that offered accommodation is in ""(.*)""")]
		public void ThenISeeThatIAmOnSearchResultPageAndSeeThatOfferedAccommodationIsIn(string destination)
		{
			searchPage.DestinationContainer = new HtmlElement(By.XPath("//a[contains (text(), '" + destination + "')]"));
			Assert.That(searchPage.DestinationContainer.Text.Contains(destination));
		}
		[Then(@"I see that Search result is for ""(.*)"" and ""(.*)""")]
		public void ThenISeeThatSearchResultIsForAnd(string category, string offer)
		{
			searchPage.CategoryCheck(category);
			searchPage.OfferedAmount = new HtmlElement(By.XPath("//h4[contains (text(), '" + offer + "')]"));
			Assert.That(searchPage.OfferedAmount.Text.Contains(offer));
		}
		[Then(@"I see that Search result contains offers with ""(.*)"" rooms")]
		public void ThenISeeThatSearchResultContainsOffersWithRooms(string count)
		{
			searchPage.RoomChecker(count);
		}
		[Then(@"I set following parameters in filter checkboxes on search result page")]
		public void ThenISetFollowingParametersInFilterCheckboxesOnSearchResultPage(Table table)
		{
			foreach (var row in table.Rows)
			{
				searchPage.ClickShowMore();
				string key = row["Field"];
				Checkbox checkbox;
				switch (key)
				{
					case "Only show available properties":
						Browser.Driver.FindElement(By.CssSelector("a[data-id='oos-1']")).Click();
						break;
					case "US$62 - US$120 per night":
					case "US$61 - US$120 per night":
					case "US$120 - US$180 per night":
					case "US$180 - US$240 per night":
					case "US$180 - US$250 per night":
					case "US$240 + per night":
					case "US$250 + per night":
					case "Wonderful: 9+":
					case "Very Good: 8+":
					case "Good: 7+":
					case "Pleasant: 6+":
					case "No rating":
					case "1 star":
					case "2 stars":
					case "3 stars":
					case "4 stars":
					case "5 stars":
					case "Unrated":
					case "Front Desk Open 24/7":
					case "Hotels":
					case "Apartments":
					case "Vacation Homes":
					case "Hostels":
					case "Guesthouses":
					case "Homestays":
					case "Family Friendly Properties":
					case "Fitness Center":
					case "Fitness":
					case "Massage":
					case "Library":
					case "Bicycle Rental":
					case "Great Value Today":
					case "Free cancellation":
					case "Book without credit card":
					case "No prepayment":
					case "Breakfast included":
					case "Great breakfast available":
					case "Kitchen facilities":
					case "Empire State Building":
					case "Times Square":
					case "Brooklyn Bridge":
					case "Central Park":
					case "Top of the Rock":
					case "Twin beds":
					case "Double bed":
					case "Smoking allowed":
					case "No smoking allowed":
					case "Pet Friendly":
					case "Facilities for Disabled Guests":
					case "Free WiFi":
					case "Restaurant":
					case "Parking":
					case "Free Parking":
					case "Room Service":
					case "Family Rooms":
					case "Spa":
					case "Airport Shuttle":
					case "Swimming Pool":
					case "Air conditioning":
					case "Bathtub":
					case "Coffee machine":
					case "Electric kettle":
					case "Flat-screen TV":
						checkbox = new Checkbox(key);
						if (table.Rows.Any(r => r.ContainsKey("Scenario Key")))
						{
							ScenarioContext.Current.Set(checkbox.getAmountOffers(), row["Scenario Key"]);
						}
						checkbox.CheckboxSelector(row["Value"]);
						searchPage.WaitFilter();
						break;
					default:
						throw new NotImplementedException();
				}
			}
		}
		[Then(@"I see that displayed ""(.*)"" of options equal to amount displayed on filter")]
		public void ThenISeeThatDisplayedOfOptionsEqualToAmountDisplayedOnFilter(string key)
		{
			Assert.AreEqual(searchPage.FilteredAmount(), ScenarioContext.Current.Get<int>(key));
		}
		[Then(@"I see that search result contains offers with selected options only")]
		public void ThenISeeThatSearchResultContainsOffersWithSelectedOptionsOnly(Table table)
		{
			ExpectedSearchItem expected = new ExpectedSearchItem(table);
			List<ActualSearchItem> seResults = GetActualSearches();
			foreach (var se in seResults)
			{
				if(expected.Comparator(se) == false)
				Assert.Fail();
			}
		}
		public List<ActualSearchItem> GetActualSearches() 
		{ 
			string PropertyBlockLocator = ".sr_property_block";
			IReadOnlyCollection<IWebElement> seElements = Browser.Driver.FindElements(By.CssSelector(PropertyBlockLocator));
			List<ActualSearchItem> seResults = new List<ActualSearchItem>();
			foreach (var se in seElements)
			{
				seResults.Add(new ActualSearchItem(se));
			}
			return seResults;
		}
	}
}
