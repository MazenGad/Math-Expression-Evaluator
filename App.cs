using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Math_Expression_Evaluator
{
    public static class App
    {
        public static void Run(string[] args)
        {
            while (true)
            {
                Console.Write("Enter Your Expression : ");
                var input = Console.ReadLine();

                var expr = ExpressionParser.Parse(input);

                Console.Write($@"Left Operand = {expr.LeftSideOperand} , ");
                Console.Write($@"Operation = {expr.Operation} , ");
                Console.WriteLine($@"Right Operand = {expr.RightSideOperand}");

                Console.WriteLine($@"{input} = {EvaluateExpression(expr)}");
            }
        }

        private static object EvaluateExpression(MathExpression expr)
        {
            switch (expr.Operation)
            {
                case MathOperation.Addition:
                    return expr.LeftSideOperand + expr.RightSideOperand;

                case MathOperation.Subtraction:
                    return expr.LeftSideOperand - expr.RightSideOperand;

                case MathOperation.Multiplication:
                    return expr.LeftSideOperand * expr.RightSideOperand;

                case MathOperation.Division:
                    return expr.LeftSideOperand / expr.RightSideOperand;

                case MathOperation.Modulus:
                    return expr.LeftSideOperand % expr.RightSideOperand;

                case MathOperation.Power:
                    return Math.Pow(expr.LeftSideOperand, expr.RightSideOperand);

                case MathOperation.Sin:
                    return Math.Sin( expr.RightSideOperand);

                case MathOperation.Cos:
                    return Math.Cos(expr.RightSideOperand);

                case MathOperation.Tan:
                    return Math.Tan(expr.RightSideOperand);

                default: return MathOperation.None;
            }


        }
    }
}
