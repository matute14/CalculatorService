using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorServer.Controllers
{
	[ApiController]
	[Route("/sub")]
	public class SubController : ControllerBase
	{
		/*
		private static readonly string[] Summaries = new[]
		{
			"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
		};
		*/
		private readonly ILogger<AddController> _logger;

		public SubController(ILogger<AddController> logger)
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
		public Resta Restar([FromBody] Sub sub)
		{
			var headers = Request.Headers;
			string key = "";
			StringValues values;
			if (headers.ContainsKey("X-Evi-Tracking-Id"))
			{
				headers.TryGetValue("X-Evi-Tracking-Id", out values);
				key = values.First();
			}
			Resta restaResponse = new Resta
			{
				Difference = sub.Minuend - sub.Substrahen
			};

			if (!key.Equals(""))
			{
				Operation p = new Operation
				{
					Oper = "Sub",
					Calculation = sub.Minuend+"-"+sub.Substrahen + "=" + restaResponse.Difference,
					Date = DateTime.Now.ToString()
				};

				Persistence.Add(key, p);
			}

			return restaResponse;
		}
	}
}
