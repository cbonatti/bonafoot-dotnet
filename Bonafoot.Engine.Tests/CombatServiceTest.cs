using Bonafoot.Engine.Enums;
using Bonafoot.Engine.Interfaces;
using Bonafoot.Engine.Services;
using Bonafoot.Engine.Services.Interfaces;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace Bonafoot.Engine.Tests
{
    public class CombatServiceTest
    {
        private ICombatService _combatService;
        private IRandomService _randomService;

        [OneTimeSetUp]
        public void Setup()
        {
            _randomService = Substitute.For<IRandomService>();
            _randomService.Generate(0, 0).ReturnsForAnyArgs(0);

            _combatService = new CombatService(_randomService);
        }

        [Test]
        public void Should_Home_Win_Combat()
        {
            _combatService.Fight(10, 9).Should().Be(CombatResult.HomeWins);
        }

        [Test]
        public void Should_Guest_Win_Combat()
        {
            _combatService.Fight(9, 10).Should().Be(CombatResult.GuestWins);
        }

        [Test]
        public void Should_Draw_Combat()
        {
            _combatService.Fight(10, 10).Should().Be(CombatResult.Draw);
        }
    }
}
