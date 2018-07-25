using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using CommonsSystem;

namespace BusinessLayer
{
	public class UserAddressValidation
	{
		public IEnumerable<ValidationResult> Validate(UserAddress address)
		{
			List<ValidationResult> result = new List<ValidationResult>();

			LanguageHandler language = Context.Instance.Language;

			if (address.User == Guid.Empty)
				result.Add(new ValidationResult(language.GetText("UserAddressValidation.EmptyUser"), ValidationResultType.Error));

			if (String.IsNullOrEmpty(address.Country))
				result.Add(new ValidationResult(language.GetText("UserAddressValidation.EmptyCountry"), ValidationResultType.Error));

			return result;
		}
	}
}
