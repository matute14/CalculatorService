using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Models
{
	public class Operation
	{
		[JsonPropertyName("Operation")]
		public string Oper { get; set; }

		public string Calculation { get; set; }

		public string Date { get; set; }

	}
}
