using System;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using Models;
using Newtonsoft.Json;



namespace CalculatorServer.Controllers
{
	[ApiController]
	[Route("/sum")]
	public class AddController : ControllerBase
	{



		private readonly ILogger<AddController> _logger;

		public AddController(ILogger<AddController> logger)
		{
			_logger = logger;
		}

		[HttpPost]
		public string Sumar([FromBody] AddRequest requestAdd)
		{
			_logger.LogInformation("Processing Add");
			var headers = Request.Headers;
			string key="";
			var response = "";
			StringValues values;
			if (requestAdd.Addens != null)
			{
				if (headers.ContainsKey(Variables.KeyId))
				{

					headers.TryGetValue(Variables.KeyId, out values);
					key = values.First();
				}

				AddResponse sum = new AddResponse
				{
					Sum = requestAdd.Addens.Sum()
				};

				if (!key.Equals(string.Empty))
				{
					_logger.LogInformation($"Processing persist operation {Variables.KeyId}= {key}");

					Operation p = new Operation
					{
						Oper = "Sum",
						Calculation = string.Join("+", requestAdd.Addens) + "=" + sum.Sum,
						Date = DateTime.Now.ToString()
					};

					Persistence.Add(key, p);
				}
				_logger.LogInformation("Processing Add - DONE");
				response = JsonConvert.SerializeObject(sum);

			}
			else
			{
				_logger.LogError("The request is invalid: addens is null");
				Error error = new Error
				{

					ErrorCode = "Bad Request",
					ErrorMessage = "Error addens is null",
					ErrorStatus = ((int)HttpStatusCode.BadRequest)
				};
				//throw DivideByZeroException();
				Response.StatusCode = error.ErrorStatus;
				response= JsonConvert.SerializeObject(error);
			}
			return response;

		}
	}
}
