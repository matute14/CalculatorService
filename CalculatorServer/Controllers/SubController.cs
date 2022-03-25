using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using Models;
using Newtonsoft.Json;



namespace CalculatorServer.Controllers
{
	[ApiController]
	[Route("/sub")]
	public class SubController : ControllerBase
	{

		private readonly ILogger<AddController> _logger;

		public SubController(ILogger<AddController> logger)
		{
			_logger = logger;
		}

		[HttpPost]
		public string Restar([FromBody] SubRequest sub)
		{
			_logger.LogInformation("User is sub");
			var headers = Request.Headers;
			string key = "";
			StringValues values;
			var response="";
			if (sub.Minuend.HasValue && sub.Substrahen.HasValue)
			{
				if (headers.ContainsKey("X-Evi-Tracking-Id"))
				{
					headers.TryGetValue("X-Evi-Tracking-Id", out values);
					key = values.First();
				}
				SubResponse restaResponse = new SubResponse
				{
					Difference = sub.Minuend.Value - sub.Substrahen.Value
				};

				if (!key.Equals(""))
				{
					Operation p = new Operation
					{
						Oper = "Sub",
						Calculation = sub.Minuend + "-" + sub.Substrahen + "=" + restaResponse.Difference,
						Date = DateTime.Now.ToString()
					};

					Persistence.Add(key, p);
				}
				_logger.LogInformation("Sub Sucees");
				response = JsonConvert.SerializeObject(restaResponse);
			}
			else
			{
				_logger.LogError("Error Bad Request Minuend & Substahen is null");
				Error error = new Error
				{
					ErrorCode = "Bad Request",
					ErrorMessage = "Error Minuend & subsatrahen is null",
					ErrorStatus = 400
				};
				//throw DivideByZeroException();
				Response.StatusCode = error.ErrorStatus;
				response = JsonConvert.SerializeObject(error);
			}
			return response;
		}
	}
}
