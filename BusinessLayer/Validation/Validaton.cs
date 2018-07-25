using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
	public enum ValidationResultType : short
	{
		Warning = 0,
		Error = 1
	}

	public class ValidationResult
	{
		public ValidationResult(string msg, ValidationResultType type)
		{
			this.Message = msg;
			this.Type = type;
		}

		public String Message { get; set; }
		public ValidationResultType Type { get; set; }
	}

	public class ValidationResults : List<ValidationResult>
	{
		public Boolean Success { get { return ((IEnumerable<ValidationResult>)this).Max(x => (short)x.Type) < 1; } }
	}

	public class ValidationException : Exception
	{
		public ValidationResults Payload { get; set; }

		public ValidationException(ValidationResult validation) : base(validation.Message) { }

		public ValidationException(ValidationResults validation) { this.Payload = validation; }
	}
}
