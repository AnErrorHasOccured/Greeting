using Greeting.Chain;
using Greeting.Ioc;
using Xunit;
using Xunit.Abstractions;

namespace Greeting.Test;

public class GreetingTests
{
    private readonly IGreeting _sut;
    private readonly ITestOutputHelper _output;

    public GreetingTests(ITestOutputHelper output)
    {
        var greetingHandler = Container.GetService<IGreetingHandler>();
        _output = output;
        _sut = new Greeting(greetingHandler);
    }

    [Fact]
    public void Should_Add_Greeting_To_Name()
    {
        var expected = "Hello, Andrea.";
        var actual = _sut.Greet("Andrea");

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Should_Handle_Null_Name()
    {
        var expected = "Hello, my friend.";
        var actual = _sut.Greet(null);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Should_Handle_Uppercase_Name()
    {
        var expected = "HELLO, ANDREA!";
        var actual = _sut.Greet("ANDREA");

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Should_Handle_Two_Name()
    {
        var expected = "Hello, Andrea and Franco.";
        var actual = _sut.Greet("Andrea", "Franco");

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Should_Handle_Multiple_Name()
    {
        var expected = "Hello, Andrea, Franco and Giuseppe.";
        var actual = _sut.Greet("Andrea", "Franco", "Giuseppe");

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Should_Handle_Multiple_Name_With_Upper()
    {
        var expected = "Hello, Andrea and Franco. AND HELLO GIUSEPPE!";
        var actual = _sut.Greet("Andrea", "Franco", "GIUSEPPE");

        Assert.Equal(expected, actual);
    }
        
    [Fact(Skip = "Sandbox Fact")]
    public void SandBox()
    {
        var actual = _sut.Greet("Andrea", "Franco", "GIUSEPPE", "Paperino", "\"h, Z\"");
        _output.WriteLine(actual);
    }
}