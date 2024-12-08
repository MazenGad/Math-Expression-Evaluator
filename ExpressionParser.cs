using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Math_Expression_Evaluator
{
    internal static class ExpressionParser
    {

        private static string MathSympols = "+*/^%";
        public static MathExpression Parse(string input)
        {
            MathExpression expr = new MathExpression();
            string token = "";
            bool LeftSideInitialized = false;
            input = input.Trim();
            for (int i = 0; i < input.Length; i++)
            {
                var currentChar = input[i];
                
                if (char.IsDigit(currentChar))
                {
                    token += currentChar;
                    if(LeftSideInitialized && i+1 == input.Length)
                    {
                        expr.RightSideOperand = double.Parse(token);
                        token = "";
                    }
                }

                else if (MathSympols.Contains(currentChar))
                {
                    if (!LeftSideInitialized)
                    {
                        expr.LeftSideOperand = double.Parse(token);
                        LeftSideInitialized = true;
                    }

                    expr.Operation = ParseMathOperation(currentChar.ToString());
                    token = "";
                }

                else if (char.IsLetter(currentChar))
                {
                    token += currentChar;
                    LeftSideInitialized = true;

                }

                else if(currentChar == ' ')
                {
                    if (!LeftSideInitialized)
                    {
                        expr.LeftSideOperand = double.Parse(token);
                        LeftSideInitialized = true;
                        token = "";

                    }
                    else if(expr.Operation == MathOperation.None)
                    {
                        expr.Operation = ParseMathOperation(token);
                        token = "";
                    }
                }

                else if(currentChar == '-' && i > 0)
                {
                    if(expr.Operation == MathOperation.None)
                    {
                        expr.Operation = MathOperation.Subtraction;

                        if (!LeftSideInitialized)
                        {
                            expr.LeftSideOperand = double.Parse(token);
                            LeftSideInitialized = true;

                        }

                        token = "";

                    }
                    else if(expr.Operation != MathOperation.None)
                    {
                        token += currentChar;
                    }

                }
                else 
                    token += currentChar;
            }

            return expr;
        }

        private static MathOperation ParseMathOperation(string operation)
        {
            switch (operation.ToLower())
            {
                case "+":
                    return MathOperation.Addition;

                case "*":
                    return MathOperation.Multiplication;

                case "/":
                    return MathOperation.Division;

                case "%":
                case "mod":
                    return MathOperation.Modulus;

                case "^":
                case "pow":
                    return MathOperation.Power;

                case "sin":
                    return MathOperation.Sin;

                case "cos":
                    return MathOperation.Cos;

                case "tan":
                    return MathOperation.Tan;

                default : return MathOperation.None;
            }
        }
    }
}
