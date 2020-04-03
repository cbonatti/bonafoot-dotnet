using Bonafoot.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;

namespace Bonafoot.Tests
{
    public class NewGameTests
    {
        [Test]
        public void Should_Create_New_Game()
        {
            var game = new Game().New();
            game.Championships.Count.Should().Be(1);
            game.Team.Should().NotBeNull();
        }
    }
}
