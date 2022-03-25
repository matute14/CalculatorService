
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
