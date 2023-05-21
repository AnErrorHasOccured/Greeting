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

    public virtual string Handle(params string[] names)
    {
        return _nextGreetingHandler?.Handle(names);
    }

    protected string Greet(string name)
    {
        var basePrashe = "{0}, {1}";
        var greet = "Hello";

        if (name is null)
            return string.Format(basePrashe, greet, "my friend");

        if (name.IsUpper())
            return string.Format(basePrashe, greet.ToUpper(), name);

        return string.Format(basePrashe, greet, name);
    }
}