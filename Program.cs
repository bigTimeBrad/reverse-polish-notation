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
            return operandStack.Pop().ToString();
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

                for (int i = 0; i < values.Count(); i++)
                {
                    //remove an value
                    int val = values.Pop();

                    //check the value
                    if (val > maxVal) { maxVal = val; }

                    //and place into a stack
                    tempStack.Push(val);
                }

                for(int i = 0; i < tempStack.Count(); i++)
                {
                    // pop the temp val
                    int val = tempStack.Pop();
                     
                    //compare it to the max
                    if (val < maxVal) {
                        //place it back if its less
                        values.Push(val);
                    }
                }

                return 0;
            }
             
            // For testing. Don't modify.
            public static void Main(string[] args)
            {
                RPN rpn = new RPN();
                rpn.Process("5");
                rpn.Process("4");
                rpn.Process("*");


                Console.WriteLine("result = " + rpn.Result());

               
            }
        }
    }
}
