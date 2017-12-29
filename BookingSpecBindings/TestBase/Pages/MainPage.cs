using System;
using System.Threading;
using OpenQA.Selenium;

namespace BookingSpecBindings.TestBase.Pages
{
	public class MainPage
	{

		private string signInButtonLocator = "//span[contains(text(), \'Sign in\')]";
		private string RegisterButtonLocator = "//span[contains(text(), 'Register') or contains(text(), 'Create Account')]";
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
		public bool waitLoading(string selector )
		{
			var el = new HtmlElement(By.CssSelector(selector));
			int timeout = 30;
			while (timeout > 0)
			{
				if (el.GetAttribute("style") != "display: block;")
				{
					return true;
				}
				timeout--;
				Thread.Sleep(1000);
			}
			throw new Exception("Sign in popup didn't load in settings.");
		}
	}
}