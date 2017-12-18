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
	class SignInPopUpBindings
	{
		SignInPopUp signPage = new SignInPopUp();

		[When(@"I set following parameters on Sign In Pop Up dialog")]
		public void WhenISetFollowingParametersOnSignInPopUp(Table table)
		{
			foreach (var row in table.Rows)
			{
					string key = row["Field"];

				switch (key)

				{
					case "Email":
					signPage.TypeEmail(row["Value"]);
						break;

					case "Password":
						signPage.TypePass(row["Value"]);
						break;

					default:
						throw new NotImplementedException();
				}
			}
		}
		[When(@"I click Sign In button on PopUp")]
		public void WhenIClickOnPopUpSignInButton()
		{
			signPage.ClickToSubmit();
		}
		[Then(@"I see message error with ""(.*)""")]
		public void ThenISeeMessageErrorWith(string message)
		{
			Console.WriteLine(signPage.GetErrorText());
			Console.WriteLine(message);
			Assert.That(signPage.GetErrorText().Contains(message), Is.True);
		}
		[When(@"I write email with length ninety chars ""(.*)""")]
		public void WhenIWriteEmailWithLengthNinetyChars(string email)
		{
			signPage.EmailField.SendKeys(email);
		}
		[Then(@"I check that length of email is (.*) chars")]
		public void ThenIAssertThatLengthOfEmailIsEightyChars(int charsCount)
		{
			Assert.AreEqual(signPage.GetEmailText().Length, charsCount);
		}
		[Then(@"I wait while page popup is working")]
		public void ThenIWaitWhilePagePopupIsWorking()
		{
			signPage.waitLoading();
		}
	}
}