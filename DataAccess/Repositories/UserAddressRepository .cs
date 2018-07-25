using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAccess
{
	public class UserAddressRepository : Repository
	{
		public static IEnumerable<UserAddress> GetAll()
		{
			return UserAddressRepository.GetByUserID(null);
		}

		public static IEnumerable<UserAddress> GetByUserID(IEnumerable<Guid> ids)
		{
			return Get<UserAddress>(FetchCommand(UserAddress.GetItemsCommand(ids)));
		}

		public static void Persist(IEnumerable<UserAddress> items)
		{
			List<SqlCommand> commands = new List<SqlCommand>();

			//foreach(var item in items)
			//{
			//	if (item.IsStored)
			//		commands.Add(FetchCommand(UserAddress.GetInsertCommand(item)));
			//	else
			//		commands.Add(FetchCommand(UserAddress.GetUpdateCommand(item)));
			//}

			Persist(commands);
		}

		public static void Delete(Guid userID)
		{
			Persist(new SqlCommand[] { FetchCommand(UserAddress.DeleteItemsCommand(new Guid[] { userID })) });
		}
	}
}
