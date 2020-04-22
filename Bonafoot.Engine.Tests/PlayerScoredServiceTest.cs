using Bonafoot.Domain.Entities;
using Bonafoot.Domain.Util;
using Bonafoot.Engine.Interfaces;
using Bonafoot.Engine.Services;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using System.Linq;

namespace Bonafoot.Engine.Tests
{
    public class PlayerScoredServiceTest
    {
        private Team _team;

        [OneTimeSetUp]
        public void Setup()
        {
            _team = BasicTeam.Generate(Domain.Enums.DivisionIndex.First, 1);
            _team.GetTeamReadyToPlay(new Team());
        }

        [Test]
        public void Should_Defense_Player_Score()
        {
            var service = new PlayerScoredService(CreateRandomService(1));
            // it will get the 4 strongest defending players and then ordering by name
            var expected = _team.PlayingPlayers.Where(x => x.Position == Domain.Enums.PlayerPosition.Defender).OrderBy(x => x.Strength).Take(4).OrderBy(x => x.Name).FirstOrDefault().Name;
            service.WhoScored(_team).Should().Be(expected);
        }

        [Test]
        public void Should_Midfielder_Player_Score()
        {
            var service = new PlayerScoredService(CreateRandomService(6));
            var expected = _team.PlayingPlayers.Where(x => x.Position == Domain.Enums.PlayerPosition.Midfielder).OrderBy(x => x.Strength).Take(3).OrderBy(x => x.Name).FirstOrDefault().Name;
            service.WhoScored(_team).Should().Be(expected);
        }

        [Test]
        public void Should_Striker_Player_Score()
        {
            var service = new PlayerScoredService(CreateRandomService(3));
            var expected = _team.PlayingPlayers.Where(x => x.Position == Domain.Enums.PlayerPosition.Striker).OrderBy(x => x.Strength).Take(3).OrderBy(x => x.Name).FirstOrDefault().Name;
            service.WhoScored(_team).Should().Be(expected);
        }

        private IRandomService CreateRandomService(int dice)
        {
            var randomService = Substitute.For<IRandomService>();
            randomService.Dice().ReturnsForAnyArgs(dice);
            randomService.ZeroToMax(0).ReturnsForAnyArgs(0);
            return randomService;
        }
    }
}
