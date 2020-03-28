using Bonafoot.Engine.Interfaces;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace Bonafoot.Engine.Tests
{
    public class RandomServiceTest
    {
        [Test]
        public void Should_Return_Random_Number()
        {
            IRandomService service = new RandomService();
            service.Generate(-2, 2).Should().BeInRange(-2, 2);
        }

        [Test]
        public void Should_Return_Configured_Number()
        {
            IRandomService service = Substitute.For<IRandomService>();
            service.Generate(-2, 2).Returns(1);
            service.Generate(-2, 2).Should().Be(1);
        }
    }
}
