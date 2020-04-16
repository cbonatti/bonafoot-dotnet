using Bonafoot.Engine.Engine;
using Bonafoot.Engine.Enums;
using System.Collections.Generic;

namespace Bonafoot.Engine
{
    public class MatchResult
    {
        public MatchResult(Match match)
        {
            Match = match;
            Scores = new List<PlayerScore>();
        }

        public Match Match { get; private set; }
        public int HomeGoals { get; private set; }
        public int GuestGoals { get; private set; }
        public IList<PlayerScore> Scores { get; private set; }
        public CombatResult Result => GetResult();

        public void HomeTeamScored(int minute, string name)
        {
            HomeGoals++;
            Score(minute, name, true);
        }

        public void GuestTeamScored(int minute, string name)
        {
            GuestGoals++;
            Score(minute, name, false);
        }

        private void Score(int minute, string name, bool home) => Scores.Add(new PlayerScore(minute, name, home));

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
