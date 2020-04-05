using Bonafoot.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Bonafoot.Core.Contracts
{
    public class MatchContract
    {
        public int Round { get; set; }
        public TeamContract Home { get; set; }
        public TeamContract Guest { get; set; }
        public IEnumerable<ScoreContract> HomeScores { get; set; }
        public IEnumerable<ScoreContract> GuestScores { get; set; }

        public static MatchContract ToContract(Match match)
        {
            if (match == null)
                return null;
            return new MatchContract()
            {
                Guest = TeamContract.ToContract(match.Guest),
                GuestScores = match.GuestScores.Select(ScoreContract.ToContract).ToList(),
                Home = TeamContract.ToContract(match.Home),
                HomeScores = match.HomeScores.Select(ScoreContract.ToContract).ToList(),
                Round = match.Round
            };
        }
    }
}
