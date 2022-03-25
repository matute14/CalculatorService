
using System.Text.Json.Serialization;


namespace Models
{
	public class SqrtResponse
	{
		[JsonPropertyName("Square")]
		public float? Square { get; set; }
	}
}
