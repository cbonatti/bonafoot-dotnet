using Bonafoot.Core.Commands;
using Bonafoot.Core.Contracts;
using Bonafoot.Core.Services.Interfaces;
using Bonafoot.Core.Validators.Interfaces;
using Bonafoot.Domain.Entities;
using Bonafoot.Domain.Enums;
using Bonafoot.Engine;
using Bonafoot.Engine.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Bonafoot.Core.Services
{
    public class MatchService : IMatchService
    {
        private readonly IGameMongoDbService _mongoDbService;
        private readonly IMatchEngine _engine;
        private readonly IPlayingTeamValidator _playingTeamValidator;
        private readonly IGameService _gameService;
        private Championship _championship;

        public MatchService(IGameMongoDbService mongoDbService, IMatchEngine engine, IPlayingTeamValidator playingTeamValidator, IGameService gameService)
        {
            _mongoDbService = mongoDbService;
            _engine = engine;
            _playingTeamValidator = playingTeamValidator;
            _gameService = gameService;
        }

        public async Task<ChampionshipContract> Play(PlayMatchCommand command)
        {
            var mongoGame = await _mongoDbService.Get(new LoadGameCommand() { Name = command.Name });
            var game = mongoGame.Game;
            if (!_playingTeamValidator.Validate(command, game.Team))
                throw new ArgumentException("Invalid Formation"); // TODO: return a Result object with message

            game.Team.SetPlayerList(command.Players);
            _championship = game.GetActiveChampionship();
            var rounds = _championship.GetActualRound();

            foreach (var round in rounds)
            {
                round.HomeTeam.GetTeamReadyToPlay(game.Team);
                round.GuestTeam.GetTeamReadyToPlay(game.Team);

                var match = new Engine.Match(round.HomeTeam, round.GuestTeam);
                CalculateResult(_engine.PlayGame(match), round.Round, round.Division);
            }

            _championship.FinishRound();

            await _gameService.Update(mongoGame);

            return ChampionshipContract.ToContract(_championship);
        }

        private void CalculateResult(MatchResult result, int round, DivisionIndex divisionIndex)
        {
            var resultMatch = result.Match;
            var match = new Domain.Entities.Match(round, resultMatch.HomeTeam, resultMatch.GuestTeam, result.Scores.Select(x => new Score(x.Minute, x.Name, x.Home)).ToList());
            _championship.AddMatch(match);

            var division = _championship.GetDivision(divisionIndex);
            
            switch (result.Result)
            {
                case Engine.Enums.CombatResult.HomeWins:
                    division.AlterStandingVictory(resultMatch.HomeTeam, result.HomeGoals, resultMatch.GuestTeam, result.GuestGoals);
                    break;
                case Engine.Enums.CombatResult.GuestWins:
                    division.AlterStandingVictory(resultMatch.GuestTeam, result.GuestGoals, resultMatch.HomeTeam, result.HomeGoals);
                    break;
                case Engine.Enums.CombatResult.Draw:
                    division.AlterStandingDraw(resultMatch.GuestTeam, resultMatch.HomeTeam, result.HomeGoals);
                    break;
                default:
                    break;
            }
        }
    }
}
