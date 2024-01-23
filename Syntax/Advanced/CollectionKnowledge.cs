using System.Collections;
using System.Collections.ObjectModel;

namespace CSharpExcise.Syntax.Advanced;

public class CollectionKnowledge
{
 public static void IndexTest()
 {
     ILookup<int, string> a;
     var predicateNumbers = new TestPeridate(new List<int>
     {
         1, 2, 41, 21, 33, 12, 42
     });
     var numbers = predicateNumbers.GetOddNumbers();
     Console.WriteLine(string.Join(',',numbers));
     numbers[0] = 6;
     Console.WriteLine(string.Join(',',numbers));;
     Console.WriteLine(string.Join(',',predicateNumbers.GetOddNumbers()));
     
         
     IList<string> strList = new List<string>();
     strList.Add("a");
     strList.Add("b");
     for (int i = 0; i < strList.Count; i++)
     {
         Console.WriteLine(strList[i]);
     }
 }

 public static void ArrayListTest()
 {
     var testArrList = new ArrayList();
     testArrList.Add(1);
     testArrList.Add("test");
    
     foreach (var ele in testArrList)
     {
         Console.WriteLine(ele.ToString());
     }

     var arrInt = CreateFixedLengthArray(typeof(int));
     var arrStr = CreateFixedLengthArray(typeof(string));
     for (int i = 0; i < arrInt.Length; i++)
     {
         arrInt.SetValue(i,i);
         arrStr.SetValue($"test{i}",i);
     }

     foreach (var ele in arrInt)
     {
         Console.Write($"{ele},");
     }
     Console.WriteLine();
     foreach (var ele in arrStr)
     {
         Console.Write($"{ele},");
     }
     Console.WriteLine();
     
     int[] intArr = {1,2,3,4,5};
     string[] strArr = {"a","b","c","d","e"};
     Console.WriteLine(arrInt.GetType());
     Console.WriteLine(arrStr.GetType());
     Console.WriteLine(typeof(int[]));
     Console.WriteLine(typeof(string[]));
     var a = new List<int>();
     // a.ToList()
 }

 public static Array CreateFixedLengthArray(Type type)
 {
     return Array.CreateInstance(type, 10);
 }
}

public class TestPeridate
{
    private List<int> _numbers;
    public TestPeridate(List<int> numbers) => _numbers = numbers;
    public List<int> GetOddNumbers()
    {
        return _numbers.FindAll(num => num % 2 == 0);
    }

    // public ReadOnlyCollection<int> GetOddNumbers()
    // {
    //     return _numbers.FindAll(num => num % 2 == 0).AsReadOnly();
    // }
}