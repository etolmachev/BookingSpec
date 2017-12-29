using System;
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
			return EmailField.GetAttribute("value");
		}
		public string GetPassText()
		{
			return PassField.GetAttribute("value");
		}
		public string GetIForgotText()
		{
			return IForgot.Text;
		}
	}
}