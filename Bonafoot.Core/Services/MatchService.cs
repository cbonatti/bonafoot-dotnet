using Bonafoot.Core.Commands;
using Bonafoot.Core.Contracts;
using Bonafoot.Core.Services.Interfaces;

namespace Bonafoot.Core.Services
{
    public class MatchService : IMatchService
    {
        private readonly IGameMongoDbService _mongoDbService;
        private readonly IGameService _gameService;

        public MatchService(IGameMongoDbService mongoDbService, IGameService gameService)
        {
            _mongoDbService = mongoDbService;
            _gameService = gameService;
        }

        public ChampionshipContract Play(PlayMatchCommand command)
        {


            return new ChampionshipContract();
        }
    }
}
