using Bonafoot.Domain.Entities;
using Bonafoot.Domain.Enums;
using Bonafoot.Domain.Util;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Linq;

namespace Bonafoot.Tests
{
    public class NewChampionshipTests
    {
        private Championship championship;

        [OneTimeSetUp]
        public void Setup()
        {
            championship = new Championship().New();
        }

        [Test]
        public void Should_Create_New_Championship()
        {
            championship.Year.Should().Be(DateTime.Now.Year);
            championship.Matches.Count().Should().Be(0);
            championship.Divisions.Count().Should().Be(4);
            championship.Rounds.Count.Should().Be(224); // division has 8 teams, each round has 4 games, so ((4 games * 7 rounds) * 4 divisions) * 2 return
        }

        [Test]
        public void Should_Create_First_Division()
        {
            var param = PlayerStatsParam.GetParams(DivisionIndex.First);

            var first = championship.Divisions.FirstOrDefault();
            first.Index.Should().Be(DivisionIndex.First);
            first.Teams.Count().Should().Be(8);
            first.Teams.FirstOrDefault().Squad.Count.Should().Be(15);
            first.Teams.FirstOrDefault().Squad.Average(x => x.Strength)
                    .Should()
                    .BeGreaterOrEqualTo(param.MinStrength)
                    .And
                    .BeLessOrEqualTo(param.MaxStrength);
        }

        [Test]
        public void Should_Create_Fourth_Division()
        {
            var param = PlayerStatsParam.GetParams(DivisionIndex.Fourth);

            var fourth = championship.Divisions.LastOrDefault();
            fourth.Index.Should().Be(DivisionIndex.Fourth);
            fourth.Teams.Count().Should().Be(8);
            fourth.Teams.FirstOrDefault().Squad.Count.Should().Be(15);
            fourth.Teams.FirstOrDefault().Squad.Average(x => x.Strength)
                    .Should()
                    .BeGreaterOrEqualTo(param.MinStrength)
                    .And
                    .BeLessOrEqualTo(param.MaxStrength);
        }
    }
}
