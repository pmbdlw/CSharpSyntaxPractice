namespace CSharpExcise.Syntax.BasicCoding;

public static class Patterns
{
    public static void SwitchPattern(object obj)
    {
        switch (obj)
        {
            case int i:
                Console.WriteLine($"Ths's {i}");
                break;
            case string s:
                Console.WriteLine($"A piece of string is {s.Length} long.");
                break;
        }
        switch (Environment.OSVersion) {
            case {Platform: PlatformID.Win32NT}: ////{ Version: { Major: 10 } }: Console.WriteLine("Windows 10, 11, or later"); break;
            break;
            
        }

    }
}