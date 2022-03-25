﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
	public static class Persistence
	{

		public static Dictionary<string, OperationsRequest> Oper { get; set; } = new Dictionary<string, OperationsRequest>();

		public static void Add(string key, Operation operation)
		{
			if (Oper.ContainsKey(key))
			{
				Oper[key].Operations.Add(operation);
			}
			else
			{
				OperationsRequest operacion = new OperationsRequest();
				operacion.Operations.Add(operation);

				Oper.Add(key, operacion);
			}

		}

	}
}