// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReversePolishNotation.cs" company="URB31075">
//  All Right Reserved 
// </copyright>
// <summary>
//   The rpn.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ArithmeticCalculator
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text.RegularExpressions;

    /// <summary>
    /// The rpn.
    /// </summary>
    public class ReversePolishNotation
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReversePolishNotation"/> class.
        /// </summary>
        public ReversePolishNotation()
        {
            this.Variables = new Dictionary<string, decimal>();
            this.Functions = new Dictionary<string, NativeFunction>
              {
                  { "sqrt", NativeFunction.Sqrt },
                  { "abs", NativeFunction.Abs },
                  { "atan", NativeFunction.Atan },
                  { "cos", NativeFunction.Cos },
                  { "exp", NativeFunction.Exp },
                  { "log", NativeFunction.Log },
                  { "log2", NativeFunction.Log2 },
                  { "log10", NativeFunction.Log10 },
                  { "pow", NativeFunction.Pow },
                  { "sin", NativeFunction.Sin }
              };

            this.Stack = new Stack<decimal>();
        }

        /// <summary>
        /// Gets or sets the variables.
        /// </summary>
        public Dictionary<string, decimal> Variables { get; set; }

        /// <summary>
        /// Gets or sets the functions.
        /// </summary>
        public Dictionary<string, NativeFunction> Functions { get; set; }

        /// <summary>
        /// Gets or sets the stack.
        /// </summary>
        public Stack<decimal> Stack { get; set; }

        /// <summary>
        /// Gets or sets the expression.
        /// </summary>
        public string Expression { get; set; }

        /// <summary>
        /// Gets or sets the lexem list.
        /// </summary>
        public List<Lexem> LexemList { get; set; }

        /// <summary>
        /// Gets the result.
        /// </summary>
        public decimal Result { get; private set; }

        /// <summary>
        /// The create lexem list.
        /// </summary>
        /// <param name="checkDefineVariable">
        /// The check define variable.
        /// </param>
        /// <returns>
        /// Возвращает список лексем
        /// </returns>
        /// <exception cref="Exception">
        /// Exception Unexpected lexem
        /// </exception>
        public List<Lexem> CreateLexemList(bool checkDefineVariable)
        {
            var splitResult = this.Expression.ToLower().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var lexemList = new List<Lexem>();
            foreach (var lexem in splitResult)
            {
                if (this.IsFunction(lexem))
                {
                    lexemList.Add(new Lexem { Value = lexem, Type = LexemType.Function });
                }
                else
                if (this.IsVariable(lexem, checkDefineVariable))
                {
                    lexemList.Add(new Lexem { Value = lexem, Type = LexemType.Variable });
                }
                else if (this.IsConstant(lexem))
                {
                    lexemList.Add(new Lexem { Value = lexem, Type = LexemType.Constant });
                }
                else if (this.IsOperation(lexem))
                {
                    lexemList.Add(new Lexem { Value = lexem, Type = LexemType.Operator });
                }
                else
                {
                    throw new Exception("Неудалось распознать выражение: " + lexem);
                }
            }

            return lexemList;
        }

        /// <summary>
        /// The set variable.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        public void SetVariable(string name, decimal value)
        {
            if (this.HasVariable(name.ToLower()))
            {
                this.Variables[name.ToLower()] = value;
            }
            else
            {
                this.Variables.Add(name.ToLower(), value);
            }
        }

        /// <summary>
        /// The has variable.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool HasVariable(string name)
        {
            return this.Variables.ContainsKey(name.ToLower());
        }

        /// <summary>
        /// The has function.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool HasFunction(string name)
        {
            return this.Functions.ContainsKey(name.ToLower());
        }

        /// <summary>
        /// The execute.
        /// </summary>
        /// <exception cref="Exception">
        /// Unexpected lexem
        /// </exception>
        public void Execute()
        {
            try
            {
                var decimalSeparator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
                foreach (var lexem in this.LexemList)
                {
                    switch (lexem.Type)
                    {
                        case LexemType.Constant:
                            this.Stack.Push(decimal.Parse(lexem.Value.Replace(".", decimalSeparator)));
                            break;
                        case LexemType.Variable:
                            this.Stack.Push(this.Variables[lexem.Value]);
                            break;
                        case LexemType.Function:
                            {
                                var func = this.Functions[lexem.Value];
                                var args = new List<decimal>();
                                for (var i = 0; i < func.NeededArgs; ++i)
                                {
                                    args.Add(this.Stack.Pop());
                                }

                                this.Stack.Push(func.Execute(args.ToArray()));
                            }

                            break;
                        case LexemType.Operator:
                            this.Stack.Push(this.BasicFunction(lexem.Value));
                            break;
                    }
                }

                this.Result = this.Stack.Pop();
            }
            catch (Exception)
            {
                throw new Exception("Ошибка выполнения арифметического выражения");
            }

            if (this.Stack.Count != 0)
            {
                throw new Exception("Ошибка выполнения арифметического выражения");
            }
        }

        /// <summary>
        /// The basic function.
        /// </summary>
        /// <param name="f">
        /// The f.
        /// </param>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        public decimal BasicFunction(string f)
        {
            decimal result = 0;
            decimal t1;
            decimal t2;
            switch (f)
            {
                case "+":
                    t1 = this.Stack.Pop();
                    t2 = this.Stack.Pop();
                    result = t2 + t1;
                    break;
                case "-":
                    t1 = this.Stack.Pop();
                    t2 = this.Stack.Pop();
                    result = t2 - t1;
                    break;
                case "*":
                    t1 = this.Stack.Pop();
                    t2 = this.Stack.Pop();
                    result = t2 * t1;
                    break;
                case "/":
                    t1 = this.Stack.Pop();
                    t2 = this.Stack.Pop();
                    result = t2 / t1;
                    break;

                case "^":
                    t1 = this.Stack.Pop();
                    t2 = this.Stack.Pop();
                    result = (decimal)Math.Pow((double)t2, (double)t1);
                    break;
            }

            return result;
        }

        /// <summary>
        /// The is number.
        /// </summary>
        /// <param name="s">
        /// The s.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool IsConstant(string s)
        {
            var decimalSeparator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            decimal parseValue;
            var result = decimal.TryParse(s.Replace(".", decimalSeparator), out parseValue);
            return result;
        }

        /// <summary>
        /// The is function.
        /// </summary>
        /// <param name="s">
        /// The s.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool IsFunction(string s)
        {
            return this.HasFunction(s);
        }

        /// <summary>
        /// The is variable.
        /// </summary>
        /// <param name="s">
        /// The s.
        /// </param>
        /// <param name="checkDefineVariable">
        /// The check Define Variable.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool IsVariable(string s, bool checkDefineVariable)
        {
            var result = checkDefineVariable ? this.HasVariable(s) : Regex.IsMatch(s, @"[$_a-zA-Z]+[$_a-zA-Z0-9]*", RegexOptions.Compiled);
            return result;
        }

        /// <summary>
        /// The is operation.
        /// </summary>
        /// <param name="s">
        /// The s.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool IsOperation(string s)
        {
            return s.In("+", "-", "*", "/", "^");
        }
    }
}