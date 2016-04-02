﻿using Rsdn.SmartApp.Configuration;

namespace CodeJam.Extensibility.Configuration
{
	[XmlSerializerSection(typeof (Section3), AllowMerge = true)]
	public interface ISection3
	{
		string[] Values { get; }
	}
}