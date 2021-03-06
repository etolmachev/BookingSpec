﻿using System;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;

namespace BookingSpecBindings.TestBase.Pages
{
	public class MainPage
	{
		private string signInButtonLocator = "//span[contains(text(), 'Sign in') or contains(text(), 'Log in')]";
		private string RegisterButtonLocator = "//span[contains(text(), 'Register') or contains(text(), 'Create Account') or contains(text(), 'Sign up')]";
		private string accountNameLocator = "//span[contains (text(), 'Your Account')]";
		private string searchFieldLocator = "input[type = 'search']";
		private string checkinYearLocator = "input[name='checkin_year']";
		private string checkinMonthDayLocator = "input[name='checkin_monthday']";
		private string checkinMonthLocator = "input[name='checkin_month']";
		private string checkOutYearLocator = "input[name='checkout_year']";
		private string checkOutMonthDayLocator = "input[name='checkout_monthday']";
		private string checkOutMonthLocator = "input[name='checkout_month']";
		private string searchButtonLocator = "//span[contains(text(), 'Search')]";
		private string dropdownAdultsLocator = "select[name = 'group_adults']";
		private string dropdownChildrenLocator = "select[name='group_children']";
		private string dropdownRoomsLocator = "select[name='no_rooms']";
		private string radioBuisnessButtonLocator = "input[name='sb_travel_purpose']";
		private string errorDestinationLocator = ".sb-searchbox__error";
		private string dropdownAgeLocator = "select[name='Age']";
		private string currencySelectLocator = "a[data-title='Choose your currency']";
		private string currencyLoadingLocator = "img[alt='Loading']";

		public HtmlElement SignInbutton;
		public HtmlElement RegisterButton;
		public HtmlElement AccountName;
		public HtmlElement searchField;
		public HtmlElement checkinYear;
		public HtmlElement checkinMonthDay;
		public HtmlElement checkinMonth;
		public HtmlElement checkOutYear;
		public HtmlElement checkOutMonthDay;
		public HtmlElement checkOutMonth;
		public HtmlElement searchButton;
		public HtmlElement dropdownAdults;
		public HtmlElement dropdownChildren;
		public HtmlElement dropdownRooms;
		public HtmlElement dropdownAge;
		public HtmlElement radioBuisnessButon;
		public HtmlElement Autocomplete;
		public HtmlElement errorDestination;
		public HtmlElement ChooseAmount;
		public HtmlElement errorDate;
		public HtmlElement currencySelector;
		public HtmlElement currencyLoading;
		public HtmlElement selectCurrency;
		public HtmlElement calendarDataType;

		public MainPage()
		{
			SignInbutton = new HtmlElement(By.XPath(signInButtonLocator));
			RegisterButton = new HtmlElement(By.XPath(RegisterButtonLocator));
			AccountName = new HtmlElement(By.XPath(accountNameLocator));
			checkinYear = new HtmlElement(By.CssSelector(checkinYearLocator));
			checkinMonthDay = new HtmlElement(By.CssSelector(checkinMonthDayLocator));
			checkinMonth = new HtmlElement(By.CssSelector(checkinMonthLocator));
			checkOutYear = new HtmlElement(By.CssSelector(checkOutYearLocator));
			checkOutMonthDay = new HtmlElement(By.CssSelector(checkOutMonthDayLocator));
			checkOutMonth = new HtmlElement(By.CssSelector(checkOutMonthLocator));
			searchField = new HtmlElement(By.CssSelector(searchFieldLocator));
			searchButton = new HtmlElement(By.XPath(searchButtonLocator));
			dropdownAdults = new HtmlElement(By.CssSelector(dropdownAdultsLocator));
			dropdownChildren = new HtmlElement(By.CssSelector(dropdownChildrenLocator));
			dropdownRooms = new HtmlElement(By.CssSelector(dropdownRoomsLocator));
			radioBuisnessButon = new HtmlElement(By.CssSelector(radioBuisnessButtonLocator));
			errorDestination = new HtmlElement(By.CssSelector(errorDestinationLocator));
			dropdownAge = new HtmlElement(By.CssSelector(dropdownAgeLocator));
			currencySelector = new HtmlElement(By.CssSelector(currencySelectLocator));
			currencyLoading = new HtmlElement(By.CssSelector(currencyLoadingLocator));

		}

