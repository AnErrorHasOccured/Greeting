using Greeting.Chain;
using NUnit.Framework;

namespace Greeting.Test;

public class NullHandlerTests
{
    private IGreetingHandler _sut;

    [SetUp]
    public void Setup()
    {
        _sut = new NullHandler();
    }

    [Test]
    public void Should_Handle_Null_Name()
    {
        var expected = "Hello, my friend.";
        var actual = _sut.Handle(null);

        Assert.AreEqual(expected, actual);
    }
}