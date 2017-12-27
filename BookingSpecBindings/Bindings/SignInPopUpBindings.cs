using System;
using BookingSpecBindings.TestBase.Pages;
using NUnit.Framework;
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
		[When(@"I click on X button")]
		public void ThenIClickOnXButton()
		{
			signPage.CloseSignInPopUp();
		}
		[Then(@"I see message error with ""(.*)""")]
		public void ThenISeeMessageErrorWith(string message)
		{
			Assert.AreEqual(signPage.GetErrorText(), message);
			if (signPage.GetErrorText().Contains("You"))
			Assert.AreEqual(signPage.GetIForgotText(), "I forgot");
		}
		[When(@"I write email with length ninety chars ""(.*)""")]
		public void WhenIWriteEmailWithLengthNinetyChars(string email)
		{
			signPage.TypeEmail(email);
		}
		[Then(@"I see that value of email field consists of (.*) chars on Sign In Pop Up dialog")]
		public void ThenISeeThatValueOfEmailFieldConsistsOfCharsOnSignInPopUpDialog(int charsCount)
		{
			Assert.AreEqual(signPage.GetEmailText().Length, charsCount);
		}
		[Then(@"I wait while page popup is working")]
		public void ThenIWaitWhilePagePopupIsWorking()
		{
			signPage.waitLoading();
		}
		[When(@"I click Forgot Your Password button")]
		public void WhenIClickForgotYourPasswordButton()
		{
			signPage.ClickForgotPass();
		}
		[Then(@"I see error message ""(.*)"" on Sign In PopUp")]
		public void ThenISeeErrorMessageOnSignInPopUp(string error)
		{
			Assert.AreEqual(signPage.GetErrorText(), error);
		}
		[Then(@"I see that credential values: ""(.*)"" ""(.*)"" are ""(.*)"" in Sign In PopUp fields")]
		public void ThenISeeThatCredentialValuesAreInSignInPopUpFields(string email, string pass, string key)
		{
			switch (key)
			{
				case "saved":
					Assert.AreEqual(signPage.GetEmailText(), email);
					Assert.AreEqual(signPage.GetPassText(), pass);
					break;
				case "not saved":
					Assert.AreEqual(signPage.GetEmailText().Length, 0);
					Assert.AreEqual(signPage.GetPassText().Length, 0);
					break;
				default:
					throw new NotImplementedException();
			}
		}
		[When(@"I write password ""(.*)""")]
		public void WhenIWritePassword(string pass)
		{
			signPage.TypePass(pass);
		}
		[When(@"I write email on Sign in PopUp ""(.*)""")]
		public void WhenIWriteEmailOnSignInPopUp(string email)
		{
			signPage.TypeEmail(email);
		}
		[Then(@"I see Sign In PopUp dialog")]
		public bool ThenISeeSignInPopUpDialog()
		{
			Console.WriteLine(signPage.PopUpButton.Displayed);
			return signPage.PopUpButton.Displayed;
		}
		[Then(@"I check that I am not Registered")]
		public void ThenICheckThatIAmNotRegistered(Table table)
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
			signPage.ClickToSubmit();
		}
	}
}