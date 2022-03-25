﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CalculatorService
{
	/*
	public class Addens
	{
		public List<float> Adden { get; set; }
	}
	*/
	public class Client
	{

		public static HttpClient client = new HttpClient();
		public static void Main(string[] args)
		{
			Menu();
		}

		public static void Menu()
		{
			Console.WriteLine("1 Suma:");
			Console.WriteLine("2 Resta:");
			Console.WriteLine("3 Multiplicacion:");
			Console.WriteLine("4 Division:");
			int opc = 0;
			string num = Console.ReadLine();
			bool validacion = Int32.TryParse(num,out opc);

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
					case 4:
						Sqrt();
						break;


				}
			}


			Console.ReadLine();

		}
		public static void Division()
		{
			float dividendo, divisor;
			Console.WriteLine("Dividendo...");
			if (float.TryParse(Console.ReadLine(), out dividendo))
			{
				Console.WriteLine("Divisor...");
				if (float.TryParse(Console.ReadLine(), out divisor))
				{

					DivRequest div = new DivRequest
					{
						Dividenc = dividendo,
						Divisor = divisor
					};
					var myContent = JsonConvert.SerializeObject(div);
					Console.WriteLine(myContent.ToString());
					var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
					var byteContent = new ByteArrayContent(buffer);
					byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

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

			Add addens = new Add {
				Addens = numeros
			};


			var myContent = JsonConvert.SerializeObject(addens);
			Console.WriteLine(myContent.ToString());
			var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
			var byteContent = new ByteArrayContent(buffer);
			byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
			var result = client.PostAsync("http://localhost:5000/sum", byteContent).Result;

			Console.WriteLine(result.Content.ReadAsStringAsync().Result.ToString());
			//Console.WriteLine("la suma es :"+numeros.Sum());

		}
		public static void Mul()
		{
			List<float> numeros;
			Console.WriteLine("Multiplicando...");

			numeros = ListaDeNumeros();

			Mult factors = new Mult
			{
				Factors = numeros
			};


			var myContent = JsonConvert.SerializeObject(factors);
			Console.WriteLine(myContent.ToString());
			var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
			var byteContent = new ByteArrayContent(buffer);
			byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
			var result = client.PostAsync("http://localhost:5000/mul", byteContent).Result;

			Console.WriteLine(result.Content.ReadAsStringAsync().Result.ToString());


		}

		static void Sub()
		{
			float minuendo, substraendo;

			Console.WriteLine("Restando...");

			Console.WriteLine("Minuendo");
			if (float.TryParse(Console.ReadLine(), out minuendo))
			{
				Console.WriteLine("subtraendo");
				if (float.TryParse(Console.ReadLine(), out substraendo))
				{
					Sub sub = new Sub
					{
					Minuend =minuendo,
					Substrahen= substraendo

				};
					var myContent = JsonConvert.SerializeObject(sub);
					Console.WriteLine(myContent.ToString());
					var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
					var byteContent = new ByteArrayContent(buffer);
					byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
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


		static List<float> ListaDeNumeros()
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