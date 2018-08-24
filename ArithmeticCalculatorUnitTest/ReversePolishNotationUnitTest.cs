// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReversePolishNotationUnitTest.cs" company="URB31075">
//   All Right Reserved
// </copyright>
// <summary>
//   The reverse polish notation.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ArithmeticCalculatorUnitTest
{
    using ArithmeticCalculator;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// The reverse polish notation.
    /// </summary>
    [TestClass]
    public class ReversePolishNotationUnitTest
    {
        /// <summary>
        /// The test constant negative.
        /// </summary>
        [TestMethod]
        public void TestConstantNegative()
        {
            var infix = "-0.43";
            var arithmeticCalculator = ArithmeticCalculator.CreateInstance(infix); // Создали экземпляр арифметического калькулятора
            var result = arithmeticCalculator.Execute();
            Assert.AreEqual(-0.43M, result);
        }

        /// <summary>
        /// The test constant positive.
        /// </summary>
        [TestMethod]
        public void TestConstantPositive()
        {
            var infix = "0.89";
            var arithmeticCalculator = ArithmeticCalculator.CreateInstance(infix); // Создали экземпляр арифметического калькулятора
            var result = arithmeticCalculator.Execute();
            Assert.AreEqual(0.89M, result);
        }

        /// <summary>
        /// The test variable list.
        /// </summary>
        [TestMethod]
        public void TestVariableList()
        {
            var infix = "(A1 + B2)*C6";
            var arithmeticCalculator = ArithmeticCalculator.CreateInstance(infix); // Создали экземпляр арифметического калькулятора
            Assert.AreEqual(true, arithmeticCalculator.VariableList.Contains("a1"));
            Assert.AreEqual(true, arithmeticCalculator.VariableList.Contains("b2"));
            Assert.AreEqual(true, arithmeticCalculator.VariableList.Contains("c6"));
        }

        /// <summary>
        /// The test variable negative.
        /// </summary>
        [TestMethod]
        public void TestVariableNegative()
        {
            var infix = "S11";
            var arithmeticCalculator = ArithmeticCalculator.CreateInstance(infix); // Создали экземпляр арифметического калькулятора
            arithmeticCalculator.SetVariableValue("S11", -2.67M);
            var result = arithmeticCalculator.Execute();
            Assert.AreEqual(-2.67M, result);
        }

        /// <summary>
        /// The test variable positive.
        /// </summary>
        [TestMethod]
        public void TestVariablePositive()
        {
            var infix = "XDR23";
            var arithmeticCalculator = ArithmeticCalculator.CreateInstance(infix); // Создали экземпляр арифметического калькулятора
            arithmeticCalculator.SetVariableValue("XDR23", 23.56M);
            var result = arithmeticCalculator.Execute();
            Assert.AreEqual(23.56M, result);
        }

        /// <summary>
        /// The test variable positive.
        /// </summary>
        [TestMethod]
        public void TestResetVariable()
        {
            var infix = "XYZ";
            var arithmeticCalculator = ArithmeticCalculator.CreateInstance(infix); // Создали экземпляр арифметического калькулятора
            arithmeticCalculator.SetVariableValue("XYZ", 23.56M);
            arithmeticCalculator.SetVariableValue("Xyz", 12.45M);
            var result = arithmeticCalculator.Execute();
            Assert.AreEqual(12.45M, result);
        }

        /// <summary>
        /// The test variable positive.
        /// </summary>
        [TestMethod]
        public void TestFunctionFromOneVariable()
        {
            var infix = "pow(2, data)";
            var arithmeticCalculator = ArithmeticCalculator.CreateInstance(infix); // Создали экземпляр арифметического калькулятора
            arithmeticCalculator.SetVariableValue("data", 5M);
            var result = arithmeticCalculator.Execute();
            Assert.AreEqual(25M, result);
        }

        /// <summary>
        /// The test variable positive.
        /// </summary>
        [TestMethod]
        public void TestFunctionFromTuVariable()
        {
            var infix = "pow(s, data)";
            var arithmeticCalculator = ArithmeticCalculator.CreateInstance(infix); // Создали экземпляр арифметического калькулятора
            arithmeticCalculator.SetVariableValue("s", 2M);
            arithmeticCalculator.SetVariableValue("data", 5M);
            var result = arithmeticCalculator.Execute();
            Assert.AreEqual(25M, result);
        }

        /// <summary>
        /// The test summ.
        /// </summary>
        [TestMethod]
        public void SetSumm()
        {
            var infix = "0.5 + 2.5";
            var arithmeticCalculator = ArithmeticCalculator.CreateInstance(infix); // Создали экземпляр арифметического калькулятора
            var result = arithmeticCalculator.Execute();
            Assert.AreEqual(3, result);
        }

        /// <summary>
        /// The test summ.
        /// </summary>
        [TestMethod]
        public void SetSub()
        {
            var infix = "8 - 2";
            var arithmeticCalculator = ArithmeticCalculator.CreateInstance(infix); // Создали экземпляр арифметического калькулятора
            var result = arithmeticCalculator.Execute();
            Assert.AreEqual(6M, result);
        }

        /// <summary>
        /// The test summ.
        /// </summary>
        [TestMethod]
        public void SetMul()
        {
            var infix = "5 * 3";
            var arithmeticCalculator = ArithmeticCalculator.CreateInstance(infix); // Создали экземпляр арифметического калькулятора
            var result = arithmeticCalculator.Execute();
            Assert.AreEqual(15M, result);
        }

        /// <summary>
        /// The test summ.
        /// </summary>
        [TestMethod]
        public void SetDiv()
        {
            var infix = "8 / 2";
            var arithmeticCalculator = ArithmeticCalculator.CreateInstance(infix); // Создали экземпляр арифметического калькулятора
            var result = arithmeticCalculator.Execute();
            Assert.AreEqual(4M, result);
        }

        /// <summary>
        /// The test summ.
        /// </summary>
        [TestMethod]
        public void SetPow()
        {
            var infix = "2^3";
            var arithmeticCalculator = ArithmeticCalculator.CreateInstance(infix); // Создали экземпляр арифметического калькулятора
            var result = arithmeticCalculator.Execute();
            Assert.AreEqual(8M, result);
        }

        /// <summary>
        /// The test summ.
        /// </summary>
        [TestMethod]
        public void SetPriority()
        {
            var infix = "((4 + 6)*2 + (2+3)^3)^2";
            var arithmeticCalculator = ArithmeticCalculator.CreateInstance(infix); // Создали экземпляр арифметического калькулятора
            var result = arithmeticCalculator.Execute();
            Assert.AreEqual(21025M, result);
        }

        /// <summary>
        /// The test negative.
        /// </summary>
        [TestMethod]
        public void SetNegative()
        {
            var infix = "-25.45";
            var arithmeticCalculator = ArithmeticCalculator.CreateInstance(infix); // Создали экземпляр арифметического калькулятора
            var result = arithmeticCalculator.Execute();
            Assert.AreEqual(-25.45M, result);
        }

        /// <summary>
        /// The test negative.
        /// </summary>
        [TestMethod]
        public void SetPositive()
        {
            var infix = "15.68";
            var arithmeticCalculator = ArithmeticCalculator.CreateInstance(infix); // Создали экземпляр арифметического калькулятора
            var result = arithmeticCalculator.Execute();
            Assert.AreEqual(15.68M, result);
        }

        /// <summary>
        /// The test method 1.
        /// </summary>
        [TestMethod]
        public void TestVariableInFunction()
        {
            var infix = "Pow((Abc1+Abc2),(Bxz1+Bxz2))";
            var arithmeticCalculator = ArithmeticCalculator.CreateInstance(infix); // Создали экземпляр арифметического калькулятора
            arithmeticCalculator.SetVariableValue("Abc1", 2);
            arithmeticCalculator.SetVariableValue("Abc2", 2);
            arithmeticCalculator.SetVariableValue("Bxz1", 3);
            arithmeticCalculator.SetVariableValue("Bxz2", 3);
            var result = arithmeticCalculator.Execute();
            Assert.AreEqual(1296, result);
        }

        /// <summary>
        /// The test constant in function.
        /// </summary>
        [TestMethod]
        public void TestConstantInFunction()
        {
            var infix = "Pow((2+2),(3+3))";
            var arithmeticCalculator = ArithmeticCalculator.CreateInstance(infix); // Создали экземпляр арифметического калькулятора
            arithmeticCalculator.SetVariableValue("A1", 2);
            arithmeticCalculator.SetVariableValue("A2", 2);
            arithmeticCalculator.SetVariableValue("B1", 3);
            arithmeticCalculator.SetVariableValue("B2", 3);
            var result = arithmeticCalculator.Execute();
            Assert.AreEqual(1296, result);
        }
    }
}