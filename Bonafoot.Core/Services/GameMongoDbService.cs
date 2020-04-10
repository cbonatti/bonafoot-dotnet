using Bonafoot.Core.Commands;
using Bonafoot.Core.Services.Interfaces;
using Bonafoot.Infra.Data.MongoDb.Interfaces;
using Bonafoot.Infra.Data.MongoDb.Models;
using System.Threading.Tasks;

namespace Bonafoot.Core.Services
{
    public class GameMongoDbService : IGameMongoDbService
    {
        private readonly IGameRepository _gameRepository;

        public GameMongoDbService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public async Task<GameMongoDb> Get(LoadGameCommand command) => await _gameRepository.Get(command.Name);
    }
}
