using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using CommonsSystem;

namespace BusinessLayer
{
	public class UserValidation
	{
		public ValidationResults Validate(User user)
		{
			ValidationResults result = new ValidationResults();

			LanguageHandler language = Context.Instance.Language;

			if (String.IsNullOrEmpty(user.Name))
				result.Add(new ValidationResult(language.GetText("UserValidation.EmptyName"), ValidationResultType.Error));

			return result;
		}
	}
}
