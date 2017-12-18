using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

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

		public void hoverAndClickSignInButton()
		{
			Actions builder = new Actions(Browser.Driver);
			builder.MoveToElement(SignInbutton.WrappedElement).Build().Perform();
			Thread.Sleep(2000);
			SignInbutton.Click();
		}
	}
}