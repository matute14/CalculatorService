
using System.Text.Json.Serialization;


namespace Models
{
	public class SqrtResponse : IOperation
	{
		[JsonPropertyName("Square")]
		public float? Square { get; set; }
	}
}
