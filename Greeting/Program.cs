using System;
using Greeting.Ioc;

namespace Greeting
{
    class Program
    {
        static void Main(string[] names)
        {
            var greeting = Container.GetService<IGreeting>();

            Console.WriteLine(greeting?.Greet(names));
        }
    }
}
