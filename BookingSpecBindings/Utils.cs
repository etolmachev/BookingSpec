using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace BookingSpecBindings
{

	static class Utils
	{ 
		public static string rnd(int length)
		{
			Random random = new Random();
			const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
			return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
		}
		private static string regexAll = "(?={{)(.*?)(?<=}})";
		private static string regexLeft = "(?<={{)(.*?)(?=::)";
		private static string regexRight = "(?<=::)(.*?)(?=}})";
		public static string Context(string key)
		{
			return ScenarioContext.Current.Get<string>(key);
		}
		public static string Resolve(string email)
		{
			string result = email;
			foreach (Match match in Regex.Matches(email, regexAll))
			{
				result = MainMethodResolve(email);
			}
			return result;
		}

		private static string MainMethodResolve(string email)
		{
			string key = Regex.Match(email, regexLeft).ToString();
			string value = Regex.Match(email, regexRight).ToString();

			string mid = String.Empty;

			switch (key)
			{
				case "rnd":
					mid = rnd(Int32.Parse(value));
					break;
				case "context":
					mid = Context(value);
					break;
				default:
					mid = "";
					break;
			}

			string left = email.Substring(0, email.IndexOf(key) - 2);
			string right = email.Substring(email.IndexOf(value) + value.Length + 2);

			return left + mid + right;
		}
	}
}