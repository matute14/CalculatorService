
using System.Text.Json.Serialization;

namespace Models
{
	public class Operation : IOperation
	{
		[JsonPropertyName("Operation")]
		public string Oper { get; set; }

		public string Calculation { get; set; }

		public string Date { get; set; }

	}
}
