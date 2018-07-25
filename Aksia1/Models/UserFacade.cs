using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccess;

namespace WebApp.Models
{
	public class UserFacade
	{
		public Guid ID { get; set; }
		public String Name { get; set; }

		public IEnumerable<UserAddressFacade> Addresses { get; set; }

		public static IEnumerable<UserFacade> Build(IEnumerable<User> users, IEnumerable<UserAddress> addresses)
		{
			List<UserFacade> result = new List<UserFacade>();

			var addressesByUser = addresses.GroupBy(x => x.User).ToDictionary(x => x.Key, y => y.ToList());

			foreach(var user in users)
			{
				UserFacade facade = new UserFacade();
				facade.ID = user.ID;
				facade.Name = user.Name;

				List<UserAddress> items;
				if (addressesByUser.TryGetValue(user.ID, out items))
					facade.Addresses = UserAddressFacade.Build(items);
			}

			return result;
		}

		public void Persist()
		{
			DataAccess.User item = DataAccess.UserRepository.GetByID(new Guid[] { this.ID }).FirstOrDefault();
			if (item == null) item = BusinessLayer.UserModule.CreateUser();

			Dictionary<Guid, DataAccess.UserAddress> addresses = DataAccess.UserAddressRepository
				.GetByUserID(new Guid[] { this.ID }).ToDictionary(x => x.ID);
			addresses.Add(Guid.Empty, null); // the new addresses fall back here

			// apply changes
			item.Name = this.Name;

			BusinessLayer.UserModule.Persist(item);

			foreach (var address in this.Addresses)
				address.Persist(addresses[address.ID]);
		}

		
	}
}