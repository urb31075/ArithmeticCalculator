// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LexemUnitTest.cs" company="URB31075">
// All Right Reserved  
// </copyright>
// <summary>
//   Defines the LexemUnitTest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ArithmeticCalculatorUnitTest
{
    using ArithmeticCalculator;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// The lexem unit test.
    /// </summary>
    [TestClass]
    public class LexemUnitTest
    {
        /// <summary>
        /// The to string test.
        /// </summary>
        [TestMethod]
        public void ToStringTest()
        {
            var lexem = new Lexem { Type = LexemType.Variable, Value = "Data" };
            var result = lexem.ToString();
            Assert.AreEqual("Variable : Data", result);
        }
    }
}
