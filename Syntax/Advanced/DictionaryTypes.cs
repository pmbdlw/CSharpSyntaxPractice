using System.Text.Json;

namespace CSharpExcise.Syntax.Advanced;

/**
 * This class used for studying Dictionary types.
 * IDictionary, IReadOnlyDictionary, ILookup,IDictionary<Tkey,TValue>, IReadOnlyDictionary<Tkey,TValue>, ILookup<Tkey,TValue>
 * Dcitionary<Tkey,TValue>, ReadOnlyDictionary<Tkey,TValue>,Lookup<Tkey,TValue>
 * Dictionary<Tkey,TValue> :
 * Lookup<Tkey,TValue>  : Can't be created directly. Must use ToLookup() included in Linq Namespace.
 */
public class DictionaryTypes
{
    
    // Test Lookup<Tkey,TValue>
    public static void Test()
    {
        var dictionaryStuff = new Dictionary<string, string>();
        dictionaryStuff.Add("key1", "value1");
        dictionaryStuff.Add("key2", "value2");
        Console.WriteLine(JsonSerializer.Serialize(dictionaryStuff));
    }
    
    public static void LookupTest()
    {
        var racers = new List<Racer>();
        racers.Add(new Racer("Jacques","Villeneuve",1982,"USA"));
        racers.Add(new Racer("Alan","Villeneuve",1982,"Canada"));
        racers.Add(new Racer("Jacques","Villeneuve",1982,"NZ"));
        racers.Add(new Racer("Cameron","Villeneuve",1982,"NZ"));
        racers.Add(new Racer("Tom Hocks","Villeneuve",1982,"Canada"));
        racers.Add(new Racer("Phillipe","Villeneuve",1982,"Australia"));
        var lookupRacers = racers.ToLookup(r => r.Country);
        Console.WriteLine(string.Join(",",lookupRacers["NZ"]));
        // racers.Find(r=>r.Name == "Alan").Country = "NZ";
        
        Console.WriteLine(lookupRacers["NZ"]);

        var aString = "hello";
        var spanStrin = aString.AsSpan(start:1, length:3);
        Console.WriteLine(spanStrin.ToString());
    }
}

public record Racer(string Name, string Team, int Year, string Country);