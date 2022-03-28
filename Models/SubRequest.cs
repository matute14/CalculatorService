
using System.Text.Json.Serialization;


namespace Models
{
	public class SubRequest : IOperation
	{
		[JsonPropertyName("Minuend")]
		public float? Minuend { get; set; }
		public float? Substrahen { get; set; }

	}
}
