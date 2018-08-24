// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NativeFunctionUnitTest.cs" company="URB31075">
// All Right Reserved  
// </copyright>
// <summary>
//   The native function unit test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ArithmeticCalculatorUnitTest
{
    using ArithmeticCalculator;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// The native function unit test.
    /// </summary>
    [TestClass]
    public class NativeFunctionUnitTest
    {
        /// <summary>
        /// The get set name method.
        /// </summary>
        [TestMethod]
        public void GetSetNameMethod()
        {
            var f = new NativeFunction("XXX", a => a[0], 1);
            var r = f.Execute(10);
            var name = f.Name;
            Assert.AreEqual(10, r);
            Assert.AreEqual("XXX", name);
        }

        /// <summary>
        /// The sqrt test method.
        /// </summary>
        [TestMethod]
        public void SqrtTestMethod()
        {
            var infix = "Sqrt(18.48)";
            var arithmeticCalculator = ArithmeticCalculator.CreateInstance(infix); // Создали экземпляр арифметического калькулятора
            var result = arithmeticCalculator.Execute();
            Assert.AreEqual(4.29883705204094M, result);
        }

        /// <summary>
        /// The abs test method.
        /// </summary>
        [TestMethod]
        public void AbsTestMethod()
        {
            var infix = "Abs(-25)";
            var arithmeticCalculator = ArithmeticCalculator.CreateInstance(infix); // Создали экземпляр арифметического калькулятора
            var result = arithmeticCalculator.Execute();
            Assert.AreEqual(25, result);
        }

        /// <summary>
        /// The atan test method.
        /// </summary>
        [TestMethod]
        public void AtanTestMethod()
        {
            var infix = "Atan(0.5)";
            var arithmeticCalculator = ArithmeticCalculator.CreateInstance(infix); // Создали экземпляр арифметического калькулятора
            var result = arithmeticCalculator.Execute();
            Assert.AreEqual(0.463647609000806M, result);
        }

        /// <summary>
        /// The cos test method.
        /// </summary>
        [TestMethod]
        public void CosTestMethod()
        {
            var infix = "Cos(0.5)";
            var arithmeticCalculator = ArithmeticCalculator.CreateInstance(infix); // Создали экземпляр арифметического калькулятора
            var result = arithmeticCalculator.Execute();
            Assert.AreEqual(0.877582561890373M, result);
        }

        /// <summary>
        /// The exp test method.
        /// </summary>
        [TestMethod]
        public void ExpTestMethod()
        {
            var infix = "Exp(2)";
            var arithmeticCalculator = ArithmeticCalculator.CreateInstance(infix); // Создали экземпляр арифметического калькулятора
            var result = arithmeticCalculator.Execute();
            Assert.AreEqual(7.38905609893065M, result);
        }

        /// <summary>
        /// The log test method.
        /// </summary>
        [TestMethod]
        public void LogTestMethod()
        {
            var infix = "Log(34, 3)";
            var arithmeticCalculator = ArithmeticCalculator.CreateInstance(infix); // Создали экземпляр арифметического калькулятора
            var result = arithmeticCalculator.Execute();
            Assert.AreEqual(0.311542816169567M, result);
        }

        /// <summary>
        /// The log 2 test method.
        /// </summary>
        [TestMethod]
        public void Log2TestMethod()
        {
            var infix = "Log2(16)";
            var arithmeticCalculator = ArithmeticCalculator.CreateInstance(infix); // Создали экземпляр арифметического калькулятора
            var result = arithmeticCalculator.Execute();
            Assert.AreEqual(4, result);
        }

        /// <summary>
        /// The log 10 test method.
        /// </summary>
        [TestMethod]
        public void Log10TestMethod()
        {
            var infix = "Log10(100)";
            var arithmeticCalculator = ArithmeticCalculator.CreateInstance(infix); // Создали экземпляр арифметического калькулятора
            var result = arithmeticCalculator.Execute();
            Assert.AreEqual(2, result);
        }

        /// <summary>
        /// The pow test method.
        /// </summary>
        [TestMethod]
        public void PowTestMethod()
        {
            var infix = "Pow(2, 5)";
            var arithmeticCalculator = ArithmeticCalculator.CreateInstance(infix); // Создали экземпляр арифметического калькулятора
            var result = arithmeticCalculator.Execute();
            Assert.AreEqual(25, result);
        }

        /// <summary>
        /// The sin test method.
        /// </summary>
        [TestMethod]
        public void SinTestMethod()
        {
            var infix = "Sin(0.5)";
            var arithmeticCalculator = ArithmeticCalculator.CreateInstance(infix); // Создали экземпляр арифметического калькулятора
            var result = arithmeticCalculator.Execute();
            Assert.AreEqual(0.479425538604203M, result);
        }
    }
}