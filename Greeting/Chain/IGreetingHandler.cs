namespace Greeting.Chain
{
    public interface IGreetingHandler
    {
        IGreetingHandler SetNext(IGreetingHandler greetingHandler);

        string Handle(params string[] names);
    }
}