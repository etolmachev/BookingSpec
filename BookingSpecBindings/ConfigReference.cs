using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingSpecBindings.TestBase;
using TechTalk.SpecFlow;

namespace BookingSpecBindings
{[Binding]
	class ConfigReference
	{
		[BeforeFeature]
		public static void AtStart()
		{
			Manager.Read();
		}
	}
}
