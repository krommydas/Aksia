using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Data.Linq.Mapping;
using CommonsSystem;

namespace DataAccess
{
    public abstract class Repository
    {
		internal static IEnumerable<T> Get<T>(SqlCommand selectCommand) where T : IDataObject
		{
			List<T> result = new List<T>();

			SqlConnection connection = Context.Instance.DBConnection;
			selectCommand.Connection = connection;

			try
			{
				SqlDataReader reader = selectCommand.ExecuteReader();

				while (reader.Read())
				{
					T item = Activator.CreateInstance<T>();
					item.ParseSqlRow((IDataRecord)reader);
					result.Add(item);
				}

				return result;
			}
			catch(Exception e)
			{
				// catch(SqlException) something to catch relative scope exceptions
				throw e;
			}
			finally
			{
				connection.Close();
			}
		} 

		internal static void Persist(IEnumerable<SqlCommand> commands)
		{
			SqlConnection connection = Context.Instance.DBConnection;
			SqlTransaction transaction = connection.BeginTransaction();

			try
			{
				foreach (var command in commands)
				{
					command.Connection = connection;
					command.ExecuteNonQuery();
				}
				transaction.Commit();
			}
			catch (Exception e)
			{
				transaction.Rollback();
				// catch(SqlException) something to catch relative scope exceptions
				throw e;
			}
			finally
			{
				connection.Close();
			}
		}

		internal static SqlCommand FetchCommand(string sql)
		{
			SqlCommand cmd = new SqlCommand();

			cmd.CommandText = sql;
			cmd.CommandType = CommandType.Text;

			return cmd;
		}
    }
}
