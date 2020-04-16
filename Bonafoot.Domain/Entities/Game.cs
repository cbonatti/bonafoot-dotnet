using Bonafoot.Domain.Base;
using Bonafoot.Domain.Enums;
using System.Collections.Generic;
using System.Linq;

namespace Bonafoot.Domain.Entities
{
    public class Game : EntityBase
    {
        public Game()
        {
            Championships = new List<Championship>();
        }

        public Team Team { get; private set; }
        public IList<Championship> Championships { get; private set; }

        public Game New(string name)
        {
            var championship = new Championship().New();
            SetName(name);
            AddChampionship(championship);

            // User is going to take the third stronger team because only advance division the two better teams
            Team = championship.Divisions
                        .FirstOrDefault(x => x.Index == DivisionIndex.Fourth)
                        .Teams
                        .Select(x => new { Team = x, Strength = x.Squad.Average(y => y.Strength) })
                        .OrderByDescending(x => x.Strength)
                        .Select(x => x.Team)
                        .ElementAt(3);

            return this;
        }

        public Game AddChampionship(Championship championship)
        {
            Championships.Add(championship);
            return this;
        }

        public Championship GetActiveChampionship() => Championships.FirstOrDefault(x => x.Status == ChampionshipStatus.Active);
    }
}
