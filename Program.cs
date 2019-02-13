using System;

namespace Postfixnotation
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    // 1. Create a Reverse Polish Notation calculator
    class RPN
    {
        // Handle numbers
        Stack<int> operandStack = new Stack<int>();

        // Handle operators (i.e. "+", "-", "*", "/")
        Stack<string> operatorStack = new Stack<string>();


        // example 5 4 + 
        public void Process(string input)
        {
            if (IsOperator(input))
            {
                // push the operator onto the stack
                operatorStack.Push(input);

                // process the stacks
                ProcessTheStack();
            }
            else
            {
                operandStack.Push(int.Parse(input)); // this could through error if a different operator is input... or NaN
            }
        }

        public string Result()
        {
            if (operandStack.Count() == 0) { return ""; }
            return operandStack.Peek().ToString();
        }

        public Boolean IsOperator(string input)
        {
            return input.Equals("+") || input.Equals("-") || input.Equals("*") || input.Equals("/");
        }

        public void ProcessTheStack()
        {
            // pop all the contents and store
            int operand1 = operandStack.Pop();
            int operand2 = operandStack.Pop();
            String operator1 = operatorStack.Pop();

            int result = 0;

            if (operator1.Equals("+"))
            {
                 result = operand1 + operand2;
            }
            else if (operator1.Equals("-"))
            {
                result = operand2 - operand1;
            }
            else if (operator1.Equals("*"))
            {
                result = operand1 * operand2;
            }
            else if (operator1.Equals("/"))
            {
                result = operand2 / operand1;
            }

            // push the result onto the stack.
            operandStack.Push(result);
        }

        class MainClass
        {
            // 2. Write a RemoveMax() function
            public static int RemoveMax(Stack<int> values)
            {
                // set max to the first value
                int maxVal = values.Peek();

                Stack<int> tempStack = new Stack<int>();

                int stackLength = values.Count();

                for (int i = 0; i < stackLength; i++)
                {
                    //remove a value
                    int val = values.Pop();

                    //find the hishest in the stack
                    if (val > maxVal) { maxVal = val;}

                    //and place all back into a stack
                    tempStack.Push(val);
                }

                stackLength = tempStack.Count();

                for (int i = 0; i < stackLength; i++)
                {
                    // pop the temp val
                    int val = tempStack.Pop();

                    //compare it to the max
                    if (val < maxVal)
                    {
                        //place it back if its less
                        values.Push(val);
                    }
                }
                return maxVal;
            }

            // For testing. Don't modify.
            public static void Main(string[] args)
            {
                RPN rpn = new RPN();
                rpn.Process("5");
                rpn.Process("4");
                rpn.Process("*");

                Console.WriteLine("result = " + rpn.Result());

                //make a stack
                Stack<int> testStack = new Stack<int>();
                testStack.Push(5);
                testStack.Push(1);
                testStack.Push(4);
                testStack.Push(7);

                Console.WriteLine("maxVal=" + RemoveMax(testStack));


            }
        }
    }
}
