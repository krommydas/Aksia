using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
	internal class Conversions
	{
		static internal T ValueFromSql<T>(String sqlValue)
		{
			if (typeof(T) == typeof(Guid))
				return (T)(Object)Guid.Parse(sqlValue);
			else if (typeof(T) == typeof(String))
				return (T)(Object)sqlValue;
			else
				throw new Exception("can not convert from sql to " + typeof(T).AssemblyQualifiedName);

		}

		static internal String ValueToSql<T>(T value)
		{
			if (typeof(T) == typeof(Guid))
				return ((Guid)(Object)value).ToString();
			else if (typeof(T) == typeof(String))
				return (String)(Object)value;
			else
				throw new Exception("can not convert to sql from " + typeof(T).AssemblyQualifiedName);

		}
	}
}
