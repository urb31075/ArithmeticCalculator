// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NativeFunction.cs" company="URB31075">
//  All Right Reserved 
// </copyright>
// <summary>
//   The native function.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ArithmeticCalculator
{
    using System;

    /// <summary>
    /// The native function.
    /// </summary>
    public class NativeFunction
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NativeFunction"/> class.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="function">
        /// The function.
        /// </param>
        /// <param name="neededArgs">
        /// The needed args.
        /// </param>
        public NativeFunction(string name, Func<decimal[], decimal> function, int neededArgs)
        {
            this.Name = name;
            this.Function = function;
            this.NeededArgs = neededArgs;
        }

        /// <summary>
        /// Gets the sin.
        /// </summary>
        public static NativeFunction Sin
        {
            get
            {
                return new NativeFunction("sin", a => (decimal)Math.Sin((double)a[0]), 1);
            }
        }

        /// <summary>
        /// Gets the cos.
        /// </summary>
        public static NativeFunction Cos
        {
            get
            {
                return new NativeFunction("cos", a => (decimal)Math.Cos((double)a[0]), 1);
            }
        }

        /// <summary>
        /// Gets the sqrt.
        /// </summary>
        public static NativeFunction Sqrt
        {
            get
            {
                return new NativeFunction("sqrt", a => (decimal)Math.Sqrt((double)a[0]), 1);
            }
        }

        /// <summary>
        /// Gets the exp.
        /// </summary>
        public static NativeFunction Exp
        {
            get
            {
                return new NativeFunction("exp", a => (decimal)Math.Exp((double)a[0]), 1);
            }
        }

        /// <summary>
        /// Gets the abs.
        /// </summary>
        public static NativeFunction Abs
        {
            get
            {
                return new NativeFunction("abs", a => Math.Abs(a[0]), 1);
            }
        }

        /// <summary>
        /// Gets the ln.
        /// </summary>
        public static NativeFunction Log10
        {
            get
            {
                return new NativeFunction("ln", a => (decimal)Math.Log10((double)a[0]), 1);
            }
        }

        /// <summary>
        /// Gets the lb.
        /// </summary>
        public static NativeFunction Log2
        {
            get
            {
                return new NativeFunction("lb", a => (decimal)Math.Log((double)a[0], 2.0), 1);
            }
        }

        /// <summary>
        /// Gets the log.
        /// </summary>
        public static NativeFunction Log
        {
            get
            {
                return new NativeFunction("log", a => (decimal)Math.Log((double)a[0], (double)a[1]), 2);
            }
        }

        /// <summary>
        /// Gets the pow.
        /// </summary>
        public static NativeFunction Pow
        {
            get
            {
                return new NativeFunction("pow", a => (decimal)Math.Pow((double)a[0], (double)a[1]), 2);
            }
        }

        /// <summary>
        /// Gets the atan.
        /// </summary>
        public static NativeFunction Atan
        {
            get
            {
                return new NativeFunction("atan", a => (decimal)Math.Atan((double)a[0]), 1);
            }
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the function.
        /// </summary>
        public Func<decimal[], decimal> Function { get; set; }

        /// <summary>
        /// Gets or sets the needed args.
        /// </summary>
        public int NeededArgs { get; set; }

        /// <summary>
        /// The execute.
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        /// <returns>
        /// The <see cref="decimal"/>.
        /// </returns>
        public decimal Execute(params decimal[] args)
        {
            return this.Function(args);
        }
    }
}