		public void waitCurrency()
		{
			currencyLoading.WaitElementDisappears();
		}
		public void CurrencyMenuClick()
		{
			currencySelector.Click();
		}

		public void clickSignIn()
		{
			SignInbutton.Click();
		}

		public void clickRegister()
		{
			RegisterButton.Click();
		}

		public string SignInCheck()
		{
			return AccountName.Text;
		}

		public void clickSearch()
		{
			searchButton.Click();
		}

		public void AutocompleteSelector(string desiredDestination)
		{
			Autocomplete = new HtmlElement(By.XPath("//b[contains(text(), '" + desiredDestination + "')]"));
			Autocomplete.Click();
		}

		public void DropdownAmount(string key, string amount)
		{
			switch (key)
			{
				case "Adults":
					ChooseAmount = new HtmlElement(dropdownAdults.FindElement(By.CssSelector("option[value='" + amount + "']")));
					ChooseAmount.Click();
					break;
				case "Children":
					ChooseAmount = new HtmlElement(dropdownChildren.FindElement(By.CssSelector("option[value='" + amount + "']")));
					ChooseAmount.Click();
					break;
				case "Rooms":
					ChooseAmount = new HtmlElement(dropdownRooms.FindElement(By.CssSelector("option[value='" + amount + "']")));
					ChooseAmount.Click();
					break;
				default:
					throw new NotImplementedException();
			}
		}

		public void checkWorkOfCalendarAutocompletion()
		{
			calendarDataType = new HtmlElement(By.CssSelector(".sb-dates__col [data-placeholder = 'Check-in Date']"));
			DateTime checkInDate = DateTime.Parse(calendarDataType.GetAttribute("textContent"));
			calendarDataType = new HtmlElement(By.CssSelector(".sb-dates__col [data-placeholder = 'Check-out Date']"));
			DateTime checkOutDate = DateTime.Parse(calendarDataType.GetAttribute("textContent"));
			Assert.That(checkOutDate.Month.CompareTo(checkInDate.Month) == 0);
			Assert.That(checkOutDate.Day - checkInDate.Day == 1);
			Assert.That(checkOutDate.Year.CompareTo(checkInDate.Year) == 0);
		}

		public void setCalendarDate()
		{
			string InMonth = DateTime.Today.Month.ToString("d2");
			string InDay = DateTime.Today.Day.ToString("d2");
			string InYear = (DateTime.Today.Year + 1).ToString();
			checkinMonthDay.SendKeys(InDay); 
			checkinYear.SendKeys(InYear);
			checkinMonth.SendKeys(InMonth);
			if (Utils.isElementPresent(By.CssSelector(".c2-calendar-close-button-icon")))
			{
				Browser.Driver.FindElement(By.CssSelector(".c2-calendar-close-button-icon")).Click();
			}
		}

		public string GetDestinationError()
		{
			return errorDestination.Text;
		}

		public string GetDateError(string error)
		{
			var newError = string.Format("//div[contains(text(), \"{0}\")]", error);
			var el = new HtmlElement(By.XPath(newError));
			return el.Text;
		}

		public void BuisnessButton()
		{
			radioBuisnessButon.Click();
		}

		public bool waitLoading(string selector)
		{
			var el = new HtmlElement(By.CssSelector(selector));
			int timeout = 30;
			while (timeout > 0)
			{
				if (el.GetAttribute("style") != "display: block;")
				{
					return true;
				}
				timeout--;
				Thread.Sleep(1000);
			}
			throw new Exception("Sign in popup didn't load in settings.");
		}
	}
}