// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Lexem.cs" company="URV321075">
//   All Right reserved
// </copyright>
// <summary>
//   The lexem type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ArithmeticCalculator
{
    /// <summary>
    /// The lexem type.
    /// </summary>
    public enum LexemType
    {
        /// <summary>
        /// The variable.
        /// </summary>
        Variable, 

        /// <summary>
        /// The function.
        /// </summary>
        Function, 

        /// <summary>
        /// The identifier.
        /// </summary>
        Identifier, 

        /// <summary>
        /// The operator.
        /// </summary>
        Operator, 

        /// <summary>
        /// The delimier.
        /// </summary>
        Delimier, 

        /// <summary>
        /// The constant.
        /// </summary>
        Constant, 

        /// <summary>
        /// The open sub.
        /// </summary>
        OpenSub, 

        /// <summary>
        /// The close sub.
        /// </summary>
        CloseSub,

        NoLexem
    }

    /// <summary>
    /// The lexem.
    /// </summary>
    public class Lexem
    {
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        public LexemType Type { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// The to string.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public override string ToString()
        {
            return string.Format("{0} : {1}", this.Type, this.Value);
        }
    }
}