using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DataAccess
{
	public interface IDataObject
	{
		Boolean IsStored { get; }

		void ParseSqlRow(IDataRecord record);
	}
}
