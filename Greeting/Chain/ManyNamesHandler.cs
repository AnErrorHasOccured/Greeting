using System.Collections.Generic;
using System.Linq;

namespace Greeting.Chain;

public class ManyNamesHandler : AbstractGreetingHandler
{
    public override string Handle(params string[] names)
    {
        if (names.Length <= 2) return base.Handle(names);

        var lastName = new List<string> { names.Last() };
        var otherNames = names.Except(lastName);

        return Greet(string.Join(", ", otherNames)) + " and " + lastName.First() + ".";

    }
}