using Bonafoot.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;

namespace Bonafoot.Tests
{
    public class NewGameTests
    {
        private const string GAME_NAME = "TEST";

        [Test]
        public void Should_Create_New_Game()
        {
            var game = new Game().New(GAME_NAME);
            game.Name.Should().Be(GAME_NAME);
            game.Championships.Count.Should().Be(1);
            game.Team.Should().NotBeNull();
        }
    }
}
