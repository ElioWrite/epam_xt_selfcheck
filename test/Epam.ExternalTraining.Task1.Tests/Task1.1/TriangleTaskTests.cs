using Epam.ExternalTraining.Abstractions;
using Epam.ExternalTraining.Abstractions.Task1_1;
using Epam.ExternalTraining.Task1.TheMagnificentTen;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Diagnostics;

namespace Epam.ExternalTraining.Task1.Tests
{
	/// <summary> Task 1.1.2 - Triangles (lines with increasing length) </summary>
	public class TriangleTaskTests : ConsoleTestBase
	{
		private ITriangleTask _triangleTask;

		[SetUp]
		public void Setup()
		{
			_triangleTask = new TriangleTask();
		}

		#region Test Cases

		public static IEnumerable<TestCaseData> Run_RegularNumbers_ShouldDrawTheTriangle_TestCases()
		{
			yield return new TestCaseData(1, "*");
			yield return new TestCaseData(3, AdjustStringForTests(Properties.Resources.TriangleTaskTests_ExpectedOutputFor_3));
			yield return new TestCaseData(15, AdjustStringForTests(Properties.Resources.TriangleTaskTests_ExpectedOutputFor_15));
		}

		[TestCaseSource(nameof(Run_RegularNumbers_ShouldDrawTheTriangle_TestCases))]
		#endregion
		public void Run_RegularNumbers_ShouldDrawTheTriangle(int n, string expectedResult)
		{
			// Arrange
			SetConsoleInput(n.ToString());
			var outputSb = BindConsoleOutput();

			// Act
			_triangleTask.Run();

			// Assert
			var output = outputSb.ToString().TrimEnd('\r', '\n');
			_testOutput.WriteLine(output);

			output.Should().EndWith(expectedResult);
		}
	}
}