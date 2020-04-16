using Bonafoot.Core.Contracts.Base;
using Bonafoot.Domain.Entities;

namespace Bonafoot.Core.Contracts
{
    public class ScoreContract : ContractBase
    {
        public int Minute { get; set; }
        public bool Home { get; set; }

        public static ScoreContract ToContract(Score score)
        {
            if (score == null)
                return null;
            return new ScoreContract()
            {
                Minute = score.Minute,
                Name = score.Name,
                Home = score.Home
            };
        }
    }
}
