using Bonafoot.Domain.Entities;
using Bonafoot.Domain.Enums;
using System.Collections.Generic;
using System.Linq;

namespace Bonafoot.Core.Contracts
{
    public class ChampionshipContract
    {
        public int Year { get; set; }
        public DivisionContract First { get; set; }
        public DivisionContract Second { get; set; }
        public DivisionContract Third { get; set; }
        public DivisionContract Fourth { get; set; }
        public IEnumerable<MatchContract> Matches { get; set; }

        public static ChampionshipContract ToContract(Championship championship)
        {
            if (championship == null)
                return null;
            return new ChampionshipContract()
            {
                Year = championship.Year,
                First = DivisionContract.ToContract(championship.Divisions.FirstOrDefault(x => x.Index == DivisionIndex.First)),
                Second = DivisionContract.ToContract(championship.Divisions.FirstOrDefault(x => x.Index == DivisionIndex.Second)),
                Third = DivisionContract.ToContract(championship.Divisions.FirstOrDefault(x => x.Index == DivisionIndex.Third)),
                Fourth = DivisionContract.ToContract(championship.Divisions.FirstOrDefault(x => x.Index == DivisionIndex.Fourth)),
                Matches = championship.Matches.Select(MatchContract.ToContract).ToList()
            };
        }
    }
}
