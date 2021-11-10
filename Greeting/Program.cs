using System;
using Greeting.Ioc;
using Microsoft.Extensions.DependencyInjection;

namespace Greeting
{
    class Program
    {
        static void Main(string[] names)
        {
            var container = Container.CreateHostBuilder().Build();
            var greeting = container.Services.GetService<Greeting>();

            Console.WriteLine(greeting?.Greet(names));
        }
    }
}
