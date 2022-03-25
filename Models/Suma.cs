using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models
{
	public class Suma
	{
		[JsonPropertyName("Sum")]
		public float Sum { get; set; }
	}
}
