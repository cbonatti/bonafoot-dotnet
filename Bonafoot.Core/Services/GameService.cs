using Bonafoot.Core.Commands;
using Bonafoot.Core.Contracts;
using Bonafoot.Core.Services.Interfaces;
using Bonafoot.Domain.Entities;
using System.Linq;

namespace Bonafoot.Core.Services
{
    public class GameService : IGameService
    {
        public GameContract New(NewGameCommand command)
        {
            var game = new Game().New(command.Name);

            var contract = GameContract.ToContract(game, game.Championships.First());
            return contract;
        }

        public GameContract Load(LoadGameCommand command)
        {
            var contract = new GameContract();
            return contract;
        }
    }
}
