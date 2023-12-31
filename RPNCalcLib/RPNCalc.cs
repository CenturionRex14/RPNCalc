﻿/*
Supported operations:
+ - Adds X and Y
- - Subtracts X from Y
/ - Divides Y by X
* - Multiplies Y by X
% - Gives remainder of Y / X
D - Drops X
S - Swaps X and Y
<Enter> - View current registers if no proceeding char
C - Clears registers
P - Push registers up

Stretch Goals:
M - Saves X into memory
V - Prints value in memory
E - Erases memory (set to 0)
L - takes place of memory in operation, e.g.:
    >5M (stores 5 into memory)
    >6<enter>
    >L*
    30
    >
*/
namespace RPNCalcLib
{
    public record class RPNCalc()
    {
        protected List<double> stack = new();
        protected double mem = 0;

        //TODO: Implement getters and setters for properies
        public double X
        {
            get => (stack.Count > 0) ? stack[^1] : 0;
            protected set
            {
                if (stack.Count < 1)
                {
                    stack.Add(value);
                }
                else
                {
                    stack[^1] = value;
                }
            }
        }
        public double Y
        {
            get => (stack.Count > 1) ? stack[^2] : 0;
            set
            {

            }
        }

        public RPNCalc Push(double num)
        {
            stack.Add(num);
            return this;
        }

        public double Drop()
        {
            double rtn = 0;
            if (stack.Count > 0)
            {
                rtn = stack[^1];
                stack.RemoveAt(stack.Count - 1);
            }
            return rtn;
        }

        public RPNCalc Swap()
        {
            double a = 0;
            double b = 0;
            if (stack.Count > 1)
            {
                a = X;
                b = Y;
                X = b;
                Y = a;
            }
            else if (stack.Count == 1)
            {
                stack.Add(0);
            }
            return this;
        }

        public RPNCalc Clear()
        {
            stack.Clear();
            return this;
        }


        public RPNCalc Add()
        {
            double temp = Drop();
            if (stack.Count > 0)
            {
                stack[^1] += temp;
            }
            else
            {
                stack.Add(temp);
            }
            return this;
        }

        public RPNCalc Subtract()
        {
            double temp = Drop();
            if (stack.Count > 0)
            {
                stack[^1] = stack[^1] - temp;
            }
            else
            {
                stack.Add(-1 * temp);
            }
            return this;
        }

        public RPNCalc Multiply()
        {
            double temp = Drop();
            if (stack.Count > 0)
            {
                stack[^1] *= temp;
            }
            return this;
        }

        public RPNCalc Divide()
        {
            double temp = Drop();
            if (stack.Count > 0 && temp != 0)
            {
                stack[^1] = stack[^1] / temp;
            }
            else if (temp == 0)
            {
                throw new DivideByZeroException();
            }
            return this;
        }

        public RPNCalc Modulo()
        {
            if (stack.Count < 2 || stack[^1] == 0 || stack[^2] == 0)
            {
                Clear();
            }
            else
            {
                double temp = Drop();
                stack[^1] = stack[^1] % temp;
            }
            return this;
        }

        public RPNCalc SaveMem()
        {
            if (stack.Count == 0)
            {
                mem = 0;
            }
            else
            {
                mem = stack[^1];
            }
            return this;
        }

        public void EraseMem()
        {
            mem = 0;
        }

        public double Mem()
        {
            return mem;
        }
    }
}