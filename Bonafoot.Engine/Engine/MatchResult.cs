using Bonafoot.Engine.Enums;

namespace Bonafoot.Engine
{
    public class MatchResult
    {
        public MatchResult(Match match)
        {
            Match = match;
        }

        public Match Match { get; private set; }
        public int HomeGoals { get; private set; }
        public int GuestGoals { get; private set; }
        public CombatResult Result => GetResult();

        public void HomeTeamScored() => HomeGoals++;
        public void GuestTeamScored() => GuestGoals++;

        private CombatResult GetResult()
        {
            if (HomeGoals == GuestGoals)
                return CombatResult.Draw;
            else if (HomeGoals > GuestGoals)
                return CombatResult.HomeWins;
            else
                return CombatResult.GuestWins;
        }
    }
}
