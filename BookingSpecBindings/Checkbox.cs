using System;
using System.Linq;
using BookingSpecBindings.TestBase;
using OpenQA.Selenium;
using Int32 = System.Int32;

namespace BookingSpecBindings
{
	class Checkbox
	{
		private HtmlElement checkboxElement;
		private string xpath = "//a[div/span[contains (text(),\"{0}\")]]";
		public Checkbox(string checkboxName)
		{
			
			try
			{
				var elements = Browser.Driver.FindElements(By.XPath(String.Format(xpath, checkboxName)));
				checkboxElement = new HtmlElement(elements.First(el => el.Displayed));
			}
			catch (Exception e)
			{
				checkboxElement = new HtmlElement(By.XPath(String.Format(xpath, checkboxName)));
			}
		}
		public bool IsCheckboxSelected()
		{
			return checkboxElement.GetAttribute("aria-checked") == "true";
		}
		public void CheckboxSelector(string expState)
		{
			switch (expState)
			{
				case "On":
					if (!IsCheckboxSelected())
					{
						checkboxElement.Click();
					}
					break;
				case "Off":
					if (IsCheckboxSelected())
					{
						checkboxElement.Click();
					}
					break;
			}
		}
		public int getAmountOffers()
		{
				string myStr = checkboxElement.FindElement(By.XPath(".//span[@class='filter_count filter_count__inline' or @class='filter_count']")).Text;
				if (myStr.Contains("("))
				{
					myStr = myStr.Trim('(', ')');
				}
				return Int32.Parse(myStr);
		}
	}
}
