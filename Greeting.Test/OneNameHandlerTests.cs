using Greeting.Chain;
using NUnit.Framework;

namespace Greeting.Test;

public class OneNameHandlerTests
{
    private IGreetingHandler _sut;

    [SetUp]
    public void Setup()
    {
        _sut = new OneNameHandler();
    }

    [Test]
    public void Should_Add_Greeting_To_Name()
    {
        var expected = "Hello, Andrea.";
        var actual = _sut.Handle("Andrea");

        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Should_Handle_Uppercase_Name()
    {
        var expected = "HELLO, ANDREA!";
        var actual = _sut.Handle("ANDREA");

        Assert.AreEqual(expected, actual);
    }
}