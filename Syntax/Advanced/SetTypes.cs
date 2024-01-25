namespace CSharpExcise.Syntax.Advanced;

public class SetTypes
{
    public static void Test()
    {
        HashSetTest();
    }

    public static void HashSetTest()
    {
        var companyTeams = new HashSet<string>()
        {
            "Ferrari", "Red Bull", "McLaren", "Racing Point", "Mercedes"
        };
        var traditionalTeams = new HashSet<string>() { "Ferrari", "McLaren","BMW" };
        var thirdTeams = new HashSet<string>() { "Ferrari", "McLaren","BMW-New" };
        companyTeams.UnionWith(traditionalTeams);
        Console.WriteLine(string.Join(",",companyTeams));
        companyTeams.IntersectWith(thirdTeams);
        Console.WriteLine(string.Join(",",companyTeams));
    }

    public static void SortedSetTest()
    {
    }
}