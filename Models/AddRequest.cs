
using System.Collections.Generic;


namespace Models
{
	public class AddRequest :IOperation
	{
		public IEnumerable<float> Addens { get; set; }
	}
}
