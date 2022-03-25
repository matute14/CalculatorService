using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models
{
	public class Sub
	{
		[JsonPropertyName("Minuend")]
		public float Minuend { get; set; }
		public float Substrahen { get; set; }

	}
}
