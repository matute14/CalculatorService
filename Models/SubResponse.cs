
using System.Text.Json.Serialization;


namespace Models
{
	public class SubResponse
	{

		[JsonPropertyName("Difference")]
		public float? Difference { get; set; }
	}
}
