namespace CSharpExcise.Syntax.Advanced;

public class QueueTest
{
    public static void Test()
    {
        Queue<int> queue = new();
        for (var i = 0; i < 10; i++)
        {
            var tmp = new Random(i).Next(0, 100);
            Console.Write(tmp+",");
            queue.Enqueue(tmp);
        }
        // There is no method to get the capacity of the queue.
        Console.WriteLine($"\n Count:{queue.Count}");
        Console.WriteLine(string.Join(',',queue));
        queue.Dequeue();
        Console.WriteLine(string.Join(',',queue));
        Console.WriteLine($" Count:{queue.Count}");
        queue.Peek();
        Console.WriteLine(string.Join(',',queue));
        Console.WriteLine($" Count:{queue.Count}");
        queue.TrimExcess();
        
        Console.WriteLine($"After trim excess Count:{queue.Count}");
    }
}