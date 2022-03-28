

namespace Models
{
	public class Error : IOperation
	{
		public string ErrorCode { get; set; }
		public int ErrorStatus { get; set; }

		public string ErrorMessage { get; set; }
	}
}
