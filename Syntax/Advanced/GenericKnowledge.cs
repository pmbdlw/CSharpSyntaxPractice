using System.Collections;
using System.Globalization;
using Random = System.Random;

namespace CSharpExcise.Syntax.Advanced;

public static class GenericKnowledge
{
    // public static void Geer
    public static void GenericKnowledgeTest()
    {
        InterfaceClass interfaceClass = new InterfaceClass();
        TestClass testClass = new TestClass();
        testClass.ID = 100;
        testClass.PublicField = "I am a public field.";
        var genericTestMethod = new GenericTestMethod<InterfaceClass, TestClass>(interfaceClass, testClass);
        genericTestMethod.Test();
    }

    public static void CommonInnerGenericType()
    {
        // List list = ArrayList.Repeat("a", 10);
        IList<string> listT;
    }
}

public class GenericTestMethod<T1, T2> where T1 : ITestInterface
    where T2 : TestClass
{
    private T1 _t1;
    private T2 _t2;

    public GenericTestMethod(T1 t1, T2 t2)
    {
        this._t1 = t1;
        this._t2 = t2;
    }

    public void Test()
    {
        _t1.DisplayAssemblyName();
        _t2.ClassMethod();
        // t2.ID = new Random().Next(100, 200);
        // t2.PublicField = "I am a public field.";
        Console.WriteLine(_t2.ID);
        Console.WriteLine(_t2.PublicField);
    }
}

public interface ITestInterface
{
    void DisplayAssemblyName();
}

public class InterfaceClass : ITestInterface
{
    public void DisplayAssemblyName()
    {
        Console.WriteLine(this.GetType());
    }
}

public class TestClass
{
    public int ID { get; set; }
    public string PublicField;

    public void ClassMethod()
    {
        Console.WriteLine("I am a class.");
    }
}