using Bonafoot.Domain.Entities;

namespace Bonafoot.Core.Contracts
{
    public class StandingContract
    {
        public TeamContract Team { get; set; }
        public int Victory { get; set; }
        public int Draw { get; set; }
        public int Loss { get; set; }
        public int ScoresPro { get; set; }
        public int ScoresCon { get; set; }

        public static StandingContract ToContract(Standing standing)
        {
            if (standing == null)
                return null;
            return new StandingContract()
            {
                Team = TeamContract.ToContract(standing.Team),
                Draw = standing.Draw,
                Loss = standing.Loss,
                ScoresCon = standing.ScoresCon,
                ScoresPro = standing.ScoresPro,
                Victory = standing.Victory
            };
        }
    }
}
