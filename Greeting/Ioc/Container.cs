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
                            var nullHandler = new NullHandler();
                            var oneNameHandler = new OneNameHandler();
                            var twoNamesHandler = new TwoNamesHandler();
                            var manyNamesWithSomeUpperHandler = new ManyNamesWithSomeUpperHandler();
                            var manyNamesHandler = new ManyNamesHandler();
                            
                            nullHandler
                                .SetNext(oneNameHandler)
                                .SetNext(twoNamesHandler)
                                .SetNext(manyNamesWithSomeUpperHandler)
                                .SetNext(manyNamesHandler);

                            return nullHandler;
                        })).Build();
    }
}
