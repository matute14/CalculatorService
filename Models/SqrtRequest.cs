
using System.Text.Json.Serialization;


namespace Models
{
	public class SqrtRequest : IOperation
	{
		[JsonPropertyName("Number")]
		public float? Number { get; set; }
	}
}
