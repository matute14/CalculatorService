using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorClient;
using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace CalculatorClient.Tests
{
	[TestClass()]
	public class ClientTests
	{
		[TestMethod()]
		public void ClientTest()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void ClientTest1()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void MainTest()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void MenuTest()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void QueryTest()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void SqrtTest()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void DivisionTest()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void SumTest()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void MulTest()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void SubTest()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void DoRequestTestSum()
		{

			var list = new List<float>();

			list.Add(5);
			list.Add(5);
			Client.DoRequest("sqrt",new AddRequest {Addens = list });
			//Assert.
			//Assert.Fail();


		}

		[TestMethod()]
		public void GetNumbersTest()
		{
			Assert.Fail();
		}
	}
}