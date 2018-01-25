using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace BookingSpecBindings.TestBase.Pages
{
	public class AccommodationSearchResult
	{
		private string destinationLocator = ".sr_header";
		private string selectedCategoryLocator = ".selected .sort_option";
		private string amountofRoomsLocator = ".sr_gr .sr-group_recommendation .room_link";
		private string filterBlocker = ".sr-usp-overlay .sr-usp-overlay--wide";
		private string showMoreLocator = "div[class = 'collapsed_partly_link collapsed_partly_more']";

		public HtmlElement SelectedCategory;
		public HtmlElement DestinationContainer;
		public HtmlElement AmountOfRooms;
		public HtmlElement FilterElement;
		public HtmlElement OfferedAmount;
		public HtmlElement FilterBlocker;
		public HtmlElement ShowMoreElement;

		public AccommodationSearchResult()
		{
			DestinationContainer = new HtmlElement(By.CssSelector(destinationLocator));
			SelectedCategory = new HtmlElement(By.CssSelector(selectedCategoryLocator));
			AmountOfRooms = new HtmlElement(By.CssSelector(amountofRoomsLocator));
			FilterBlocker = new HtmlElement(By.CssSelector(filterBlocker));
			ShowMoreElement = new HtmlElement(By.CssSelector(showMoreLocator));
		}
		public void CategoryCheck(string category)
		{
			category = "Top Picks for " + category;
			Assert.AreEqual(SelectedCategory.Text, category);
		}
		public void RoomChecker(string count)
		{
			string amount = AmountOfRooms.Text;
			if (Char.IsNumber(amount[2]))
			{
				amount = amount.Substring(0, 2);
				Assert.AreEqual(count, amount);
			}
			else
			{
				amount = amount.Substring(0, 1);
				Assert.AreEqual(count, amount);
			}
		}

		public bool ClickShowMore()
		{
			try
			{
				List<IWebElement> elements = new List<IWebElement>(Browser.Driver.FindElements(By.CssSelector(showMoreLocator)));
				foreach (var el in elements)
				{
					if (el.Displayed)
					{
						el.Click();
						return true;
					}
				}
			}
			catch (Exception e)
			{
				try
				{
					ShowMoreElement.Click();
					return true;
				}
				catch (Exception ex)
				{
					return false;
				}
			}
			return false;
		}
		public void WaitFilter()
		{
			try
			{
				FilterBlocker.WaitElementDisappears();
			}
			catch (Exception e)
			{
			}
		}
		public void ClickAllButtonsShowMore()
		{
			int t = 10;
			while (t > 0 && ClickShowMore())
			{
				t--;
				Thread.Sleep(2000);
			}
		}
		public int FilteredAmount()
		{
			string fullHeader = DestinationContainer.Text;
			string pattern = "(: )(\\d+)(.*?)(properties)";
			string amount = String.Empty;
			Regex reg = new Regex(pattern);
			MatchCollection matches = Regex.Matches(fullHeader, pattern);
			foreach (Match match in matches)
			{
				amount = match.Groups[2].Value;
				break;
			}
			return Int32.Parse(amount);
		}
	}
}

