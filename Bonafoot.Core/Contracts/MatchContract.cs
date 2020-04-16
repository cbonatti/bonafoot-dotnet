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
        public IEnumerable<ScoreContract> Scores { get; set; }

        public static MatchContract ToContract(Match match)
        {
            if (match == null)
                return null;
            return new MatchContract()
            {
                Guest = TeamContract.ToContract(match.Guest),
                Home = TeamContract.ToContract(match.Home),
                Scores = match.Scores.Select(ScoreContract.ToContract).ToList(),
                Round = match.Round
            };
        }
    }
}
