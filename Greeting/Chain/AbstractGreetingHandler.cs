using Greeting.Utility;

namespace Greeting.Chain;

public abstract class AbstractGreetingHandler : IGreetingHandler
{
    private IGreetingHandler _nextGreetingHandler;

    public IGreetingHandler SetNext(IGreetingHandler greetingHandler)
    {
        _nextGreetingHandler = greetingHandler;
        return greetingHandler;
    }

    public virtual string Handle(params string[] names) => _nextGreetingHandler?.Handle(names);

    protected string Greet(string? name)
    {
        var greet = "Hello";

        if (name is null)
            return $"{greet}, my friend";

        return name.IsUpper() ? $"{greet.ToUpper()}, {name}" : $"{greet}, {name}";
    }
}