using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccess;

namespace WebApp.Models
{
	public class UserAddressFacade
	{
		public Guid ID { get; set; }

		public static IEnumerable<UserAddressFacade> Build(IEnumerable<UserAddress> addresses)
		{
			List<UserAddressFacade> result = new List<UserAddressFacade>();

			return result;
		}

		public void Persist()
		{
			DataAccess.UserAddress item = DataAccess.UserAddressRepository.GetAll().FirstOrDefault();
			Persist(item);
		}

		public void Persist(DataAccess.UserAddress item)
		{
			if (item == null)
				item = BusinessLayer.UserModule.CreateUserAddress();

			//apply changes

			//persist
		}
	}
}