using System.Globalization;
using System.Numerics;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Xml;

namespace CSharpExcise.Syntax.BasicCoding;

/// <summary>
/// Fundamental data types
/// </summary>
public static class DataTypes
{
    /**
     * - Numeric types
     * - Boolean
     * - Strings and Characters
     * - Arrays
     * - Tuples
     * - Objects
     * - Enums
     * - Nullable
     * - Dynamic
     */
    
    public static void NumericTypes()
    {
        // int[eger]
        // long
        // float
        // double
        // decimal
        int number1 = 1;
        // seven decimal digits with precision
        float number2 = 1.1f;
        // fifteen decimal digits with precision
        double number3 = 1.1;
        decimal number4 = 1.1m;
        long number5 = 1L;
        float testFloat = 2.1f;
        Console.WriteLine($"{number1  + 1} {number2  + 1} {number3  + 1} {number4  + 1} {number5  + 1}");
        // Test float,double,decimal counting precision
        Console.WriteLine($"float: 2.1 {((number2 + 1).Equals(testFloat)?"":"not")} equals {number2 + 1}");
        // Test float,double,decimal counting precision
        Console.WriteLine($"float: 2.1 {(Math.Abs((number2 + 1) - 2.1) < Double.Epsilon?"==":"!=")} {number2 + 1}");
        // number1.Equals()
        
        // Test float,double,decimal counting precision
        Console.WriteLine($"decimal: 2.1 {((number4 + 1).Equals(2.1m)?"":"not")} equals {number4 + 1}");
        
        // checked context 
        // The checked keyword can check an expression if it is overflowed. expression
        int testCheckedNumber = checked(2 + 1);
        checked
        {
            int r1 = new Random().Next();
            int r2 = r1 + (int)(Random.Shared.Next());
        }
        
        // BigInteger
        // There’s one last numeric type worth being aware of: BigInteger.
        // It’s part of the runtime libraries and gets no special recognition from the C# compiler, so it doesn’t strictly belong in this section of the book.
        // However, it defines arithmetic operators and conversions, meaning that you can use it just like the built-in data types.
        // It will compile to slightly less compact code—the compiled format for .NET programs can represent integers and floating-point values natively,
        // but BigInteger has to rely on the more general-purpose mechanisms used by ordinary class library types.
        // In theory it is likely to be significantly slower too,
        // although in an awful lot of code, the speed at which you can perform basic arithmetic on small integers is not a limiting factor,
        // so it’s quite possible that you won’t notice. And as far as the programming model goes, it looks and feels like a normal numeric type in your code.
        // As the name suggests, a BigInteger represents an integer. Its unique selling point is that it will grow as large as is necessary to accommodate values.
        // So unlike the built-in numeric types, it has no theoretical limit on its range. Example 2-39 uses it to calculate values in the Fibonacci sequence,
        // showing every 100,000th value. This quickly produces numbers far too large to fit into any of the other integer types.
        // I’ve shown the full source of this example, including the using directive, to illustrate that this type is defined in the System.Numerics namespace.
        BigInteger i1 = 1; 
        BigInteger i2 = 1; 
        Console.WriteLine(i1); 
        int count = 0;
        while (true) {
            // The % operator returns the remainder of dividing its 1st operand by its // 2nd, so this displays the number only when count is divisible by 100000.
            if (count++ % 100000 == 0)
            {
                Console.WriteLine(i2);
            }
            BigInteger next = i1 + i2;
            i1 = i2;
            i2 = next;
        }
    }

