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

        public Match(int round, Team home, Team guest, IEnumerable<Score> homeScores, IEnumerable<Score> guestScores)
            : this(round, home, guest)
        {
            HomeScores = homeScores;
            GuestScores = guestScores;
        }

        public int Round { get; private set; }
        public Team Home { get; private set; }
        public Team Guest { get; private set; }
        public IEnumerable<Score> HomeScores { get; private set; }
        public IEnumerable<Score> GuestScores { get; private set; }

        public Match AddHomeScores(IEnumerable<Score> scores)
        {
            HomeScores = scores;
            return this;
        }

        public Match AddGuestScores(IEnumerable<Score> scores)
        {
            GuestScores = scores;
            return this;
        }
    }
}
