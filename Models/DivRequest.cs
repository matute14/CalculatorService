
using System.Text.Json.Serialization;


namespace Models
{
	public class DivRequest
	{
		[JsonPropertyName("Dividend")]
		public float? Dividend { get; set; }

		[JsonPropertyName("Divisor")]
		public float? Divisor { get; set; }

	}
}
