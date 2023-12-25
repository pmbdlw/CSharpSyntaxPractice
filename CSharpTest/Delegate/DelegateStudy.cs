using System;

namespace CSharpTest.Delegate
{
    public static class DelegateStudy
    {
        
        // General delegate
        public static void GeneralDelegatePractice(int a, int b)
        {
            var calcu = new GeneralDelegate();
            var optionList = new CalculateOptionTwoNumbers[] { calcu.Add, calcu.Subtract, calcu.Multiply, calcu.Divide };
            Console.WriteLine(calcu.SumCalculateOption(optionList, a,b));
        }
        // Anonymous delegate
        
        // Lambda
        
        // Event
        
        // Action<T1,...,Tn>
        
        // Function<T1,...,TResult>
    }
}