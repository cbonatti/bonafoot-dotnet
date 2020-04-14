using Bonafoot.Core.Commands;
using Bonafoot.Core.Validators.Interfaces;
using Bonafoot.Domain.Entities;
using Bonafoot.Domain.Enums;
using System.Linq;

namespace Bonafoot.Core.Validators
{
    public class PlayingTeamValidator : IPlayingTeamValidator
    {
        public bool Validate(PlayMatchCommand command, Team team)
        {
            if (command.Players.Count() != 11)
                return false;

            var playersCountByPosition = team
                                            .SetPlayerList(command.Players)
                                            .PlayingPlayers
                                                .GroupBy(x => x.Position)
                                                .Select(x => new { Position = x.Key, Count = x.Count() })
                                                .ToList();

            if (playersCountByPosition.Sum(x => x.Count) != 11)
                return false;

            // must have only one GK
            var gk = playersCountByPosition.FirstOrDefault(x => x.Position == PlayerPosition.Goalkeeper);
            if (gk == null || gk.Count != 1)
                return false;

            return true;
        }
    }
}
