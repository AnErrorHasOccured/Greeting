using Greeting.Chain;
using Xunit;

namespace Greeting.Test;

public class OneNameHandlerTests
{
    private IGreetingHandler _sut;
    
    public OneNameHandlerTests()
    {
        _sut = new OneNameHandler();
    }

    [Fact]
    public void Should_Add_Greeting_To_Name()
    {
        var expected = "Hello, Andrea.";
        var actual = _sut.Handle("Andrea");

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Should_Handle_Uppercase_Name()
    {
        var expected = "HELLO, ANDREA!";
        var actual = _sut.Handle("ANDREA");

        Assert.Equal(expected, actual);
    }
}