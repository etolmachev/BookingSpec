using OpenQA.Selenium;

namespace BookingSpecBindings.TestBase.Pages
{
	class RegisterPopUp
	{
		private string GetStartedLocator = "input[value='Get started']";

		private string emailFieldLocator = "form.js-user-access-form--signup input[name='username']";

		private string passFieldLocator = "form.js-user-access-form--signup input[name='password']";

		private string XmarkButtonLocator = ".modal-mask-closeBtn";

		private string MsgErrorLocator = ".form-shown-section .alert-error";

		public HtmlElement GetStartedButton;
		public HtmlElement EmailField;
		public HtmlElement PassField;
		public HtmlElement XmarkButton;
		public RegisterPopUp()
		{
			EmailField = new HtmlElement(By.CssSelector(emailFieldLocator));
			PassField = new HtmlElement(By.CssSelector(passFieldLocator));
			XmarkButton = new HtmlElement(By.CssSelector(XmarkButtonLocator));
			GetStartedButton = new HtmlElement(By.CssSelector(GetStartedLocator));
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
			if(Utils.isElementPresent(By.CssSelector(GetStartedLocator)))
			GetStartedButton.Click();
			else
			Browser.Driver.FindElement(By.CssSelector("input[value='Sign up']")).Click();
		}
		public void CloseSignInPopUp()
		{
			XmarkButton.Click();
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
	}
}
