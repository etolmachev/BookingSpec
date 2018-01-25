using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace BookingSpecBindings.TestBase
{
	public class ExpectedSearch
	{
		private string Price = "*";
		private string Stars = "*";
		private string Rating ="*";
		private string FreeWIFI = "*";

		public ExpectedSearch(Table table)
		{
			foreach (var row in table.Rows)
			{
				string key = row["Field"];
				switch (key)
				{
					case "Price":
						Price = row["Value"];
						break;
					case "Stars":
						Stars = row["Value"];
						break;
					case "Rating":
						Rating = row["Value"];
						break;
					case "Free Wifi":
						FreeWIFI = row["Value"].ToLower();
						break;
				}
			}
		}
		public bool Comparator(ActualSearch search)
		{
			string[] prices = Price.Split(' ');
			if ((Int32.Parse(prices[0]) <= Int32.Parse(search.Price) && Int32.Parse(search.Price) <= Int32.Parse(prices[1])) || Price == "*")
			{
				if ((Double.Parse(search.Rating) >= Double.Parse(Rating)) || Rating == "*")
				{
					if ((Stars == search.Stars.Substring(0, 1)) || Stars == "*")
					{
						if ((search.FreeWIFI.Contains(FreeWIFI)) || FreeWIFI == "*")
						return true;
					}
				}
			}
			return false;
		}
	}
}