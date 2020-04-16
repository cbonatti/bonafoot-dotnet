using Bonafoot.Domain.Entities;
using Bonafoot.Domain.Util;
using Bonafoot.Engine.Interfaces;
using Bonafoot.Engine.Services;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

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
            service.WhoScored(_team).Should().Be("DF 1");
        }

        [Test]
        public void Should_Midfielder_Player_Score()
        {
            var service = new PlayerScoredService(CreateRandomService(6));
            service.WhoScored(_team).Should().Be("MF 1");
        }

        [Test]
        public void Should_Striker_Player_Score()
        {
            var service = new PlayerScoredService(CreateRandomService(3));
            service.WhoScored(_team).Should().Be("ST 1");
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
