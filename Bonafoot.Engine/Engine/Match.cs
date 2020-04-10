using Bonafoot.Domain.Entities;
using Bonafoot.Engine.Interfaces;

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

        public MatchResult Play(IRandomService service) => new MatchEngine(service).PlayGame(this);
    }
}
