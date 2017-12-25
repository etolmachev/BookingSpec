using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace BookingSpecBindings.TestBase.Pages
{
	public class MainPage
	{

		private string signInButtonLocator = "//span[contains(text(), \'Sign in\')]";
		private string RegisterButtonLocator = "//span[contains(text(), \'Register\')]";
		private string accountNameLocator = "//span[contains (text(), 'Your Account')]";

		public HtmlElement SignInbutton;
		public HtmlElement RegisterButton;
		public HtmlElement AccountName;

		public MainPage()
		{
			SignInbutton = new HtmlElement(By.XPath(signInButtonLocator));
			RegisterButton = new HtmlElement(By.XPath(RegisterButtonLocator));
			AccountName = new HtmlElement(By.XPath(accountNameLocator));
		}

		public void clickSignIn()
		{
			SignInbutton.Click();
		}
		public void clickRegister()
		{
			RegisterButton.Click();
		}
		public string SignInCheck()
		{
			return AccountName.Text;
		}
	}
}