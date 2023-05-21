using Greeting.Chain;
using Greeting.Utility;

namespace Greeting;

public class Greeting : IGreeting
{
    private readonly IGreetingHandler _greetingHandler;

    public Greeting(IGreetingHandler greetingHandler)
    {
        _greetingHandler = greetingHandler;
    }

    public string Greet(string[] names)
    {
        names = names.NormalizeNames();
        return _greetingHandler.Handle(names);
    }
}