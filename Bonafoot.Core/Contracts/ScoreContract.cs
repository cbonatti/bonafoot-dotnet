using Bonafoot.Domain.Entities;

namespace Bonafoot.Core.Contracts
{
    public class ScoreContract
    {
        public PlayerContract Player { get; set; }
        public int Minute { get; set; }

        public static ScoreContract ToContract(Score score)
        {
            if (score == null)
                return null;
            return new ScoreContract()
            {
                Minute = score.Minute,
                Player = PlayerContract.ToContract(score.Player)
            };
        }
    }
}
