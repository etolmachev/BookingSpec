using System;
using BookingSpecBindings.TestBase.Pages;
using TechTalk.SpecFlow;

namespace BookingSpecBindings.Bindings
{    [Binding]
    class SignInPopUpBindings
    {
        SignInPopUp signPage = new SignInPopUp();

        [When(@"I set following parameters on SignInPopUp")]
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
        [When(@"I click on PopUp Sign In button")]
        public void WhenIClickOnPopUpSignInButton()
        {
            signPage.ClickToSubmit();
        }
    }
}
