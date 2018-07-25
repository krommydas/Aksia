using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace CommonsSystem
{
	public class LanguageRepository
	{
		private const String DefaultText = "";

		public LanguageRepository(LanguageOrigin origin, string valuesFile)
		{
			this.Values = new Dictionary<string, string>();
			this.fileName = valuesFile;
			this.Origin = origin;
		}

		private String fileName;

		public LanguageOrigin Origin { get; private set; }

		private Boolean IsLoaded;

		private Dictionary<String, String> Values { get; set; }

		public String this[String key]
		{
			get
			{
				if (!this.IsLoaded)
					this.FromXML();

				String text;
				if (!this.Values.TryGetValue(key, out text))
					text = DefaultText;

				return text;
			}
		}

		private void FromXML()
		{
			

			// restore text and keys from the language xml file

			
		}
	}
}
