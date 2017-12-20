﻿using System;
using System.Threading;
using BookingSpecBindings.TestBase.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support;
using TechTalk.SpecFlow;

namespace BookingSpecBindings.Bindings
{
	[Binding]
	class ForgotYourPasswordPopUpBindings
	{
		ForgotYourPasswordPopUp forgotPage = new ForgotYourPasswordPopUp();

		[When(@"I set following parameters on Forgot Your Password Pop Up dialog")]
		public void WhenISetFollowingParametersOnForgotYourPasswordPopUpDialog(Table table)
		{
			foreach (var row in table.Rows)
			{
				string key = row["Field"];
				switch (key)
				{
					case "Email":
						forgotPage.TypeEmail(row["Value"]);
						break;
					default:
						throw new NotImplementedException();
				}
			}
		}
		
		[When(@"I Click button Send on Forgot Your Password PopUp")]
		public void WhenIClickButtonSend()
		{
			forgotPage.clickSendButton();
		}
		[When(@"I wait while page popup is loading")]
		public void WhenIWaitWhilePagePopupIsLoading()
		{
			forgotPage.waitLoading();
		}

		[Then(@"I wait while page popup is loading")]
		public void ThenIWaitWhilePagePopupIsLoading()
		{
			forgotPage.waitLoading();
		}
		[Then(@"I see error message ""(.*)"" on Forgot Your Password PopUp")]
		public void ThenISeeErrorMessageOnForgotYourPasswordPopUp(string error)
		{
			Assert.AreEqual(forgotPage.GetErrorText(), error);
		}
		[Then(@"I click button Cancel on Forgot Your Password PopUp")]
		public void WhenIClickButtonCancel()
		{
			forgotPage.clickCancelButton();
		}
		[Then(@"I click button Back To Sign In on Forgot Your Password PopUp")]
		public void ThenIClickButtonBackToSignInOnForgotYourPasswordPopUp()
		{
			forgotPage.clickBackToSignInButton();
		}
	}
}