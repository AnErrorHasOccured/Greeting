﻿namespace Greeting.Chain
{
    public class NullHandler : AbstractGreetingHandler
    {
        public override string Handle(params string[] names)
        {
            if (names is null)
                return Greet(null) + ".";

            return base.Handle(names);
        }
    }
}