    public static void StringsAndCharacters()
    {
        // char
        char[] chars = {'w','s','a',',','d', (char) 0x301};
        // string
        string test = new string(chars);
        
        // * string methods
        // string test = "Hello, World!";
        Console.WriteLine(test.Length); // returns the length of the string
        Console.WriteLine(test.ToUpper()); // converts the string to uppercase
        Console.WriteLine(test.ToLower()); // converts the string to lowercase
        Console.WriteLine(test.Substring(7)); // returns a substring starting from index 7
        Console.WriteLine(test.Contains("World")); // checks if the string contains a specific substring
        Console.WriteLine(test.Replace("Hello", "Hi")); // replaces a substring with another substring
        Console.WriteLine(test.IndexOf("o")); // returns the index of the first occurrence of a character or substring
        Console.WriteLine(test.LastIndexOf("o")); // returns the index of the last occurrence of a character or substring
        Console.WriteLine(test.StartsWith("Hello")); // checks if the string starts with a specific substring
        Console.WriteLine(test.EndsWith("World!")); // checks if the string ends with a specific substring
        Console.WriteLine(test.Trim()); // removes leading and trailing whitespace
        Console.WriteLine(test.Split(","));
        
        // * string interpolation
        var name = "That's ok";
        int age = 20;
        string message = $"{name} is {age} years old";
        
        double width = 3, height = 4;
        string info = $"Hypotenuse: {Math.Sqrt(width * width + height * height)}";
        
        // * Using string.Format
        string message2 = string.Format("{0} is {1} years old", name, age);
        string message3 = string.Format("Hypotenuse: {0}", Math.Sqrt(width * width + height * height)); 
        string message4 = $"{name} is {age:f1} years old";
        
        //  Format specifiers with invariant culture
        decimal v = 1234567.654m;
        string i = string.Create(CultureInfo.InvariantCulture, $"Quantity {v:N}"); 
        string f = string.Create(new CultureInfo("fr"), $"Quantity {v:N}");
        string frc = string.Create(new CultureInfo("fr-FR"), $"Quantity {v:C}");
        string cac = string.Create(new CultureInfo("fr-CA"), $"Quantity {v:C}");
    }

    public static void DonymicType()
    {
        // Nothing
    }
    
    public static void TuplesStuff()
    {
        //  Creating and using a tuple

        #region We'd better not use this ways.
        // this way make us to infer the type of the tuple difficultly.
        var pointNo = (10, "test");
        Console.WriteLine($"number: {pointNo.Item1}, string: {pointNo.Item2}");
        
        // Inferring tuple member names from variables
        // There the tuple member's name is used as properties, in C# specification, property name usually starts with a capital letter.
        int x = 10, y = 5;
        var point2 = (x, y);
        Console.WriteLine($"X: {point2.x}, Y: {point2.y}");

        #endregion
        //  Deconstructing a tuple
        (int X, int Y) point = (10, 5); 
        Console.WriteLine($"X: {point.X}, Y: {point.Y}");
        (int Id, string Name) person = (1, "John");
        Console.WriteLine($"Id: {person.Id}, Name: {person.Name}");
        // Notes: Actually, the following statement of serializing the tuple will return {}.
        // So I think we can't use tuple type for serialization to JSON.
        // If we want to implement this feature, we have to use anonymous type.
        Console.WriteLine(JsonSerializer.Serialize(person));
        
        //  Naming tuple members in the initializer
        var point1 = (X: 10, Y: 5);
        Console.WriteLine($"X: {point.X}, Y: {point.Y}");

        (int width, int height) = point1;
        Console.WriteLine($"Width: {width}, Height: {height}");
        
        //  Structural equivalence of tuples
        // Once we would like to use this feature, we must be very very careful as penitential wrong understand.
        (int X, int Y) point3 = (46, 3);
        (int Width, int Height) dimensions = point; 
        (int Age, int NumberOfChildren) person3 = point;
        // Declaring an tuple to return json and xml formatting data together
        (JsonDocument json, XmlDocument xml) data = new (JsonDocument.Parse("{}"), new XmlDocument());
        Console.WriteLine(data.json);
        Console.WriteLine(data.xml);
        //  Anonymous types
        var person1 = new {Id = 1, Name = "John"};
        Console.WriteLine(JsonSerializer.Serialize(person1));

        // anonymous types
        var anotherPerson = new {Id = 2, Name = "Jane"};
        Console.WriteLine(JsonSerializer.Serialize(anotherPerson));
    }
    
    public static void BooleanStuff()
    {
        //Nothing
    }
}