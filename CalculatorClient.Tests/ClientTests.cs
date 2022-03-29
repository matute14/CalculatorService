using NUnit.Framework;
using CalculatorClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CalculatorClient.Tests
{
	[TestFixture()]
	public class ClientTests
	{
		/*
		[Test()]
		public void MainTest()
		{
		//	Assert.Fail();
			//Client.Sum();

		}
		*/
		[Test]
		public void AddTest()
		{


			try
			{
				var stringReader = new StringReader("5\r\ns\r\n5\r\nn");
				Console.SetIn(stringReader);
				var stringWriter = new StringWriter();
				Console.SetOut(stringWriter);
				Client.Sum();

				var outp = stringWriter.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
				var p = outp[outp.Length - 1];
				Assert.AreEqual("10",p );
				Assert.IsTrue(true);
			}
			catch
			{
				Assert.IsTrue(false);
			}
		}
		[Test]
		public void SqrtTest()
		{


			try
			{
				var stringReader = new StringReader("36\r\n");
				Console.SetIn(stringReader);
				var stringWriter = new StringWriter();
				Console.SetOut(stringWriter);
				Client.Sqrt();

				var outp = stringWriter.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
				var p = outp[outp.Length - 1];
				Assert.AreEqual("6", p);
				Assert.IsTrue(true);
			}
			catch
			{
				Assert.IsTrue(false);
			}
		}
		[Test]
		public void MulTest()
		{


			try
			{
				var stringReader = new StringReader("5\r\ns\r\n2\r\nn");
				Console.SetIn(stringReader);
				var stringWriter = new StringWriter();
				Console.SetOut(stringWriter);
				Client.Mul();

				var outp = stringWriter.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
				var p = outp[outp.Length - 1];
				Assert.AreEqual("10", p);
				Assert.IsTrue(true);
			}
			catch
			{
				Assert.IsTrue(false);
			}
		}
		[Test]
		public void SubTest()
		{


			try
			{
				var stringReader = new StringReader("20\r\n10\r\n");
				Console.SetIn(stringReader);
				var stringWriter = new StringWriter();
				Console.SetOut(stringWriter);
				Client.Sub();

				var outp = stringWriter.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
				var p = outp[outp.Length - 1];
				Assert.AreEqual("10", p);
				Assert.IsTrue(true);
			}
			catch
			{
				Assert.IsTrue(false);
			}
		}

		[Test]
		public void DivTest()
		{


			try
			{
				var stringReader = new StringReader("20\r\n2\r\n");
				Console.SetIn(stringReader);
				var stringWriter = new StringWriter();
				Console.SetOut(stringWriter);
				Client.Division();

				var outp = stringWriter.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
				var p = outp[outp.Length - 1];
				Assert.AreEqual("10", p);
				Assert.IsTrue(true);
			}
			catch
			{
				Assert.IsTrue(false);
			}
		}

	}
}