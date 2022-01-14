using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Epam.ExternalTraining.Task1.Tests
{
	public abstract class ConsoleTestBase
	{
		protected TextWriter _testOutput;


		protected static void SetConsoleInput(params string[] inputLines)
		{
			var input = new StringReader(string.Join(Environment.NewLine, inputLines));
			Console.SetIn(input);
		}

		protected StringBuilder BindConsoleOutput()
		{
			_testOutput = Console.Out;

			var textWriter = new StringWriter();
			Console.SetOut(textWriter);

			return textWriter.GetStringBuilder();
		}

		/// <summary> Removes first empty line and adjusts line breaks to the environment equivalent </summary>
		protected static string AdjustStringForTests(string input)
		{
			return Regex.Replace(input.TrimStart('\r', '\n'), @"\r\n|\n", Environment.NewLine);
		}
	}
}