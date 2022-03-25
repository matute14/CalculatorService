
using System.Text.Json.Serialization;


namespace Models
{
	public class SubRequest
	{
		[JsonPropertyName("Minuend")]
		public float? Minuend { get; set; }
		public float? Substrahen { get; set; }

	}
}
