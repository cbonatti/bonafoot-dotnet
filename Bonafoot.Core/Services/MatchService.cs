using Bonafoot.Core.Commands;
using Bonafoot.Core.Contracts;
using Bonafoot.Core.Services.Interfaces;
using Bonafoot.Core.Validators.Interfaces;
using Bonafoot.Engine.Interfaces;
using System;
using System.Threading.Tasks;

namespace Bonafoot.Core.Services
{
    public class MatchService : IMatchService
    {
        private readonly IGameMongoDbService _mongoDbService;
        private readonly IMatchEngine _engine;
        private readonly IPlayingTeamValidator _playingTeamValidator;

        public MatchService(IGameMongoDbService mongoDbService, IMatchEngine engine, IPlayingTeamValidator playingTeamValidator)
        {
            _mongoDbService = mongoDbService;
            _engine = engine;
            _playingTeamValidator = playingTeamValidator;
        }

        public async Task<ChampionshipContract> Play(PlayMatchCommand command)
        {
            var game = await _mongoDbService.Get(new LoadGameCommand() { Name = command.Name });
            if (!_playingTeamValidator.Validate(command, game.Game.Team))
                throw new ArgumentException("Invalid Formation"); // TODO: return a Result object with message

            game.Game.Team.SetPlayerList(command.Players);
            

            return new ChampionshipContract();
        }
    }
}
