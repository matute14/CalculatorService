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
		public string Sumar([FromBody] AddRequest lista)
		{
			_logger.LogInformation("user add operation");
			var headers = Request.Headers;
			string key="";
			var response = "";
			StringValues values;
			if (lista.Addens != null)
			{
				if (headers.ContainsKey("X-Evi-Tracking-Id"))
				{
					headers.TryGetValue("X-Evi-Tracking-Id", out values);
					key = values.First();
				}

				AddResponse sum = new AddResponse
				{
					Sum = lista.Addens.Sum()
				};

				if (!key.Equals(""))
				{
					Operation p = new Operation
					{
						Oper = "Sum",
						Calculation = string.Join("+", lista.Addens) + "=" + sum.Sum,
						Date = DateTime.Now.ToString()
					};

					Persistence.Add(key, p);
				}
				_logger.LogInformation("Add Succees");
				response = JsonConvert.SerializeObject(sum);

			}
			else
			{
				_logger.LogError("Bad request addens is null");
				Error error = new Error
				{

					ErrorCode = "Bad Request",
					ErrorMessage = "Error addens is null",
					ErrorStatus = 400
				};
				//throw DivideByZeroException();
				Response.StatusCode = error.ErrorStatus;
				response= JsonConvert.SerializeObject(error);
			}
			return response;

		}
	}
}
