using BookingSpecBindings.TestBase.Pages;
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
		[Then(@"I see that i am Signed In")]
		public void ThenISeeThatIAmSignedIn()
		{
			page.SignInCheck();
		}


		[Then(@"I hover mouse over Sign in button")]
		public void ThenIHoverMouseOverSignInButton()
		{
			page.hoverAndClickSignInButton();
		}
	}
}