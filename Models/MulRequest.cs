
using System.Collections.Generic;


namespace Models
{
	public class MulRequest : IOperation
	{
		public IEnumerable<float> Factors { get; set; }
	}
}
