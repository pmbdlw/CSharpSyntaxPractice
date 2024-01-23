using System.Collections;
using System.Security;

namespace CSharpExcise.Syntax.Advanced;

public class EnumerableTest
{
    public static void Test()
    {
        foreach (var ele in SimpleList())
        {
            Console.WriteLine(ele);
        }
    }

    public static IEnumerable SimpleList()
    {
        yield return 1;
        yield return 2;
        yield return 3;
    }
}

// public class Enumrable