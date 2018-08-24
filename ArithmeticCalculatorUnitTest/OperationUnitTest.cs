// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OperationUnitTest.cs" company="URB31075">
//   All Right Reserved
// </copyright>
// <summary>
//   The operation unit test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ArithmeticCalculatorUnitTest
{
    using ArithmeticCalculator;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// The operation unit test.
    /// </summary>
    [TestClass]
    public class OperationUnitTest
    {
        /// <summary>
        /// The variant 0.
        /// </summary>
        [TestMethod]
        public void Variant0()
        {
            var infix = "(3)-2";
            var arithmeticCalculator = ArithmeticCalculator.CreateInstance(infix); // Создали экземпляр арифметического калькулятора
            var result = arithmeticCalculator.Execute();
            var postfix = arithmeticCalculator.PostFix;
            Assert.AreEqual(1, result, infix + "  ->  " + postfix);
        }

        /// <summary>
        /// The variant 1.
        /// </summary>
        [TestMethod]
        public void Variant1()
        {
            var infix = "((2+3)*5)+(2+4)*(4+8)";
            var arithmeticCalculator = ArithmeticCalculator.CreateInstance(infix); // Создали экземпляр арифметического калькулятора
            var result = arithmeticCalculator.Execute();
            var postfix = arithmeticCalculator.PostFix;
            Assert.AreEqual(97M, result, infix + "  ->  " + postfix);
        }

        /// <summary>
        /// The variant 2.
        /// </summary>
        [TestMethod]
        public void Variant2()
        {
            var infix = "((2+3)*5)+(2+4)*(4+8)+3";
            var arithmeticCalculator = ArithmeticCalculator.CreateInstance(infix); // Создали экземпляр арифметического калькулятора
            var result = arithmeticCalculator.Execute();
            var postfix = arithmeticCalculator.PostFix;
            Assert.AreEqual(100M, result, infix + "  ->  " + postfix);
        }

        /// <summary>
        /// The variant 2.
        /// </summary>
        [TestMethod]
        public void Variant3()
        {
            var infix = "(-(-50+90+((((2+3)*5)+(2+4)*(4+8)+3)*4/2)+10)*-2)/5";
            var arithmeticCalculator = ArithmeticCalculator.CreateInstance(infix); // Создали экземпляр арифметического калькулятора
            var result = arithmeticCalculator.Execute();
            var postfix = arithmeticCalculator.PostFix;
            Assert.AreEqual(100M, result, infix + "  ->  " + postfix);
        }

        /// <summary>
        /// The variant 3.
        /// </summary>
        [TestMethod]
        public void Variant9()
        {
            var infix = "(-(3)-(4))";
            var arithmeticCalculator = ArithmeticCalculator.CreateInstance(infix); // Создали экземпляр арифметического калькулятора
            arithmeticCalculator.SetVariableValue("data", 1);
            var result = arithmeticCalculator.Execute();
            var postfix = arithmeticCalculator.PostFix;
            Assert.AreEqual(-7, result, infix + "  ->  " + postfix);
        }

        /// <summary>
        /// The variant 31.
        /// </summary>
        [TestMethod]
        public void Variant31()
        {
            var infix = "3-data";
            var arithmeticCalculator = ArithmeticCalculator.CreateInstance(infix); // Создали экземпляр арифметического калькулятора
            arithmeticCalculator.SetVariableValue("data", 1);
            var result = arithmeticCalculator.Execute();
            var postfix = arithmeticCalculator.PostFix;
            Assert.AreEqual(2, result, infix + "  ->  " + postfix);
        }

        /// <summary>
        /// The variant 32.
        /// </summary>
        [TestMethod]
        public void Variant32()
        {
            var infix = "3+(-data)";
            var arithmeticCalculator = ArithmeticCalculator.CreateInstance(infix); // Создали экземпляр арифметического калькулятора
            arithmeticCalculator.SetVariableValue("data", 1);
            var result = arithmeticCalculator.Execute();
            var postfix = arithmeticCalculator.PostFix;
            Assert.AreEqual(2, result, infix + "  ->  " + postfix);
        }

        /// <summary>
        /// The variant 33.
        /// </summary>
        [TestMethod]
        public void Variant33()
        {
            var infix = "3-(-data)";
            var arithmeticCalculator = ArithmeticCalculator.CreateInstance(infix); // Создали экземпляр арифметического калькулятора
            arithmeticCalculator.SetVariableValue("data", -2);
            var result = arithmeticCalculator.Execute();
            var postfix = arithmeticCalculator.PostFix;
            Assert.AreEqual(1, result, infix + "  ->  " + postfix);
        }

        /// <summary>
        /// The variant 34.
        /// </summary>
        [TestMethod]
        public void Variant34()
        {
            var infix = "-1*(3-(-data))";
            var arithmeticCalculator = ArithmeticCalculator.CreateInstance(infix); // Создали экземпляр арифметического калькулятора
            arithmeticCalculator.SetVariableValue("data", -2);
            var result = arithmeticCalculator.Execute();
            var postfix = arithmeticCalculator.PostFix;
            Assert.AreEqual(-1, result, infix + "  ->  " + postfix);
        }
    }
}