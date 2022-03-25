using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models
{
	public class SqrtRequest
	{
		[JsonPropertyName("Number")]
		public float Number { get; set; }
	}
}
