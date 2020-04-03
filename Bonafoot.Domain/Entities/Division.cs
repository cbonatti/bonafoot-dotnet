using Bonafoot.Domain.Base;
using Bonafoot.Domain.Enums;
using Bonafoot.Domain.Util;
using System.Collections.Generic;

namespace Bonafoot.Domain.Entities
{
    public class Division : EntityBase
    {
        public Division(DivisionIndex index)
        {
            Index = index;
            Standing = new Standing();
            Teams = LoadTeam(index);
        }

        public DivisionIndex Index { get; private set; }
        public Standing Standing { get; private set; }
        public IEnumerable<Team> Teams { get; private set; }

        private IEnumerable<Team> LoadTeam(DivisionIndex division)
        {
            for (int i = 1; i <= 8; i++)
                yield return BasicTeam.Generate(division, i);
        }
    }
}
