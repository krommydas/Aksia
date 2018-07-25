using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAccess
{
	public class UserRepository : Repository
	{
		public static IEnumerable<User> GetAll()
		{
			return UserRepository.GetByID(null);
		}

		public static IEnumerable<User> GetByID(IEnumerable<Guid> ids)
		{
			return Get<User>(FetchCommand(User.GetItemsCommand(ids)));
		}

		public static void Persist(IEnumerable<User> items)
		{
			List<SqlCommand> commands = new List<SqlCommand>();

			foreach(var item in items)
			{
				if (item.IsStored)
					commands.Add(FetchCommand(User.GetInsertCommand(item)));
				else
					commands.Add(FetchCommand(User.GetUpdateCommand(item)));
			}

			Persist(commands);
		}

		public static void Delete(Guid itemID)
		{
			Persist(new SqlCommand[] { FetchCommand(User.DeleteItemsCommand(itemID)) });
		}
	}
}
