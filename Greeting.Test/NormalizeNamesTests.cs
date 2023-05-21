using Greeting.Utility;
using NUnit.Framework;

namespace Greeting.Test;

public class NormalizeNamesTests
{
    [Test]
    public void Should_Handle_Names_With_Double_Quote()
    {
        var input = new[]
        {
            "Andrea",
            "\"Franco, Alfredo\""
        };

        var expected = new[]
        {
            "Andrea",
            "Franco, Alfredo"
        };

        var actual = input.NormalizeNames();
            
        Assert.AreEqual(expected, actual);
    }


    [Test]
    public void Should_Handle_Element_With_Sign()
    {
        var input = new[]
        {
            "Andrea",
            "Franco, Alfredo"
        };

        var expected = new[]
        {
            "Andrea",
            "Franco",
            "Alfredo"
        };

        var actual = input.NormalizeNames();

        Assert.AreEqual(expected, actual);
    }
}