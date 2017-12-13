using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace BookingSpecBindings.TestBase.Pages
{
     public class SignInPopUp
    {

        private string emailFieldLocator = "form.js-user-access-form--signin input[name='username']";

        private string passFieldLocator = "form.js-user-access-form--signin input[name='password']";

        private string popUpButtonLocator = "form.js-user-access-form--signin input[value='Sign in']";

        public HtmlElement EmailField;
        public HtmlElement PassField;
        public HtmlElement PopUpButton;

        public SignInPopUp()
        {
            EmailField = new HtmlElement(By.CssSelector(emailFieldLocator));
            PassField = new HtmlElement(By.CssSelector(passFieldLocator));
            PopUpButton = new HtmlElement(By.CssSelector(popUpButtonLocator));
        }
        public void TypeEmail(string email)
        {
            EmailField.SendKeys(email);
        }

        public void TypePass(string pass)
        {
            PassField.SendKeys(pass);
        }

        public void ClickToSubmit()
        {
            PopUpButton.Click();

        }
    }
}
