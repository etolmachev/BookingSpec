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

	    [When(@"I write my email ""(.*)""")]
	    public void WhenIWriteMyEmail(string email)
	    {
	        page.typeEmail(email);
	    }
	    [When(@"I write my password ""(.*)""")]
	    public void WhenIWriteMyPassword(string pass)
	    {
	        page.typePass(pass);
        }
	   [When(@"I click on PopUp Sign In button")]
	    public void WhenIClickOnPopUpSignInButton()
	    {
	        page.clickToSubmit();
	    }


    }
}
