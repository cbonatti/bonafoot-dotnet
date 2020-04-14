using Bonafoot.Domain.Enums;

namespace Bonafoot.Domain.Entities
{
    public class ChampionshipRound
    {
        public ChampionshipRound(int round, Team home, Team guest, DivisionIndex division)
        {
            Round = round;
            HomeTeam = home;
            GuestTeam = guest;
            Division = division;
        }

        public int Round { get; private set; }
        public Team HomeTeam { get; private set; }
        public Team GuestTeam { get; private set; }
        public DivisionIndex Division { get; private set; }
    }
}
