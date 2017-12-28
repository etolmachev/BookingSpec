using System;
using BookingSpecBindings.TestBase.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace BookingSpecBindings.Bindings
{
	[Binding]
	class RegisterPopUpBindings
	{
		RegisterPopUp regPage = new RegisterPopUp();

		[Then(@"I see that value of email field consists of (.*) chars on Register Pop Up dialog")]
		public void ThenISeeThatValueOfEmailFieldConsistsOfCharsOnRegisterPopUpDialog(int charsCount)
		{
			Assert.AreEqual(regPage.GetEmailText().Length, charsCount);
		}
		[When(@"I set following parameters on Register Pop Up dialog")]
		public void WhenISetFollowingParametersOnRegisterPopUp(Table table)
		{
			foreach (var row in table.Rows)
			{
				string key = row["Field"];
				switch (key)
				{
					case "Email":
						regPage.TypeEmail(Utils.Resolve(row["Value"]));
						break;
					case "Password":
						regPage.TypePass(row["Value"]);
						break;
					default:
						throw new NotImplementedException();
				}
			}
		}
		[When(@"I click Get Started button on PopUp")]
		public void WhenIClickGetStartedButtonOnPopUp()
		{
			regPage.ClickToSubmit();
		}
		[Then(@"I see that credential values: ""(.*)"" ""(.*)"" are ""(.*)"" in Register PopUp fields")]
		public void ThenISeeThatCredentialValuesAreInRegisterPopUpFields(string email, string pass, string key)
		{
			switch (key)
			{
				case "saved":
					Assert.AreEqual(regPage.GetEmailText(), email);
					Assert.AreEqual(regPage.GetPassText(), pass);
					break;
				case "not saved":
					Assert.AreEqual(regPage.GetEmailText().Length, 0);
					Assert.AreEqual(regPage.GetPassText().Length, 0);
					break;
				default:
					throw new NotImplementedException();
			}
		}
		[Then(@"I see error message ""(.*)"" on Register PopUp")]
		public void ThenISeeErrorMessageOnRegisterPopUp(string error)
		{
			Assert.AreEqual(regPage.GetErrorText(), error);
		}
	}
}
