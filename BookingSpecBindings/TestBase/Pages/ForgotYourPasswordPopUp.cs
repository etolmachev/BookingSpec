using System;
using System.Threading;
using OpenQA.Selenium;

namespace BookingSpecBindings.TestBase.Pages
{
	class ForgotYourPasswordPopUp
	{
		private string emailFieldLocator = ".js-user-access-form--reminder .user_access_email_section input[name = 'username']";
		private string sendButtonLocator = "input[value='Send']";
		private string cancelButtonLocator = ".signup_no_thanks";
		private string MsgErrorLocator = ".form-shown-section .alert-error";
		private string BackToSignInLocator = ".user_access_section_trigger_link .js-user-access-form--back-to-signin";

		public HtmlElement emailField;
		public HtmlElement sendButton;
		public HtmlElement cancelButton;
		public HtmlElement MsgError;
		public HtmlElement BackToSignInButton;

		public ForgotYourPasswordPopUp()
		{
			emailField = new HtmlElement(By.CssSelector(emailFieldLocator));
			sendButton = new HtmlElement(By.CssSelector(sendButtonLocator));
			cancelButton = new HtmlElement(By.CssSelector(cancelButtonLocator));
			MsgError = new HtmlElement(By.CssSelector(MsgErrorLocator));
			BackToSignInButton = new HtmlElement(By.CssSelector(BackToSignInLocator));
		}
		public void TypeEmail(string email)
		{
			emailField.SendKeys(email);
		}
		public void clickSendButton()
		{
			sendButton.Click();
		}
		public void clickCancelButton()
		{
			cancelButton.Click();
		}
		public string GetErrorText()
		{
			return new HtmlElement(By.CssSelector(MsgErrorLocator)).Text;
		}
		public void clickBackToSignInButton()
		{
			BackToSignInButton.Click();
		}
		public bool waitLoading(int timeout = 30)
		{
			var el = new HtmlElement(By.CssSelector(".user_access_menu .form-loading"));
			while (timeout > 0)
			{
				if (el.GetAttribute("style") != "display: block;")
				{
					return true;
				}
				timeout--;
				Thread.Sleep(1000);
			}
			throw new Exception("Forgot your password popup didn't load in settings.");
		}
	}
}