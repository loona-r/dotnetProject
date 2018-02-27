using System;
using Xunit;
using Isen.DotNet.Library;

namespace Isen.DotNet.Tests
{
    public class HelloTest
    {
        [Fact]
        public void World()
        {
            var result = Hello.World;
            var expected = "Hello, World";
            Assert.True(result == expected);
        }

        [Fact]
        public void Greet()
        {
            var result = Hello.Greet("Loona");
            Assert.StartsWith("Hello Loona, it is ", result);
        }

        [Fact]
        public void GreetUpper()
        {
            var result = Hello.GreetUpper("Loona");
            Assert.StartsWith("Hello LOONA, it is ", result);
        }

    }
}
