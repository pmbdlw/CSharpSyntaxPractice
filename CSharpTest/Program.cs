using System;
using System.Collections;
using CSharpTest.Delegate;

namespace CSharpTest
{
    class Program
    {
        static void Main(string[] args)
        {
            DelegateStudy.GeneralDelegatePractice(5,6);
            Console.ReadLine();
        }

        private static void GenericTest()
        {
            var testObj = new GenericStudy();
            Console.WriteLine(testObj.ShowFullName<Person>("Andrew", "Smith"));
        }

        private static void DelegateTest()
        {
            Func<string,string> greet = delegate(string name) { return "Hi " + name;};
            greet += name => { return "How are you!"; }; 
            Console.Write(greet("Neo"));
        }

        private static void AddBeforeOrAfterITest()
        {
            int i = 2;
            Console.WriteLine(++i);
            Console.WriteLine(i++);
            Console.WriteLine(i);
        }
        
        private void EnumTest()
        {
            Console.WriteLine((int)Color.Red);
            Console.WriteLine((int)Color.Green);
            Console.WriteLine((int)Color.Blue);
            Console.WriteLine(Color.Green == Color.Blue);
            Console.WriteLine(Object.ReferenceEquals(Color.Green,Color.Blue));
        }
        
        private void TryCatchTest()
        {
            Console.WriteLine("Hello World!");
            int[] arr = { 1, 2, 3, 4, 5 };
            try
            {
                Console.Write(arr[10]);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Index exception.");
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Null reference exception.");
            }
            catch (Exception)
            {
                Console.WriteLine("Common Exception.");
            }
            
        }
    }
    
    public class InterfaceTest:Itest1,Itest2,IProtectedMemberTest
    {
        public void Test()
        {
            Console.WriteLine("Hello World!");
        }

        void Itest1.Add(int a, int b)
        {
            Console.WriteLine("Itest1 add result is "+(a+b));
        }

        void Itest2.Add(int a, int b)
        {
            Console.WriteLine("Itest2 add result is "+(a+b));
        }

        void IProtectedMemberTest.Show()
        {
            
        }
    }

    interface Itest1
    {
        void Add(int a, int b);
    }
    
    interface Itest2
    {
        void Add(int a, int b);
    }

    interface IProtectedMemberTest
    {
        protected void Show();
    }

    enum Color
    {
        Red,
        Green=0,
        Blue=0
    }
}