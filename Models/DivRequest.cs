using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models
{
	public class DivRequest
	{
		[JsonPropertyName("Dividend")]
		public float Dividend { get; set; }

		[JsonPropertyName("Divisor")]
		public float Divisor { get; set; }

	}
}
