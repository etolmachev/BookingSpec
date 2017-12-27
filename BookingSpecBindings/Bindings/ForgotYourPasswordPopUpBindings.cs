using System;
using BookingSpecBindings.TestBase.Pages;
using NUnit.Framework;
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
		[When(@"I click button (Cancel|Send|Back To Sign In) on Forgot Your Password PopUp")]
		public void WhenIClickButtonCancel(string buttonname)
		{
			switch (buttonname)
			{
				case "Cancel":
					forgotPage.clickCancelButton();
					break;
				case "Send":
					forgotPage.clickSendButton();
					break;
				case "Back To Sign In":
					forgotPage.clickBackToSignInButton();
					break;
				default:
					throw new NotImplementedException();
			}
			
		}
	}
}