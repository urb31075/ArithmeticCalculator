// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Extensions.cs" company="URB31075">
//   All Right Reserved
// </copyright>
// <summary>
//   The my parser extension.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ArithmeticCalculator
{
    using System.Linq;

    /// <summary>
    /// The my parser extension.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// The in.
        /// </summary>
        /// <param name="c">
        /// The c.
        /// </param>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool In(this char c, params char[] p)
        {
            return p.Contains(c);
        }

        /// <summary>
        /// The in.
        /// </summary>
        /// <param name="s">
        /// The s.
        /// </param>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool In(this string s, params string[] p)
        {
            return p.Contains(s);
        }

        /// <summary>
        /// The in.
        /// </summary>
        /// <param name="l">
        /// The l.
        /// </param>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool In(this LexemType l, params LexemType[] p)
        {
            return p.Any(lexema => l == lexema);
        }
    }
}