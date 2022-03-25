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
	[Route("/sum")]
	public class AddController : ControllerBase
	{


		/*
		private static readonly string[] Summaries = new[]
		{
			"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
		};
		*/
		private readonly ILogger<AddController> _logger;

		public AddController(ILogger<AddController> logger)
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
		public Suma Sumar([FromBody] Add lista)
		{
			_logger.LogTrace("pepe");
			var headers = Request.Headers;
			string key="";
			StringValues values;
			if (headers.ContainsKey("X-Evi-Tracking-Id"))
			{
				headers.TryGetValue("X-Evi-Tracking-Id",out values);
				key = values.First();
			}

			Suma sum=new Suma
			{
				Sum = lista.Addens.Sum()
			};

			if (!key.Equals(""))
			{
				Operation p = new Operation {
				Oper="Sum",
				Calculation= string.Join("+",lista.Addens)+"="+sum.Sum,
				Date= DateTime.Now.ToString()
				};

				Persistence.Add(key,p);
			}
			return sum;

		}
	}
}
