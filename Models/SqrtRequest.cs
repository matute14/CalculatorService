
using System.Text.Json.Serialization;


namespace Models
{
	public class SqrtRequest
	{
		[JsonPropertyName("Number")]
		public float? Number { get; set; }
	}
}
