using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace BookingSpecBindings.TestBase
{
	public class ActualSearch
	{
		private string PropertyBlockLocator = ".sr_property_block";
		private string PriceLocator = "//b[contains (text(), 'US$')]";
		private string StarsLocator = "//i/span[contains (text(), 'star')]";
		private string RatingLocator = "span[class=\'review-score-badge\']";
		private string FreeWIFILocator = "//span[contains (text(), 'WiFi')]";

		public string Price;
		public string Stars;
		public string Rating;
		public string FreeWIFI;

		public ActualSearch(IWebElement element)
		{
			Price = element.FindElement(By.XPath(PriceLocator)).Text.Substring(3);
			Stars = element.FindElement(By.XPath(StarsLocator)).Text;
			Rating = element.FindElement(By.CssSelector(RatingLocator)).Text;
			FreeWIFI = element.FindElement(By.XPath(FreeWIFILocator)).Text.ToLower();
		}
	}
}
