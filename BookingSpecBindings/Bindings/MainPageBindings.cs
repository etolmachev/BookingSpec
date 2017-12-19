﻿using BookingSpecBindings.TestBase.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace BookingSpecBindings.Bindings
{
	[Binding]
	class MainPageBindings
	{
		MainPage page = new MainPage();

		[When(@"I click Sign In button")]
		public void WhenIClickSignInButton()
		{
			page.clickSignIn();
		}

		[Then(@"I click Sign In button")]
		public void ThenIClickSignInButton()
		{
			page.clickSignIn();
		}

		[Then(@"I see that i am Signed In")]
		public void ThenISeeThatIAmSignedIn()
		{
			Assert.AreEqual(page.SignInCheck(), "Your Account");
		}
	}
}
