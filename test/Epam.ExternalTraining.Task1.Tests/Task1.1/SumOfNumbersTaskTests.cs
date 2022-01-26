using Epam.ExternalTraining.Abstractions.Task1_1;
using Epam.ExternalTraining.Task1.TheMagnificentTen;
using FluentAssertions;
using NUnit.Framework;

namespace Epam.ExternalTraining.Task1.Tests
{
	/// <summary> Task 1.1.5 - Sum of numbers (sum of numbers divisible by 3 and 5) </summary>
	public class SumOfNumbersTaskTests : ConsoleTestBase
	{
		private ISumOfNumbersTask _sumOfNumbersTask;

		[SetUp]
		public void Setup()
		{
			_sumOfNumbersTask = new SumOfNumbersTask();
		}


		[TestCase(50, 543)]
		[TestCase(1000, 233168)]
		[TestCase(28622, 191138670)]
		[TestCase(18624, 80919419)]
		public void Run_RegularNumbers_ShouldWriteTheAreaResult(int maxNumber, int expectedResult)
		{
			// Arrange
			SetConsoleInput(maxNumber.ToString());

			var outputSb = BindConsoleOutput();

			// Act
			_sumOfNumbersTask.Run();

			// Assert
			var output = outputSb.ToString().TrimEnd('\r', '\n');
			_testOutput.WriteLine(output);

			output.Should().EndWith(expectedResult.ToString());
		}
	}
}