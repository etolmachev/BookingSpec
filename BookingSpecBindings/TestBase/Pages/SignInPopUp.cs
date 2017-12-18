using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace BookingSpecBindings.TestBase.Pages
{
	public class SignInPopUp
		{
		private string MsgErrorLocator = ".form-shown-section .alert-error";

		private string emailFieldLocator = "form.js-user-access-form--signin input[name='username']";

		private string passFieldLocator = "form.js-user-access-form--signin input[name='password']";

		private string popUpButtonLocator = "form.js-user-access-form--signin input[value='Sign in']";

		private string tipElementLocator = ".user_access_menu_checkbox.bicon - question"; 

		public HtmlElement EmailField;
		public HtmlElement PassField;
		public HtmlElement PopUpButton;
		public HtmlElement MsgError;
		public HtmlElement TipElement;
		public SignInPopUp()
		{
			EmailField = new HtmlElement(By.CssSelector(emailFieldLocator));
			PassField = new HtmlElement(By.CssSelector(passFieldLocator));
			PopUpButton = new HtmlElement(By.CssSelector(popUpButtonLocator));
			TipElement = new HtmlElement(By.CssSelector(tipElementLocator));
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
		public string TipHold()
		{
			//var el = new HtmlElement();
			//Actions builder = new Actions(Browser.Driver);
			string tipText = TipElement.GetAttribute("value");
			return tipText;
		}
		public string GetErrorText()
		{
			return new HtmlElement(By.CssSelector(MsgErrorLocator)).Text;
		}
		public string GetEmailText()
		{
			string EmailValue = EmailField.GetAttribute("value");
			return EmailValue;
		}

		public bool waitLoading(int timeout = 30)
		{
			var el = new HtmlElement(By.CssSelector(".user_access_signin_menu .form-loading"));

			while (timeout > 0)
			{
				Console.WriteLine(el.GetAttribute("style"));

				if (el.GetAttribute("style") != "display: block;")
				{
					return true;
				}
				timeout--;
				Thread.Sleep(1000);
			}
			throw new Exception("still loading");
		}
	}
}