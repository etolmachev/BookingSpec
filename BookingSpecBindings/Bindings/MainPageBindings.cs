using System;
using BookingSpecBindings.TestBase.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace BookingSpecBindings.Bindings
{
	[Binding]
	class MainPageBindings
	{
		MainPage page = new MainPage();

		[When(@"I click Sign In button on Ribbon menu")]
		public void WhenIClickSignInButton()
		{
			page.clickSignIn();
		}
		[Then(@"I click Sign In button on Ribbon menu")]
		public void ClickSignInButton()
		{
			page.clickSignIn();
		}
		[Then(@"I click Sign In button")]
		public void ThenIClickSignInButton()
		{
			page.clickSignIn();
		}
		[When(@"I click Register button on Ribbon menu")]
		public void WhenIClickRegisterButtonOnRibbonMenu()
		{
			page.clickRegister();
		}

		[Then(@"I see that I am Signed In")]
		public void ThenISeeThatIAmSignedIn()
		{
			Assert.AreEqual(page.SignInCheck(), "Your Account");
		}
		[Then(@"I see that I am not Signed In")]
		public bool ThenISeeThatIAmNotSignedInAndNotRegistered()
		{
			return page.SignInbutton.Displayed;
		}
		[Then(@"I wait while ""(.*)"" popup is working")]
		public void ThenIWaitWhilePopupIsWorking(string popup)
		{
			switch (popup)
			{
				case "Sign In":
					page.waitLoading(".user_access_signin_menu .form-loading");
					break;
				case "Registration":
					page.waitLoading(".user_access_signup_menu .form-loading");
					break;
				case "Forgot Your Password":
					page.waitLoading(".user_access_menu .form-loading");
					break;
				default:
				throw new NotImplementedException();
			}
		}
	}
}
