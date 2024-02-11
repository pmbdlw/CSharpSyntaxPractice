using System.Text.Json;

namespace CSharpExcise.Syntax.BasicCoding;

public static class Operators
{
    //  Basic arithmetic operators +,-,*,/,%,++,--
    
    // Binary integer operators ~, &, |, ^, <<, >>
    public static void BinaryIntegerOperators()
    {
        int x = 2;
        int y = 1;
        Console.WriteLine($"x: {x}, y: {y}");
        Console.WriteLine($"~ {~x}");
        Console.WriteLine($"& {x & y}");
        Console.WriteLine($"| {x | y}");
        Console.WriteLine($"^ {x ^ y}");
        Console.WriteLine($"<< {x << y}");
        Console.WriteLine($">> {x >> y}");
        
        uint a = 0b_0000_1111_0000_1111_0000_1111_0000_1100;
        uint b = ~a;
        Console.WriteLine(Convert.ToString(b, toBase: 2));
// Output:
// 11110000111100001111000011110011
        int aa = 4;
        int bb = ~aa;
        Console.WriteLine(Convert.ToString(aa, toBase: 2));
        Console.WriteLine(Convert.ToString(bb, toBase: 2));
        Console.WriteLine(bb);

        Console.WriteLine($"^ {2 ^ 13}"); // 15

        // ～ operator
        // 1, if the variable is negative, return the complement of the variable.
        // The complement's origin code is the result. 
        // 2, if variable is positive,
        // The against complement's origin code is the result.(complement code - 1), then reverse it.
        Console.WriteLine(~(-3)); // 2
        Console.WriteLine(~3); // -4

        Console.WriteLine((-2)<<1); // -4
        Console.WriteLine((-2)>>1); // -1


        Console.WriteLine(4<<1); // 8
        Console.WriteLine(4>>1); // 2
        
//        JsonDocument testObj = JsonDocument.Parse("{}");
        // var testString = testObj!.ToString();

        var score = new Random().Next(59, 100);
        Console.WriteLine($"Score: {score}");
        switch (score)
        {
            case < 60:
                Console.WriteLine("F");
                break;
            case < 80:
                Console.WriteLine("E");
                break;
            case < 90:
                Console.WriteLine("B");
                break;
            default:
                Console.WriteLine("Awesome！");
                break;
        }
    }

    public static long FibonacciSequence(int n)
    {
        var firstNumber = 1;
        var secondNumbe = 1;
        var i = 2;
        int result = 0;
        do
        {
            if (i == 2)
            {
                Console.WriteLine($"curent step: 1, result: 1, firstNumber: {firstNumber}, secondNumbe: {secondNumbe}");
                Console.WriteLine($"curent step: 2, result: 1, firstNumber: {firstNumber}, secondNumbe: {secondNumbe}");
            }
            else
            {
                Console.WriteLine($"curent step: {i}, result: {result}, firstNumber: {firstNumber}, secondNumbe: {secondNumbe}");
            }
            result = firstNumber + secondNumbe;
            firstNumber = secondNumbe;
            secondNumbe = result;
            i++;
        } while (i <= n && i > 2);

        return result;
    }
    // Operators for bool
}