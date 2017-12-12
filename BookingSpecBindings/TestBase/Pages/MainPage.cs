using OpenQA.Selenium;

namespace BookingSpecBindings.TestBase.Pages
{
    public class MainPage
    {

        private string signInButtonLocator = "//span[contains(text(), \'Sign in\')]";

        public HtmlElement SignInbutton;
        

        public MainPage()
        {
            SignInbutton = new HtmlElement(By.XPath(signInButtonLocator));
           
        }

        public void clickSignIn()
        {
            SignInbutton.Click();
        }
    }
}
