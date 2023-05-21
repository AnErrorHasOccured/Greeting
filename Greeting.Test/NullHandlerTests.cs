using Greeting.Chain;
using Xunit;

namespace Greeting.Test;

public class NullHandlerTests
{
    private IGreetingHandler _sut;
    
    public NullHandlerTests()
    {
        _sut = new NullHandler();
    }

    [Fact]
    public void Should_Handle_Null_Name()
    {
        var expected = "Hello, my friend.";
        var actual = _sut.Handle(null);

        Assert.Equal(expected, actual);
    }
}