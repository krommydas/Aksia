using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;

namespace BusinessLayer
{
	public class UserModule
	{
		public static User CreateUser()
		{
			User user = new User();
			user.ID = Guid.NewGuid();
			return user;
		}

		public static UserAddress CreateUserAddress()
		{
			UserAddress address = new UserAddress();
			address.ID = Guid.NewGuid();
			return address;
		}

		public static void Persist(User user)
		{
			// first check if we have the right to update users - authorization

			ValidationResults validation = Validate(user);
			if (!validation.Success) throw new ValidationException(validation);

			UserRepository.Persist(new User[] { user });
		}

		public static void Delete(Guid userID)
		{
			// first check if we have the right to delete that user - authorization

			UserAddressRepository.Delete(userID);
			UserRepository.Delete(userID);
		}

		public static ValidationResults Validate(User user)
		{
			return new UserValidation().Validate(user);
		}
	}
}
