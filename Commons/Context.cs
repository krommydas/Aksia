using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace CommonsSystem
{
    public class Context
    {
		public static Context Instance { get; private set; }

		public static void Initialize()
		{
			Instance = new Context();
		}

		public SqlConnection DBConnection { get; private set; }
		public LanguageHandler Language { get; private set; }
    }
}
