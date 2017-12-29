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
		public static string Resolve(string input)
		{
			string result = input;
			foreach (Match match in Regex.Matches(input, regexAll))
			{
				result = MainMethodResolve(input);
			}
			return result;
		}
		private static string MainMethodResolve(string input)
		{
			string key = Regex.Match(input, regexLeft).ToString();
			string value = Regex.Match(input, regexRight).ToString();

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
			string left = input.Substring(0, input.IndexOf(key) - 2);
			string right = input.Substring(input.IndexOf(value) + value.Length + 2);
			return left + mid + right;
		}
	}
}