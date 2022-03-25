using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
namespace CalculatorServer.Controllers
{
	[ApiController]
	[Route("/query")]
	public class QueryController :ControllerBase
	{

		private readonly ILogger<QueryController> _logger;

		public QueryController(ILogger<QueryController> logger)
		{
			_logger = logger;
		}

		[HttpPost]
		public OperationsRequest Query([FromBody] IdRequest id)
		{

			Console.WriteLine(id);

			return Persistence.Oper[id.Id];
		}
	}
}
