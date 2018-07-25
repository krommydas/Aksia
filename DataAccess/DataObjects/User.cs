using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;

namespace DataAccess
{
	public class User : IDataObject
	{
		private const String TableName = "User";

		#region Fields

		private FieldParser<String> mName = new FieldParser<string>("Name");
		public String Name { get { return this.mName.Value; } set { this.mName.Value = value; } }

		private FieldParser<Guid> mID = new FieldParser<Guid>("ID");
		public Guid ID { get { return this.mID.Value; } set { this.mID.Value = value; } }

		#endregion

		#region Restore From Database

		private Boolean mIsStored;

		public Boolean IsStored { get { return mIsStored; } }

		public void ParseSqlRow(System.Data.IDataRecord record)
		{
			mIsStored = true;

			try
			{
				mName.SqlValue = (String)record[mName.Name];
				mID.SqlValue = (String)record[mID.Name];
			}
			catch(Exception e)
			{
				// handle exception somehow
				throw e;
			}
		}

		#endregion

		#region Available Commands

		internal static String GetInsertCommand(User item)
		{
			StringBuilder command = new StringBuilder(CriteriaBuilder.GetInsertCommand(TableName));
			command.Append("(");

			command.Append("'");
			command.Append(item.mID.SqlValue);
			command.Append("',");

			command.Append("'");
			command.Append(item.mName.SqlValue);
			command.Append("'");

			command.Append(")");
			return command.ToString();
		}

		internal static String GetUpdateCommand(User item)
		{
			StringBuilder command = new StringBuilder(CriteriaBuilder.GetUpdateCommand(TableName));

			command.Append(item.mID.Name);
			command.Append("=");
			command.Append(item.mID.SqlValue);
			command.Append(",");

			command.Append(item.mName.Name);
			command.Append("=");
			command.Append(item.mName.SqlValue);
			command.Append(",");

			return command.ToString();
		}

		internal static String GetItemsCommand()
		{
			return User.GetItemsCommand(null);
		}
		internal static String GetItemsCommand(IEnumerable<Guid> ids)
		{
			return CriteriaBuilder.GetSelectCommand(TableName) + CriteriaBuilder.GetIDSCommand("ID", ids);
		}

		internal static String DeleteItemsCommand(Guid id)
		{
			return User.DeleteItemsCommand(new Guid[] { id });
		}
		internal static String DeleteItemsCommand(IEnumerable<Guid> ids)
		{
			return CriteriaBuilder.GetDeleteCommand(TableName) + CriteriaBuilder.GetIDSCommand("ID", ids);
		}

		#endregion
	}
}
