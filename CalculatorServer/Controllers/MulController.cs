
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using Models;

namespace CalculatorServer.Controllers
{
	[ApiController]
	[Route("/mul")]
	public class MulController : ControllerBase
	{
		/*
		private static readonly string[] Summaries = new[]
		{
			"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
		};
		*/
		private readonly ILogger<MulController> _logger;

		public MulController(ILogger<MulController> logger)
		{
			_logger = logger;
		}
		/*
		[HttpGet]
		public IEnumerable<WeatherForecast> Get()
		{
			var rng = new Random();
			return Enumerable.Range(1, 5).Select(index => new WeatherForecast
			{
				Date = DateTime.Now.AddDays(index),
				TemperatureC = rng.Next(-20, 55),
				Summary = Summaries[rng.Next(Summaries.Length)]
			})
			.ToArray();
		}
		*/
		[HttpPost]
		public Multiplicacion Multiplicar([FromBody] Mult mult)
		{

			var headers = Request.Headers;
			string key = "";
			StringValues values;
			if (headers.ContainsKey("X-Evi-Tracking-Id"))
			{
				headers.TryGetValue("X-Evi-Tracking-Id", out values);
				key = values.First();
			}
			List<float> lista = mult.Factors;

			float factor=lista[0];
			for (int i = 1; i<lista.Count ; i++)
			{
				factor *= lista[i];
			}

			Multiplicacion response=new Multiplicacion
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

			return response;
		}
	}
}
