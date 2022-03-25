﻿
using System;
using System.Collections.Generic;
using System.Linq;
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
			if (mult.Factors != null)
			{
				if (headers.ContainsKey("X-Evi-Tracking-Id"))
				{
					headers.TryGetValue("X-Evi-Tracking-Id", out values);
					key = values.First();
				}
				List<float> lista = mult.Factors;

				float factor = lista[0];
				for (int i = 1; i < lista.Count; i++)
				{
					factor *= lista[i];
				}

				MulResponse responseMul = new MulResponse
				{
					Product = factor
				};

				if (!key.Equals(""))
				{

					Operation p = new Operation
					{
						Oper = "Mul",
						Calculation = string.Join("*", lista) + "=" + factor,
						Date = DateTime.Now.ToString()
					};

					Persistence.Add(key, p);


				}
				response = JsonConvert.SerializeObject(responseMul);
			}
			else
			{
				_logger.LogError("Bad request MulRequest is null");
				Error error = new Error
				{

					ErrorCode = "Bad Request",
					ErrorMessage = "Error addens is null",
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
