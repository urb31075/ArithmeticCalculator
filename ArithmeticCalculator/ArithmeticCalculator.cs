// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ArithmeticCalculator.cs" company="URB31075">
//   All Right Reserved
// </copyright>
// <summary>
//   Defines the MyParser type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ArithmeticCalculator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The my parser.
    /// </summary>
    public class ArithmeticCalculator
    {
        /// <summary>
        /// The reverse polish notation.
        /// </summary>
        private ReversePolishNotation reversePolishNotation;

        /// <summary>
        /// Prevents a default instance of the <see cref="ArithmeticCalculator"/> class from being created.
        /// </summary>
        private ArithmeticCalculator()
        {
            this.reversePolishNotation = new ReversePolishNotation();
        }

        /// <summary>
        /// Выражение в обратной польской нотации
        /// </summary>
        public string PostFix { get; private set; }

        /// <summary>
        /// Список переменных
        /// </summary>
        public List<string> VariableList { get; private set; }

        /// <summary>
        /// Создание экземпляра арифметического калькулятора
        /// </summary>
        /// <param name="expression">
        /// The expression.
        /// </param>
        /// <returns>
        /// Возврат экземпляра арифметического калькулятора
        /// </returns>
        public static ArithmeticCalculator CreateInstance(string expression)
        {
            var arithmeticCalculator = new ArithmeticCalculator
                  {
                      reversePolishNotation = new ReversePolishNotation(),
                      PostFix = InfixToPostfixConversion(expression)
                  };

            arithmeticCalculator.reversePolishNotation.Expression = arithmeticCalculator.PostFix;
            var lexemList = arithmeticCalculator.reversePolishNotation.CreateLexemList(false); // Без проверки предопределенных переменных
            arithmeticCalculator.VariableList = lexemList.Where(c => c.Type == LexemType.Variable).Select(c => c.Value).ToList();
            return arithmeticCalculator;
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
        public void SetVariableValue(string name, decimal value)
        {
            this.reversePolishNotation.SetVariable(name, value);
        }

        /// <summary>
        /// The execute.
        /// </summary>
        /// <returns>
        /// The <see cref="decimal"/>.
        /// </returns>
        public decimal Execute()
        {
            this.reversePolishNotation.LexemList = this.reversePolishNotation.CreateLexemList(true); // С проверкой предорпределенных переменных            
            this.reversePolishNotation.Execute();
            return this.reversePolishNotation.Result;
        }

        /// <summary>
        /// The preprocessing string.
        /// </summary>
        /// <param name="infix">
        /// The infix.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private static string PreprocessingString(string infix)
        {
            string processedString = string.Empty;
            var expr = infix.Replace(" ", string.Empty);
            for (var i = 0; i < expr.Length; ++i)
            {
                var curr = expr[i];
                var next = '@';
                var pred = '@';

                if (i > 0)
                {
                    pred = expr[i - 1];
                }

                if (i < expr.Length - 2)
                {
                    next = expr[i + 1];
                }

                if (curr.In('-') && pred.In('@', '(', ',', '+', '-', '*', '/'))
                {
                    // Определили, что "-" это унитарный оператор
                    if (char.IsLetter(next) || next.In('('))
                    {
                        processedString += "(~1)*";
                    }
                    else
                    {
                        processedString += "~"; // Вставили ~ в качестве оператора инверсии
                    }
                }
                else
                {
                    processedString += curr;
                }
            }

            return processedString;
        }

        /// <summary>
        /// The check infix string.
        /// </summary>
        /// <param name="infix">
        /// The infix.
        /// </param>
        /// <exception cref="Exception">
        /// Exception Недопустимый символ во входном выражении
        /// </exception>
        private static void CheckInfixString(string infix)
        {
            var expr = infix.Replace(" ", string.Empty);
            foreach (var curr in expr)
            {
                if (char.IsLetterOrDigit(curr) || curr.In('(', ')', ',', '+', '-', '*', '/', '^', '.'))
                {
                    continue;
                }

                var msg = string.Format("Недопустимый символ во входном выражении: {0}", curr);
                throw new Exception(msg);
            }
        }

        /// <summary>
        /// The standart to rpn.
        /// </summary>
        /// <param name="infix">
        /// The expr.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private static string InfixToPostfixConversion(string infix)
        {
            CheckInfixString(infix);
            var expr = PreprocessingString(infix);
            var lexemList = GetLexem(expr);
            var operators = new Stack<Lexem>();
            var result = new List<string>();
            foreach (var item in lexemList)
            {
                if (item.Type.In(LexemType.Variable, LexemType.Constant))
                {
                    result.Add(item.Value);
                }
                else if (item.Type == LexemType.Operator && item.Value == ")")
                {
                    Lexem l0;
                    while ((l0 = operators.Pop()).Value != "(")
                    {
                        if (l0.Value != ",")
                        {
                            result.Add(l0.Value);
                        }
                    }
                }
                else if (item.Type.In(LexemType.Operator, LexemType.Function))
                {
                    if (operators.Count > 0 && (GetPriority(operators.Peek()) >= GetPriority(item)))
                    {
                        if (item.Value.In("(", ")") == false)
                        {
                            var l0 = operators.Pop();
                            if (l0.Value != ",")
                            {
                                result.Add(l0.Value);
                            }
                        }
                    }

                    operators.Push(item);
                }
            }

            while (operators.Count > 0)
            {
                var l0 = operators.Pop();
                if (l0.Value != ",")
                {
                    result.Add(l0.Value);
                }
            }

            string rpnExpr = string.Join(" ", result);
            return rpnExpr;
        }

        /// <summary>
        /// The get ast.
        /// </summary>
        /// <param name="expr">
        /// The expr.
        /// </param>
        /// <returns>
        /// Возврат списка лексем
        /// </returns>
        /// <exception cref="Exception">
        /// Unexpected char 
        /// </exception>
        private static IEnumerable<Lexem> GetLexem(string expr)
        {
            var lexemList = new List<Lexem>();
            var lexem = string.Empty;
            var readingId = false;
            var nextType = LexemType.NoLexem;
            foreach (var curr in expr)
            {
                if (char.IsLetter(curr))
                {
                    if (!readingId)
                    {
                        nextType = LexemType.Identifier;
                        readingId = true;
                    }

                    lexem += curr;
                }
                else if (char.IsDigit(curr))
                {
                    if (!readingId)
                    {
                        nextType = LexemType.Constant;
                        readingId = true;
                    }

                    lexem += curr;
                }
                else if (curr == '.' && readingId && nextType == LexemType.Constant)
                {
                    lexem += '.';
                }
                else if (curr == '.' && readingId && nextType != LexemType.Constant) 
                {
                    throw new Exception("Недопустимое использование разделителя десятичных разрядов '.' !");
                }
                else if (curr.In('~'))
                {
                    nextType = LexemType.Constant;
                    readingId = true;
                    lexem += '-';
                }
                else if (curr.In('(', ')', '+', '-', '*', '/', '^'))
                {
                    if (readingId)
                    {
                        readingId = false;
                        if (curr == '(' && nextType == LexemType.Identifier)
                        {
                            nextType = LexemType.Function;
                        }
                        else if (curr != '(' && nextType == LexemType.Identifier)
                        {
                            nextType = LexemType.Variable;
                        }

                        lexemList.Add(new Lexem { Value = lexem, Type = nextType });
                        lexem = string.Empty;
                    }

                    lexemList.Add(new Lexem { Value = curr.ToString(), Type = LexemType.Operator });
                }
                else if (curr == ',')
                {
                    if (readingId)
                    {
                        readingId = false;
                        if (curr != '(' && nextType == LexemType.Identifier)
                        {
                            nextType = LexemType.Variable;
                        }

                        lexemList.Add(new Lexem { Value = lexem, Type = nextType });
                        lexem = string.Empty;
                    }

                    lexemList.Add(new Lexem { Value = curr.ToString(), Type = LexemType.Delimier });
                }
            }

            if (lexem != string.Empty)
            {
                if (nextType == LexemType.Identifier)
                  {
                      nextType = LexemType.Variable;
                      lexemList.Add(new Lexem { Value = lexem, Type = nextType });
                  }
                  else
                  {
                      lexemList.Add(new Lexem { Value = lexem, Type = nextType });
                  }
            }

            return lexemList;
        }

        /// <summary>
        /// The get priority.
        /// </summary>
        /// <param name="lexem">
        /// The l.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        private static int GetPriority(Lexem lexem)
        {
            var priority = -1;
            if (lexem.Type == LexemType.Operator)
            {
                if (lexem.Value.In("(", ")"))
                {
                    priority = 0;
                }

                if (lexem.Value.In("+", "-"))
                {
                    priority = 1;
                }

                if (lexem.Value.In("*", "/"))
                {
                    priority = 2;
                }

                if (lexem.Value.In("^"))
                {
                    priority = 3;
                }
            }

            if (lexem.Type == LexemType.Function)
            {
                priority = 4;                
            }

            return priority;
        }
    }
}