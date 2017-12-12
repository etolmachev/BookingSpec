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
    }
}
