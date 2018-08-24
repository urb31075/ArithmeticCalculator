// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExtensionUnitTest.cs" company="URB31075">
//  All Right Reserved 
// </copyright>
// <summary>
//   The extension test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ArithmeticCalculatorUnitTest
{
    using ArithmeticCalculator;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// The extension test.
    /// </summary>
    [TestClass]
    public class ExtensionUnitTest
    {
        /// <summary>
        /// The char in 1.
        /// </summary>
        [TestMethod]
        public void LexemIn1()
        {
            var c = LexemType.Function;
            var result = c.In(LexemType.Function);
            Assert.IsTrue(result);
        }

        /// <summary>
        /// The char in 1.
        /// </summary>
        [TestMethod]
        public void CharIn1()
        {
            char c = '.';
            var result = c.In('.');
            Assert.IsTrue(result);
        }

        /// <summary>
        /// The char in 2.
        /// </summary>
        [TestMethod]
        public void CharIn2()
        {
            char c = '.';
            var result = c.In('.', 'x');
            Assert.IsTrue(result);
        }

        /// <summary>
        /// The char in 3.
        /// </summary>
        [TestMethod]
        public void CharIn3()
        {
            char c = '.';
            var result = c.In('.', 'x', 'y');
            Assert.IsTrue(result);
        }

        /// <summary>
        /// The char in 4.
        /// </summary>
        [TestMethod]
        public void CharIn4()
        {
            char c = '.';
            var result = c.In('.', 'x', 'y', 'z');
            Assert.IsTrue(result);
        }

        /// <summary>
        /// The char in 5.
        /// </summary>
        [TestMethod]
        public void CharIn5()
        {
            char c = '.';
            var result = c.In('.', 'x', 'y', 'z', 'w');
            Assert.IsTrue(result);
        }

        /// <summary>
        /// The char in 6.
        /// </summary>
        [TestMethod]
        public void CharIn6()
        {
            char c = '.';
            var result = c.In('.', 'x', 'y', 'z', 'w', 'q');
            Assert.IsTrue(result);
        }

        /// <summary>
        /// The char in 7.
        /// </summary>
        [TestMethod]
        public void CharIn7()
        {
            char c = '.';
            var result = c.In('.', 'x', 'y', 'z', 'w', 'q', 'w');
            Assert.IsTrue(result);
        }

        /// <summary>
        /// The char in 8.
        /// </summary>
        [TestMethod]
        public void CharIn8()
        {
            char c = '.';
            var result = c.In('.', 'x', 'y', 'z', 'w', 'q', 'w', 'e');
            Assert.IsTrue(result);
        }

        /// <summary>
        /// The char in 8.
        /// </summary>
        [TestMethod]
        public void CharIn9()
        {
            char c = '.';
            var result = c.In('.', 'x', 'y', 'z', 'w', 'q', 'w', 'e', 'r');
            Assert.IsTrue(result);
        }

        /// <summary>
        /// The string in 3.
        /// </summary>
        [TestMethod]
        public void StringIn3()
        {
            string c = "a";
            var result = c.In("a", "b", "c");
            Assert.IsTrue(result);
        }

        /// <summary>
        /// The string in 4.
        /// </summary>
        [TestMethod]
        public void StringIn4()
        {
            string c = "a";
            var result = c.In("a", "b", "c", "d");
            Assert.IsTrue(result);
        }

        /// <summary>
        /// The string in 4.
        /// </summary>
        [TestMethod]
        public void StringIn5()
        {
            string c = "a";
            var result = c.In("a", "b", "c", "d", "e");
            Assert.IsTrue(result);
        }
    }
}