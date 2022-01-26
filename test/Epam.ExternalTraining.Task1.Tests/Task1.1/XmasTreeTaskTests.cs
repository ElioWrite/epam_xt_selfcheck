using Epam.ExternalTraining.Abstractions.Task1_1;
using Epam.ExternalTraining.Task1.TheMagnificentTen;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace Epam.ExternalTraining.Task1.Tests
{
	/// <summary> Task 1.1.4 - X-mas tree (a tree of triangles) </summary>
	public class XmasTreeTaskTests : ConsoleTestBase
	{
		private IXmasTreeTask _xmasTreeTask;

		[SetUp]
		public void Setup()
		{
			_xmasTreeTask = new XmasTreeTask();
		}

		#region Test Cases

		public static IEnumerable<TestCaseData> Run_RegularNumbers_ShouldDrawTheXmasTree_TestCases()
		{
			yield return new TestCaseData(1, "*");
			yield return new TestCaseData(3, AdjustStringForTests(Properties.Resources.XmasTreeTaskTests_ExpectedOutputFor_3));
			yield return new TestCaseData(15, AdjustStringForTests(Properties.Resources.XmasTreeTaskTests_ExpectedOutputFor_15));
		}

		[TestCaseSource(nameof(Run_RegularNumbers_ShouldDrawTheXmasTree_TestCases))]
		#endregion
		public void Run_RegularNumbers_ShouldDrawTheXmasTree(int n, string expectedResult)
		{
			// Arrange
			SetConsoleInput(n.ToString());
			var outputSb = BindConsoleOutput();

			// Act
			_xmasTreeTask.Run();

			// Assert
			var output = outputSb.ToString().TrimEnd('\r', '\n');
			_testOutput.WriteLine(output);

			output.Should().EndWith(expectedResult);
		}
	}
}