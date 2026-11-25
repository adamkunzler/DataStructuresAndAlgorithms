using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Algorithms
{
    public static class Conversions
    {
        /// <summary>
        /// Convert an integer number to its binary form
        /// </summary>
        /// <param name="integerNumber"></param>
        /// <returns></returns>
        public static string IntegerToBinary(int integerNumber)
        {
            var stack = new DataStructures.AStack<int>();

            while(integerNumber > 0)
            {
                stack.Push(integerNumber % 2);
                integerNumber /= 2;
            }

            var binaryString = new StringBuilder();
            while(!stack.IsEmpty())
            {
                binaryString.Append(stack.Pop());
            }

            return binaryString.ToString();
        }

        /// <summary>
        /// very rudimentary infix to postfix converter. only handles single digit numbers. todo would be to tokenize the input and pass that to the function.
        /// </summary>
        /// <param name="infixExpression"></param>
        /// <returns></returns>
        public static string InfixToPostfix(string infixExpression)
        {
            int Precedence(char op)
            {
                return op switch
                {                    
                    '+' or '-' => 1,
                    '*' or '/' => 2,
                    '^' => 3,
                    _ => 0
                };
            }

            var stack = new DataStructures.AStack<char>();
            var output = new StringBuilder();

            foreach(var ch in infixExpression)
            {
                if (char.IsWhiteSpace(ch)) continue;


                if (char.IsDigit(ch))
                {
                    output.Append(ch);
                    output.Append(' ');
                }
                else if (ch == '(')
                {
                    stack.Push(ch);
                }
                else if (ch == ')')
                {
                    var tempC = stack.Pop();
                    while (tempC != '(')
                    {
                        output.Append(tempC);
                        output.Append(' ');
                        
                        if (stack.IsEmpty()) break;
                        
                        tempC = stack.Pop();
                    }
                }
                else
                {
                    while (!stack.IsEmpty() && Precedence(stack.Peek()) >= Precedence(ch))
                    {
                        output.Append(stack.Pop());
                        output.Append(' ');
                    }

                    stack.Push(ch);
                }

            }

            // flush the stack
            while (!stack.IsEmpty())
            {
                output.Append(stack.Pop());
                output.Append(' ');
            }


            return output.ToString();

        }

        /// <summary>
        /// Evaluate a postfix expression (basic)
        /// </summary>
        /// <param name="postfix"></param>
        /// <returns></returns>
        public static int EvalPostfix(string postfix)
        {
            var stack = new DataStructures.AStack<int>();

            foreach (var ch in postfix)
            {
                if (char.IsWhiteSpace(ch)) continue;

                int left, right;
                int result;

                if (char.IsDigit(ch))
                {
                    stack.Push(ch - '0'); // convert char to int
                }
                else
                {
                    right = stack.Pop();
                    left = stack.Pop();
                    result = ch switch
                    {
                        '+' => left + right,
                        '-' => left - right,
                        '*' => left * right,
                        '/' => left / right,
                        _ => throw new InvalidOperationException($"Unsupported operator: {ch}")
                    };
                    stack.Push(result);
                }
            }

            if(stack.Count() == 1)
            {
                return stack.Pop();
            }
            else
            {
                throw new InvalidOperationException("Invalid postfix expression");
            }            
        }
    } // end class
} // end namespace
