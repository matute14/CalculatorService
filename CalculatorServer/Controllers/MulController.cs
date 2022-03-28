
using System;
using System.Collections.Generic;
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
	[Route("/mul")]
	public class MulController : ControllerBase
	{

		private readonly ILogger<MulController> _logger;

		public MulController(ILogger<MulController> logger)
		{
			_logger = logger;
		}

		[HttpPost]
		public string Multiplicar([FromBody] MulRequest mult)
		{
			var headers = Request.Headers;
			string key = "";
			var response = "";
			StringValues values;

			_logger.LogInformation("Processing Mul");
			if (mult.Factors != null)
			{
				if (headers.ContainsKey(Variables.KeyId))
				{
					headers.TryGetValue(Variables.KeyId, out values);
					key = values.First();
				}
				IEnumerable<float> lista = mult.Factors;

				float factor = lista.First();

				for (int i = 1; i < lista.Count(); i++)
				{
					factor *= lista.ElementAt(i);
				}

				MulResponse responseMul = new MulResponse
				{
					Product = factor
				};

				if (!key.Equals(string.Empty))
				{
					_logger.LogInformation($"Processing persist operation {Variables.KeyId}= {key}");
					Operation p = new Operation
					{
						Oper = "Mul",
						Calculation = string.Join("*", lista) + "=" + factor,
						Date = DateTime.Now.ToString()
					};

					Persistence.Add(key, p);


				}
				_logger.LogInformation("Processing Mul - DONE");
				response = JsonConvert.SerializeObject(responseMul);
			}
			else
			{
				_logger.LogError("The request is invalid: dividend or divisor is null");
				Error error = new Error
				{

					ErrorCode = "Bad Request",
					ErrorMessage = "Error addens is null",
					ErrorStatus = ((int)HttpStatusCode.BadRequest)
				};

				Response.StatusCode = error.ErrorStatus;
				response = JsonConvert.SerializeObject(error);
			}
			return response;

		}
	}
}
