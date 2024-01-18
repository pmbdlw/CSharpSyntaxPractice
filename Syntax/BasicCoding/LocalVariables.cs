namespace CSharpExcise.Syntax.BasicCoding;

/// <summary>
/// local variables
/// </summary>
public class LocalVariables
{
    /// <summary>
    /// some concepts in the beginning part of the chapter
    /// </summary>
    public static void LocalVariableKnowledgeList()
    {
        // Single variable declaration(Simplify the variable declaration by var keyword)
        List<int> numbers1 = new List<int>();
        var numbers2 = new List<int>();
        List<int> numbers3 = new();
        // Multiple variables in a single declaration
        double a, b = 2.5, c = -2.5;
    }

    /// <summary>
    /// Scope
    /// </summary>
    public static void Scope()
    {
        
    }

    /// <summary>
    /// Statements and expressions
    /// </summary>
    public static void StatementAndExpression()
    {
        // block statement
        // This example shows a block statement has the specific scope.
        // {
        //     int a = 19; 
        //     int b = 23; 
        // }
        // int c = a + b; 
        // Console.WriteLine(c);

    }
}