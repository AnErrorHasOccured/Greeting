using Greeting.Chain;
using Xunit;

namespace Greeting.Test;

public class ManyNamesWithSomeUpperHandlerTests
{
    private readonly IGreetingHandler _sut;
    
    public ManyNamesWithSomeUpperHandlerTests()
    {
        _sut = new ManyNamesWithSomeUpperHandler();
    }

    [Fact]
    public void Should_Handle_Multiple_Name_With_Upper()
    {
        var expected = "Hello, Andrea and Franco. AND HELLO GIUSEPPE!";
        var actual = _sut.Handle("Andrea", "Franco", "GIUSEPPE");

        Assert.Equal(expected, actual);
    }
}