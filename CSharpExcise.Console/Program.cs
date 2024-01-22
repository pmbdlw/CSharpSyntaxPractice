// See https://aka.ms/new-console-template for more information

using CSharpExcise.Console;
using CSharpExcise.Syntax.BasicCoding;

Console.WriteLine("Let's practice!");

// ServiceProvider.GetServices().ForEach(x => Console.WriteLine(x));
// DataTypes.DynamicType();
// Operators.BinaryIntegerOperators();
for (int i = 0; i < 10; i++)
{
    Console.WriteLine($"Seed {i} ============ {DateTime.Now}");
    Operators.FibonacciSequence(i);
}
Console.ReadLine();
