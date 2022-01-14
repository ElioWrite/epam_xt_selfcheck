﻿namespace Epam.ExternalTraining.Abstractions.Task1_1
{
	/// <summary><b>1.1.2. TRIANGLE</b></summary>
	/// <remarks>
	/// Написать программу, которая запрашивает с клавиатуры число N и выводит на экран следующее «изображение», состоящее из N строк:
	///	<para>
	///		(притворимся, что здесь изображение <i>прямоугольного</i> треугольника с нарастающей к низу шириной. 
	///		Intellisense все равно не сможет правильно изобразить)
	/// </para>
	/// </remarks>
	public interface ITriangleTask
	{
		/// <summary>
		/// Метод должен содержать логику, считывающую пользовательский ввод из консоли и выводящий результат обратно в консоль.
		/// </summary>
		/// <remarks>
		/// <para> Пример ввода: "1", "5", "15" </para>
		/// <para> Вывод может быть произвольным, но он должен оканчиваться строками, составляющими треугольник. </para>
		/// </remarks>
		void Run();
	}
}
