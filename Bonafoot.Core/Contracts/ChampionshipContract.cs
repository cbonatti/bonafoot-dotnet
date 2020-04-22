using Bonafoot.Domain.Entities;
using Bonafoot.Domain.Enums;
using System.Collections.Generic;
using System.Linq;

namespace Bonafoot.Core.Contracts
{
    public class ChampionshipContract
    {
        public int Year { get; set; }
        public int ActualRound { get; set; }
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
                ActualRound = championship.ActualRound,
                First = GetDivision(championship, DivisionIndex.First),
                Second = GetDivision(championship, DivisionIndex.Second),
                Third = GetDivision(championship, DivisionIndex.Third),
                Fourth = GetDivision(championship, DivisionIndex.Fourth),
                Matches = championship.Matches.Select(MatchContract.ToContract).ToList()
            };
        }

        private static DivisionContract GetDivision(Championship championship, DivisionIndex index)
        {
            var division = championship.Divisions.FirstOrDefault(x => x.Index == index);
            var rounds = championship.Rounds.Where(x => x.Division == index).Select(ChampionshipRoundContract.ToContract).ToList();
            return DivisionContract.ToContract(division, rounds);
        }
    }
}
