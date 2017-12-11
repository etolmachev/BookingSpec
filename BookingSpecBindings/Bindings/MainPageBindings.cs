using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingSpecBindings.TestBase.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace BookingSpecBindings.Bindings
{
	[Binding]
	class MainPageBindings
	{
		MainPage page = new MainPage();

		[When(@"I click Sign In button")]
		public void WhenIClickSignInButton()
		{
			page.clickSignIn();
		}

	}
}
