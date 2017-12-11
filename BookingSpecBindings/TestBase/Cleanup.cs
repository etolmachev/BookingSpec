using TechTalk.SpecFlow;

namespace BookingSpecBindings.TestBase
{
	[Binding]
	public class Cleanup
	{
		[AfterScenario]
		public void closeBrowser()
		{
			Browser.Quit();
		}
	}
}
