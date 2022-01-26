using Epam.ExternalTraining.Abstractions.Task1_1;
using Epam.ExternalTraining.Task1.TheMagnificentTen;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace Epam.ExternalTraining.Task1.Tests
{
	/// <summary> Task 1.1.3 - Another triangle (isosceles triangle) </summary>
	public class AnotherTriangleTaskTests : ConsoleTestBase
	{
		private IAnotherTriangleTask _anotherTriangleTask;

		[SetUp]
		public void Setup()
		{
			_anotherTriangleTask = new AnotherTriangleTask();
		}

		#region Test Cases

		public static IEnumerable<TestCaseData> Run_RegularNumbers_ShouldDrawTheIsoscelesTriangle_TestCases()
		{
			yield return new TestCaseData(1, "*");
			yield return new TestCaseData(3, AdjustStringForTests(Properties.Resources.AnotherTriangleTests_ExpectedOutputFor_3));
			yield return new TestCaseData(15, AdjustStringForTests(Properties.Resources.AnotherTriangleTests_ExpectedOutputFor_15));
		}

		[TestCaseSource(nameof(Run_RegularNumbers_ShouldDrawTheIsoscelesTriangle_TestCases))]
		#endregion
		public void Run_RegularNumbers_ShouldDrawTheIsoscelesTriangle(int n, string expectedResult)
		{
			// Arrange
			SetConsoleInput(n.ToString());
			var outputSb = BindConsoleOutput();

			// Act
			_anotherTriangleTask.Run();

			// Assert
			var output = outputSb.ToString().TrimEnd('\r', '\n');
			_testOutput.WriteLine(output);

			output.Should().EndWith(expectedResult);
		}
	}
}