
using System.Text.Json.Serialization;


namespace Models
{
	public class SubResponse : IOperation
	{

		[JsonPropertyName("Difference")]
		public float? Difference { get; set; }
	}
}
