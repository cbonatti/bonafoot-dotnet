using Bonafoot.Core.Contracts.Base;
using Bonafoot.Domain.Entities;

namespace Bonafoot.Core.Contracts
{
    public class GameContract : ContractBase
    {
        public TeamContract Team { get; set; }
        public ChampionshipContract Championship { get; set; }

        public static GameContract ToContract(Game game)
        {
            if (game == null)
                return null;
            return new GameContract()
            {
                Name = game.Name,
                Team = TeamContract.ToContract(game.Team),
                Championship = ChampionshipContract.ToContract(game.GetActiveChampionship())
            };
        }
    }
}
