using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using Newtonsoft.Json;

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
		public string Query([FromBody] IdRequest id)
		{
			string response;
			Console.WriteLine(id);
			_logger.LogInformation("Processing history");
			if (id == null)
			{
				_logger.LogError("The request is invalid: id is null");
				Error error = new Error
				{
					ErrorCode = "Bad Request",
					ErrorMessage = "Error id is null",
					ErrorStatus = ((int)HttpStatusCode.BadRequest)


				};

				response = JsonConvert.SerializeObject(error);
				Response.StatusCode = error.ErrorStatus;
			}
			else
			{
				response = JsonConvert.SerializeObject(Persistence.Oper[id.Id]);
				_logger.LogInformation("Processing Mul - DONE");
			}

			return response;
		}
	}
}
