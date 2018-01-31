using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BookingSpecBindings
{
	public static class Manager
	{
		public static Config config
		{
			get;
			set;
		}
		public static void Read()
		{
			string path = "C:\\Users\\vkrasnobelmov\\Desktop\\Config.xml";

			try
			{
				XmlSerializer x = new XmlSerializer(typeof(Config));
				StreamReader reader = new StreamReader(path);
				config = (Config)x.Deserialize(reader);
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex);
			}
		}
	}
}

