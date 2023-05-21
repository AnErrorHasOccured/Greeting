using Greeting.Utility;

namespace Greeting.Chain;

public class OneNameHandler : AbstractGreetingHandler
{
    public override string Handle(params string[] names)
    {
        if (names.Length == 1)
            return $"{Greet(names[0])}{(names[0].IsUpper() ? "!" : ".")}";

        return base.Handle(names);
    }
}