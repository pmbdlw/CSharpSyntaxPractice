namespace CSharpExcise.Console.TestLib;

/// <summary>
/// Record type practice
/// </summary>
/// <param name="Name">Name Description</param>
/// <param name="Age">Age Description</param>
public record WithKeywordTest(string Name, string Age)
{
    /// <summary>
    /// Return details.
    /// </summary>
    /// <returns></returns>
    public string ReturnDetail()
    {
        return $"{Name} {Age}";
    }
};