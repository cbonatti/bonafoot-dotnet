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
            var mongoGame = await _mongoDbService.Get(new LoadGameCommand() { Name = command.Name });
            var game = mongoGame.Game;
            if (!_playingTeamValidator.Validate(command, game.Team))
                throw new ArgumentException("Invalid Formation"); // TODO: return a Result object with message

            game.Team.SetPlayerList(command.Players);
            var champ = game.GetActiveChampionship();
            var rounds = champ.GetActualRound();

            foreach (var round in rounds)
            {
                round.HomeTeam.GetTeamReadyToPlay(game.Team);
                round.GuestTeam.GetTeamReadyToPlay(game.Team);

                // _engine.PlayGame(new Engine.Match())
            }

            champ.FinishRound();

            return new ChampionshipContract();
        }
    }
}
