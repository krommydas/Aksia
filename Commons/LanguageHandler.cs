using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonsSystem
{
	public enum LanguageOrigin : short
	{
		English = 0,
		Greek = 1,
	}

	public class LanguageHandler
	{
		public LanguageHandler(IEnumerable<LanguageRepository> repositories)
		{
			this.Repositories = repositories.ToDictionary(x => x.Origin);
		}

		private Dictionary<LanguageOrigin, LanguageRepository> Repositories;

		public LanguageOrigin ActiveOrigin { get; set; }

		public String GetText(string key)
		{
			return this.GetText(key, this.ActiveOrigin);
		}

		public String GetText(string key, LanguageOrigin origin)
		{
			if (!this.Repositories.ContainsKey(origin))
				throw new Exception("not supported language");

			return this.Repositories[origin][key];
		}
	}
}
