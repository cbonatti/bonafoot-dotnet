using Bonafoot.Core.Commands;
using Bonafoot.Core.Validators;
using Bonafoot.Domain.Entities;
using Bonafoot.Domain.Enums;
using FluentAssertions;
using NUnit.Framework;
using System.Linq;

namespace Bonafoot.Tests
{
    public class PlayingTeamValidatorTests
    {
        private Team _team;
        private PlayingTeamValidator _validator;

        [OneTimeSetUp]
        public void Setup()
        {
            var division = new Division(DivisionIndex.First);
            _team = division.Teams.FirstOrDefault();

            _validator = new PlayingTeamValidator();
        }

        [Test]
        public void Should_Not_Validade_10_Players()
        {
            var command = new PlayMatchCommand() { Players = _team.Players.Take(10).Select(x => x.Id).ToList() };
            _validator.Validate(command, _team).Should().BeFalse();
        }

        [Test]
        public void Should_Not_Validade_12_Players()
        {
            var command = new PlayMatchCommand() { Players = _team.Players.Take(12).Select(x => x.Id).ToList() };
            _validator.Validate(command, _team).Should().BeFalse();
        }

        [Test]
        public void Should_Not_Validade_0_GK()
        {
            var command = new PlayMatchCommand()
            {
                Players = (
                    _team.Players.Where(x => x.Position == PlayerPosition.Defender).Take(4)
                    .Union(_team.Players.Where(x => x.Position == PlayerPosition.Midfielder).Take(4))
                    .Union(_team.Players.Where(x => x.Position == PlayerPosition.Striker).Take(3))
                    .Select(x => x.Id)
                ).ToList()
            };

            _validator.Validate(command, _team).Should().BeFalse();
        }

        [Test]
        public void Should_Not_Validade_2_GK()
        {
            var command = new PlayMatchCommand()
            {
                Players = (
                    _team.Players.Where(x => x.Position == PlayerPosition.Goalkeeper).Take(2)
                    .Union(_team.Players.Where(x => x.Position == PlayerPosition.Defender).Take(4))
                    .Union(_team.Players.Where(x => x.Position == PlayerPosition.Midfielder).Take(4))
                    .Union(_team.Players.Where(x => x.Position == PlayerPosition.Striker).Take(1))
                    .Select(x => x.Id)
                ).ToList()
            };

            _validator.Validate(command, _team).Should().BeFalse();
        }

        [Test]
        public void Should_Validade_Team()
        {
            var command = new PlayMatchCommand()
            {
                Players = (
                    _team.Players.Where(x => x.Position == PlayerPosition.Goalkeeper).Take(1)
                    .Union(_team.Players.Where(x => x.Position == PlayerPosition.Defender).Take(4))
                    .Union(_team.Players.Where(x => x.Position == PlayerPosition.Midfielder).Take(4))
                    .Union(_team.Players.Where(x => x.Position == PlayerPosition.Striker).Take(2))
                    .Select(x => x.Id)
                ).ToList()
            };

            _validator.Validate(command, _team).Should().BeTrue();
        }
    }
}
