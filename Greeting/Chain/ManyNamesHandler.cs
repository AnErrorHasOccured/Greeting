using System.Collections.Generic;
using System.Linq;

namespace Greeting.Chain;

public class ManyNamesHandler : AbstractGreetingHandler
{
    public override string Handle(params string[] names)
    {
        if (names.Length <= 2) return base.Handle(names);
        
        var otherNames = names.Except(new List<string> { names.Last() });
        return Greet(string.Join(", ", otherNames)) + " and " + names.Last() + ".";
    }
}