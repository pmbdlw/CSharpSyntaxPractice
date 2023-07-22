// See https://aka.ms/new-console-template for more information

using CSharpExcise.Console.TestLib;

Console.WriteLine("Hello, World!");
Console.ReadLine();
var w1 = new WithKeywordTest("name1", "age1");
var w2 = w1 with { Name = "name2" };
Console.WriteLine(w1.ReturnDetail());
Console.WriteLine(w2.ReturnDetail());