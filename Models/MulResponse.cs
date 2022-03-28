
using System.Text.Json.Serialization;


namespace Models
{
	public class MulResponse : IOperation
	{
		[JsonPropertyName("Product")]
		public float Product { set; get; }
	}
}
