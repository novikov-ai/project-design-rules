using System;
using System.Linq;

namespace RemovePrimitivesDataStructures.Example2
{
    public enum Operations
    {
        Add,
        Sub,
        Multiply,
        Divide,
    }
    public static class ReversePolishCalc
    {
        private static int CalculateResult(Operations operation, int num1, int num2)
        {
            switch (operation)
            {
                case Operations.Add:
                    return num1 + num2;
                case Operations.Sub:
                    return num1 - num2;
                case Operations.Multiply:
                    return num1 * num2;
                case Operations.Divide:
                    return num1 / num2;
                default:
                    {
                        throw new ArgumentException(@"Check the expression. 
                Allowed only operations: +, -, *, /.");
                    }
            }
        }

        private static void PushToStackCalculatedResult(Stack<int> stack, string item)
        {
            int num2 = stack.Pop();
            int num1 = stack.Pop();

            stack.Push(CalculateResult(item, num1, num2));
        }
    }
}