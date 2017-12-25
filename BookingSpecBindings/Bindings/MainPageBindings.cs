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
		[Then(@"I click Register button")]
		public void ThenIClickRegisterButton()
		{
			page.clickRegister();
		}

		[Then(@"I see that I am Signed In")]
		public void ThenISeeThatIAmSignedIn()
		{
			Assert.AreEqual(page.SignInCheck(), "Your Account");
		}
	}
}
