using Bonafoot.Domain.Entities;
using Bonafoot.Domain.Enums;
using Bonafoot.Engine.Interfaces;
using Bonafoot.Engine.Services.Interfaces;

namespace Bonafoot.Engine.Services
{
    public class PlayerScoredService : IPlayerScoredService
    {
        private readonly IRandomService _randomService;

        public PlayerScoredService(IRandomService randomService)
        {
            _randomService = randomService;
        }

        public string WhoScored(Team team)
        {
            var twoDicesResult = _randomService.Dice() + _randomService.Dice();

            if (twoDicesResult <= 2)
                return GetDefensePlayer(team);
            else if (twoDicesResult >= 11)
                return GetMidfielderPlayer(team);
            else
                return GetStrikerPlayer(team);
        }

        private string GetDefensePlayer(Team team) => GetPlayerName(team, PlayerPosition.Defender);

        private string GetMidfielderPlayer(Team team) => GetPlayerName(team, PlayerPosition.Midfielder);

        private string GetStrikerPlayer(Team team) => GetPlayerName(team, PlayerPosition.Striker);

        private string GetPlayerName(Team team, PlayerPosition position)
        {
            var players = team.GetPlayerByPosition(position);
            var index = _randomService.ZeroToMax(players.Count - 1);
            return players[index].Name;
        }
    }
}
