using Greeting.Chain;
using Xunit;

namespace Greeting.Test;

public class ManyNamesHandlerTests
{
    private IGreetingHandler _sut;
    
    public ManyNamesHandlerTests()
    {
        _sut = new ManyNamesHandler();
    }

    [Fact]
    public void Should_Handle_Multiple_Name()
    {
        var expected = "Hello, Andrea, Franco and Giuseppe.";
        var actual = _sut.Handle("Andrea", "Franco", "Giuseppe");

        Assert.Equal(expected, actual);
    }
}