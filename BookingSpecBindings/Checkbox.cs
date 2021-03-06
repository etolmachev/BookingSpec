﻿using System;
using System.Linq;
using BookingSpecBindings.TestBase;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Int32 = System.Int32;

namespace BookingSpecBindings
{
	class Checkbox : HtmlElement
	{
		private string xpath = "//a[div/span[contains (text(),\"{0}\")]]";
		public Checkbox(string checkboxName) : base(By.XPath(checkboxName))
		{
			try
			{
				var elements = Browser.Driver.FindElements(By.XPath(String.Format(xpath, checkboxName)));
				this.WrappedElement = elements.First(el => el.Displayed);
			}
			catch (Exception e)
			{
				this.WrappedElement = Browser.Driver.FindElement(By.XPath(String.Format(xpath, checkboxName)));
			}
		}
		public bool IsCheckboxSelected()
		{
			return this.WrappedElement.GetAttribute("aria-checked") == "true";
		}
		public void CheckboxSelector(string expState)
		{
			switch (expState)
			{
				case "On":
					if (!IsCheckboxSelected())
					{
						if (!this.WrappedElement.Enabled) break;
						this.WrappedElement.Click();
					}
					break;
				case "Off":
					if (IsCheckboxSelected())
					{
						if(!this.WrappedElement.Enabled) break;
						this.WrappedElement.Click();
					}
					break;
				default:
					throw new NotImplementedException();
			}
		}
		public int getAmountOffers()
		{
				string myStr = this.WrappedElement.FindElement(By.XPath(".//span[@class='filter_count filter_count__inline' or @class='filter_count']")).Text;
				if (myStr.Contains("("))
				{
					myStr = myStr.Trim('(', ')');
				}
				return Int32.Parse(myStr);
		}
	}
}
