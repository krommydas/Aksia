using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
	internal class FieldParser<T>
	{
		public FieldParser(String name) { this.Name = name; }

		internal String Name { get; private set; }

		private Boolean sqlValueDirty = false;
		private String mSqlValue;
		internal string SqlValue
		{
			get
			{
				if (valueDirty)
				{
					mSqlValue = Conversions.ValueToSql<T>(mValue);
					valueDirty = false;
				}

				return mSqlValue;
			}
			set
			{
				mSqlValue = value;
				sqlValueDirty = true;
			}
		}

		private Boolean valueDirty = false;
		private T mValue;
		internal T Value
		{
			get
			{
				if (sqlValueDirty)
				{
					mValue = Conversions.ValueFromSql<T>(mSqlValue);
					sqlValueDirty = false;
				}

				return mValue;
			}
			set
			{
				mValue = value;
				valueDirty = true;
			}

		}
	}
}
