﻿using System;
using System.Threading;
using OpenQA.Selenium;

namespace BookingSpecBindings.TestBase.Pages
{
	public class SignInPopUp
	{
		private string MsgErrorLocator = ".form-shown-section .alert-error";

		private string emailFieldLocator = "form.js-user-access-form--signin input[name='username']";

		private string passFieldLocator = "form.js-user-access-form--signin input[name='password']";

		private string popUpButtonLocator = "form.js-user-access-form--signin input[value='Sign in']";

		private string forgotPassLocator = ".user_access_form .forgot_pass_trigger";

		private string XmarkButtonLocator = ".modal-mask-closeBtn";

		private string IForgotLocator = ".forgot_pass_trigger";

		public HtmlElement EmailField;
		public HtmlElement PassField;
		public HtmlElement PopUpButton;
		public HtmlElement MsgError;
		public HtmlElement ForgotPassButton;
		public HtmlElement XmarkButton;
		public HtmlElement IForgot;
		public SignInPopUp()
		{
			EmailField = new HtmlElement(By.CssSelector(emailFieldLocator));
			PassField = new HtmlElement(By.CssSelector(passFieldLocator));
			PopUpButton = new HtmlElement(By.CssSelector(popUpButtonLocator));
			ForgotPassButton = new HtmlElement(By.CssSelector(forgotPassLocator));
			XmarkButton = new HtmlElement(By.CssSelector(XmarkButtonLocator));
			IForgot = new HtmlElement(By.CssSelector(IForgotLocator));
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
		public void CloseSignInPopUp()
		{
			XmarkButton.Click();
		}
		public void ClickForgotPass()
		{
			ForgotPassButton.Click();
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
		public string GetPassText()
		{
			string PassValue = PassField.GetAttribute("value");
			return PassValue;
		}
		public string GetIForgotText()
		{
			return IForgot.Text;
		}
		public bool waitLoading(int timeout = 30)
		{
			var el = new HtmlElement(By.CssSelector(".user_access_signin_menu .form-loading"));

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