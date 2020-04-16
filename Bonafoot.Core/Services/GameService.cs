using Bonafoot.Core.Commands;
using Bonafoot.Core.Contracts;
using Bonafoot.Core.Services.Interfaces;
using Bonafoot.Domain.Entities;
using Bonafoot.Infra.Data.MongoDb.Interfaces;
using Bonafoot.Infra.Data.MongoDb.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bonafoot.Core.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;

        public GameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public async Task<GameContract> New(NewGameCommand command)
        {
            var game = new Game().New(command.Name);
            var gameMongo = new GameMongoDb(game);

            await _gameRepository.Create(gameMongo);

            var contract = GameContract.ToContract(game);
            return contract;
        }

        public async Task<GameContract> Update(GameMongoDb game)
        {
            await _gameRepository.Update(game);

            var contract = GameContract.ToContract(game.Game);
            return contract;
        }

        public async Task<GameContract> Load(LoadGameCommand command)
        {
            var game = await _gameRepository.Get(command.Name);
            return GameContract.ToContract(game.Game);
        }

        public async Task<GameMongoDb> Get(LoadGameCommand command) => await _gameRepository.Get(command.Name);

        public async Task<IEnumerable<GameContract>> GetAll()
        {
            var games = await _gameRepository.GetAll();
            return games.Select(x => GameContract.ToContract(x.Game)).ToList();
        }

        public async Task<bool> Delete(DeleteGameCommand command) => await _gameRepository.Delete(command.Name);
    }
}
