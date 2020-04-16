using Bonafoot.Domain.Base;
using System.Collections.Generic;

namespace Bonafoot.Domain.Entities
{
    public class Match : IdentityEntity
    {
        public Match(int round, Team home, Team guest)
        {
            Round = round;
            Home = home;
            Guest = guest;
        }

        public Match(int round, Team home, Team guest, IEnumerable<Score> scores)
            : this(round, home, guest)
        {
            Scores = scores;
        }

        public int Round { get; private set; }
        public Team Home { get; private set; }
        public Team Guest { get; private set; }
        public IEnumerable<Score> Scores { get; private set; }
    }
}
