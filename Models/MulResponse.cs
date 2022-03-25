
using System.Text.Json.Serialization;


namespace Models
{
	public class MulResponse
	{
		[JsonPropertyName("Product")]
		public float Product { set; get; }
	}
}
