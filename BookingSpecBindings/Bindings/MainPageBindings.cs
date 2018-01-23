using System;
using System.Linq;
using System.Text.RegularExpressions;
using BookingSpecBindings.TestBase;
using BookingSpecBindings.TestBase.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace BookingSpecBindings.Bindings
{
	[Binding]
	class MainPageBindings
	{
		MainPage page = new MainPage();

		[Then(@"I wait while ""(.*)"" popup is working")]
		public void ThenIWaitWhilePopupIsWorking(string popup)
		{
			switch (popup)
			{
				case "Sign In":
					page.waitLoading(".user_access_signin_menu .form-loading");
					break;
				case "Registration":
					page.waitLoading(".user_access_signup_menu .form-loading");
					break;
				case "Forgot Your Password":
					page.waitLoading(".user_access_menu .form-loading");
					break;
				default:
					throw new NotImplementedException();
			}
		}
		[Then(@"I make sure that check-out date is later for one day than check-in")]
		public void ThenIMakeSureThatCheck_OutDateIsLaterForOneDayThanCheck_In()
		{
			page.checkWorkOfCalendarAutocompletion();
		}
		[When(@"I click Sign In button on Ribbon menu")]
		public void WhenIClickSignInButton()
		{
			page.clickSignIn();
		}
		[Then(@"I click Sign In button on Ribbon menu")]
		public void ClickSignInButton()
		{
			page.clickSignIn();
		}
		[Then(@"I click Sign In button")]
		public void ThenIClickSignInButton()
		{
			page.clickSignIn();
		}
		[When(@"I click Register button on Ribbon menu")]
		public void WhenIClickRegisterButtonOnRibbonMenu()
		{
			page.clickRegister();
		}
		[Then(@"I see that I am Signed In")]
		public void ThenISeeThatIAmSignedIn()
		{
			Assert.AreEqual(page.SignInCheck(), "Your Account");
		}
		[Then(@"I see that I am not Signed In")]
		public bool ThenISeeThatIAmNotSignedInAndNotRegistered()
		{
			return page.SignInbutton.Displayed;
		}
		[When(@"I input data ""(.*)"" in Destination Search field on main page")]
		public void WhenIInputDataInDestinationSearchFieldOnMainPage(string destination)
		{
			page.searchField.SendKeys(destination);
		}
		[When(@"I click on first autocomplete option that contains ""(.*)""")]
		public void WhenIClickOnFirstAutocompleteOptionThatContains(string desiredDestination)
		{
			page.AutocompleteSelector(desiredDestination);
		}
		[When(@"I set following parameters in calendar on main page")]
		public void WhenISetFollowingParametersInCalendarOnMainPage(Table table)
		{
			foreach (var row in table.Rows)
			{
				string key = row["Field"];
				switch (key)
				{
					case "Check In":
						page.checkinMonth.SendKeys(row["Month"]);
						page.checkinMonthDay.SendKeys(row["MonthDay"]);
						page.checkinYear.SendKeys(row["Year"]);
						break;
					case "Check Out":
						page.checkOutMonth.SendKeys(row["Month"]);
						page.checkOutMonthDay.SendKeys(row["MonthDay"]);
						page.checkOutYear.SendKeys(row["Year"]);
						break;
					default:
						throw new NotImplementedException();
				}
			}
		}
		[Then(@"I click button Search on main page")]
		public void ThenIClickButtonSearchOnMainPage()
		{
			page.clickSearch();
			Browser.WaitReadyState();
		}
		[When(@"I set my currency as ""(.*)""")]
		public void WhenISetMyCurrencyAs(string currency)
		{
			page.CurrencyMenuClick();
			page.waitCurrency();
			page.selectCurrency = new HtmlElement(By.XPath("//span[contains (text(), '" + currency + "')]"));
			page.selectCurrency.Click();
		}
		[Then(@"I see date error message ""(.*)"" on main page")]
		public void ThenISeeDateErrorMessageOnMainPage(string error)
		{
			Assert.AreEqual(page.GetDateError(error), error);
		}

		[Then(@"I see destination error message ""(.*)"" on main page")]
		public void ThenISeeDestinationErrorMessageOnMainPage(string error)
		{
			Assert.AreEqual(page.GetDestinationError(), error);
		}
		[When(@"I click Yes for Buisness traveling on main page")]
		public void WhenIClickYesForBuisnessTravelingOnMainPage()
		{
			page.BuisnessButton();
		}
		[When(@"I click ""(.*)"" and choose ""(.*)"" in dropdown menu on main page")]
		public void WhenIClickAndChooseInDropdownMenuOnMainPage(string key, int count)
		{
			switch (key)
			{
				case "Adults":
					page.dropdownAdults.Click();
					page.DropdownAmount(key,count);
					page.dropdownAdults.Click();
					break;
				case "Children":
					page.dropdownChildren.Click();
					page.DropdownAmount(key, count);
					page.dropdownChildren.Click();
					break;
				case "Rooms":
					page.dropdownRooms.Click();
					page.DropdownAmount(key, count);
					page.dropdownRooms.Click();
					break;
				default:
					throw new NotImplementedException();
			}
		}
		[When(@"I set the calendar for the current date plus one year")]
		public void WhenISetTheCalendarForTheCurrentDatePlusOneYear()
		{
			page.setCalendarDate();
		}
	}
}
