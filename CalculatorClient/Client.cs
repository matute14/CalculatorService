using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Models;

namespace CalculatorClient
{

	public class Client
	{

		public static HttpClient client = new HttpClient();
		public static string idTracking = "";

		public static void Main(string[] args)
		{
			Menu();
		}

		public static void Menu()
		{

			int opc;
			do
			{
				Console.WriteLine(
				@"0 Salir:
				1 Suma:
				2 Resta:
				3 Multiplicacion
				4 Division:
				5 Raiz cuadrada:
				6 Historial:");

				Console.Write("quieres persistir las operaciones : ");
				if (Console.ReadLine().Equals("s"))
				{
					Console.Write("Dime id");
					idTracking = Console.ReadLine();
				}
				Console.Write("Elija numero");
				string num = Console.ReadLine();
				bool validacion = Int32.TryParse(num, out opc);
				if (!validacion)
				{
					opc = -1;
				}

				if (validacion)
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

					}
				}

			}
			while (opc != 0);


		}
		public static void  Query()
		{
			string id;

			Console.WriteLine("Dime el id del que quieres ver historial");
			id = Console.ReadLine();
			var myContent = JsonConvert.SerializeObject(new IdRequest { Id= id });
			Console.WriteLine(myContent.ToString());
			var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
			var byteContent = new ByteArrayContent(buffer);
			byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

			byteContent.Headers.Add("X-Evi-Tracking-Id", idTracking);

			var result = client.PostAsync("http://localhost:5000/query", byteContent).Result;

			Console.WriteLine(result.Content.ReadAsStringAsync().Result.ToString());



		}
		public static void Sqrt()
		{
			float number;


			Console.WriteLine("Sqrt...");
			if (float.TryParse(Console.ReadLine(), out number))
			{

					SqrtRequest req = new SqrtRequest {
					Number=number
					};

					var myContent = JsonConvert.SerializeObject(req);
					Console.WriteLine(myContent.ToString());
					var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
					var byteContent = new ByteArrayContent(buffer);
					byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

					byteContent.Headers.Add("X-Evi-Tracking-Id",idTracking);

					var result = client.PostAsync("http://localhost:5000/sqrt", byteContent).Result;

				Console.WriteLine(result.Content.ReadAsStringAsync().Result.ToString());

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

			Console.Write("Dividendo...");
			if (float.TryParse(Console.ReadLine(), out dividendo))
			{
				Console.Write("Divisor...");
				if (float.TryParse(Console.ReadLine(), out divisor))
				{

					DivRequest div = new DivRequest
					{
						Dividend = dividendo,
						Divisor = divisor
					};
					var myContent = JsonConvert.SerializeObject(div);
					Console.WriteLine(myContent.ToString());
					var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
					var byteContent = new ByteArrayContent(buffer);
					byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
					byteContent.Headers.Add("X-Evi-Tracking-Id", idTracking);
					var result = client.PostAsync("http://localhost:5000/div", byteContent).Result;

					Console.WriteLine(result.Content.ReadAsStringAsync().Result.ToString());

				}

			}
			else
			{
				Console.WriteLine("dividendo incorrecto");
			}



		}
		public static void Sum()
		{
			List<float> numeros;
			Console.WriteLine("Sumando...");

			numeros = ListaDeNumeros();

			AddRequest addens = new AddRequest {
				Addens = numeros
			};


			var myContent = JsonConvert.SerializeObject(addens);
			Console.WriteLine(myContent.ToString());
			var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
			var byteContent = new ByteArrayContent(buffer);
			byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
			byteContent.Headers.Add("X-Evi-Tracking-Id", idTracking);
			var result = client.PostAsync("http://localhost:5000/sum", byteContent).Result;

			Console.WriteLine(result.Content.ReadAsStringAsync().Result.ToString());


		}
		public static void Mul()
		{
			List<float> numeros;
			Console.WriteLine("Multiplicando...");

			numeros = ListaDeNumeros();

			MulRequest factors = new MulRequest
			{
				Factors = numeros
			};


			var myContent = JsonConvert.SerializeObject(factors);
			Console.WriteLine(myContent.ToString());
			var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
			var byteContent = new ByteArrayContent(buffer);
			byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
			byteContent.Headers.Add("X-Evi-Tracking-Id", idTracking);
			var result = client.PostAsync("http://localhost:5000/mul", byteContent).Result;

			Console.WriteLine(JsonConvert.DeserializeObject<dynamic>(result.Content.ReadAsStringAsync().Result));

		}

		public static void Sub()
		{
			float minuendo, substraendo;

			Console.WriteLine("Restando...");

			Console.WriteLine("Minuendo");
			if (float.TryParse(Console.ReadLine(), out minuendo))
			{
				Console.WriteLine("subtraendo");
				if (float.TryParse(Console.ReadLine(), out substraendo))
				{
					SubRequest sub = new SubRequest
					{
					Minuend =minuendo,
					Substrahen= substraendo

				};
					var myContent = JsonConvert.SerializeObject(sub);
					Console.WriteLine(myContent.ToString());
					var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
					var byteContent = new ByteArrayContent(buffer);
					byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
					byteContent.Headers.Add("X-Evi-Tracking-Id", idTracking);
					var result = client.PostAsync("http://localhost:5000/sub", byteContent).Result;

					Console.WriteLine(result.Content.ReadAsStringAsync().Result.ToString());
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

		public static List<float> ListaDeNumeros()
		{
			List<float> lista = new List<float>();
			float val;
			do
			{
				Console.WriteLine("Introduciendo Numeros");

				if (float.TryParse(Console.ReadLine(), out val))
				{
					lista.Add(val);
				}
				else
				{
					Console.WriteLine("Numero no valido");
				}

				Console.WriteLine("quieres añadir un numero s/n");
			} while (Console.ReadLine().Equals("s"));

			return lista;
		}

	}
}
