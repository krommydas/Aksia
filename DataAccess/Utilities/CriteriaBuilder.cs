using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
	internal class CriteriaBuilder
	{
		public static String GetIDSCommand(string idFieldName, IEnumerable<Guid> ids)
		{
			StringBuilder sb = new StringBuilder();

			if (ids != null && ids.Count() > 0)
			{
				sb.Append(" where ");
				sb.Append(idFieldName);
				sb.Append(" in (");
				foreach (var id in ids)
				{
					sb.Append("'");
					sb.Append(id.ToString());
					sb.Append("',");
				}

				sb.Replace(',', ')', sb.Length - 2, 1);
			}

			return sb.ToString();
		}

		public static String GetSelectCommand(string tableName)
		{
			return "select * from " + tableName;
		}

		public static String GetDeleteCommand(string tableName)
		{
			return "delete from " + tableName;
		}

		public static String GetInsertCommand(string tableName)
		{
			return "insert into " + tableName;
		}

		public static String GetUpdateCommand(string tableName)
		{
			return "update " + tableName + " set ";
		}
	}
}
