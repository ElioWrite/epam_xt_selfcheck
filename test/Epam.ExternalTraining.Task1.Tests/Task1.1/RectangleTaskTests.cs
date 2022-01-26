using Epam.ExternalTraining.Abstractions;
using Epam.ExternalTraining.Abstractions.Task1_1;
using Epam.ExternalTraining.Task1.TheMagnificentTen;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Text.RegularExpressions;

namespace Epam.ExternalTraining.Task1.Tests
{
	/// <summary> Task 1.1.1 - Rectangle (calculate area) </summary>
	public class RectangleTaskTests : ConsoleTestBase
	{
		private IRectangleTask _rectangleTask;

		[SetUp]
		public void Setup()
		{
			_rectangleTask = new RectangleTask();
		}


		[TestCase(2,2,4)]
		[TestCase(8235, 15326, 126209610)]
		public void Run_RegularNumbers_ShouldWriteTheAreaResult(int a, int b, int expectedResult)
		{
			// Arrange
			SetConsoleInput(a.ToString(), b.ToString());

			var outputSb = BindConsoleOutput();

			// Act
			_rectangleTask.Run();

			// Assert
			var output = outputSb.ToString().TrimEnd('\r', '\n');
			_testOutput.WriteLine(output);

			output.Should().EndWith(expectedResult.ToString(), "with the correct input, a number is expected");
		}

		[TestCase(0, 2), TestCase(-1, 2)]
		[TestCase(2, 0), TestCase(2, -254)]
		[TestCase(0, 0), TestCase(-242743, 0)]
		public void Run_ZeroOrNegative_ShouldWriteAnErrorMessage(int a, int b)
		{
			// Arrange
			SetConsoleInput(a.ToString(), b.ToString());

			var outputSb = BindConsoleOutput();

			// Act
			_rectangleTask.Run();

			// Assert
			var output = outputSb.ToString().TrimEnd('\r', '\n');
			_testOutput.WriteLine(output);

			output.Should().NotMatchRegex(@"\n-?\d+$", "with incorrect input, an error is expected");
		}
	}
}