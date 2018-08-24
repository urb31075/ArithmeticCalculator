// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExeptionUnitTest.cs" company="urb31075">
//  All Righnt Reserved 
// </copyright>
// <summary>
//   The exeption unit test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ArithmeticCalculatorUnitTest
{
    using System;
    using ArithmeticCalculator;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// The exeption unit test.
    /// </summary>
    [TestClass]
    public class ExeptionUnitTest
    {
        /// <summary>
        /// The test error expression 01.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestErrorExpression01()
        {
            try
            {
                const string Infix = "5,6";
                var arithmeticCalculator = ArithmeticCalculator.CreateInstance(Infix);
                arithmeticCalculator.Execute(); // Создали экземпляр арифметического калькулятора
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message.Contains("Ошибка выполнения арифметического выражения"), ex.Message);
                throw;
            }
        }

        /// <summary>
        /// The test error expression 01X.
        /// </summary>
        [TestMethod]
        public void TestErrorExpression01X()
        { 
            MyAssert.Throws<Exception>(
                () =>
                    {
                        const string Infix = "5,6";
                        var arithmeticCalculator = ArithmeticCalculator.CreateInstance(Infix);
                        arithmeticCalculator.Execute(); // Создали экземпляр арифметического калькулятора
                    },
                @"Ошибка выполнения арифметического выражения");
        }

        /// <summary>
        /// The test error expression 02.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestErrorExpression02()
        {
            try
            {
                const string Infix = "(5,6)";
                var arithmeticCalculator = ArithmeticCalculator.CreateInstance(Infix);
                arithmeticCalculator.Execute(); // Создали экземпляр арифметического калькулятора
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message.Contains("Ошибка выполнения арифметического выражения"), ex.Message);
                throw;
            }
        }

        /// <summary>
        /// The test error expression 03.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestErrorExpression03()
        {
            try
            {
                const string Infix = "Pow(5,)";
                var arithmeticCalculator = ArithmeticCalculator.CreateInstance(Infix);
                arithmeticCalculator.Execute(); // Создали экземпляр арифметического калькулятора
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message.Contains("Ошибка выполнения арифметического выражения"), ex.Message);
                throw;
            }
        }

        /// <summary>
        /// The test error expression 04.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestErrorExpression04()
        {
            try
            {
                const string Infix = "Pow(5,6,7)";
                var arithmeticCalculator = ArithmeticCalculator.CreateInstance(Infix);
                arithmeticCalculator.Execute(); // Создали экземпляр арифметического калькулятора
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message.Contains("Ошибка выполнения арифметического выражения"), ex.Message);
                throw;
            }
        }

        /// <summary>
        /// The test error expression 04.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestErrorExpression05()
        {
            try
            {
                const string Infix = "sqrt(5,6)";
                var arithmeticCalculator = ArithmeticCalculator.CreateInstance(Infix);
                arithmeticCalculator.Execute(); // Создали экземпляр арифметического калькулятора
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message.Contains("Ошибка выполнения арифметического выражения"), ex.Message);
                throw;
            }
        }

        /// <summary>
        /// The test error expression 04.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestErrorExpression06()
        {
            try
            {
                const string Infix = "sqrt()";
                var arithmeticCalculator = ArithmeticCalculator.CreateInstance(Infix);
                arithmeticCalculator.Execute(); // Создали экземпляр арифметического калькулятора
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message.Contains("Ошибка выполнения арифметического выражения"), ex.Message);
                throw;
            }
        }

        /// <summary>
        /// The test error expression 04.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestErrorExpression07()
        {
            try
            {
                const string Infix = "sqrt";
                var arithmeticCalculator = ArithmeticCalculator.CreateInstance(Infix);
                arithmeticCalculator.Execute(); // Создали экземпляр арифметического калькулятора
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message.Contains("Ошибка выполнения арифметического выражения"), ex.Message);
                throw;
            }
        }

        /// <summary>
        /// The test unexpected char in variable.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestUnexpectedCharInExpression()
        {
            try
            {
                const string Infix = "5$6";
                ArithmeticCalculator.CreateInstance(Infix); // Создали экземпляр арифметического калькулятора
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message.Contains("Недопустимый символ"), ex.Message);
                throw;
            }
        }

        /// <summary>
        /// The test unexpected char in variable.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestUnexpectedDotInVariable()
        {
            try
            {
                const string Infix = "D.5";
                ArithmeticCalculator.CreateInstance(Infix); // Создали экземпляр арифметического калькулятора
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message.Contains("Недопустимое использование"), ex.Message);
                throw;
            }
        }

        /// <summary>
        /// The test nodefined function.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestNodefinedFunction()
        {
            try
            {
                const string Infix = "ufunc(34)";
                var arithmeticCalculator = ArithmeticCalculator.CreateInstance(Infix);

                    // Создали экземпляр арифметического калькулятора
                arithmeticCalculator.Execute();
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message.Contains("Неудалось распознать"), ex.Message);
                throw;
            }
        }

        /// <summary>
        /// The test nodefined variable.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestNodefinedVariable()
        {
            try
            {
                const string Infix = "23 + D5 + 10";
                var arithmeticCalculator = ArithmeticCalculator.CreateInstance(Infix);

                    // Создали экземпляр арифметического калькулятора
                arithmeticCalculator.Execute();
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message.Contains("Неудалось распознать"), ex.Message);
                throw;
            }
        }
    }

    public static class MyAssert
    {
        public static void Throws<T>(Action func, string expectedExceptionMessage) where T : Exception
        {
            var exceptionThrown = false;
            try
            {
                func.Invoke();
            }
            catch (T ex)
            {
                if (ex.Message == expectedExceptionMessage)
                {
                    exceptionThrown = true;
                }
            }

            if (!exceptionThrown)
            {
                throw new AssertFailedException(String.Format("An exception of type {0} was expected, but not thrown", typeof(T)));
            }
        }
    }
}