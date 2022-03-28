
using System.Text.Json.Serialization;


namespace Models
{
	public class DivResponse : IOperation
	{
		[JsonPropertyName("Quotient")]
		public float Quotient { get; set; }

		[JsonPropertyName("Remainder")]
		public float Remainder { get; set; }
	}
}
