// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InfixToPostfixConversionUnitTest.cs" company="URB31075">
//   All Right Reserved
// </copyright>
// <summary>
//   The infix to postfix conversion unit test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ArithmeticCalculatorUnitTest
{
    using ArithmeticCalculator;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// The infix to postfix conversion unit test.
    /// </summary>
    [TestClass]
    public class InfixToPostfixConversionUnitTest
    {
        /// <summary>
        /// The test 00.
        /// </summary>
        [TestMethod]
        public void Test00()
        {
            var infix = "(3)";
            var arithmeticCalculator = ArithmeticCalculator.CreateInstance(infix); // Создали экземпляр арифметического калькулятора
            var postfix = arithmeticCalculator.PostFix;
            Assert.AreEqual("3", postfix, infix + "  ->  " + postfix);
        }

        /// <summary>
        /// The test 01.
        /// </summary>
        [TestMethod]
        public void Test01()
        {
            var infix = "(-3)";
            var arithmeticCalculator = ArithmeticCalculator.CreateInstance(infix); // Создали экземпляр арифметического калькулятора
            var postfix = arithmeticCalculator.PostFix;
            Assert.AreEqual("-3", postfix, infix + "  ->  " + postfix);
        }

        /// <summary>
        /// The test 02.
        /// </summary>
        [TestMethod]
        public void Test02()
        {
            var infix = "3*-2";
            var arithmeticCalculator = ArithmeticCalculator.CreateInstance(infix); // Создали экземпляр арифметического калькулятора
            var postfix = arithmeticCalculator.PostFix;
            Assert.AreEqual("3 -2 *", postfix, infix + "  ->  " + postfix);
        }

        /// <summary>
        /// The test 03.
        /// </summary>
        [TestMethod]
        public void Test03()
        {
            var infix = "3*2";
            var arithmeticCalculator = ArithmeticCalculator.CreateInstance(infix); // Создали экземпляр арифметического калькулятора
            var postfix = arithmeticCalculator.PostFix;
            Assert.AreEqual("3 2 *", postfix, infix + "  ->  " + postfix);
        }

        /// <summary>
        /// The test 04.
        /// </summary>
        [TestMethod]
        public void Test04()
        {
            var infix = "3/-2";
            var arithmeticCalculator = ArithmeticCalculator.CreateInstance(infix); // Создали экземпляр арифметического калькулятора
            var postfix = arithmeticCalculator.PostFix;
            Assert.AreEqual("3 -2 /", postfix, infix + "  ->  " + postfix);
        }

        /// <summary>
        /// The test 05.
        /// </summary>
        [TestMethod]
        public void Test05()
        {
            var infix = "log(3,-2)";
            var arithmeticCalculator = ArithmeticCalculator.CreateInstance(infix); // Создали экземпляр арифметического калькулятора
            var postfix = arithmeticCalculator.PostFix;
            Assert.AreEqual("3 -2 log", postfix, infix + "  ->  " + postfix);
        }

        /// <summary>
        /// The test 06.
        /// </summary>
        [TestMethod]
        public void Test06()
        {
            var infix = "log(-3,-2)";
            var arithmeticCalculator = ArithmeticCalculator.CreateInstance(infix); // Создали экземпляр арифметического калькулятора
            var postfix = arithmeticCalculator.PostFix;
            Assert.AreEqual("-3 -2 log", postfix, infix + "  ->  " + postfix);
        }

        /// <summary>
        /// The test 07.
        /// </summary>
        [TestMethod]
        public void Test07()
        {
            var infix = "3-data";
            var arithmeticCalculator = ArithmeticCalculator.CreateInstance(infix); // Создали экземпляр арифметического калькулятора
            var postfix = arithmeticCalculator.PostFix;
            Assert.AreEqual("3 data -", postfix, infix + "  ->  " + postfix);
        }

        /// <summary>
        /// The test 08.
        /// </summary>
        [TestMethod]
        public void Test08()
        {
            var infix = "3+(-data)";
            var arithmeticCalculator = ArithmeticCalculator.CreateInstance(infix); // Создали экземпляр арифметического калькулятора
            var postfix = arithmeticCalculator.PostFix;
            Assert.AreEqual("3 -1 data * +", postfix, infix + "  ->  " + postfix);
        }

        /// <summary>
        /// The test 09.
        /// </summary>
        [TestMethod]
        public void Test09()
        {
            var infix = "(3)+2";
            var arithmeticCalculator = ArithmeticCalculator.CreateInstance(infix); // Создали экземпляр арифметического калькулятора
            var postfix = arithmeticCalculator.PostFix;
            Assert.AreEqual("3 2 +", postfix, infix + "  ->  " + postfix);
        }

        /// <summary>
        /// The test 10.
        /// </summary>
        [TestMethod]
        public void Test10()
        {
            var infix = "(3)-2";
            var arithmeticCalculator = ArithmeticCalculator.CreateInstance(infix); // Создали экземпляр арифметического калькулятора
            var postfix = arithmeticCalculator.PostFix;
            Assert.AreEqual("3 2 -", postfix, infix + "  ->  " + postfix);
        }

        /// <summary>
        /// The test 11.
        /// </summary>
        [TestMethod]
        public void Test11()
        {
            var infix = "(data)+2";
            var arithmeticCalculator = ArithmeticCalculator.CreateInstance(infix); // Создали экземпляр арифметического калькулятора
            var postfix = arithmeticCalculator.PostFix;
            Assert.AreEqual("data 2 +", postfix, infix + "  ->  " + postfix);
        }

        /// <summary>
        /// The test 12.
        /// </summary>
        [TestMethod]
        public void Test12()
        {
            var infix = "(data)-2";
            var arithmeticCalculator = ArithmeticCalculator.CreateInstance(infix); // Создали экземпляр арифметического калькулятора
            var postfix = arithmeticCalculator.PostFix;
            Assert.AreEqual("data 2 -", postfix, infix + "  ->  " + postfix);
        }

        /// <summary>
        /// The test 13.
        /// </summary>
        [TestMethod]
        public void Test13()
        {
            var infix = "(3)+(2)";
            var arithmeticCalculator = ArithmeticCalculator.CreateInstance(infix); // Создали экземпляр арифметического калькулятора
            var postfix = arithmeticCalculator.PostFix;
            Assert.AreEqual("3 2 +", postfix, infix + "  ->  " + postfix);
        }

        /// <summary>
        /// The test 14.
        /// </summary>
        [TestMethod]
        public void Test14()
        {
            var infix = "(3)-(2)";
            var arithmeticCalculator = ArithmeticCalculator.CreateInstance(infix); // Создали экземпляр арифметического калькулятора
            var postfix = arithmeticCalculator.PostFix;
            Assert.AreEqual("3 2 -", postfix, infix + "  ->  " + postfix);
        }

        /// <summary>
        /// The test 15.
        /// </summary>
        [TestMethod]
        public void Test15()
        {
            var infix = "((2+3)*5)";
            var arithmeticCalculator = ArithmeticCalculator.CreateInstance(infix); // Создали экземпляр арифметического калькулятора
            var postfix = arithmeticCalculator.PostFix;
            Assert.AreEqual("2 3 + 5 *", postfix, infix + "  ->  " + postfix);
        }

        /// <summary>
        /// The test 16.
        /// </summary>
        [TestMethod]
        public void Test16()
        {
            var infix = "((2+3)*5)+9";
            var arithmeticCalculator = ArithmeticCalculator.CreateInstance(infix); // Создали экземпляр арифметического калькулятора
            var postfix = arithmeticCalculator.PostFix;
            Assert.AreEqual("2 3 + 5 * 9 +", postfix, infix + "  ->  " + postfix);
        }

        /// <summary>
        /// The test 17.
        /// </summary>
        [TestMethod]
        public void Test17()
        {
            var infix = "((2+3)*5)+(9)";
            var arithmeticCalculator = ArithmeticCalculator.CreateInstance(infix); // Создали экземпляр арифметического калькулятора
            var postfix = arithmeticCalculator.PostFix;
            Assert.AreEqual("2 3 + 5 * 9 +", postfix, infix + "  ->  " + postfix);
        }

        /// <summary>
        /// The test 18.
        /// </summary>
        [TestMethod]
        public void Test18()
        {
            var infix = "-3-4";
            var arithmeticCalculator = ArithmeticCalculator.CreateInstance(infix); // Создали экземпляр арифметического калькулятора
            var postfix = arithmeticCalculator.PostFix;
            Assert.AreEqual("-3 4 -", postfix, infix + "  ->  " + postfix);
        }

        /// <summary>
        /// The test 19.
        /// </summary>
        [TestMethod]
        public void Test19()
        {
            var infix = "(-(3)-(4))";
            var arithmeticCalculator = ArithmeticCalculator.CreateInstance(infix); // Создали экземпляр арифметического калькулятора
            var postfix = arithmeticCalculator.PostFix;
            Assert.AreEqual("-1 3 * 4 -", postfix, infix + "  ->  " + postfix);
        }

        /// <summary>
        /// The function test.
        /// </summary>
        [TestMethod]
        public void Test54()
        {
            var infix = "((2+3)*5)+(2+4)*(4+8)";
            var arithmeticCalculator = ArithmeticCalculator.CreateInstance(infix); // Создали экземпляр арифметического калькулятора
            var postfix = arithmeticCalculator.PostFix;
            Assert.AreEqual("2 3 + 5 * 2 4 + 4 8 + * +", postfix, infix + "  ->  " + postfix);
        }

        /// <summary>
        /// The function test.
        /// </summary>
        [TestMethod]
        public void Test55()
        {
            var infix = "(3+4)*2";
            var arithmeticCalculator = ArithmeticCalculator.CreateInstance(infix); // Создали экземпляр арифметического калькулятора
            var postfix = arithmeticCalculator.PostFix;
            Assert.AreEqual("3 4 + 2 *", postfix, infix + "  ->  " + postfix);
        }

        /// <summary>
        /// The test 56.
        /// </summary>
        [TestMethod]
        public void Test56()
        {
            var infix = "(3+4)*2+(5+6)*8";
            var arithmeticCalculator = ArithmeticCalculator.CreateInstance(infix); // Создали экземпляр арифметического калькулятора
            var postfix = arithmeticCalculator.PostFix;
            Assert.AreEqual("3 4 + 2 * 5 6 + 8 * +", postfix, infix + "  ->  " + postfix);
        }

        /// <summary>
        /// The function test.
        /// </summary>
        [TestMethod]
        public void FunctionTest()
        {
            var infix = "Pow(2,5) + Sqrt(16) + 10";
            var arithmeticCalculator = ArithmeticCalculator.CreateInstance(infix); // Создали экземпляр арифметического калькулятора
            var postfix = arithmeticCalculator.PostFix;
            Assert.AreEqual("2 5 Pow 16 Sqrt 10 + +", postfix, infix + "  ->  " + postfix);
        }

        /// <summary>
        /// The function test.
        /// </summary>
        [TestMethod]
        public void NegativeValueTest()
        {
            var infix = "Abs(-25)";
            var arithmeticCalculator = ArithmeticCalculator.CreateInstance(infix); // Создали экземпляр арифметического калькулятора
            var postfix = arithmeticCalculator.PostFix;
            Assert.AreEqual("-25 Abs", postfix, postfix);
        }
    }
}