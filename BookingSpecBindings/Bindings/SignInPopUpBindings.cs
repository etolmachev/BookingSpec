using BookingSpecBindings.TestBase.Pages;
using TechTalk.SpecFlow;

namespace BookingSpecBindings.Bindings
{    [Binding]
    class SignInPopUpBindings
    {
        SignInPopUp signPage = new SignInPopUp();

        [When(@"I write my email ""(.*)""")]
        public void WhenIWriteMyEmail(string email)
        {
            signPage.typeEmail(email);
        }
        [When(@"I write my password ""(.*)""")]
        public void WhenIWriteMyPassword(string pass)
        {
            signPage.typePass(pass);
        }
        [When(@"I click on PopUp Sign In button")]
        public void WhenIClickOnPopUpSignInButton()
        {
            signPage.clickToSubmit();
        }
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
