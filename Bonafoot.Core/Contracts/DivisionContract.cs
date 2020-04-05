using Bonafoot.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Bonafoot.Core.Contracts
{
    public class DivisionContract
    {
        public StandingContract Standing { get; set; }
        public IEnumerable<TeamContract> Teams { get; set; }

        public static DivisionContract ToContract(Division division)
        {
            if (division == null)
                return null;
            return new DivisionContract()
            {
                Standing = StandingContract.ToContract(division.Standing),
                Teams = division.Teams.Select(TeamContract.ToContract).ToList()
            };
        }
    }
}
