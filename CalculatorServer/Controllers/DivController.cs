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
	[Route("/div")]
	public class DivController : ControllerBase
	{
		private readonly ILogger<DivController> _logger;

		public DivController(ILogger<DivController> logger)
		{
			_logger = logger;
		}
		[HttpPost]
		public DivResponse Div([FromBody] DivRequest div)
		{
			var headers = Request.Headers;
			string key = "";
			DivResponse response = new DivResponse();
			StringValues values;
			if (headers.ContainsKey("X-Evi-Tracking-Id"))
			{
				headers.TryGetValue("X-Evi-Tracking-Id", out values);
				key = values.First();
			}
			if (div.Divisor == 0)
			{
				throw DivideByZeroException();
			}
			else
			{
				response.Quotient = (float)Math.Floor(div.Dividend / div.Divisor);
				response.Remainder = div.Dividend % div.Divisor;
				if (!key.Equals("")) {
					Operation p = new Operation
					{
						Oper = "Div",
						Calculation =  div.Dividend+ "/"+div.Dividend+"=" + response.Quotient,
						Date = DateTime.Now.ToString()
					};

					Persistence.Add(key, p);
				}


			}

			return response;

		}

		private Exception DivideByZeroException()
		{
			throw new NotImplementedException();
		}
	}
}
