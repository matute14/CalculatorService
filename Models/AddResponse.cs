
using System.Text.Json.Serialization;

namespace Models
{
	public class AddResponse : IOperation
	{
		[JsonPropertyName("Sum")]
		public float Sum { get; set; }
	}
}
