using Bonafoot.Domain.Entities;
using Bonafoot.Domain.Enums;
using Bonafoot.Engine.Enums;
using Bonafoot.Engine.Interfaces;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Bonafoot.Engine.Tests
{
    public class MatchEngineTest
    {
        IRandomService randomService;

        [OneTimeSetUp]
        public void Setup()
        {
            randomService = Substitute.For<IRandomService>();
            randomService.Generate(0, 0).ReturnsForAnyArgs(0);
        }

        [Test]
        public void Ball_Should_Move_From_Center_To_Guest_Midfield()
        {
            var home = new Team("", new List<Player>() { new Player("", 10, PlayerPosition.Midfielder) });
            var guest = new Team("", new List<Player>() { new Player("", 9, PlayerPosition.Midfielder) });

            var match = new Match(home, guest);
            var engine = new MatchEngine(match, randomService);
            engine.MidVsMid();
            engine.BallPosition.Should().Be(BallPosition.GuestMid);
        }

        [Test]
        public void Ball_Should_Move_From_Center_To_Home_Midfield()
        {
            var home = new Team("", new List<Player>() { new Player("", 10, PlayerPosition.Midfielder) });
            var guest = new Team("", new List<Player>() { new Player("", 11, PlayerPosition.Midfielder) });

            var match = new Match(home, guest);
            var engine = new MatchEngine(match, randomService);
            engine.MidVsMid();
            engine.BallPosition.Should().Be(BallPosition.HomeMid);
        }

        [Test]
        public void Ball_Should_Stay_On_Center()
        {
            var home = new Team("", new List<Player>() { new Player("", 10, PlayerPosition.Midfielder) });
            var guest = new Team("", new List<Player>() { new Player("", 10, PlayerPosition.Midfielder) });

            var match = new Match(home, guest);
            var engine = new MatchEngine(match, randomService);
            engine.MidVsMid();
            engine.BallPosition.Should().Be(BallPosition.Center);
        }

        [Test]
        public void Ball_Should_Move_From_Guest_Midfield_To_Center()
        {
            var home = new Team("", new List<Player>() { new Player("", 10, PlayerPosition.Midfielder) });
            var guest = new Team("", new List<Player>() { new Player("", 11, PlayerPosition.Defender) });

            var match = new Match(home, guest);
            var engine = new MatchEngine(match, randomService);
            engine.HomeMidVsDef();
            engine.BallPosition.Should().Be(BallPosition.Center);
        }

        [Test]
        public void Ball_Should_Move_From_Guest_Midfield_To_Guest_Defense()
        {
            var home = new Team("", new List<Player>() { new Player("", 10, PlayerPosition.Midfielder) });
            var guest = new Team("", new List<Player>() { new Player("", 9, PlayerPosition.Defender) });

            var match = new Match(home, guest);
            var engine = new MatchEngine(match, randomService);
            engine.HomeMidVsDef();
            engine.BallPosition.Should().Be(BallPosition.GuestDef);
        }

        [Test]
        public void Ball_Should_Move_From_Guest_Defense_To_Guest_Midfield()
        {
            var home = new Team("", new List<Player>() { new Player("", 10, PlayerPosition.Striker) });
            var guest = new Team("", new List<Player>() { new Player("", 11, PlayerPosition.Goalkeeper) });

            var match = new Match(home, guest);
            var engine = new MatchEngine(match, randomService);
            engine.HomeStVsGk();
            engine.BallPosition.Should().Be(BallPosition.GuestMid);
        }

        [Test]
        public void Ball_Should_Move_From_Guest_Defense_To_Center()
        {
            var home = new Team("", new List<Player>() { new Player("", 10, PlayerPosition.Striker) });
            var guest = new Team("", new List<Player>() { new Player("", 9, PlayerPosition.Goalkeeper) });

            var match = new Match(home, guest);
            var engine = new MatchEngine(match, randomService);
            engine.HomeStVsGk();
            engine.BallPosition.Should().Be(BallPosition.Center);
        }

        [Test]
        public void Ball_Should_Move_From_Home_Midfield_To_Center()
        {
            var home = new Team("", new List<Player>() { new Player("", 10, PlayerPosition.Defender) });
            var guest = new Team("", new List<Player>() { new Player("", 9, PlayerPosition.Midfielder) });

            var match = new Match(home, guest);
            var engine = new MatchEngine(match, randomService);
            engine.GuestMidVsDef();
            engine.BallPosition.Should().Be(BallPosition.Center);
        }

        [Test]
        public void Ball_Should_Move_From_Home_Midfield_To_Home_Defense()
        {
            var home = new Team("", new List<Player>() { new Player("", 10, PlayerPosition.Defender) });
            var guest = new Team("", new List<Player>() { new Player("", 11, PlayerPosition.Midfielder) });

            var match = new Match(home, guest);
            var engine = new MatchEngine(match, randomService);
            engine.GuestMidVsDef();
            engine.BallPosition.Should().Be(BallPosition.HomeDef);
        }

        [Test]
        public void Ball_Should_Move_From_Home_Defense_To_Home_Midfield()
        {
            var home = new Team("", new List<Player>() { new Player("", 10, PlayerPosition.Goalkeeper) });
            var guest = new Team("", new List<Player>() { new Player("", 9, PlayerPosition.Striker) });

            var match = new Match(home, guest);
            var engine = new MatchEngine(match, randomService);
            engine.GuestStVsGk();
            engine.BallPosition.Should().Be(BallPosition.HomeMid);
        }

        [Test]
        public void Ball_Should_Move_From_Home_Defense_To_Center()
        {
            var home = new Team("", new List<Player>() { new Player("", 10, PlayerPosition.Goalkeeper) });
            var guest = new Team("", new List<Player>() { new Player("", 11, PlayerPosition.Striker) });

            var match = new Match(home, guest);
            var engine = new MatchEngine(match, randomService);
            engine.GuestStVsGk();
            engine.BallPosition.Should().Be(BallPosition.Center);
        }

        [Test]
        public void Home_Team_Should_Win()
        {
            var home = new Team("", new List<Player>() 
            {
                new Player("", 20, PlayerPosition.Goalkeeper),
                new Player("", 20, PlayerPosition.Defender),
                new Player("", 20, PlayerPosition.Midfielder),
                new Player("", 20, PlayerPosition.Striker)
            });
            var guest = new Team("", new List<Player>()
            {
                new Player("", 10, PlayerPosition.Goalkeeper),
                new Player("", 10, PlayerPosition.Defender),
                new Player("", 10, PlayerPosition.Midfielder),
                new Player("", 10, PlayerPosition.Striker)
            });

            var match = new Match(home, guest);
            var result = match.Play();
            result.Result.Should().Be(CombatResult.HomeWins);
        }

        [Test]
        public void Guest_Team_Should_Win()
        {
            var home = new Team("", new List<Player>()
            {
                new Player("", 10, PlayerPosition.Goalkeeper),
                new Player("", 10, PlayerPosition.Defender),
                new Player("", 10, PlayerPosition.Midfielder),
                new Player("", 10, PlayerPosition.Striker)
            });
            var guest = new Team("", new List<Player>()
            {
                new Player("", 20, PlayerPosition.Goalkeeper),
                new Player("", 20, PlayerPosition.Defender),
                new Player("", 20, PlayerPosition.Midfielder),
                new Player("", 20, PlayerPosition.Striker)
            });

            var match = new Match(home, guest);
            var result = match.Play();
            result.Result.Should().Be(CombatResult.GuestWins);
        }
    }
}
