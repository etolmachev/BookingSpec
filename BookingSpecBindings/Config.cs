using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace BookingSpecBindings
{
	[XmlRoot("Config")]
	[Serializable]
	public class Config
	{
	[XmlElement("email")]
		public string Email
		{
			get;
			set;
		}

		[XmlElement("password")]
		public string Password
		{
			get;
			set;
		}
	}
}
