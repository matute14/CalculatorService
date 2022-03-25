
using System.Text.Json.Serialization;

namespace Models
{
	public class AddResponse
	{
		[JsonPropertyName("Sum")]
		public float Sum { get; set; }
	}
}
