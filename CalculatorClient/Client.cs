using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Models;
using System.Text;
using Microsoft.Extensions.Logging;

namespace CalculatorClient
{

	public class Client
	{

		private static readonly HttpClient client = new HttpClient();
		private static string idTracking = "";
		private const string URL = "http://localhost:5000/";



		private  readonly ILogger<Client> _logger;

		public Client(ILogger<Client> logger)
		{
			_logger = logger;
		}

		public static void Main(string[] args)
		{
			Menu();
		}

		public static void Menu()
		{

			int opc;

			Console.Write("Quieres persistir las operaciónes : (s/n) ");
			if (Console.ReadLine().Equals("s", StringComparison.InvariantCultureIgnoreCase))
			{
				Console.Write("Dime id : ");
				idTracking = Console.ReadLine();
			}
			do
			{

				var menuOptions = "0 Salir:" + "\n1 Suma:" + "\n2 Resta:" + "\n3 Resta:" + "\n3 Multiplicacion:" + "\n4 Division:" + "\n5 Raiz cuadrada:" + "\n6 Historial:";

				Console.WriteLine(menuOptions);

				Console.Write("Elija opcion del menu : ");
				string num = Console.ReadLine();
				bool validate = Int32.TryParse(num, out opc);
				if (!validate)
				{
					opc = -1;
				}

				if (validate)
				{

					switch (opc)
					{
						case 1:

							Sum();
							break;
						case 2:
							Sub();
							break;
						case 3:
							Mul();
							break;
						case 4:
							Division();
							break;
						case 5:
							Sqrt();
							break;
						case 6:
							Query();
							break;
						default:
							Console.WriteLine("No option in menu");
							break;

					}
				}

			}
			while (opc != 0);


		}
		public static void  Query()
		{
			Console.WriteLine("Dime el id del que quieres ver historial");
			var id = Console.ReadLine();
			DoRequest("query", new IdRequest { Id = id });

		}
		public static void Sqrt()
		{

			Console.WriteLine("Sqrt... \n Dime un numero");

			if (float.TryParse(Console.ReadLine(), out var number))
			{

				var req = new SqrtRequest {
					Number=number
				};

				DoRequest("sqrt", req);

			}
			else
			{
				Console.WriteLine("Numero no valido");
			}

		}
		public static void Division()
		{
			float dividendo, divisor;
			Console.WriteLine("Dividiendo...");

			Console.Write("Dividendo:");
			if (float.TryParse(Console.ReadLine(), out dividendo))
			{
				Console.Write("Divisor:");
				if (float.TryParse(Console.ReadLine(), out divisor))
				{

					DivRequest div = new DivRequest
					{
						Dividend = dividendo,
						Divisor = divisor
					};

					DoRequest("div", div);


				}

			}
			else
			{
				Console.WriteLine("dividendo incorrecto");
			}



		}
		public static void Sum()
		{
			IEnumerable<float> numeros;
			Console.WriteLine("Sumando...");

			numeros = GetNumbers();

			AddRequest addens = new AddRequest {
				Addens = numeros
			};

			DoRequest("sum", addens);

		}
		public static void Mul()
		{

			Console.WriteLine("Multiplicando...");

			var numeros = GetNumbers();

			IOperation factors = new MulRequest
			{
				Factors = numeros
			};

			DoRequest("mul", factors);


		}

		public static void Sub()
		{
			float minuendo, substrahend;

			Console.WriteLine("Restando...");

			Console.WriteLine("Minuendo");
			if (float.TryParse(Console.ReadLine(), out minuendo))
			{
				Console.WriteLine("subtraendo");
				if (float.TryParse(Console.ReadLine(), out substrahend))
				{
					IOperation sub = new SubRequest
					{
					Minuend =minuendo,
					Substrahen= substrahend

				};
					DoRequest("sub", sub);
				}
				else
				{
					Console.WriteLine("dato mal introducido");
				}
			}
			else
			{
				Console.WriteLine("dato mal introducido");
			}
		}
		public static void DoRequest(string action,IOperation operation)
		{
			try
			{
				var myContent = JsonConvert.SerializeObject(operation);
				Console.WriteLine(myContent);
				var buffer = Encoding.UTF8.GetBytes(myContent);
				var byteContent = new ByteArrayContent(buffer);
				byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
				byteContent.Headers.Add(Variables.KeyId, idTracking);
				var result = client.PostAsync(URL + action, byteContent).Result;
				Console.WriteLine(result.Content.ReadAsStringAsync().Result);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}

		}
		public static IEnumerable<float> GetNumbers()
		{
			var lista = new List<float>();
			do
			{
				Console.WriteLine("Introduciendo Numeros");

				if (float.TryParse(Console.ReadLine(), out var val))
				{
					lista.Add(val);
				}
				else
				{
					Console.WriteLine("Numero no valido");
				}

				Console.WriteLine("quieres añadir un numero s/n");
			}
			while (Console.ReadLine().Trim().Equals("s",StringComparison.InvariantCultureIgnoreCase));

			return lista;
		}

	}
}
