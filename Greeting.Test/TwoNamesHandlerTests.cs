using Greeting.Chain;
using Xunit;

namespace Greeting.Test;

public class TwoNamesHandlerTests
{
    private IGreetingHandler _sut;
    
    public TwoNamesHandlerTests()
    {
        _sut = new TwoNamesHandler();
    }

    [Fact]
    public void Should_Handle_Two_Name()
    {
        var expected = "Hello, Andrea and Franco.";
        var actual = _sut.Handle("Andrea", "Franco");

        Assert.Equal(expected, actual);
    }
}