// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="URB31075">
// All Right Reserved  
// </copyright>
// <summary>
//   The program.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ArithmeticCalculatorExample
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    using ArithmeticCalculator;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Пример использования арифметического каликулятора
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// The main.
        /// </summary>
        public static void Main()
        {
            const string Expression = "(10*(A1 + B2 + C10) +25) * 0.5"; // Задали арифметическое выражение
            Console.WriteLine("Expression: {0}", Expression);
            var arithmeticCalculator = ArithmeticCalculator.CreateInstance(Expression); // Создали экземпляр арифметического калькулятора

            Console.WriteLine("PostFix notation: {0}", arithmeticCalculator.PostFix); // Справочная информация Просмотр выражения в обратной польской нотации
            Console.WriteLine("VariableList:");

            arithmeticCalculator.VariableList.ForEach(Console.WriteLine); // Справочная информация Просмотр списка используемых переменных

            arithmeticCalculator.SetVariableValue("A1", 2); // Задаем значения переменных
            arithmeticCalculator.SetVariableValue("B2", 3);
            arithmeticCalculator.SetVariableValue("C10", 4);

            var result = arithmeticCalculator.Execute(); // Выполняем вычисление

            Console.WriteLine("Result: {0}", result);
        }
    }

    /// <summary>
    /// The main unit test.
    /// </summary> 
    [TestClass]
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed. Suppression is OK here.")]
    [SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1202:ElementsMustBeOrderedByAccess", Justification = "Reviewed. Suppression is OK here.")]
    public class MainUnitTest
    {
        /// <summary>
        /// The to string test.
        /// </summary>
        [TestMethod]
        public void MainTest()
        {
            Program.Main();
            Assert.IsTrue(true);
        }
    }
}