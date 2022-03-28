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
	[Route("/div")]
	public class DivController : ControllerBase
	{
		private readonly ILogger<DivController> _logger;

		public DivController(ILogger<DivController> logger)
		{
			_logger = logger;
		}
		[HttpPost]
		public string Div([FromBody] DivRequest div)
		{

			var headers = Request.Headers;
			string key = "";
			string repsonse = "";
			DivResponse divResponse = new DivResponse();
			StringValues values;
			_logger.LogInformation("Processing Div");

			if (headers.ContainsKey("X-Evi-Tracking-Id"))
			{
				headers.TryGetValue("X-Evi-Tracking-Id", out values);
				key = values.First();
			}
			if (div.Dividend.HasValue&& div.Divisor.HasValue)
			{
				_logger.LogError("Error Bad Request");
				if (div.Divisor == 0)
				{
					Error error = new Error
					{
						ErrorCode = "Bad Request",
						ErrorMessage = "Error cant do a negative square root",
						ErrorStatus = 400
					};
					//throw DivideByZeroException();
					Response.StatusCode = error.ErrorStatus;
					repsonse = JsonConvert.SerializeObject(error);
				}
				else
				{

					divResponse.Quotient = (float)Math.Floor(div.Dividend.Value / div.Divisor.Value);
					divResponse.Remainder = div.Dividend.Value % div.Divisor.Value;

					if (!key.Equals(""))
					{
						_logger.LogTrace("Persist div");
						Operation p = new Operation
						{
							Oper = "Div",
							Calculation = div.Dividend.Value + "/" + div.Dividend.Value + "=" + divResponse.Quotient,
							Date = DateTime.Now.ToString()
						};

						Persistence.Add(key, p);
					}
					_logger.LogInformation("Processing Div - DONE");
					repsonse = JsonConvert.SerializeObject(divResponse);

				}
			}
			else
			{
				_logger.LogError("The request is invalid: dividend or divisor is null");
				Error error = new Error
				{
					ErrorCode = "Bad Request",
					ErrorMessage = "Error dividen & divisor is null",
					ErrorStatus = 400
				};
				//throw DivideByZeroException();
				Response.StatusCode = error.ErrorStatus;
				repsonse = JsonConvert.SerializeObject(error);
			}
			return repsonse;

		}

		private Exception DivideByZeroException()
		{
			throw new NotImplementedException();
		}
	}
}
