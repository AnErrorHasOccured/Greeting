using System.Linq;
using Greeting.Utility;

namespace Greeting.Chain;

public class ManyNamesWithSomeUpperHandler : AbstractGreetingHandler
{
    public override string Handle(params string[] names)
    {
        if (names.Length <= 2 || !names.Any(_ => StringExtension.IsUpper((string)_))) return base.Handle(names);
        {
            var uppers = names.Where(_ => _.IsUpper());
            var normal = names.Except(uppers);

            return Greet(string.Join(" and ", normal)) + ". AND HELLO " + string.Join(", ", uppers) + "!";
        }

    }
}