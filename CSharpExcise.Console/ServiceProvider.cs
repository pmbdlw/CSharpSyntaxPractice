using System.Reflection;

namespace CSharpExcise.Console;

public class ServiceProvider
{
    public static List<string> GetServices() {
        var result = new List<string>();
        Assembly assembly = Assembly.LoadFrom("Syntax.dll");
        Type[] types = assembly.GetTypes();

        foreach (Type type in types)
        {
            if (type.FullName != null) result.Add(type.FullName);
        }

        return result;
    }
}