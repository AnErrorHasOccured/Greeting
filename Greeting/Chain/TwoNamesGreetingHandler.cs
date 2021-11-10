namespace Greeting.Chain
{
    public class TwoNamesGreetingHandler : AbstractGreetingHandler
    {
        public override string Handle(params string[] names)
        {
            if (names.Length == 2)
                return Greet(string.Join(" and ", names)) + ".";

            return base.Handle(names);
        }
    }
}