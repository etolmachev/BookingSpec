using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace BookingSpecBindings.TestBase.Pages
{
	public class MainPage
	{

		private string signInButtonLocator = "//span[contains(text(), \'Sign in\')]";

		private string accountNameLocator = "//span[contains (text(), 'Your Account')]";

		public HtmlElement SignInbutton;
		public HtmlElement AccountName;
		
		public MainPage()
		{
			SignInbutton = new HtmlElement(By.XPath(signInButtonLocator));
			AccountName = new HtmlElement(By.XPath(accountNameLocator));
		}

		public void clickSignIn()
		{
			SignInbutton.Click();
		}

		public void SignInCheck()
		{
			Assert.AreEqual(AccountName.Text, "Your Account");
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