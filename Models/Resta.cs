using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models
{
	public class Resta
	{

		[JsonPropertyName("Difference")]
		public float Difference { get; set; }
	}
}
