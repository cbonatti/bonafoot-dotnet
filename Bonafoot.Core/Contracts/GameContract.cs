using Bonafoot.Core.Contracts.Base;
using Bonafoot.Domain.Entities;
using Bonafoot.Domain.Enums;
using System.Linq;

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
                Team = TeamContract.ToPlayerContract(game.Team, GetPlayerTeamDivision(game)),
                Championship = ChampionshipContract.ToContract(game.GetActiveChampionship())
            };
        }

        public static GameContract ToSimpleContract(Game game)
        {
            if (game == null)
                return null;
            return new GameContract()
            {
                Name = game.Name,
                Team = TeamContract.ToSimpleContract(game.Team)
            };
        }

        private static DivisionIndex GetPlayerTeamDivision(Game game) => game.GetActiveChampionship().Divisions.FirstOrDefault(x => x.Teams.Any(y => y.Id == game.Team.Id)).Index;
    }
}
