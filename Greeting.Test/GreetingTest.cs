using Greeting.Chain;
using Greeting.Ioc;
using NUnit.Framework;
using Microsoft.Extensions.DependencyInjection;

namespace Greeting.Test
{
    public class Tests
    {
        private IGreeting _sut;

        [SetUp]
        public void Setup()
        {
            var container = Container.CreateHostBuilder().Build();
            _sut = new Greeting(container.Services.GetService<IGreetingHandler>());
        }

        [Test]
        public void Should_Add_Greeting_To_Name()
        {
            var expected = "Hello, Andrea.";
            var actual = _sut.Greet("Andrea");

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Should_Handle_Null_Name()
        {
            var expected = "Hello, my friend.";
            var actual = _sut.Greet(null);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Should_Handle_Uppercase_Name()
        {
            var expected = "HELLO, ANDREA!";
            var actual = _sut.Greet("ANDREA");

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Should_Handle_Two_Name()
        {
            var expected = "Hello, Andrea and Franco.";
            var actual = _sut.Greet("Andrea", "Franco");

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Should_Handle_Multiple_Name()
        {
            var expected = "Hello, Andrea, Franco and Giuseppe.";
            var actual = _sut.Greet("Andrea", "Franco", "Giuseppe");

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Should_Handle_Multiple_Name_With_Upper()
        {
            var expected = "Hello, Andrea and Franco. AND HELLO GIUSEPPE!";
            var actual = _sut.Greet("Andrea", "Franco", "GIUSEPPE");

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Should_Handle_Names_With_Double_Quote()
        {
            var expected = "Hello, Andrea, Franco and Alfredo.";
            var actual = _sut.Greet("Andrea", "\"Franco, Alfredo\"");

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Ignore("SandBox test")]
        public void SandBox()
        {
            var actual = _sut.Greet("Andrea", "Franco", "GIUSEPPE", "Paperino", "\"h, Z\"");

            Assert.Pass(actual);
        }
    }
}