
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CalculatorServer.Controllers
{
	[Microsoft.AspNetCore.Mvc.ApiController]
	[Microsoft.AspNetCore.Mvc.Route("/sqrt")]
	public class SqrtController : Microsoft.AspNetCore.Mvc.ControllerBase
	{
		private readonly ILogger<SqrtController> _logger;

		public SqrtController(ILogger<SqrtController> logger)
		{
			_logger = logger;
		}
		[Microsoft.AspNetCore.Mvc.HttpPost]
		public SqrtResponse Sqrt([System.Web.Http.FromBody] SqrtRequest sqrt) //HttpResponseMessage
		{
			_logger.LogTrace("user ");
			var headers = Request.Headers;
			string key = "";
			SqrtResponse sqrtresponse=new SqrtResponse {
			Square=0};
			StringValues values;
			if (headers.ContainsKey("X-Evi-Tracking-Id"))
			{
				headers.TryGetValue("X-Evi-Tracking-Id", out values);
				key = values.First();
			}


			if (sqrt.Number < 1)
			{
				var message = "Error number menor que 0";// string.Format("Valor desde","");
				//return new HttpResponseMessage();//Request.CreateErrorResponse(HttpStatusCode.BadRequest, message);
			}
			else
			{
				sqrtresponse = new SqrtResponse
				{
					Square = (float)Math.Sqrt(sqrt.Number)
				};

				if (!key.Equals(""))
				{
					Operation p = new Operation
					{
						Calculation = "Sqrt",
						Oper = " Sqrt " + sqrt.Number + " =" + sqrtresponse.Square,
						Date = Request.Headers.ContainsKey("Date").ToString()
					};
					Persistence.Add(key, p);
				}
				return sqrt;
				//return Request.CreateResponse(HttpStatusCode.OK, sqrtresponse);
			}

		}


	}
}
