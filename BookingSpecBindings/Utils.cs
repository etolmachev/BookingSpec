using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace BookingSpecBindings
{

	class Utils
	{
		private static Random random = new Random();
		public static string rnd(string email)
		{
			int length = Int32.Parse(Regex.Match(email, regexRight).ToString());
			const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
			string mid = new string(Enumerable.Repeat(chars, length)
			.Select(s => s[random.Next(s.Length)]).ToArray());
			string left = email.Substring(0, email.IndexOf("{{"));
			string right = email.Substring(email.IndexOf("}}") + 2);
			return left + mid + right;
		}
		private static string regexAll = "(?={{)(.*?)(?<=}})";
		private static string regexLeft = "(?<={{)(.*?)(?=::)";
		private static string regexRight = "(?<=::)(.*?)(?=}})";
		public static string Context(string email)
		{
			string key = Regex.Match(email, regexRight).ToString();
			return ScenarioContext.Current.Get<string>(key);
		}
		public static string Resolve(string result)
		{
			string placeholder = Regex.Match(result, regexLeft).ToString();
			Console.WriteLine(placeholder);
			switch (placeholder)
			{
				case "rnd":
					return rnd(result);
					break;
				case "context":
					return Context(result);
					break;
				default:
					throw new NotImplementedException();
			}
		}
	}
}
