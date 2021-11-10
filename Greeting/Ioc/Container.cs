using Greeting.Chain;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Greeting.Ioc
{
    public static class Container
    {
        public static T GetService<T>() 
            => CreateHostBuilder().Services.GetService<T>();

        private static IHost CreateHostBuilder() =>
            Host
                .CreateDefaultBuilder()
                .ConfigureServices((_, services) =>
                    services
                        .AddSingleton<IGreeting, Greeting>()
                        .AddSingleton<IGreetingHandler>(_ =>
                        {
                            var nullHandler = new NullGreetingHandler();
                            var oneNameHandler = new OneNameGreetingHandler();
                            var twoNamesHandler = new TwoNamesGreetingHandler();
                            var manyNamesWithSomeUpperHandler = new ManyNamesWithSomeUpperGreetingHandler();
                            var manyNamesHandler = new ManyNamesGreetingHandler();


                            nullHandler
                                .SetNext(oneNameHandler)
                                .SetNext(twoNamesHandler)
                                .SetNext(manyNamesWithSomeUpperHandler)
                                .SetNext(manyNamesHandler);

                            return nullHandler;
                        })).Build();
    }
}
