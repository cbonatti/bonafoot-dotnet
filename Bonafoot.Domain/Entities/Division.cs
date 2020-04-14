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
    }
}
