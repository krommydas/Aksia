using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
	public class UserAddress : IDataObject
	{
		private const String TableName = "Adress";

		#region Fields

		private FieldParser<String> mName = new FieldParser<string>("Name");
		public String Name { get { return this.mName.Value; } set { this.mName.Value = value; } }

		private FieldParser<Guid> mID = new FieldParser<Guid>("ID");
		public Guid ID { get { return this.mID.Value; } set { this.mID.Value = value; } }

		private FieldParser<Guid> mUser = new FieldParser<Guid>("UserID");
		public Guid User { get { return this.mUser.Value; } set { this.mUser.Value = value; } }

		private FieldParser<String> mCountry = new FieldParser<String>("Country");
		public String Country { get { return this.mCountry.Value; } set { this.mCountry.Value = value; } }

		private FieldParser<String> mPostalCode = new FieldParser<String>("PostalCode");
		public String PostalCode { get { return this.mPostalCode.Value; } set { this.mPostalCode.Value = value; } }

		private FieldParser<String> mCity = new FieldParser<String>("City");
		public String City { get { return this.mCity.Value; } set { this.mCity.Value = value; } }

		#endregion

		#region Restore From Database

		private Boolean mIsStored;

		public Boolean IsStored { get { return mIsStored; } }

		public void ParseSqlRow(System.Data.IDataRecord record)
		{
			mIsStored = true;

			try
			{
				mCountry.SqlValue = (String)record[mCountry.Name];
				mPostalCode.SqlValue = (String)record[mPostalCode.Name];
				mCity.SqlValue = (String)record[mCity.Name];
				//mName.SqlValue = (String)record[mName.Name];
				mID.SqlValue = (String)record[mID.Name];
				mUser.SqlValue = (String)record[mUser.Name];
			}
			catch (Exception e)
			{
				// handle exception somehow
				throw e;
			}
		}

		#endregion

		#region Available Commands

		public static String GetItemsCommand()
		{
			return UserAddress.GetItemsCommand(null);
		}
		public static String GetItemsCommand(IEnumerable<Guid> userIDs)
		{
			return CriteriaBuilder.GetSelectCommand(TableName) + CriteriaBuilder.GetIDSCommand("UserID", userIDs);
		}

		public static String DeleteItemsCommand(IEnumerable<Guid> userIDs)
		{
			return CriteriaBuilder.GetDeleteCommand(TableName) + CriteriaBuilder.GetIDSCommand("UserID", userIDs);
		}

		#endregion
	}
}
