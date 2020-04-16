using Bonafoot.Domain.Base;
using Bonafoot.Domain.Enums;
using Bonafoot.Domain.Util;
using System.Collections.Generic;
using System.Linq;

namespace Bonafoot.Domain.Entities
{
    public class Division : EntityBase
    {
        public Division(DivisionIndex index)
        {
            Index = index;
            Teams = LoadTeam(index).ToList();
            Standings = NewStandings();
        }

        public DivisionIndex Index { get; private set; }
        public IEnumerable<Standing> Standings { get; private set; }
        public IEnumerable<Team> Teams { get; private set; }

        private IEnumerable<Team> LoadTeam(DivisionIndex division)
        {
            for (int i = 1; i <= 8; i++)
                yield return BasicTeam.Generate(division, i);
        }

        private IEnumerable<Standing> NewStandings() => Teams
                                                            .OrderBy(x => x.Name)
                                                            .Select(x => new Standing(x))
                                                            .ToList();

        private Standing GetTeamStanding(Team team) => Standings.FirstOrDefault(x => x.Team.Id == team.Id);

        public Division AlterStandingVictory(Team winningTeam, int winningScores, Team defeatedTeam, int defeatedScores)
        {
            var winningStandings = GetTeamStanding(winningTeam);
            winningStandings.SetVictory(winningScores, defeatedScores);

            var defeatedStandings = GetTeamStanding(defeatedTeam);
            defeatedStandings.SetDefeat(defeatedScores, winningScores);

            return this;
        }

        public Division AlterStandingDraw(Team home, Team guest, int score)
        {
            var homeStandings = GetTeamStanding(home);
            homeStandings.SetDraw(score);

            var guestStandings = GetTeamStanding(guest);
            guestStandings.SetDraw(score);
            return this;
        }
    }
}
