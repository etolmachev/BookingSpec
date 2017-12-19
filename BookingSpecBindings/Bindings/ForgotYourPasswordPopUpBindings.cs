using System;
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
		
		[When(@"I write email ""(.*)""")]
		public void WhenIWriteEmail(string email)
		{
			forgotPage.TypeEmail(email);
		}
		[When(@"I Click button Send")]
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

		[Then(@"I see an error on ForgotYourPasswordPopUp")]
		public void ThenISeeAnErrorOnForgotYourPasswordPopUp()
		{
			Assert.AreEqual(forgotPage.GetErrorText(), "Oops! We can\'t find a profile registered with that name.");
		}
		[Then(@"I click button Cancel")]
		public void WhenIClickButtonCancel()
		{
			forgotPage.clickCancelButton();
		}
		[Then(@"I click button Back to sign in")]
		public void ThenIClickButtonBackToSignIn()
		{
			forgotPage.clickBackToSignInButton();
		}

	}
}