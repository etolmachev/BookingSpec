﻿using System;
using System.Linq;
using System.Threading;
using BookingSpecBindings.TestBase;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace BookingSpecBindings
{
	[Binding]
	public class CommonBindings
	{

		[When(@"I open browser")]
		public void IOpenBrowser()
		{
			if (!Browser.IsInitialized)
			{
				Browser.BuildBrowser();
				Browser.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
			}
		}
		[When(@"I navigate to url ""(.*)""")]
		public void GivenNavigateToUrl(string url)
		{
			Browser.Driver.Navigate().GoToUrl(url);
			Browser.WaitReadyState();
			if (Utils.isElementPresent(By.CssSelector(".notify-asking-reject")))
			{
				Browser.Driver.FindElement(By.CssSelector(".notify-asking-reject")).Click();
			}
		}
		[Then(@"I wait for (.*) seconds")]
		public void IWait(int seconds)
		{
			Thread.Sleep(TimeSpan.FromSeconds(seconds));
		}
		[When(@"I refresh page")]
		public void WhenIRefreshPage()
		{
			Browser.Driver.Navigate().Refresh();
		}
		[When(@"I remember ""(.*)"" as ""(.*)""")]
		public void WhenIRememberAs(string alias, string email)
		{
			ScenarioContext.Current.Set(Utils.Resolve(alias), email);
		}
		[Then(@"I wait browser page to load")]
		public void ThenIWaitBrowserPageToLoad()
		{
			Browser.WaitReadyState();
		}
	}
}
