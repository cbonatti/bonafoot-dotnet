using Bonafoot.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Bonafoot.Core.Contracts
{
    public class DivisionContract
    {
        public IEnumerable<StandingContract> Standing { get; set; }
        public IEnumerable<TeamContract> Teams { get; set; }
        public IEnumerable<ChampionshipRoundContract> Rounds { get; set; }

        public static DivisionContract ToContract(Division division, IEnumerable<ChampionshipRoundContract> rounds)
        {
            if (division == null)
                return null;
            return new DivisionContract()
            {
                Standing = division.Standings.Select(StandingContract.ToSimpleContract),
                Teams = division.Teams.Select(TeamContract.ToContract).ToList(),
                Rounds = rounds
            };
        }
    }
}
