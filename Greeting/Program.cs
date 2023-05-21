using System;
using Greeting;
using Greeting.Ioc;

var greeting = Container.GetService<IGreeting>();

Console.WriteLine(greeting?.Greet(args));