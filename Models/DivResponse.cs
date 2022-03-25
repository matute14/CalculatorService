using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models
{
	public class DivResponse
	{
		[JsonPropertyName("Quotient")]
		public float Quotient { get; set; }

		[JsonPropertyName("Remainder")]
		public float Remainder { get; set; }
	}
}
