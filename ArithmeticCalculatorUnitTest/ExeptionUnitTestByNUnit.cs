// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExeptionUnitTestByNUnit.cs" company="urb31075">
// All Right Reserved  
// </copyright>
// <summary>
//   Defines the ExeptionUnitTestByNUnit type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ArithmeticCalculatorUnitTest
{
    using System;
    using ArithmeticCalculator;
    using NUnit.Framework;
    using Assert = NUnit.Framework.Assert;

    /// <summary>
    /// The exeption unit test by n unit.
    /// </summary>
    [TestFixture]
    public class ExeptionUnitTestByNUnit
    {
        /// <summary>
        /// The return true.
        /// </summary>
        [Test]
        public void ReturnTrue()
        {
            Assert.IsTrue(true);
        }

        /// <summary>
        /// The expected exception test.
        /// </summary>
        [Test]
        public void ExpectedExceptionTest()
        {
            var ex = Assert.Throws<ArgumentException>(delegate 
            {
                throw new ArgumentException("expected message");
            });
            Assert.IsTrue(ex.Message.Contains("expected message"));
        }

        /// <summary>
        /// The test error expression 01.
        /// </summary>
        [Test]
        public void TestErrorExpression01()
        {
            var ex = Assert.Throws<Exception>(delegate
            {
                const string Infix = "(5,6)";
                var arithmeticCalculator = ArithmeticCalculator.CreateInstance(Infix);
                arithmeticCalculator.Execute();
            });

            Assert.IsTrue(ex.Message.Contains("Ошибка выполнения арифметического выражения"), ex.Message);
        }

        /// <summary>
        /// The test error expression 02.
        /// </summary>
        [Test]
        public void TestErrorExpression02()
        {
            var ex = Assert.Throws<Exception>(delegate
            {
                const string Infix = "(5,6)";
                var arithmeticCalculator = ArithmeticCalculator.CreateInstance(Infix);
                arithmeticCalculator.Execute();
            });

            Assert.IsTrue(ex.Message.Contains("Ошибка выполнения арифметического выражения"), ex.Message);
        }

        /// <summary>
        /// The test error expression 03.
        /// </summary>
        [Test]
        public void TestErrorExpression03()
        {
            var ex = Assert.Throws<Exception>(delegate
            {
                const string Infix = "Pow(5,)";
                var arithmeticCalculator = ArithmeticCalculator.CreateInstance(Infix);
                arithmeticCalculator.Execute();
            });

            Assert.IsTrue(ex.Message.Contains("Ошибка выполнения арифметического выражения"), ex.Message);
        }

        /// <summary>
        /// The test error expression 04.
        /// </summary>
        [Test]
        public void TestErrorExpression04()
        {
            var ex = Assert.Throws<Exception>(delegate
            {
                const string Infix = "Pow(5,6,7)";
                var arithmeticCalculator = ArithmeticCalculator.CreateInstance(Infix);
                arithmeticCalculator.Execute();
            });

            Assert.IsTrue(ex.Message.Contains("Ошибка выполнения арифметического выражения"), ex.Message);
        }

        /// <summary>
        /// The test error expression 04.
        /// </summary>
        [Test]
        public void TestErrorExpression05()
        {
            var ex = Assert.Throws<Exception>(delegate
            {
                const string Infix = "sqrt(5,6)";
                var arithmeticCalculator = ArithmeticCalculator.CreateInstance(Infix);
                arithmeticCalculator.Execute();
            });

            Assert.IsTrue(ex.Message.Contains("Ошибка выполнения арифметического выражения"), ex.Message);
        }

        /// <summary>
        /// The test error expression 04.
        /// </summary>
        [Test]
        public void TestErrorExpression06()
        {
            var ex = Assert.Throws<Exception>(delegate
            {
                const string Infix = "sqrt()";
                var arithmeticCalculator = ArithmeticCalculator.CreateInstance(Infix);
                arithmeticCalculator.Execute();
            });

            Assert.IsTrue(ex.Message.Contains("Ошибка выполнения арифметического выражения"), ex.Message);
        }

        /// <summary>
        /// The test error expression 04.
        /// </summary>
        [Test]
        public void TestErrorExpression07()
        {
            var ex = Assert.Throws<Exception>(delegate
            {
                const string Infix = "sqrt";
                var arithmeticCalculator = ArithmeticCalculator.CreateInstance(Infix);
                arithmeticCalculator.Execute();
            });

            Assert.IsTrue(ex.Message.Contains("Ошибка выполнения арифметического выражения"), ex.Message);
        }

        /// <summary>
        /// The test unexpected char in variable.
        /// </summary>
        [Test]
        public void TestUnexpectedCharInExpression()
        {
            var ex = Assert.Throws<Exception>(delegate
            {
                const string Infix = "5$6";
                ArithmeticCalculator.CreateInstance(Infix); // Создали экземпляр арифметического калькулятора
            });

            Assert.IsTrue(ex.Message.Contains("Недопустимый символ"), ex.Message);
        }

        /// <summary>
        /// The test unexpected char in variable.
        /// </summary>
        [Test]
        public void TestUnexpectedDotInVariable()
        {
            var ex = Assert.Throws<Exception>(delegate
            {
                const string Infix = "D.5";
                ArithmeticCalculator.CreateInstance(Infix); // Создали экземпляр арифметического калькулятора
            });

            Assert.IsTrue(ex.Message.Contains("Недопустимое использование"), ex.Message);
        }

        /// <summary>
        /// The test nodefined function.
        /// </summary>
        [Test]
        public void TestNodefinedFunction()
        {
            var ex = Assert.Throws<Exception>(delegate
            {
                const string Infix = "ufunc(34)";
                var arithmeticCalculator = ArithmeticCalculator.CreateInstance(Infix);
                arithmeticCalculator.Execute();
            });

            Assert.IsTrue(ex.Message.Contains("Неудалось распознать"), ex.Message);
        }

        /// <summary>
        /// The test nodefined variable.
        /// </summary>
        [Test]
        public void TestNodefinedVariable()
        {
            var ex = Assert.Throws<Exception>(delegate
            {
                const string Infix = "23 + D5 + 10";
                var arithmeticCalculator = ArithmeticCalculator.CreateInstance(Infix);
                arithmeticCalculator.Execute();
            });

            Assert.IsTrue(ex.Message.Contains("Неудалось распознать"), ex.Message);
        }
    }
}
