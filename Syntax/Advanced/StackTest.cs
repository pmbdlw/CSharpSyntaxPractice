namespace CSharpExcise.Syntax.Advanced;

public class StackTest
{
    public static void Test()
    {
        Stack<int> stack = new();
        for (var i = 0; i < 10; i++)
        {
            var tmp = new Random(i).Next(0, 100);
            Console.Write(tmp+",");
            stack.Push(tmp);
        }
        Console.WriteLine($"\n Count:{stack.Count}");
        Console.WriteLine(string.Join(',',stack));
        stack.Pop();
        Console.WriteLine(string.Join(',',stack));
        Console.WriteLine($" Count:{stack.Count}");
        stack.Peek();
        Console.WriteLine(string.Join(',',stack));
        Console.WriteLine($" Count:{stack.Count}");
        stack.TrimExcess();
        
        Console.WriteLine($"After trim excess Count:{stack.Count}");
        
    }
}