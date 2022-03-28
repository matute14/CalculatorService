
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
	[Route("/sqrt")]
	public class SqrtController : ControllerBase
	{
		private readonly ILogger<SqrtController> _logger;

		public SqrtController(ILogger<SqrtController> logger)
		{
			_logger = logger;
		}
		[Microsoft.AspNetCore.Mvc.HttpPost]
		public string Sqrt([System.Web.Http.FromBody] SqrtRequest sqrt)
		{
			_logger.LogInformation("Processing Sqrt ");
			var headers = Request.Headers;
			string key = "";
			var response="";
			if (sqrt.Number.HasValue)
			{
				SqrtResponse sqrtresponse = new SqrtResponse
				{
					Square = 0
				};
				StringValues values;
				if (headers.ContainsKey("X-Evi-Tracking-Id"))
				{
					headers.TryGetValue("X-Evi-Tracking-Id", out values);
					key = values.First();
				}

				if (sqrt.Number < 1)
				{
					_logger.LogError("The request is invalid: number<0");

					Error error = new Error
					{
						ErrorCode = "Bad Request",
						ErrorMessage = "Error cant do a negative square root",
						ErrorStatus = 400

					};

					response = JsonConvert.SerializeObject(error);
					Response.StatusCode = error.ErrorStatus;

				}
				else
				{
					sqrtresponse = new SqrtResponse
					{
						Square = (float)Math.Sqrt(sqrt.Number.Value)
					};

					if (!key.Equals(""))
					{
						Operation p = new Operation
						{
							Calculation = "Sqrt",
							Oper = " Sqrt " + sqrt.Number.Value + " =" + sqrtresponse.Square,
							Date = Request.Headers.ContainsKey("Date").ToString()
						};
						Persistence.Add(key, p);

					}
					_logger.LogInformation("Processing Sqrt - DONE");
					response = JsonConvert.SerializeObject(sqrtresponse);
				}
			}
			else
			{
				_logger.LogError("The request is invalid: is null");
				Error error = new Error
				{
					ErrorCode = "Bad Request",
					ErrorMessage = "Error Number is null",
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
