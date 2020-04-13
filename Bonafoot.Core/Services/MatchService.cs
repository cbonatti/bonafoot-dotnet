using Bonafoot.Core.Commands;
using Bonafoot.Core.Contracts;
using Bonafoot.Core.Services.Interfaces;
using Bonafoot.Core.Validators.Interfaces;
using System;
using System.Threading.Tasks;

namespace Bonafoot.Core.Services
{
    public class MatchService : IMatchService
    {
        private readonly IGameMongoDbService _mongoDbService;
        private readonly IGameService _gameService;
        private readonly IPlayingTeamValidator _playingTeamValidator;

        public MatchService(IGameMongoDbService mongoDbService, IGameService gameService, IPlayingTeamValidator playingTeamValidator)
        {
            _mongoDbService = mongoDbService;
            _gameService = gameService;
            _playingTeamValidator = playingTeamValidator;
        }

        public async Task<ChampionshipContract> Play(PlayMatchCommand command)
        {
            var game = await _mongoDbService.Get(new LoadGameCommand() { Name = command.Name });
            if (!_playingTeamValidator.Validate(command, game.Game.Team))
                throw new ArgumentException("Formação Inválida");

            return new ChampionshipContract();
        }
    }
}
