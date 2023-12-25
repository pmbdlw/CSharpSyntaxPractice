using System;

namespace CSharpTest.Delegate
{
    public delegate int CalculateOptionTwoNumbers(int a, int b);
    public class GeneralDelegate
    {
        public int SumCalculateOption(CalculateOptionTwoNumbers[] options,int a, int b)
        {
            int retVal = 0;
            foreach (var option in options)
            {
                retVal += option(a, b);
            }
            return retVal;
        }
        
        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Subtract(int a, int b)
        {
            return a - b;
        }

        public int Multiply(int a, int b)
        {
            return a * b;
        }

        public int Divide(int a, int b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero");
            }
            return a / b;
        }
    }
}