namespace CSharpExcise.Console;
/// <summary>
/// Requirement: Implement a palindrome checker to make the following test cases pass. This starter code is in C# but you are welcome to write your solution in any language
/// Refactoring suggestion: The method Check and Main can be moved to unit test project and split to multiple test cases. This can make automated testing easier and more reliable.
/// </summary>
public class PalindromeChecker
{
    private bool IsPalindrome(string s)
    {
        s = s.Replace(" ", "").ToLower();
        /* Linq version */
        // var reverseString = new string(s.Reverse().ToArray());
        /* Array version */
        var reverseCharArray = s.ToCharArray();
        Array.Reverse(reverseCharArray);
        var reverseString = new string(reverseCharArray);
        
        return s.Equals(reverseString);
    }
 
    private void Check(string s, bool shouldBePalindrome){
        System.Console.WriteLine(IsPalindrome(s) == shouldBePalindrome ? "pass" : "FAIL");   
    }
 
    /// <summary>
    /// Just call this method to do the test.
    /// </summary>
    public void CheckTest()
    {
        Check("abcba", true);
        Check("abcde", false);
        Check("Mr owl ate my metal worm", true);
        Check("Never Odd Or Even", true);
        Check("Never Even Or Odd", false);
    }
}