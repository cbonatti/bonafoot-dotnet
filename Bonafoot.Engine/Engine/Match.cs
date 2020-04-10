using Bonafoot.Domain.Entities;

namespace Bonafoot.Engine
{
    public class Match
    {
        public Match(Team home, Team guest)
        {
            HomeTeam = home;
            GuestTeam = guest;
        }

        public Team HomeTeam { get; private set; }
        public Team GuestTeam { get; private set; }

        public MatchResult Play() => new MatchEngine(this).PlayGame();
    }
}
