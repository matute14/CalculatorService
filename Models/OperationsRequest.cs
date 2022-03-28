
using System.Collections.Generic;


namespace Models
{
	public  class OperationsRequest : IOperation
	{
		public  List<Operation> Operations { get; set; } = new List<Operation>();
	}
}
