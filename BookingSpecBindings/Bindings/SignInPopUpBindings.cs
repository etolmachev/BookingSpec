using System;
using BookingSpecBindings.TestBase.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace BookingSpecBindings.Bindings
{    [Binding]
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
        [Then(@"I see message error with (.*)")]
        public void ThenISeeMessageErrorWith(string message)
        {
            Assert.That(signPage.GetErrorText().Contains(message), Is.True);
        }

    }
}
